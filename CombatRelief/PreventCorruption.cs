using HarmonyLib;
using Kingmaker.Corruption;

namespace AlterAsc.CombatRelief
{
    [HarmonyPatch(typeof(CorruptionManager), nameof(CorruptionManager.IncreaseValue))]
    internal static class PreventCorruption
    {
        [HarmonyPrefix]
        private static bool Prefix()
        {
            if (!Main.Settings.PreventCorruption)
                return true;
            try
            {
                return false;
            }
            catch
            {
            }
            return true;
        }
    }
}
