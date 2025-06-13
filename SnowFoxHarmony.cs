using MelonLoader;
using Il2Cpp;

namespace FoxCompanion
{
    public class SnowFoxHarmonyMain : MelonMod
    {
        [HarmonyLib.HarmonyPatch(typeof(SaveGameSystem), "SaveGame")]
        public class SaveGameSystemSaveAddon
        {
            public static void Postfix()
            {
                SnowFoxSettings.options.Save();
            }
        }        
    }
}