﻿using UnityEngine;
using MelonLoader;

namespace FoxCompanion
{
    public class SnowFoxInstanceMain : MonoBehaviour
    {
        public static void SnowFoxInstanceLoad()
        {
            // Instantiate fox in scene
            MelonLogger.Msg("Loading ...");

            // load fox asset in game
            FoxVars.foxasset = FoxVars.foxload.LoadAsset<GameObject>("Fox_Snow");
			//FoxVars.foxasset = FoxVars.foxload.LoadAsset<GameObject>("Fox_New");
			//MelonLogger.Msg("Asset: " + FoxVars.foxasset);
			
			FoxVars.fox = GameObject.Instantiate(FoxVars.foxasset);
			//MelonLogger.Msg("Instance: " + FoxVars.fox);
			FoxVars.foxanimator = FoxVars.fox.GetComponentInChildren<Animator>();
            FoxVars.fox.AddComponent<CharacterController>();
            FoxVars.foxController = FoxVars.fox.GetComponent<CharacterController>();
			
			// Pathfinder
			//FoxVars.fox.AddComponent<CorvoPathFinder>();
			//FoxVars.fox.AddComponent<UnitPathfinder>();
			//FoxVars.foxPathfinder = FoxVars.fox.GetComponent<CorvoPathFinder>();
			
			FoxVars.ringasset_red = FoxVars.foxload.LoadAsset<GameObject>("ring_red");
            FoxVars.ringred = GameObject.Instantiate(FoxVars.ringasset_red);
            FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);
            DontDestroyOnLoad(FoxVars.ringred);
			
			FoxVars.ringasset_green = FoxVars.foxload.LoadAsset<GameObject>("ring_green");
            FoxVars.ringgreen = GameObject.Instantiate(FoxVars.ringasset_green);
            FoxVars.ringgreen.transform.position = new Vector3(-1000, -1000, -1000);
            DontDestroyOnLoad(FoxVars.ringgreen);
			
			FoxVars.ringasset_white = FoxVars.foxload.LoadAsset<GameObject>("ring_white");
            FoxVars.ringwhite = GameObject.Instantiate(FoxVars.ringasset_white);
            FoxVars.ringwhite.transform.position = new Vector3(-1000, -1000, -1000);
            DontDestroyOnLoad(FoxVars.ringwhite);
	
			FoxVars.ringasset_blue = FoxVars.foxload.LoadAsset<GameObject>("ring_blue");
            FoxVars.ringblue = GameObject.Instantiate(FoxVars.ringasset_blue);
            FoxVars.ringblue.transform.position = new Vector3(-1000, -1000, -1000);
            DontDestroyOnLoad(FoxVars.ringblue);
	
			/*FoxVars.twinkleasset_red = FoxVars.foxload.LoadAsset<GameObject>("twinkle_red");
            FoxVars.twinklered = GameObject.Instantiate(FoxVars.twinkleasset_red);
            FoxVars.twinklered.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

            FoxVars.twinkleasset_blue = FoxVars.foxload.LoadAsset<GameObject>("twinkle_blue");
            FoxVars.twinkleblue = GameObject.Instantiate(FoxVars.twinkleasset_blue);
            FoxVars.twinklered.transform.localScale = new Vector3(1, 1, 1);

            FoxVars.twinkleasset_white = FoxVars.foxload.LoadAsset<GameObject>("twinkle_white");
            FoxVars.twinklewhite = GameObject.Instantiate(FoxVars.twinkleasset_white);
            FoxVars.twinklered.transform.localScale = new Vector3(1, 1, 1);

            FoxVars.twinkleasset_green = FoxVars.foxload.LoadAsset<GameObject>("twinkle_green");
            FoxVars.twinklegreen = GameObject.Instantiate(FoxVars.twinkleasset_green);
            FoxVars.twinklered.transform.localScale = new Vector3(1, 1, 1);

            FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);

            FoxVars.twinklewhite.transform.position = new Vector3(-1000, -1000, -1000);
            FoxVars.twinkleblue.transform.position = new Vector3(-1000, -1000, -1000);
            FoxVars.twinklered.transform.position = new Vector3(-1000, -1000, -1000);
            FoxVars.twinklegreen.transform.position = new Vector3(-1000, -1000, -1000);*/

			/*DontDestroyOnLoad(FoxVars.twinklered);
            DontDestroyOnLoad(FoxVars.twinkleblue);
            DontDestroyOnLoad(FoxVars.twinklewhite);
            DontDestroyOnLoad(FoxVars.twinklegreen);*/

			MelonLogger.Msg("Loading shader ...");
	

			// Fur shader
			FoxVars.furShaderAsset = FoxVars.foxload.LoadAsset<GameObject>("furShaderObj3");
            FoxVars.furShaderObj = GameObject.Instantiate(FoxVars.furShaderAsset);
            FoxVars.furShaderMat = FoxVars.furShaderObj.GetComponent<SkinnedMeshRenderer>().material;
            DontDestroyOnLoad(FoxVars.furShaderObj);
            DontDestroyOnLoad(FoxVars.furShaderMat);

			FoxVars.fox.layer = 14; // 16 = NPC

            // Fox controller settings
                FoxVars.foxController.center = new Vector3(0, 0.40f, 0.21f); //(0, 0.40f, 0.21f);
                FoxVars.foxController.radius = 0.30f; // 0.14
                FoxVars.foxController.height = 0.6f; // 0.6
                FoxVars.foxController.enableOverlapRecovery = true;
                FoxVars.foxController.minMoveDistance = 0.001f; // 0.001f;
                FoxVars.foxController.skinWidth = 0.12f; //0.08
                FoxVars.foxController.slopeLimit = 80;
                FoxVars.foxController.stepOffset = 0.05f; //0.3
	
			//FoxVars.foxanimator.updateMode = AnimatorUpdateMode.UnscaledTime;

			FoxVars.foxSpawnTimer = 0f;
                
                // Get aurora skinned mesh
                GameObject aurora = FoxVars.fox.transform.Find("Magic").gameObject;
                FoxVars.foxRendererAurora = aurora.GetComponent<SkinnedMeshRenderer>();
                FoxVars.foxRendererAurora.enabled = false;
                FoxVars.foxRendererAuroraMaterial = aurora.GetComponent<SkinnedMeshRenderer>().material;

            // Get normal skinned mesh and material
            GameObject foxmesh = FoxVars.fox.transform.Find("Fox").gameObject;
                FoxVars.foxRenderer = foxmesh.GetComponent<SkinnedMeshRenderer>();
                FoxVars.foxMaterial = foxmesh.GetComponent<SkinnedMeshRenderer>().material;
                FoxVars.foxRenderer.receiveShadows = true;
                FoxVars.foxRenderer.castShadows = true;


			// Load name file
			if (File.Exists("Mods\\FoxCompanionName.txt"))
			{
				// Open the stream and read it back.
				using (StreamReader sr = File.OpenText("Mods\\FoxCompanionName.txt"))
				{
					FoxVars.foxName = sr.ReadLine();
				}
			}


			if (SnowFoxSettings.options.settingFoxFurShader == true)
            {
                FoxVars.foxRenderer.material = FoxVars.furShaderMat;

                //FoxVars.foxRendererAurora.material = FoxVars.furShaderMat;
            }
            else
            {
                FoxVars.foxRenderer.material = FoxVars.foxMaterial;
                //FoxVars.foxRendererAurora.material = FoxVars.foxRendererAuroraMaterial;
            }                      
            
            /*[Choice("Snow", "Black", "Orange", "Mane", "Zerda", "Custom 1", "Custom 2", "Custom 3")]
            public int settingTexture = 0;*/
            byte[] img;

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

                FoxVars.foxTexture = new Texture2D(128, 64);
                //FoxVars.foxTexture.LoadImage(FoxVars.foxTexture, img);
                ImageConversion.LoadImage(FoxVars.foxTexture, img);
           


                FoxVars.foxRenderer.material.mainTexture = FoxVars.foxTexture;
                

                FoxVars.foxFurColor = new Color(SnowFoxSettings.options.settingFoxFurColorR, SnowFoxSettings.options.settingFoxFurColorG, SnowFoxSettings.options.settingFoxFurColorB, 1f);
                FoxVars.foxAuroraEmissionColor = new Vector4(SnowFoxSettings.options.settingFoxAuroraColorR, SnowFoxSettings.options.settingFoxAuroraColorG, SnowFoxSettings.options.settingFoxAuroraColorB, 1f) * SnowFoxSettings.options.settingFoxAuroraIntensity;
                FoxVars.foxAuroraPatternColor = new Color(SnowFoxSettings.options.settingFoxAuroraColorR, SnowFoxSettings.options.settingFoxAuroraColorG, SnowFoxSettings.options.settingFoxAuroraColorB, 1f);

                // Fur color
                FoxVars.foxRenderer.material.SetColor("_Color", FoxVars.foxFurColor);

                // Aurora pattern color
                //FoxVars.foxRendererAurora.material.SetColor("_EmissionColor", FoxVars.foxAuroraPatternColor);
                FoxVars.foxRendererAurora.material.SetColor("_Color", FoxVars.foxAuroraPatternColor);
                FoxVars.foxRendererAurora.material.SetColor("_EmissionColor", FoxVars.foxAuroraEmissionColor);

            // Light
                FoxVars.foxLight = new GameObject();
                FoxVars.foxLight.transform.SetParent(FoxVars.fox.transform, true);
                FoxVars.foxLight.transform.localPosition = new Vector3(0f, 0.6f, 0.3f); //new Vector3(0.01f, 0.05f, 0.523f);
                FoxVars.foxLightComp = FoxVars.foxLight.AddComponent<Light>();
                FoxVars.foxLightComp.color = FoxVars.foxAuroraPatternColor;
                FoxVars.foxLightComp.intensity = SnowFoxSettings.options.foxAuroraLightIntensity;
                FoxVars.foxLightComp.range = SnowFoxSettings.options.foxAuroraLightRange;
                FoxVars.foxLightComp.enabled = false;
               

                FoxVars.foxTexture.Apply();

                // Initiate standard 
                FoxVars.foxanimator.SetBool("Stand", true);
                FoxVars.foxanimator.SetInteger("IDInt", 2);
                FoxVars.foxanimator.SetLayerWeight(FoxVars.foxanimator.GetLayerIndex("Fox"), 1);


                if (SnowFoxSettings.options.settingAutoFollow == true)
                {
                    MelonLogger.Msg("Autofollow enabled");
                    FoxVars.foxShouldFollowSomething = false;
                    FoxVars.foxShouldFollowPlayer = true;
                }
                else
                {
                    MelonLogger.Msg("Autofollow disabled");
                    FoxVars.foxShouldFollowSomething = false;
                    FoxVars.foxShouldFollowPlayer = false;
                }

                MelonLogger.Msg("Snow fox is instantiated");
                FoxVars.foxSpawned = true;
                FoxVars.foxactive = true;
                FoxVars.isLevelLoaded = true;
                DontDestroyOnLoad(FoxVars.fox);

			

		}
    }
}