using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using ModMenu.Settings;
using System;
using System.Collections.Generic;

namespace AlterAsc.CombatRelief;

internal class SettingsModMenu
{
    private static readonly string RootKey = "alterasc.combat-relief";

    public bool AvoidRandom => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("avoid-random"));

    public bool CrusadersArmyAlwaysWin => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("crusaders-army-always-win"));

    public bool PreventCorruption => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("prevent-corruption"));

    public bool ModifySkillRolls => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("modify-skill-rolls"));
    public bool OnlyOutOfCombat => ModMenu.ModMenu.GetSettingValue<bool>(GetKey("only-out-of-combat"));

    public IDictionary<StatType, Func<int>> SkillMods = new Dictionary<StatType, Func<int>>()
    {
        {StatType.SkillAthletics, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("athletics")) },
        {StatType.SkillMobility, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("mobility")) },
        {StatType.SkillThievery, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("trickery")) },
        {StatType.SkillStealth, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("stealth")) },
        {StatType.SkillKnowledgeArcana, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("knowledgearcana")) },
        {StatType.SkillKnowledgeWorld, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("knowledgeworld")) },
        {StatType.SkillLoreNature, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("lorenature")) },
        {StatType.SkillLoreReligion, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("lorereligion")) },
        {StatType.SkillPerception, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("perception")) },
        {StatType.SkillPersuasion, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("persuasion")) },
        {StatType.CheckBluff, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("persuasion")) },
        {StatType.CheckDiplomacy, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("persuasion")) },
        {StatType.CheckIntimidate, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("persuasion")) },
        {StatType.SkillUseMagicDevice, () => ModMenu.ModMenu.GetSettingValue<int>(GetKey("usemagicdevice")) }
    };
    internal void Initialize()
    {
        List<LocalizedString> skillRollChoices =
        [
            CreateString("mm-skillrollmod-1", "Roll normally"),
            CreateString("mm-skillrollmod-2", "Take 10"),
            CreateString("mm-skillrollmod-3", "Take 20")
        ];

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
            .AddToggle(
              Toggle
                .New(GetKey("modify-skill-rolls"), defaultValue: false, CreateString("mm-modify-skill-rolls", "Enable skill rolls modification"))
                .WithLongDescription(CreateString("mm-modify-skill-rolls-desc", "When enabled allows modification of skill rolls."))
                .DependsOnSave()
            )
            .AddSubHeader(
                   CreateString("mm-skill-settings", "Skill roll mod settings"), false
            )
                .AddToggle(
                  Toggle
                    .New(GetKey("only-out-of-combat"), defaultValue: true, CreateString("mm-only-out-of-combat", "Modify only out-of-combat rolls"))
                    .WithLongDescription(CreateString("mm-modify-skill-rolls-desc", "When enabled allows modification only of skill rolls made out of combat."))
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("athletics"),
                        defaultSelected: 1,
                        CreateString("mm-athletics-rollmod", "Athletics"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("mobility"),
                        defaultSelected: 1,
                        CreateString("mm-mobility-rollmod", "Mobility"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("trickery"),
                        defaultSelected: 2,
                        CreateString("mm-trickery-rollmod", "Trickery"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("stealth"),
                        defaultSelected: 0,
                        CreateString("mm-stealth-rollmod", "Stealth"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("knowledgearcana"),
                        defaultSelected: 1,
                        CreateString("mm-knowledgearcana-rollmod", "Knowledge (Arcana)"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("knowledgeworld"),
                        defaultSelected: 1,
                        CreateString("mm-knowledgeworld-rollmod", "Knowledge (World)"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("lorenature"),
                        defaultSelected: 1,
                        CreateString("mm-lorenature-rollmod", "Lore (Nature)"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("lorereligion"),
                        defaultSelected: 1,
                        CreateString("mm-lorereligion-rollmod", "Lore (Religion)"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("perception"),
                        defaultSelected: 2,
                        CreateString("mm-perception-rollmod", "Perception"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("persuasion"),
                        defaultSelected: 1,
                        CreateString("mm-persuasion-rollmod", "Persuasion"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .WithLongDescription(CreateString("mm-persuasion-rollmod-desc", "Affects things such as Demoralize and Dazzling Display, since they are skill checks too. " +
                    "Use with caution if you enable in-combat-rolls"))
                    .DependsOnSave()
                )
                .AddDropdownList(
                    DropdownList.New(
                        GetKey("usemagicdevice"),
                        defaultSelected: 1,
                        CreateString("mm-usemagicdevice-rollmod", "Use Magic Device"),
                        skillRollChoices)
                    .ShowVisualConnection()
                    .DependsOnSave()
                )
            .AddSubHeader(
                   CreateString("mm-tool-buttons", "Tricks"), true
            )
            .AddButton(
                Button
                .New(CreateString("skeletrader-tp", "Teleport to skeleton trader"), CreateString("", "Teleport"), () => Tricks.TryTeleportToSkeletonTrader())
                .WithLongDescription(CreateString("skeletrader-tp-desc", "Teleports to skeleton trader. Works only in Main campaign. " +
                "Does NOT check where you are before teleporting. Does NOT allow returning. If you break your game by teleporting out of Act 4 or quest locked area - it's on you to reload or teleport back via ToyBox."))
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
