using System;
using HarmonyLib;
using Dissonance;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;
using BepInEx;
using BepInEx.Logging;
using System.Runtime.CompilerServices;
using UnityEngine.Windows;

namespace VoiceAudioAccesibility.Patches
{


    [HarmonyPatch(typeof(DissonanceComms), "Update")]
    public static class VAA
    {
        private const string modGUID = "eyeguess.VoiceMod";
        internal static ManualLogSource mls;

        public static void Postfix(ref DissonanceComms __instance)
        {
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            if (Keyboard.current.kKey.isPressed)
            {
                __instance.RemoteVoiceVolume = 0f;
                mls.LogInfo("K button pressed: Everyone has been muted");

            }
            else if (Keyboard.current.rKey.isPressed)
            {
                __instance.RemoteVoiceVolume = 0.1f;
                mls.LogInfo("R button pressed: Everyone has their voice lowered!");

            }else
            {
                __instance.RemoteVoiceVolume = 1f;

            }

        }
    }
}
