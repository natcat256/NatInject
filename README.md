# NatInject
Bare-bones Windows DLL injector
![NatInject GUI](https://github.com/natcat256/NatInject/assets/95653800/56592506-b730-4988-9bde-e361cb9d3e96)

## Features
NatInject is very basic and intended to be a learning resource. As such, it can be easily defeated by most anti-tampering software. It does, however, offer a few pros:
- Support for both 32-bit and 64-bit applications
- Minimal, simple-to-use GUI
- Easy integration into other projects

## API
NatInject can be integrated into other projects with the presence of ``NatInject`` and ``NatInject.32BitHelper``.

A ``DllInjector`` class is provided within the ``NatInject`` namespace, which only needs to be instantiated once to perform any number of injections. It contains a method ``Inject`` with the following signature:
```cs
void Inject(System.Diagnostics.Process process, string dllPath)
```
where ``process`` represents the target process and ``dllPath`` is the path of the DLL file to be injected.

Both the constructor and ``Inject`` method of ``DllInjector`` are capable of throwing, and so the caller is expected to handle any potential exceptions.