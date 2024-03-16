using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace BaseMisc
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    [BepInDependency("com.snmodding.nautilus")]
    public class BaseMiscPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.Bobasaur.BaseMisc";
        private const string PluginName = "BaseMisc";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake()
        {
            Logger.LogInfo($"Will load {PluginName} version {VersionString}.");
            Harmony.PatchAll();
            Logger.LogInfo($"{PluginName} version {VersionString} is loaded.");

            Log = Logger;

            Loading.LoadAllAssets();

            Loading.RegisterAllPrefabs();
        }
    }
}
