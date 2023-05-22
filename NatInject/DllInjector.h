#pragma once

namespace NatInject
{
	public ref class DllInjector
	{
	private:
		LPVOID m_pLoadLibraryW32;
		LPVOID m_pLoadLibraryW64;

	public:
		DllInjector();

		void Inject(System::Diagnostics::Process^ process, System::String^ dllPath);

	};
}
