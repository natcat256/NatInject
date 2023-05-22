#include "pch.h"
#include "DllInjector.h"

#include <msclr/marshal.h>
#include <msclr/marshal_cppstd.h>

using namespace NatInject;
using namespace System;
using namespace System::Diagnostics;

// this is highly detectable as-is, but it is intended to be simple

DllInjector::DllInjector()
{
    // retrieving the address of LoadLibraryW for 32-bit processes from a 64-bit process isn't trivial...
    // however, it is possible to have another 32-bit process provide the address
    Process^ pHelper = Process::Start("NatInject.32BitHelper.exe");
    pHelper->WaitForExit();

    // the helper provides the address in the return code
    m_pLoadLibraryW32 = reinterpret_cast<LPVOID>(pHelper->ExitCode);
    m_pLoadLibraryW64 = GetProcAddress(GetModuleHandle(L"kernelbase.dll"), "LoadLibraryW");
}

void DllInjector::Inject(Process^ process, String^ dllPath)
{
    if (process == nullptr)
    {
        throw gcnew ArgumentNullException("process");
    }
    if (dllPath == nullptr)
    {
        throw gcnew ArgumentNullException("dllPath");
    }

    if (!IO::File::Exists(dllPath))
    {
        throw gcnew Exception("The DLL file path is not valid");
    }

    HANDLE hProcess = process->Handle.ToPointer();

    BOOL bIsWoW64;
    if (!IsWow64Process(hProcess, &bIsWoW64))
    {
        throw gcnew Exception("Could not determine whether the process is running under WoW64");
    }

    // the DLL path must be written somewhere in the target process' address space so that it is accessible by LoadLibraryW
    std::wstring sDllPath = msclr::interop::marshal_as<std::wstring>(dllPath);
    size_t nDllPathByteCount = (sDllPath.size() + 1) * sizeof(wchar_t);
    LPVOID pDllPathAddress = VirtualAllocEx(hProcess, nullptr, nDllPathByteCount, MEM_COMMIT, PAGE_READWRITE);
    if (!pDllPathAddress)
    {
        throw gcnew Exception("Could not allocate process memory to store the DLL path");
    }

    if (!WriteProcessMemory(hProcess, pDllPathAddress, &sDllPath[0], nDllPathByteCount, nullptr))
    {
        throw gcnew Exception("Could not write the DLL path to process memory");
    }

    // kernelbase and friends are usually mapped at the same location within every process' address space
    LPVOID pLoadLibraryW = bIsWoW64 ? m_pLoadLibraryW32 : m_pLoadLibraryW64;

    // LoadLibraryW can be invoked using CreateRemoteThread because it only takes 1 argument the size of a pointer
    HANDLE hThread = CreateRemoteThread(hProcess, nullptr, 0, reinterpret_cast<LPTHREAD_START_ROUTINE>(pLoadLibraryW), pDllPathAddress, 0, nullptr);
    if (!hThread)
    {
        throw gcnew Exception("Could not invoke LoadLibraryW in a remote thread");
    }

    WaitForSingleObject(hThread, INFINITE);

    CloseHandle(hThread);

    VirtualFreeEx(hProcess, pDllPathAddress, 0, MEM_RELEASE);
}
