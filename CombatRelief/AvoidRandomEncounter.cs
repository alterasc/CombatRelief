using HarmonyLib;
using Kingmaker.Assets.Controllers.GlobalMap;
using Kingmaker.RandomEncounters;

namespace AlterAsc.CombatRelief
{
  [HarmonyPatch(typeof (RandomEncountersController), "GetAvoidanceCheckResult")]
  internal static class AvoidRandomEncounter
  {
    private static void Postfix(ref RandomEncounterAvoidanceCheckResult __result)
    {
      if (!Main.settings.AvoidRandom)
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
