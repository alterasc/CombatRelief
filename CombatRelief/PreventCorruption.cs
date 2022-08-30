using HarmonyLib;
using Kingmaker.Corruption;

namespace AlterAsc.CombatRelief
{
  [HarmonyPatch(typeof (CorruptionManager), "IncreaseValue")]
  internal static class PreventCorruption
  {
    private static bool Prefix()
    {
      if (!Main.settings.PreventCorruption)
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
