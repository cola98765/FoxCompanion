using MelonLoader;
using Il2Cpp;

namespace FoxCompanion
{
    public class SnowFoxAuroraMain : MelonMod
    {
        public static void SnowFoxAurora()
        {
            if (SnowFoxSettings.options.settingAuroraFox == 0)
            {
                if (GameManager.GetAuroraManager().AuroraIsActive() && GameManager.GetAuroraManager().GetNormalizedAlpha() >= 0.05f) // [Range(0.01f, 1f)] Aurora sensitivity
                {
                    FoxVars.foxRendererAurora.enabled = true;
                    FoxVars.foxLightComp.enabled = true;
                    FoxVars.foxLightComp.intensity = SnowFoxSettings.options.foxAuroraLightIntensity;
                    FoxVars.foxLightComp.range = SnowFoxSettings.options.foxAuroraLightRange;
                }
                else
                {
                    FoxVars.foxRendererAurora.enabled = false;
                    FoxVars.foxLightComp.enabled = false;
                }
            }
            else if (SnowFoxSettings.options.settingAuroraFox == 1 && FoxVars.foxRendererAurora.enabled != true)
            {
                FoxVars.foxRendererAurora.enabled = true;
                FoxVars.foxLightComp.enabled = true;
                FoxVars.foxLightComp.intensity = SnowFoxSettings.options.foxAuroraLightIntensity;
                FoxVars.foxLightComp.range = SnowFoxSettings.options.foxAuroraLightRange;
            }
            else if (SnowFoxSettings.options.settingAuroraFox == 2 && FoxVars.foxRendererAurora.enabled != false)
            {
                FoxVars.foxRendererAurora.enabled = false;
                FoxVars.foxLightComp.enabled = false;
            }
        }
    }
}