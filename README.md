# AutoTranslator Hotkey Input Shim

## ⚠ Disclaimer

> **This plugin was thrown together as a quick-and-dirty fix by someone who knows next to nothing about Unity.**  
> Use it at your own risk — it merely _works on my machine_.

## Why would I need this?

If BepInEx + XUnity.AutoTranslator is installed but **none of the hotkeys work**, drop this DLL into your game and they should start responding.

- UI toggle (Alt + 0) is still disabled.
- It is aimed at users who only need **Alt + R** (reload translations) and **Alt + T** (toggle translations) to function.

## Dependencies

- XUnity.AutoTranslator 5.4.x
- BepInEx 5.4.x

## How to use

- Download dll from [Releases](https://github.com/k-chop/XUAHotkeyInputShim/releases)
- Copy dll to `<GameFolder>\BepInEx\plugins\XUAHotkeyInputShim.dll`

## Build (for Developers)

### Install .NET SDK (WSL2 Ubuntu example)

```bash
sudo apt update && sudo apt install -y dotnet-sdk-8.0
```

### Prepare reference DLLs

```
<ProjectRoot>/libs/
├─ 0Harmony.dll                      (from BepInEx/core)
├─ BepInEx.dll                       (from BepInEx/core)
├─ Unity.InputSystem.dll             (from <GameName>_Data/Managed)
├─ UnityEngine.CoreModule.dll        (from <GameName>_Data/Managed)
├─ UnityEngine.InputLegacyModule.dll (from <GameName>_Data/Managed)
└─ UnityEngine.dll                   (from <GameName>_Data/Managed)
```

### Build

```bash
dotnet build -c Release
# → bin/Release/netstandard2.1/XUAHotkeyInputShim.dll
```

### Deploy

- Copy dll to `<GameFolder>\BepInEx\plugins\XUAHotkeyInputShim.dll`
