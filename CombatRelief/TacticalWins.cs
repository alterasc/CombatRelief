using HarmonyLib;
using Kingmaker.Armies;
using Kingmaker.Armies.TacticalCombat;
using Kingmaker.Globalmap.State;

namespace AlterAsc.CombatRelief
{
    [HarmonyPatch(typeof(TacticalCombatResultsPrediction), "GetAttackerLossesPercent")]
    internal static class TacticalWins
    {
        private static void Postfix(
          ref float __result,
          GlobalMapArmyState attacker,
          GlobalMapArmyState defender,
          ref float relativeDefenderPower,
          ref int attackerExp,
          ref int defenderExp)
        {
            if (!Main.settings.NoCrusaderCombat)
                return;
            float num;
            if (attacker.Data.Faction == ArmyFaction.Crusaders)
            {
                num = 0.0f;
            }
            else
            {
                num = 100.0f;
            }
            __result = num;
        }
    }
}
