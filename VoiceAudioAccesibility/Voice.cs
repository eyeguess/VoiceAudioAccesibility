using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using VoiceAudioAccesibility.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace VoiceAudioAccesibility
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class VoiceMod : BaseUnityPlugin
    {

        private const string modGUID = "eyeguess.VoiceMod";
        private const string modName = "VoiceAudioAccesibility";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static VoiceMod Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Voice Audio Accesibility is online.");
            harmony.PatchAll(typeof(VoiceMod));
            harmony.PatchAll(typeof(VAA));

        }


    }
}
