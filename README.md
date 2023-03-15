# CnCNet.Launcher
Launcher for Windows for the XNA / MonoGame client that automatically selects the correct executable to run for the user's platform.

Also checks and notifies about any needed client runtimes.
## Optional arguments
Do not autoselect a version, run the WinForms DirectX client:
```
-DX
```
Do not autoselect a version, run the WinForms OpenGL client:
```
-OGL
```
Do not autoselect a version, run the cross-platform OpenGL client:
```
-UGL
```
Do not autoselect a version, run the WinForms XNA client:
```
-XNA
```
## Custom icon
- Online: The publishcustomicon workflow, which takes an icon URL as input, can be used to directly publish a custom launcher.
- Offline: The CnCNet.LauncherStub.exe release can be downloaded and modified using [Rebundler](https://github.com/Rans4ckeR/Rebundler).