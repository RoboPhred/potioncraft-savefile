using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace RoboPhredDev.PotionCraft.SaveFiles
{

    [BepInPlugin("net.robophreddev.potioncraft.SaveFiles", "Store saves on the filesystem", "1.0.0.0")]
    public class SaveFilesPlugin : BaseUnityPlugin
    {
        public static string AssemblyDirectory
        {
            get
            {
                var assemblyLocation = typeof(SaveFilesPlugin).Assembly.Location;
                return System.IO.Path.GetDirectoryName(assemblyLocation);
            }
        }

        void Awake()
        {
            UnityEngine.Debug.Log($"[SaveFiles]: Loaded");

            this.ApplyPatches();
        }


        private void ApplyPatches()
        {
            var harmony = new Harmony("net.robophreddev.potioncraft.SaveFiles");
            harmony.PatchAll();
        }
    }
}