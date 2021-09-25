
using System.IO;
using HarmonyLib;
using SaveLoadSystem;
using UnityEngine;

namespace RoboPhredDev.PotionCraft.SaveFiles
{

    [HarmonyPatch(typeof(SaveLoadProgressInPlayerPrefs), "SaveStateToPlayerPrefs")]
    static class SaveStateToPlayerPrefsPatch
    {
        static bool Prefix(ref bool __result, int toId, ProgressState progressState)
        {
            Debug.Log($"[SaveFile] Saving slot {toId}");
            var saveContents = JsonUtility.ToJson(progressState);
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            var savePath = $"saves/{progressState.version}_{toId}.json";
            // var existed = File.Exists(savePath);
            File.WriteAllText(savePath, saveContents);

            // Allow it to save into the registry, in case the mod is ever uninstalled.
            // __result = existed;
            return true;
        }
    }
}