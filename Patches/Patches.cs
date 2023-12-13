using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Networking;

namespace Croissant.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class Patches
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void hoarderSFXpatch(ref AudioClip ___chitterSFX)
        {
            string filepath = "file://" + Paths.PluginPath + "\\CroissantHoarderSFX\\croisant.mp3";
            UnityWebRequest loadSFX = UnityWebRequestMultimedia.GetAudioClip(filepath, (AudioType)13);
            loadSFX.SendWebRequest();
            while(!loadSFX.isDone) 
            {
            }
            if ((int)loadSFX.result == 1)
            {
                ___chitterSFX = DownloadHandlerAudioClip.getContent(audioClip);
            }
        }
    }
}
