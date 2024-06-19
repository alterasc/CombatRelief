using HarmonyLib;
using Kingmaker.RuleSystem.Rules;

namespace AlterAsc.CombatRelief;

internal class SkillRolls
{
    [HarmonyPatch(typeof(RuleSkillCheck), nameof(RuleSkillCheck.RollD20))]
    public static class RuleSkillCheck_RollD20_Patch
    {
        [HarmonyPrefix]
        private static bool Prefix(ref RuleRollD20 __result, RuleSkillCheck __instance)
        {
            if (!__instance.Initiator.IsPlayerFaction)
            {
                return true;
            }
            if (!Main.Settings.ModifySkillRolls)
            {
                return true;
            }
            if (__instance.Initiator.IsInCombat && Main.Settings.OnlyOutOfCombat)
            {
                return true;
            }
            Main.Settings.SkillMods.TryGetValue(__instance.StatType, out var mod);
            if (mod != null)
            {
                var value = mod.Invoke();
                switch (value)
                {
                    case 1:
                        __result = RuleRollD20.FromInt(__instance.Initiator, 10);
                        return false;
                    case 2:
                        __result = RuleRollD20.FromInt(__instance.Initiator, 20);
                        return false;
                    default: return true;
                }
            }
            return true;
        }
    }
}
