using HarmonyLib;
using Kingmaker;
using Kingmaker.Assets.Controllers.GlobalMap;
using Kingmaker.RuleSystem.Rules;

namespace AlterAsc.CombatRelief;

[HarmonyPatch(typeof(RandomEncountersController), nameof(RandomEncountersController.GetAvoidanceCheckResult))]
internal class RandomEncounterNoCamping
{
    [HarmonyPrefix]
    private static void UpdateInputRule(ref RuleSkillCheck rule, int dc)
    {
        if (rule == null && Main.Settings.FixRandomChecks)
        {
            try
            {
                var rulePartyStatCheck = new RulePartyStatCheck(Kingmaker.EntitySystem.Stats.StatType.SkillStealth, dc, false, false);
                Game.Instance.Rulebook.TriggerEvent(rulePartyStatCheck);
                rule = (RuleSkillCheck)rulePartyStatCheck.CreateSkillCheck();
            }
            catch (System.Exception ex)
            {
                PFLog.Default.Error("Failed to replace rule", ex);
            }
        }
    }
}
