# AutoTranslator Hotkey Input Shim

## ⚠ Disclaimer

> Unity なんも知らん人間が AI 任せで書いた Plugin なので自己責任でご利用ください  
> 少なくとも自分の環境では動いた

## 説明

BepInEx + AutoTranslator 入れたけどショートカットキーが効かん！という時に入れると解決するかもしれない Plugin

なお UI は開けません。とりあえず `ALT+R` と `ALT+T` が使えりゃいい人向け

## 依存

- XUnity.AutoTranslator 5.4.x
- BepInEx 5.4.x

たぶんちょっとくらい version 前後しても動くけど試してない

## 使い方

- [Releases](https://github.com/k-chop/XUAHotkeyInputShim/releases) から dll をダウンロード
- `<GameFolder>\BepInEx\plugins\XUAHotkeyInputShim.dll` に置いて起動

## ビルド方法

### .NET SDK のインストール (WSL2 Ubuntu の例)

```bash
sudo apt update && sudo apt install -y dotnet-sdk-8.0
```

### DLL ファイルを配置

```
<ProjectRoot>/libs/
├─ 0Harmony.dll                      (from BepInEx/core)
├─ BepInEx.dll                       (from BepInEx/core)
├─ Unity.InputSystem.dll             (from <GameName>_Data/Managed)
├─ UnityEngine.CoreModule.dll        (from <GameName>_Data/Managed)
├─ UnityEngine.InputLegacyModule.dll (from <GameName>_Data/Managed)
└─ UnityEngine.dll                   (from <GameName>_Data/Managed)
```

### ビルド

```bash
dotnet build -c Release
# → bin/Release/netstandard2.1/XUAHotkeyInputShim.dll
```

### デプロイ

- `<GameFolder>\BepInEx\plugins\XUAHotkeyInputShim.dll` にできた dll をぶち込む
