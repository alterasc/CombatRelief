using UnityModManagerNet;

namespace AlterAsc.CombatRelief
{
  public class Settings : UnityModManager.ModSettings
  {
    public bool NoRandom;
    public bool AvoidRandom = true;
    public bool NoCrusaderCombat = true;
    public bool CrusaderRewards = true;
    public bool PreventCorruption = true;
    public bool PreventSieges;
    public bool AllowAchievements;

    public virtual void Save(UnityModManager.ModEntry modEntry) => UnityModManager.ModSettings.Save<Settings>(this, modEntry);
  }
}
