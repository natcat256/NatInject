#include <Windows.h>

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PWSTR pCmdLine, int nCmdShow)
{
    // kernelbase and friends are usually mapped at the same location within every process' address space
    return reinterpret_cast<int>(GetProcAddress(GetModuleHandle(L"kernelbase.dll"), "LoadLibraryW"));
}
