using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System.Reflection;
using UnityModManagerNet;

namespace AlterAsc.CombatRelief;

internal static class Main
{
    public static SettingsModMenu Settings;
    public static UnityModManager.ModEntry ModEntry;
    public static Harmony HarmonyInstance;

    private static bool Load(UnityModManager.ModEntry modEntry)
    {
        Settings = new SettingsModMenu();
        ModEntry = modEntry;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        return true;
    }
}

internal class SettingsStarter
{
    [HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init))]
    internal static class BlueprintsCache_Init_Patch
    {
        private static bool _initialized;

        [HarmonyPostfix]
        static void Postfix()
        {
            if (_initialized) return;
            _initialized = true;
            Main.Settings.Initialize();
        }
    }
}
