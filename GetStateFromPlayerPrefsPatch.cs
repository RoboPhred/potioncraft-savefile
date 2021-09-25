using System.IO;
using HarmonyLib;
using SaveLoadSystem;
using UnityEngine;

namespace RoboPhredDev.PotionCraft.SaveFiles
{

    [HarmonyPatch(typeof(SaveLoadProgressInPlayerPrefs), "GetStateFromPlayerPrefs", new System.Type[] { typeof(int), typeof(string) })]
    static class GetStateFromPlayerPrefsPatch
    {
        static bool Prefix(ref ProgressState __result, int fromId, string versionPrefix)
        {
            Debug.Log($"[SaveFile] Trying to load slot {fromId} at version {versionPrefix}");

            var savePath = $"saves/{versionPrefix}_{fromId}.json";
            if (!File.Exists(savePath))
            {
                // Try loading from prefs
                Debug.Log(" > No save file found, falling back to prefs.");
                return true;
            }

            Debug.Log(" > Save file found.");
            var saveContents = File.ReadAllText(savePath);

            __result = ScriptableObject.CreateInstance<ProgressState>();
            __result.name = SaveLoadProgressInPlayerPrefs.GenerateNameFromSlotId(fromId);
            JsonUtility.FromJsonOverwrite(saveContents, __result);
            return false;
        }
    }
}