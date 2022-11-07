using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers;
using System;

namespace CombatRelief.Base
{
    internal class Tricks
    {
        internal static void TryTeleportToSkeletonTrader()
        {
            if (Game.Instance.Player?.Campaign?.AssetGuid.m_Guid == Guid.Parse("fd2e11ebb8a14d6599450fc27f03486a"))
            {
                var enterPointGUIDs = new string[] { "1e6cd972f0064864a8cd25708cb2afda", "e3a715b951c110640afb9811434972d6", "754e16ab6132ce0489f180b5e0b63803" };
                var r = new Random().Next(2);

                var areaPoint = ResourcesLibrary.TryGetBlueprint<BlueprintAreaEnterPoint>(enterPointGUIDs[r]);
                var d2 = Game.Instance.CurrentlyLoadedArea;

                if (d2 != null && d2 == areaPoint.Area)
                {
                    areaPoint = ResourcesLibrary.TryGetBlueprint<BlueprintAreaEnterPoint>(enterPointGUIDs[(r + 1) % 3]);
                }
                GameHelper.EnterToArea(areaPoint, Kingmaker.EntitySystem.Persistence.AutoSaveMode.None);
            }
        }
    }
}
