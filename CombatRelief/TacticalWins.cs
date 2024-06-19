using HarmonyLib;
using Kingmaker.Armies;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Globalmap.State;

namespace AlterAsc.CombatRelief;

[HarmonyPatch(typeof(TacticalCombatResultsPrediction), nameof(TacticalCombatResultsPrediction.GetAttackerLossesPercent))]
internal static class TacticalWins
{
    [HarmonyPostfix]
    private static void Postfix(
      ref float __result,
      GlobalMapArmyState attacker,
      GlobalMapArmyState defender,
      ref float relativeDefenderPower,
      ref int attackerExp,
      ref int defenderExp)
    {
        if (!Main.Settings.CrusadersArmyAlwaysWin)
        {
            return;
        }
        __result = attacker.Data.Faction == ArmyFaction.Crusaders ? 0f : 100f;
    }
}
