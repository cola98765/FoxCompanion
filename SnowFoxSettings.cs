﻿using System.Reflection;
using UnityEngine;
using ModSettings;
using Il2Cpp;

namespace FoxCompanion
{
    internal class SnowFoxSettingsMain : JsonModSettings
    {
        [Section("General settings")]

        [Name("Enable / disable mod")]
        [Description("Enable mod (if disabled fox won't spawn on loading/starting a game or disappears on scene transition (eg. going inside)")]
        public bool settingFoxEnable = true;

        [Name("Auto follow")]
        [Description("Fox automatically follows player after transition / spawning")]
        public bool settingAutoFollow = true;

        [Name("Onscreen messages")]
        [Description("Display messages when entering command mode")]
        public bool settingDisplayMsg = true;
        
        [Name("Aurora effects")]
        [Description("Show aurora effects")]
        [Choice("During aurora", "Always", "Never")]
        public int settingAuroraFox = 0;

		[Name("Chance to catch")]
		[Description("Chance to catch rabbits in percent")]
		[Slider(0, 100)]
		public float chanceToCatch = 50;

		[Section("Texture")]

        [Name("Fox texture")]
        [Description("Change the look of your fox")]
        [Choice("Snow", "Black", "Orange", "Mane", "Zerda", "Custom 1", "Custom 2", "Custom 3")]
        public int settingTexture = 0;

        [Name("Fox fur")]
        [Description("Enable / disable fur shader")]
        public bool settingFoxFurShader = false;

        [Section("Fur tint color (Default: R(1) G(1) B(1))")]

        [Name("Red")]
        [Description("Red color component of the fur")]
        [Slider(0f, 1f)]
        public float settingFoxFurColorR = 1;

        [Name("Green")]
        [Description("Blue color component of the fur")]
        [Slider(0f, 1f)]
        public float settingFoxFurColorG = 1;

        [Name("Blue")]
        [Description("Blue color component of the fur")]
        [Slider(0f, 1f)]
        public float settingFoxFurColorB = 1;
        
        [Section("Aurora effect glow color (Default: R(1) G(1) B(1))")]

        [Name("Red")]
        [Description("Red color component of the aurora effect on the fox")]
        [Slider(0, 1f)]
        public float settingFoxAuroraColorR = 1;

        [Name("Green")]
        [Description("Blue color component of the aurora effect on the fox")]
        [Slider(0, 1f)]
        public float settingFoxAuroraColorG = 1;

        [Name("Blue")]
        [Description("Blue color component of the aurora effect on the fox")]
        [Slider(0, 1f)]
        public float settingFoxAuroraColorB = 1;

        [Name("Glow intensity")]
        [Description("Brightness of the glow effect")]
        [Slider(0, 20f)]
        public float settingFoxAuroraIntensity = 2;

        [Name("Light intensity")]
        [Description("Brightness of the light illuminating the surroundings")]
        [Slider(0, 3f)]
        public float foxAuroraLightIntensity = 2.0f;

        [Name("Light range")]
        [Description("Range of the light illuminating the surroundings")]
        [Slider(0, 3f)]
        public float foxAuroraLightRange = 0.5f;

		     

		[Section("Keybinds")]

		[Name("Teleport")]
		[Description("Teleports fox to player, useful if fox gets stuck or lost")]
		public UnityEngine.KeyCode inputButtonTeleport = KeyCode.P;

		[Name("Follow player / stop (toggle)")]
		[Description("Toggles following the player and stopping (stopping works for follow/goto target too")]
		public UnityEngine.KeyCode inputButtonFollow = KeyCode.V;

		/*
		[Name("Follow target / Goto target")]
		[Description("Order to follow/goto target. Hold key down to display crosshair, release to issue command to fox")]
		public UnityEngine.KeyCode inputButtonGoTo = KeyCode.LeftAlt;*/

		[Name("Enable command mode")]
		[Description("Aim at an object/animal while mode is enabled. Execute on left mouse button, cancel on right mouse button.")]
		public UnityEngine.KeyCode inputButtonCommandMode = KeyCode.B;

		/*
		[Name("Teleport")]
        [Description("Teleports fox to player, useful if fox gets stuck or lost")]
        [Choice("B", "C", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "X", "Y", "Z", "Insert", "Home", "End", "PageUp", "PageDown", "Pause", "Clear")]
        public int buttonTeleport = 12;

        [Name("Follow player / stop (toggle)")]
        [Description("Toggles following the player and stopping (stopping works for follow/goto target too")]
        [Choice("B", "C", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "X", "Y", "Z", "Insert", "Home", "End", "PageUp", "PageDown", "Pause", "Clear")]
        public int buttonFollowPlayer = 9;

        [Name("Follow target / Goto target")]
        [Description("Order to follow/goto target. Hold key down to display crosshair, release to issue command to fox")]
        [Choice("B", "C", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "X", "Y", "Z", "Insert", "Home", "End", "PageUp", "PageDown", "Pause", "Clear")]
        public int buttonFollowTarget = 10;

        [Name("Enable command mode")]
        [Description("Aim at an object/animal while mode is enabled. Execute on left mouse button, cancel on right mouse button.")]
        [Choice("B", "C", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "X", "Y", "Z", "Insert", "Home", "End", "PageUp", "PageDown", "Pause", "Clear")]
        public int buttonCommandMode = 0;*/


		protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {           
            GameManager.GetCameraEffects().DepthOfFieldTurnOff(true);
            GameManager.GetCameraEffects().VignettingEnable(false);
            GameManager.GetCameraEffects().ContrastEnhanceEnable(false);

            FoxVars.SettingsBackgroundSprite = GameObject.Find("Panel_OptionsMenu/Pages/ModSettings/bg (2)");
            FoxVars.SettingsBackgroundSprite.GetComponent<UISprite>().mColor = new Color(0f, 0f, 0f, 0f);
            FoxVars.SettingsBackgroundMark = GameObject.Find("Panel_OptionsMenu/Pages/ModSettings/mark (2)");
            FoxVars.SettingsBackgroundMark.GetComponent<UISprite>().mColor = new Color(0f, 0f, 0f, 0f);
            FoxVars.SettingsBackgroundVignette = GameObject.Find("Panel_OptionsMenu/Pages/ModSettings/Vignette (2)");
            FoxVars.SettingsBackgroundVignette.GetComponent<UISprite>().mColor = new Color(0f, 0f, 0f, 0f);

            byte[] img;
            // Apply texture
            switch (SnowFoxSettings.options.settingTexture)
            {
                case 0:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\snow.png");
                    break;
                case 1:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\black.png");
                    break;
                case 2:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\orange.png");
                    break;
                case 3:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\mane.png");
                    break;
                case 4:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\zerda.png");
                    break;
                case 5:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\custom1.png");
                    break;
                case 6:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\custom2.png");
                    break;
                case 7:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\custom3.png");
                    break;
                default:
                    img = System.IO.File.ReadAllBytes("Mods\\foxtures\\snow.png");
                    break;
            }

            if (SnowFoxSettings.options.settingFoxFurShader == true)
            {
                FoxVars.foxRenderer.material = FoxVars.furShaderMat;
            }
            else
            {
                FoxVars.foxRenderer.material = FoxVars.foxMaterial;
            }

            FoxVars.foxTexture = new Texture2D(128, 64);
            //FoxVars.foxTexture.LoadImage(FoxVars.foxTexture, img);
            ImageConversion.LoadImage(FoxVars.foxTexture, img);

            FoxVars.foxRenderer.material.mainTexture = FoxVars.foxTexture;
           

            FoxVars.foxTexture.Apply();
            
            FoxVars.foxFurColor = new Color(settingFoxFurColorR, settingFoxFurColorG, settingFoxFurColorB, 1f);
            FoxVars.foxAuroraEmissionColor = new Vector4(settingFoxAuroraColorR, settingFoxAuroraColorG, settingFoxAuroraColorB, 1f) * settingFoxAuroraIntensity;
            FoxVars.foxAuroraPatternColor = new Color(settingFoxAuroraColorR, settingFoxAuroraColorG, settingFoxAuroraColorB, 1f);

            // Fur color
            FoxVars.foxRenderer.material.SetColor("_Color", FoxVars.foxFurColor);
            

            // Aurora pattern color
            //FoxVars.foxRendererAurora.material.SetColor("_EmissionColor", FoxVars.foxAuroraPatternColor);
            FoxVars.foxRendererAurora.material.SetColor("_EmissionColor", FoxVars.foxAuroraEmissionColor);
            FoxVars.foxLightComp.color = FoxVars.foxAuroraPatternColor;
            FoxVars.foxLightComp.intensity = foxAuroraLightIntensity;
            FoxVars.foxLightComp.range = foxAuroraLightRange;
        }

        protected override void OnConfirm()
        {            
            base.OnConfirm();
        }
    }

    internal static class SnowFoxSettings
    {
        public static SnowFoxSettingsMain options;
        public static KeyCode returnKeyValue;

        public static void OnLoad()
        {
            options = new SnowFoxSettingsMain();
            ///options.RefreshFields();
            options.AddToModSettings("Fox Settings");       

            
        }


        public static KeyCode GetInputKeyFromString(int keyStringInt)
        {
            switch(keyStringInt)
            {
                case 0:
                    returnKeyValue = KeyCode.B;
                    break;
                case 1:
                    returnKeyValue = KeyCode.C;
                    break;
                case 2:
                    returnKeyValue = KeyCode.F;
                    break;
                case 3:
                    returnKeyValue = KeyCode.G;
                    break;
                case 4:
                    returnKeyValue = KeyCode.H;
                    break;
                case 5:
                    returnKeyValue = KeyCode.I;
                    break;
                case 6:
                    returnKeyValue = KeyCode.K;
                    break;
                case 7:
                    returnKeyValue = KeyCode.K;
                    break;
                case 8:
                    returnKeyValue = KeyCode.L;
                    break;
                case 9:
                    returnKeyValue = KeyCode.M;
                    break;
                case 10:
                    returnKeyValue = KeyCode.N;
                    break;
                case 11:
                    returnKeyValue = KeyCode.O;
                    break;
                case 12:
                    returnKeyValue = KeyCode.P;
                    break;
                case 13:
                    returnKeyValue = KeyCode.R;
                    break;
                case 14:
                    returnKeyValue = KeyCode.T;
                    break;
                case 15:
                    returnKeyValue = KeyCode.U;
                    break;
                case 16:
                    returnKeyValue = KeyCode.V;
                    break;
                case 17:
                    returnKeyValue = KeyCode.X;
                    break;
                case 18:
                    returnKeyValue = KeyCode.Y;
                    break;
                case 19:
                    returnKeyValue = KeyCode.Z;
                    break;
                case 20:
                    returnKeyValue = KeyCode.Insert;
                    break;
                case 21:
                    returnKeyValue = KeyCode.Home;
                    break;
                case 22:
                    returnKeyValue = KeyCode.End;
                    break;
                case 23:
                    returnKeyValue = KeyCode.PageUp;
                    break;
                case 24:
                    returnKeyValue = KeyCode.PageDown;
                    break;
                case 25:
                    returnKeyValue = KeyCode.Pause;
                    break;
                case 26:
                    returnKeyValue = KeyCode.Clear;
                    break;
            }

            return returnKeyValue;
        }

    }
}
