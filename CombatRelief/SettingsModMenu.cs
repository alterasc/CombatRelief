using Kingmaker.Localization;
using ModMenu.Settings;

namespace AlterAsc.CombatRelief
{
    internal class SettingsModMenu
    {
        private static readonly string RootKey = "alterasc.combat-relief";

        public bool AvoidRandom => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("avoid-random"));

        public bool CrusadersArmyAlwaysWin => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("crusaders-army-always-win"));

        public bool PreventCorruption => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("prevent-corruption"));

        internal void Initialize()
        {
            ModMenu.ModMenu.AddSettings(
              SettingsBuilder
                .New(GetKey("title"), CreateString("alterasc.combatrelief.title-name", "Combat Relief"))
                .AddToggle(
                  Toggle
                    .New(GetKey("crusaders-army-always-win"), defaultValue: true, CreateString("mm-crusaders-army-always-win", "Autowin Crusade"))
                    .WithLongDescription(CreateString("mm-crusaders-army-always-win-desc", "Crusaders' armies always win autoresolve. Do not forget " +
                    "to enable crusade setting \"Run the tactical combat automatically\" otherwise this does nothing"))
                    .DependsOnSave()
                )
                .AddToggle(
                  Toggle
                    .New(GetKey("avoid-random"), defaultValue: true, CreateString("mm-avoid-random", "Avoid random encounters"))
                    .WithLongDescription(CreateString("mm-avoid-random-desc", "Makes your party always avoid random encounters. " +
                    "Story encounters during travel are unaffected by the mod."))
                    .DependsOnSave()
                )
                .AddToggle(
                  Toggle
                    .New(GetKey("prevent-corruption"), defaultValue: true, CreateString("mm-prevent-corruption", "Prevent Corruption"))
                    .WithLongDescription(CreateString("mm-prevent-corruption-desc", "When enabled corruption is not gained during rest."))
                    .DependsOnSave()
                )
            );
        }

        private static LocalizedString CreateString(string partialKey, string text)
        {
            return CreateStringInner(GetKey(partialKey), text);
        }

        private static string GetKey(string partialKey)
        {
            return $"{RootKey}.{partialKey}";
        }

        private static LocalizedString CreateStringInner(string key, string value)
        {
            LocalizedString result = new()
            {
                m_Key = key
            };
            LocalizationManager.CurrentPack.PutString(key, value);
            return result;
        }
    }
}
