using HarmonyLib;
using Kingmaker;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;
using UnityModManagerNet;

namespace TemplateProject
{
#if DEBUG
    [EnableReloading]
#endif
    static class Main
    {
        public static bool Enabled;
        public static UnityModManager.ModEntry ModEntry;
        static bool Load(UnityModManager.ModEntry modEntry)
        {            
            var harmony = new Harmony(modEntry.Info.Id);
            ModEntry = modEntry;
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
#if DEBUG
            modEntry.OnUnload = OnUnload;
#endif
            harmony.PatchAll();
            return true;
        }
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Enabled = value;
            return true;
        }

        static bool OnUnload(UnityModManager.ModEntry modEntry)
        {
            return true;
        }


        static void OnGUI(UnityModManager.ModEntry modEntry)
        {

        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {

        }
    }
}
