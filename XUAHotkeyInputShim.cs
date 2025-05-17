using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace XUAHotkeyInputShim {
    public static class PluginInfo
    {
        public const string Fqdn = "com.github.k-chop.xua.hotkeyinputshim";
        public const string Name = "XUnity.AutoTranslator Hotkey Input Shim";
        public const string Version = "0.0.1";
    }

    [BepInPlugin(PluginInfo.Fqdn, PluginInfo.Name, PluginInfo.Version)]
    public class XUAHotkeyInputShim : BaseUnityPlugin
    {
        void Awake() => new Harmony(PluginInfo.Fqdn).PatchAll();

        static bool TryMap(KeyCode keycode, out KeyControl key)
        {
            key = keycode switch
            {
                KeyCode.Alpha0 or KeyCode.Keypad0 => Keyboard.current.digit0Key,
                KeyCode.Alpha1 or KeyCode.Keypad1 => Keyboard.current.digit1Key,
                KeyCode.Alpha2 or KeyCode.Keypad2 => Keyboard.current.digit2Key,
                KeyCode.Alpha3 or KeyCode.Keypad3 => Keyboard.current.digit3Key,
                KeyCode.Alpha4 or KeyCode.Keypad4 => Keyboard.current.digit4Key,
                KeyCode.Alpha5 or KeyCode.Keypad5 => Keyboard.current.digit5Key,
                KeyCode.Alpha6 or KeyCode.Keypad6 => Keyboard.current.digit6Key,
                KeyCode.Alpha7 or KeyCode.Keypad7 => Keyboard.current.digit7Key,
                KeyCode.Alpha8 or KeyCode.Keypad8 => Keyboard.current.digit8Key,
                KeyCode.Alpha9 or KeyCode.Keypad9 => Keyboard.current.digit9Key,

                KeyCode.T => Keyboard.current.tKey,
                KeyCode.R => Keyboard.current.rKey,
                KeyCode.U => Keyboard.current.uKey,
                KeyCode.F => Keyboard.current.fKey,
                KeyCode.Q => Keyboard.current.qKey,

                KeyCode.LeftAlt  => Keyboard.current.leftAltKey,
                KeyCode.RightAlt => Keyboard.current.rightAltKey,
                KeyCode.LeftControl  => Keyboard.current.leftCtrlKey,
                KeyCode.RightControl => Keyboard.current.rightCtrlKey,
                _ => null
            };
            return key != null;
        }

        [HarmonyPatch(typeof(Input), nameof(Input.GetKey), typeof(KeyCode))]
        [HarmonyPriority(Priority.First)]
        class Patch_GetKey
        {
            static bool Prefix(KeyCode key, ref bool __result)
            {
                if (Keyboard.current != null && TryMap(key, out var k))
                {
                    __result = k.isPressed;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Input), nameof(Input.GetKeyDown), typeof(KeyCode))]
        [HarmonyPriority(Priority.First)]
        class Patch_GetKeyDown
        {
            static bool Prefix(KeyCode key, ref bool __result)
            {
                if (Keyboard.current != null && TryMap(key, out var k))
                {
                    __result = k.wasPressedThisFrame;
                    return false;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Input), nameof(Input.GetKeyUp), typeof(KeyCode))]
        [HarmonyPriority(Priority.First)]
        class Patch_GetKeyUp
        {
            static bool Prefix(KeyCode key, ref bool __result)
            {
                if (Keyboard.current != null && TryMap(key, out var k))
                {
                    __result = k.wasReleasedThisFrame;
                    return false;
                }
                return true;
            }
        }
    }
}
