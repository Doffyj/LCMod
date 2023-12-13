using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;
using Croissant.Patches;


namespace CroissantHoarderSFX
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class CroissantHoarder : BaseUnityPlugin
    {
        //from the video
        private const string modGUID = "Doffyj.CroissantHoarderSFX";
        private const string modName = "Croissant Hoarder SFX";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static CroissantHoarder Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null) 
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo((object)"CroissantHoarderSFX: Checking the bakery....");
            harmony.PatchAll();
            mls.LogInfo((object)"CroissantHoarderSFX: Croissant Hoarders loaded!");
        }
    }
}
