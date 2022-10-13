using HarmonyLib;
using Kingmaker.Assets.Controllers.GlobalMap;
using Kingmaker.RandomEncounters;

namespace AlterAsc.CombatRelief
{
    [HarmonyPatch(typeof(RandomEncountersController), nameof(RandomEncountersController.GetAvoidanceCheckResult))]
    internal static class AvoidRandomEncounter
    {
        [HarmonyPostfix]
        private static void Postfix(ref RandomEncounterAvoidanceCheckResult __result)
        {
            if (!Main.Settings.AvoidRandom)
                return;
            try
            {
                __result = RandomEncounterAvoidanceCheckResult.Success;
            }
            catch
            {
            }
        }
    }
}
