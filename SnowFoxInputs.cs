using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace FoxCompanion
{
    public class SnowFoxInputsMain : MelonMod
    {  

        public static void SnowFoxInputsUpdate()
        {
            if (InputManager.GetKeyDown(InputManager.m_CurrentContext, SnowFoxSettings.options.inputButtonFollow) && FoxVars.foxactive == true && FoxVars.foxSpawned == true)
            {
                // Toggle following player
                if (FoxVars.foxShouldFollowPlayer == false)
                {
                    //MelonLogger.Msg("Fox is now following player");
                    FoxVars.foxShouldFollowPlayer = true;
                    FoxVars.foxShouldFollowSomething = false;
                    if (SnowFoxSettings.options.settingDisplayMsg == true)
                    {
                        HUDMessage.AddMessage(FoxVars.foxName + " is following you now", 1f, true, false);
                    }
                    
                }
                else if (FoxVars.foxShouldFollowPlayer == true)
                {
                    //MelonLogger.Msg("Fox is now waiting");
                    FoxVars.foxShouldFollowPlayer = false;
                    FoxVars.foxState_Movement = "idle";
                    if (SnowFoxSettings.options.settingDisplayMsg == true)
                    {
                        HUDMessage.AddMessage(FoxVars.foxName + " will be waiting for you", 1f, true, false);
                    }                    
                    FoxVars.idleStateChangeTimer = 0;
                }
            }

            // Teleport fox to player
            if (InputManager.GetKeyDown(InputManager.m_CurrentContext, SnowFoxSettings.options.inputButtonTeleport) && FoxVars.foxactive == true && FoxVars.foxSpawned == true) // Teleport fox to player
            {
                SnowFoxTeleportFoxMain.TeleportFoxToTarget(FoxVars.playerTransform);

				if (SnowFoxSettings.options.settingDisplayMsg == true)
                {
                    HUDMessage.AddMessage("You've teleported " + FoxVars.foxName +" to you", 1f, true, false);
                }
            }

			/*if (InputManager.GetKeyDown(InputManager.m_CurrentContext, KeyCode.Keypad0)) // Dumbfuckery :)
			{
                MelonLogger.Msg("Get Path started");
                

            }*/


			if (InputManager.GetKeyDown(InputManager.m_CurrentContext, SnowFoxSettings.options.inputButtonCommandMode) && FoxVars.foxactive == true && FoxVars.foxSpawned == true && FoxVars.targetsphereActive == false) // Enable targeting mode
            {
				//FoxVars.showCrosshair = true;
				//Settings.options.foxCalories = Settings.options.foxCalories - 100;
				if (SnowFoxSettings.options.settingDisplayMsg == true)
				{
					HUDMessage.AddMessage("You've activated the command mode", 1f, true, false);
				}
				FoxVars.targetsphereActive = true;
                
                GameManager.GetPlayerManagerComponent().SetControlMode(PlayerControlMode.BearSpear);

                if(GameManager.GetPlayerAnimationComponent().m_State != PlayerAnimation.State.Aiming)
                {
                    FoxVars.tempPlayerState = GameManager.GetPlayerAnimationComponent().m_State;
                }
                //GameManager.GetPlayerAnimationComponent().m_State = PlayerAnimation.State.Aiming;
                //GameManager.GetPlayerAnimationComponent().MaybeSetState(PlayerAnimation.State.Aiming);               
            }

            if (InputManager.GetMouseButtonDown(InputManager.m_CurrentContext, 0) && FoxVars.foxactive == true && FoxVars.foxSpawned == true && FoxVars.targetsphereActive == true)
            {                
                if(FoxVars.targetsphereActive == true)
                {					
                    //GameManager.GetPlayerManagerComponent().SetControlMode(PlayerControlMode.Normal);
                    //GameManager.GetPlayerAnimationComponent().m_State = FoxVars.tempPlayerState;
                    //GameManager.GetPlayerAnimationComponent().m_State = PlayerAnimation.State.Hidden;
                    GameManager.GetPlayerManagerComponent().SetControlMode(PlayerControlMode.Normal);
                    if (FoxVars.sphereTargetObject == 1)
                    {
						
						HUDMessage.AddMessage(FoxVars.foxName, 1f, true, false);
						
						
						FoxVars.targetHitObject = FoxVars.sphereLastHitObj;

                        FoxVars.targetTransform = FoxVars.sphereLastHitObj.transform;

                        FoxVars.foxShouldFollowPlayer = false;
                        FoxVars.foxShouldFollowSomething = false;
                        FoxVars.rabbidKilled = false;
                        FoxVars.rabbidEvaded = false;

                        FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringgreen.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringblue.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringwhite.transform.position = new Vector3(-1000, -1000, -1000);
                    }

                    if (FoxVars.sphereTargetObject == 2 && FoxVars.foundRabbit == true)
                    {
						if (SnowFoxSettings.options.settingDisplayMsg == true)
						{
							HUDMessage.AddMessage("You've sent " + FoxVars.foxName + " to hunt", 1f, true, false);
						}
						
						FoxVars.targetHitObject = FoxVars.sphereLastHitObj;

                        FoxVars.targetTransform = FoxVars.sphereLastHitObj.transform;

                        FoxVars.foxShouldFollowPlayer = false;
                        FoxVars.foxShouldFollowSomething = true;
                        FoxVars.rabbidKilled = false;
                        FoxVars.rabbidEvaded = false;
                            
                        //MelonLogger.Msg("Found the rabbit! " + FoxVars.whiteRabbit.name);

                        FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringgreen.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringblue.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringwhite.transform.position = new Vector3(-1000, -1000, -1000);
                    }

                    if (FoxVars.sphereTargetObject == 3)
                    {
						if (SnowFoxSettings.options.settingDisplayMsg == true)
						{
							HUDMessage.AddMessage("You've sent " + FoxVars.foxName + " to fetch", 1f, true, false);
						}
						
						FoxVars.targetHitObject = FoxVars.sphereLastHitObj;
                        
                        FoxVars.targetTransform = FoxVars.sphereLastHitObj.transform;
                        
                        FoxVars.foxShouldFollowPlayer = false;
                        FoxVars.foxShouldFollowSomething = true;
                        FoxVars.rabbidKilled = false;
                        FoxVars.rabbidEvaded = false;

                        FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringgreen.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringblue.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringwhite.transform.position = new Vector3(-1000, -1000, -1000);
                    }

                    if (FoxVars.sphereTargetObject == 4)
                    {
						if (SnowFoxSettings.options.settingDisplayMsg == true)
						{
							HUDMessage.AddMessage("You've sent " + FoxVars.foxName + " to eat", 1f, true, false);
						}
						
						FoxVars.targetHitObject = FoxVars.sphereLastHitObj;
                       
                        FoxVars.targetTransform = FoxVars.sphereLastHitObj.transform;

                        FoxVars.foxShouldFollowPlayer = false;
                        FoxVars.foxShouldFollowSomething = true;

                        FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringgreen.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringblue.transform.position = new Vector3(-1000, -1000, -1000);
                        FoxVars.ringwhite.transform.position = new Vector3(-1000, -1000, -1000);
                    }
                   
                    FoxVars.targetsphereActive = false;
                }
            }

            if (InputManager.GetMouseButtonDown(InputManager.m_CurrentContext, 1) && FoxVars.foxactive == true && FoxVars.foxSpawned == true)
            {     
                if(FoxVars.targetsphereActive == true)
                    {
                    //GameManager.GetPlayerAnimationComponent().m_State = FoxVars.tempPlayerState;
                    //GameManager.GetPlayerAnimationComponent().m_State = PlayerAnimation.State.Hidden;
                    //GameManager.GetPlayerManagerComponent().SetControlMode(PlayerControlMode.Normal);
                    GameManager.GetPlayerManagerComponent().SetControlMode(PlayerControlMode.Normal);

					if (SnowFoxSettings.options.settingDisplayMsg == true)
					{
						HUDMessage.AddMessage("You've deactivated the command mode", 1f, true, false);
					}
					
					
                    //GameManager.GetPlayerAnimationComponent().MaybeSetState(PlayerAnimation.State.Aiming);

					FoxVars.targetsphereActive = false;
                    FoxVars.foundRabbit = false;
                    FoxVars.foundBed = false;
                    FoxVars.foundItem = false;
                   
                    FoxVars.ringred.transform.position = new Vector3(-1000, -1000, -1000);
                    FoxVars.ringgreen.transform.position = new Vector3(-1000, -1000, -1000);
                    FoxVars.ringblue.transform.position = new Vector3(-1000, -1000, -1000);
                    FoxVars.ringwhite.transform.position = new Vector3(-1000, -1000, -1000);
				}
			}
        }
    }
}