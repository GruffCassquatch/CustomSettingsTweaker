using HarmonyLib;
using Il2Cpp;
using Il2CppTLD.Gameplay;
using MelonLoader;
using UnityEngine;
using UnityEngine.AddressableAssets;
using CustomExperienceModeManager = Il2CppTLD.Gameplay.Tunable;

namespace CustomSettingsTweaker
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(ExperienceModeManager), "GetCustomMode")]
        private static class GetCustomExperienceModeUpdated
        {
            private static void Postfix(CustomExperienceMode __result)
            {
                if (GameManager.m_ActiveScene == "MainMenu") return;
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled) return;

                // GAME START
                // Baseline Resource Availability
                //MelonLogger.Msg("Baseline Resource Availability ORIGINAL " + __result.m_BaseWorldDifficulty.ToString());
                switch (Settings.settings.resourceAvailability)
                {
                    case ChoiceDLMHV.Low:
                        __result.m_BaseWorldDifficulty = CustomExperienceModeManager.CustomTunableLMHV.Low;
                        break;
                    case ChoiceDLMHV.Medium:
                        __result.m_BaseWorldDifficulty = CustomExperienceModeManager.CustomTunableLMHV.Medium;
                        break;
                    case ChoiceDLMHV.High:
                        __result.m_BaseWorldDifficulty = CustomExperienceModeManager.CustomTunableLMHV.High;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __result.m_BaseWorldDifficulty = CustomExperienceModeManager.CustomTunableLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Baseline Resource Availability NEW " + __result.m_BaseWorldDifficulty.ToString());


                // Survivor Monologue 
                //MelonLogger.Msg("Survivor Monologue ORIGINAL " + __result.m_SurvivorVoiceOver.ToString());
                switch (Settings.settings.survivorMonologue)
                {
                    case ChoiceDNY.No:
                        __result.m_SurvivorVoiceOver = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_SurvivorVoiceOver = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Survivor Monologue new " + __result.m_SurvivorVoiceOver.ToString());

                // ENVIRONMENT
                // Wind Variability
                //MelonLogger.Msg("Wind Variability ORIGINAL " + __result.m_WindVariability.ToString());
                switch (Settings.settings.windVariability)
                {
                    case ChoiceDLMH.Low:
                        __result.m_WindVariability = CustomExperienceModeManager.CustomTunableLMH.Low;
                        break;
                    case ChoiceDLMH.Medium:
                        __result.m_WindVariability = CustomExperienceModeManager.CustomTunableLMH.Medium;
                        break;
                    case ChoiceDLMH.High:
                        __result.m_WindVariability = CustomExperienceModeManager.CustomTunableLMH.High;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wind Variability NEW " + __result.m_WindVariability.ToString());

                // Aurora
                switch (Settings.settings.auroraFrequency)
                {
                    case ChoiceDNLMH.None:
                        __result.m_AuroraFrequency = CustomExperienceModeManager.CustomTunableNLMH.None;
                        break;
                    case ChoiceDNLMH.Low:
                        __result.m_AuroraFrequency = CustomExperienceModeManager.CustomTunableNLMH.Low;
                        break;
                    case ChoiceDNLMH.Medium:
                        __result.m_AuroraFrequency = CustomExperienceModeManager.CustomTunableNLMH.Medium;
                        break;
                    case ChoiceDNLMH.High:
                        __result.m_AuroraFrequency = CustomExperienceModeManager.CustomTunableNLMH.High;
                        break;
                    default:
                        break;
                }


                // Fire Overcomes Ambient
                //MelonLogger.Msg("Fire Overcomes Ambient Temp ORIGINAL " + __result.m_UseMinAirTempValue.ToString());
                switch (Settings.settings.fireOvercomesAmbient)
                {
                    case ChoiceDNY.No:
                        __result.m_UseMinAirTempValue = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_UseMinAirTempValue = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Fire Overcomes Ambient Temp NEW " + __result.m_UseMinAirTempValue.ToString());

                // Endless Night
                //MelonLogger.Msg("Endless Night ORIGINAL " + __result.m_EndlessNight.ToString());
                switch (Settings.settings.endlessNight)
                {
                    case ChoiceDNY.No:
                        __result.m_EndlessNight = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_EndlessNight = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Endless Night NEW " + __result.m_EndlessNight.ToString());

                // HEALTH
                // Frostbite
                //MelonLogger.Msg("Frostbite Risk ORIGINAL " + __result.m_FrosbiteRisk.ToString());
                switch (Settings.settings.frostbiteRate)
                {
                    case ChoiceDNLMHV.None:
                        __result.m_FrosbiteRisk = CustomExperienceModeManager.CustomTunableNLMHV.None;
                        break;
                    case ChoiceDNLMHV.Low:
                        __result.m_FrosbiteRisk = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                        break;
                    case ChoiceDNLMHV.Medium:
                        __result.m_FrosbiteRisk = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                        break;
                    case ChoiceDNLMHV.High:
                        __result.m_FrosbiteRisk = CustomExperienceModeManager.CustomTunableNLMHV.High;
                        break;
                    case ChoiceDNLMHV.VeryHigh:
                        __result.m_FrosbiteRisk = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Frostbite Risk NEW " + __result.m_FrosbiteRisk.ToString());

                // Cabin Fever
                //MelonLogger.Msg("Cabin Fever ORIGINAL " + __result.m_CabinFeverEnabled.ToString());
                switch (Settings.settings.cabinFever)
                {
                    case ChoiceDNY.No:
                        __result.m_CabinFeverEnabled = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_CabinFeverEnabled = true;
                        break;
                    default:
                        break;
                }

                // Intestinal Parasites
                //MelonLogger.Msg("Intestinal Parasites ORIGINAL " + __result.m_ParasitesEnabled.ToString());
                switch (Settings.settings.intestinalParasites)
                {
                    case ChoiceDNY.No:
                        __result.m_ParasitesEnabled = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_ParasitesEnabled = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Intestinal Parasites NEW " + __result.m_ParasitesEnabled.ToString());

                // Dysentry
                //MelonLogger.Msg("Dysentry ORIGINAL " + __result.m_EnableDysentery.ToString());
                switch (Settings.settings.dysentry)
                {
                    case ChoiceDNY.No:
                        __result.m_EnableDysentery = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_EnableDysentery = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Dysentry NEW " + __result.m_EnableDysentery.ToString());

                // Sprains
                //MelonLogger.Msg("Sprains ORIGINAL " + __result.m_EnableSprains.ToString());
                switch (Settings.settings.sprains)
                {
                    case ChoiceDNY.No:
                        __result.m_EnableSprains = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_EnableSprains = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Sprains NEW " + __result.m_EnableSprains.ToString());

                // Food Poisoning
                //MelonLogger.Msg("Food Poisoning ORIGINAL " + __result.m_EnableFoodPoisoning.ToString());
                switch (Settings.settings.foodPoisoning)
                {
                    case ChoiceDNY.No:
                        __result.m_EnableFoodPoisoning = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_EnableFoodPoisoning = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Food Poisoning NEW " + __result.m_EnableFoodPoisoning.ToString());

                // Broken Ribs
                //MelonLogger.Msg("Broken Ribs ORIGINAL " + __result.m_EnableBrokenRibs.ToString());
                switch (Settings.settings.brokenRibs)
                {
                    case ChoiceDNY.No:
                        __result.m_EnableBrokenRibs = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_EnableBrokenRibs = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Broken Ribs NEW " + __result.m_EnableBrokenRibs.ToString());

                // Rest
                //MelonLogger.Msg("Rest As Resource ORIGINAL " + __result.m_LimitedRest.ToString());
                switch (Settings.settings.restAsResource)
                {
                    case ChoiceDNY.No:
                        __result.m_LimitedRest = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_LimitedRest = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Rest As Resource NEW " + __result.m_LimitedRest.ToString());

                // Fires Prevent Freezing
                //MelonLogger.Msg("Fires Prevent Freezing ORIGINAL " + __result.m_AdjustFreezingDueToNearbyFire.ToString());
                switch (Settings.settings.firesPreventFreezing)
                {
                    case ChoiceDNY.No:
                        __result.m_AdjustFreezingDueToNearbyFire = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_AdjustFreezingDueToNearbyFire = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Fires Prevent Freezing NEW " + __result.m_AdjustFreezingDueToNearbyFire.ToString());

                // Wake up When Freezing Near Fire
                //MelonLogger.Msg("Wake up When Freezing Near Fire ORIGINAL " + __result.m_InterruptIfFreezingWhileSleeping.ToString());
                switch (Settings.settings.wakeUpWhenFreezing)
                {
                    case ChoiceDNY.No:
                        __result.m_InterruptIfFreezingWhileSleeping = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_InterruptIfFreezingWhileSleeping = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wake up When Freezing Near Fire NEW " + __result.m_InterruptIfFreezingWhileSleeping.ToString());

                // Birch Bark Tea Crafting
                //MelonLogger.Msg("Birch Bark Tea Crafting ORIGINAL " + __result.m_IsBirchBarkTreeCraftable.ToString());
                switch (Settings.settings.birchBarkTea)
                {
                    case ChoiceDNY.No:
                        __result.m_IsBirchBarkTreeCraftable = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_IsBirchBarkTreeCraftable = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Birch Bark Tea Crafting NEW " + __result.m_IsBirchBarkTreeCraftable.ToString());

                // GEAR
                // Empty Container Chance
                //MelonLogger.Msg("Empty Container Chance ORIGINAL " + __result.m_EmptyContainerChance.ToString());
                switch (Settings.settings.emptyContainerChance)
                {
                    case ChoiceDNLMH.None:
                        __result.m_EmptyContainerChance = CustomExperienceModeManager.CustomTunableNLMH.None;
                        break;
                    case ChoiceDNLMH.Low:
                        __result.m_EmptyContainerChance = CustomExperienceModeManager.CustomTunableNLMH.Low;
                        break;
                    case ChoiceDNLMH.Medium:
                        __result.m_EmptyContainerChance = CustomExperienceModeManager.CustomTunableNLMH.Medium;
                        break;
                    case ChoiceDNLMH.High:
                        __result.m_EmptyContainerChance = CustomExperienceModeManager.CustomTunableNLMH.High;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Empty Container Chance ORIGINAL " + __result.m_EmptyContainerChance.ToString());

                // Rifle Availability
                //MelonLogger.Msg("Rifle Availability ORIGINAL " + __result.m_RiflesInWorld.ToString());
                switch (Settings.settings.rifleAvailability)
                {
                    case ChoiceDNY.No:
                        __result.m_RiflesInWorld = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_RiflesInWorld = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Rifle Availability NEW " + __result.m_RiflesInWorld.ToString());

                // Revolver Availability
                //MelonLogger.Msg("Revolver Availability ORIGINAL " + __result.m_RevolversInWorld.ToString());
                switch (Settings.settings.revolverAvailability)
                {
                    case ChoiceDNY.No:
                        __result.m_RevolversInWorld = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_RevolversInWorld = true;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Revolver Availability NEW " + __result.m_RevolversInWorld.ToString());

                // Harvestable Plant Availability
                //MelonLogger.Msg("Harvestable Plant Availability ORIGINAL " + __result.m_PlantSpawnFrequency.ToString());
                switch (Settings.settings.harvestablePlants)
                {
                    case ChoiceDLMH.Low:
                        __result.m_PlantSpawnFrequency = CustomExperienceModeManager.CustomTunableLMH.Low;
                        break;
                    case ChoiceDLMH.Medium:
                        __result.m_PlantSpawnFrequency = CustomExperienceModeManager.CustomTunableLMH.Medium;
                        break;
                    case ChoiceDLMH.High:
                        __result.m_PlantSpawnFrequency = CustomExperienceModeManager.CustomTunableLMH.High;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Harvestable Plant Availability NEW " + __result.m_PlantSpawnFrequency.ToString());

                // WILDLIFE SPAWNS
                // Bear
                //MelonLogger.Msg("Bear Spawn ORIGINAL " + __result.m_BearSpawnChance.ToString());
                switch (Settings.settings.bearSpawn)
                {
                    case ChoiceDNLMHV.None:
                        __result.m_BearSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.None;
                        break;
                    case ChoiceDNLMHV.Low:
                        __result.m_BearSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                        break;
                    case ChoiceDNLMHV.Medium:
                        __result.m_BearSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                        break;
                    case ChoiceDNLMHV.High:
                        __result.m_BearSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.High;
                        break;
                    case ChoiceDNLMHV.VeryHigh:
                        __result.m_BearSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Bear Spawn NEW " + __result.m_BearSpawnChance.ToString());

                // Deer
                //MelonLogger.Msg("Deer Spawn ORIGINAL " + __result.m_DeerSpawnChance.ToString());
                switch (Settings.settings.deerSpawn)
                {
                    case ChoiceDNLMHV.None:
                        __result.m_DeerSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.None;
                        break;
                    case ChoiceDNLMHV.Low:
                        __result.m_DeerSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                        break;
                    case ChoiceDNLMHV.Medium:
                        __result.m_DeerSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                        break;
                    case ChoiceDNLMHV.High:
                        __result.m_DeerSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.High;
                        break;
                    case ChoiceDNLMHV.VeryHigh:
                        __result.m_DeerSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Deer Spawn NEW " + __result.m_DeerSpawnChance.ToString());

                // Rabbit
                //MelonLogger.Msg("Rabbit Spawn ORIGINAL " + __result.m_RabbitSpawnChance.ToString());
                switch (Settings.settings.rabbitSpawn)
                {
                    case ChoiceDNLMHV.None:
                        __result.m_RabbitSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.None;
                        break;
                    case ChoiceDNLMHV.Low:
                        __result.m_RabbitSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                        break;
                    case ChoiceDNLMHV.Medium:
                        __result.m_RabbitSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                        break;
                    case ChoiceDNLMHV.High:
                        __result.m_RabbitSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.High;
                        break;
                    case ChoiceDNLMHV.VeryHigh:
                        __result.m_RabbitSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Rabbit Spawn NEW " + __result.m_RabbitSpawnChance.ToString());

                // Moose
                //MelonLogger.Msg("Moose Spawn ORIGINAL " + __result.m_MooseSpawnChance.ToString());
                switch (Settings.settings.mooseSpawn)
                {
                    case ChoiceDNLMHV.None:
                        __result.m_MooseSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.None;
                        break;
                    case ChoiceDNLMHV.Low:
                        __result.m_MooseSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                        break;
                    case ChoiceDNLMHV.Medium:
                        __result.m_MooseSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                        break;
                    case ChoiceDNLMHV.High:
                        __result.m_MooseSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.High;
                        break;
                    case ChoiceDNLMHV.VeryHigh:
                        __result.m_MooseSpawnChance = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Moose Spawn NEW " + __result.m_MooseSpawnChance.ToString());

                // Wildlife Respawn Frequency
                ////MelonLogger.Msg("Wildlife Respawn Frequency ORIGINAL " + __result.m_WildlifeSpawnFrequency.ToString());
                switch (Settings.settings.wildlifeRespawn)
                {
                    case ChoiceDLMHV.Low:
                        __result.m_WildlifeSpawnFrequency = CustomExperienceModeManager.CustomTunableLMHV.Low;
                        break;
                    case ChoiceDLMHV.Medium:
                        __result.m_WildlifeSpawnFrequency = CustomExperienceModeManager.CustomTunableLMHV.Medium;
                        break;
                    case ChoiceDLMHV.High:
                        __result.m_WildlifeSpawnFrequency = CustomExperienceModeManager.CustomTunableLMHV.High;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __result.m_WildlifeSpawnFrequency = CustomExperienceModeManager.CustomTunableLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wildlife Respawn Frequency NEW " + __result.m_WildlifeSpawnFrequency.ToString());

                // WILDLIFE BEHAVIOUR
                // Scent Increase
                switch (Settings.settings.scentIncrease)
                {
                    case ChoiceDNLMH.None:
                        __result.m_ScentIncreaseFromMeatBlood = CustomExperienceModeManager.CustomTunableNLMH.None;
                        break;
                    case ChoiceDNLMH.Low:
                        __result.m_ScentIncreaseFromMeatBlood = CustomExperienceModeManager.CustomTunableNLMH.Low;
                        break;
                    case ChoiceDNLMH.Medium:
                        __result.m_ScentIncreaseFromMeatBlood = CustomExperienceModeManager.CustomTunableNLMH.Medium;
                        break;
                    case ChoiceDNLMH.High:
                        __result.m_ScentIncreaseFromMeatBlood = CustomExperienceModeManager.CustomTunableNLMH.High;
                        break;
                    default:
                        break;
                }

                // Passive Wildlife
                switch (Settings.settings.passiveWildlife)
                {
                    case ChoiceDNY.No:
                        __result.m_WildlifeNotAttackUnprovoked = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_WildlifeNotAttackUnprovoked = true;
                        break;
                    default:
                        break;
                }

                // Wildlife attck during Rest
                switch (Settings.settings.wildlifeAttackResting)
                {
                    case ChoiceDNY.No:
                        __result.m_WildlifeInterruptRest = false;
                        break;
                    case ChoiceDNY.Yes:
                        __result.m_WildlifeInterruptRest = true;
                        break;
                    default:
                        break;
                }

                // Wolf Fear
                //MelonLogger.Msg("Wolf Fear ORIGINAL " + __result.m_WolfFleeChance.ToString());
                switch (Settings.settings.wolfFear)
                {
                    case ChoiceDNLMH.None:
                        __result.m_WolfFleeChance = CustomExperienceModeManager.CustomTunableNLMH.None;
                        break;
                    case ChoiceDNLMH.Low:
                        __result.m_WolfFleeChance = CustomExperienceModeManager.CustomTunableNLMH.Low;
                        break;
                    case ChoiceDNLMH.Medium:
                        __result.m_WolfFleeChance = CustomExperienceModeManager.CustomTunableNLMH.Medium;
                        break;
                    case ChoiceDNLMH.High:
                        __result.m_WolfFleeChance = CustomExperienceModeManager.CustomTunableNLMH.High;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wolf Fear NEW " + __result.m_WolfFleeChance.ToString());

                // Timberwolf Morale
                //MelonLogger.Msg("Timberwolf Morale ORIGINAL " + __result.m_TimberWolfPackFear.ToString());
                switch (Settings.settings.timberwolfMorale)
                {
                    case ChoiceDLMH.Low:
                        __result.m_TimberWolfPackFear = CustomExperienceModeManager.CustomTunableLMH.Low;
                        break;
                    case ChoiceDLMH.Medium:
                        __result.m_TimberWolfPackFear = CustomExperienceModeManager.CustomTunableLMH.Medium;
                        break;
                    case ChoiceDLMH.High:
                        __result.m_TimberWolfPackFear = CustomExperienceModeManager.CustomTunableLMH.High;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Timberwolf Morale NEW " + __result.m_TimberWolfPackFear.ToString());

                // Wildlife Detection Range
                //MelonLogger.Msg("Wildlife Detection Range ORIGINAL " + __result.m_WildlifeDetectionRange.ToString());
                switch (Settings.settings.wildlifeDetectionRange)
                {
                    case Distance.Close:
                        __result.m_WildlifeDetectionRange = CustomExperienceModeManager.CustomTunableDistance.Close;
                        break;
                    case Distance.Medium:
                        __result.m_WildlifeDetectionRange = CustomExperienceModeManager.CustomTunableDistance.Medium;
                        break;
                    case Distance.Far:
                        __result.m_WildlifeDetectionRange = CustomExperienceModeManager.CustomTunableDistance.Far;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wildlife Detection Range NEW " + __result.m_WildlifeDetectionRange.ToString());

                // WILDLIFE STRUGGLE
                // Struggle Damage Severity
                //MelonLogger.Msg("Wildlife Struggle Damage Severity ORIGINAL " + __result.m_StruggleDamageEventSeverity.ToString());
                switch (Settings.settings.struggleSeverity)
                {
                    case ChoiceDLMHV.Low:
                        __result.m_StruggleDamageEventSeverity = CustomExperienceModeManager.CustomTunableLMHV.Low;
                        break;
                    case ChoiceDLMHV.Medium:
                        __result.m_StruggleDamageEventSeverity = CustomExperienceModeManager.CustomTunableLMHV.Medium;
                        break;
                    case ChoiceDLMHV.High:
                        __result.m_StruggleDamageEventSeverity = CustomExperienceModeManager.CustomTunableLMHV.High;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __result.m_StruggleDamageEventSeverity = CustomExperienceModeManager.CustomTunableLMHV.VeryHigh;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wildlife Struggle Damage Severity NEW " + __result.m_StruggleDamageEventSeverity.ToString());
            }
        }

        [HarmonyPatch(typeof(CustomExperienceMode), "UpdateBaseValues")]
        private static class TweakSettings
        {
            private static void Postfix(CustomExperienceMode __instance)
            {
                if (GameManager.m_ActiveScene == "MainMenu") return;
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled) return;

                System.Collections.Generic.List<ExperienceMode> baseXPModesSortedByDifficultyAsc = GetBaseXPModesSortedByDifficultyAsc();
                // ENVIRONMENT
                // Length of day multiplier
                //MelonLogger.Msg("Length of day multiplier ORIGINAL " + __instance.m_DayNightDurationScale.ToString());
                if (Settings.settings.lengthOfDay == ChoiceDC.Custom)
                {
                    __instance.m_DayNightDurationScale = Settings.settings.lengthOfDaySlider;
                }
                //MelonLogger.Msg("Length of day multiplier NEW " + __instance.m_DayNightDurationScale.ToString());

                // Weather variability
                //MelonLogger.Msg("Weather variability ORIGINAL " + __instance.m_WeatherDurationScale.ToString());
                switch (Settings.settings.weatherVariability) // 0.25, 0.5, 1, 1.5
                {
                    case ChoiceDLMHV.Low:
                        __instance.m_WeatherDurationScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Low)].m_WeatherDurationScale;
                        break;
                    case ChoiceDLMHV.Medium:
                        __instance.m_WeatherDurationScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Medium)].m_WeatherDurationScale;
                        break;
                    case ChoiceDLMHV.High:
                        __instance.m_WeatherDurationScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.High)].m_WeatherDurationScale;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __instance.m_WeatherDurationScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.VeryHigh)].m_WeatherDurationScale;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Weather variability NEW " + __instance.m_WeatherDurationScale.ToString());

                // Blizzard Frequency
                //MelonLogger.Msg("Blizzard Frequency ORIGINAL " + __instance.m_ChanceOfBlizzardScale.ToString());
                switch (Settings.settings.blizzardFrequency) // 0, 0.75, 1, 1.25, 2
                {
                    case ChoiceDNLMHVC.None:
                        __instance.m_ChanceOfBlizzardScale = 0f;
                        break;
                    case ChoiceDNLMHVC.Low:
                        __instance.m_ChanceOfBlizzardScale = baseXPModesSortedByDifficultyAsc[CustomExperienceModeManager.CustomTunableNLMHV.Low - CustomExperienceModeManager.CustomTunableNLMHV.Low].m_ChanceOfBlizzardScale;
                        break;
                    case ChoiceDNLMHVC.Medium:
                        __instance.m_ChanceOfBlizzardScale = baseXPModesSortedByDifficultyAsc[CustomExperienceModeManager.CustomTunableNLMHV.Medium - CustomExperienceModeManager.CustomTunableNLMHV.Low].m_ChanceOfBlizzardScale;
                        break;
                    case ChoiceDNLMHVC.High:
                        __instance.m_ChanceOfBlizzardScale = baseXPModesSortedByDifficultyAsc[CustomExperienceModeManager.CustomTunableNLMHV.High - CustomExperienceModeManager.CustomTunableNLMHV.Low].m_ChanceOfBlizzardScale;
                        break;
                    case ChoiceDNLMHVC.VeryHigh:
                        __instance.m_ChanceOfBlizzardScale = baseXPModesSortedByDifficultyAsc[CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableNLMHV.Low].m_ChanceOfBlizzardScale;
                        break;
                    case ChoiceDNLMHVC.Custom:
                        __instance.m_ChanceOfBlizzardScale = Settings.settings.blizzardSlider;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Blizzard Frequency NEW " + __instance.m_ChanceOfBlizzardScale.ToString());

                // World Gets Colder Over Time
                //MelonLogger.Msg("World Gets Colder Over Time OutdoorTempDropCelsiusMax ORIGINAL " + __instance.m_OutdoorTempDropCelsiusMax.ToString());
                //MelonLogger.Msg("World Gets Colder Over Time OutdoorTempDropDayStart ORIGINAL " + __instance.m_OutdoorTempDropDayStart.ToString());
                //MelonLogger.Msg("World Gets Colder Over Time OutdoorTempDropDayFinal ORIGINAL " + __instance.m_OutdoorTempDropDayFinal.ToString());
                switch (Settings.settings.worldGetsColder)
                {
                    case ChoiceDNLMH.None:
                        __instance.m_OutdoorTempDropCelsiusMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.None].m_OutdoorTempDropCelsiusMax;
                        __instance.m_OutdoorTempDropDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.None].m_OutdoorTempDropDayStart;
                        __instance.m_OutdoorTempDropDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.None].m_OutdoorTempDropDayFinal;
                        break;
                    case ChoiceDNLMH.Low:
                        __instance.m_OutdoorTempDropCelsiusMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Low].m_OutdoorTempDropCelsiusMax;
                        __instance.m_OutdoorTempDropDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Low].m_OutdoorTempDropDayStart;
                        __instance.m_OutdoorTempDropDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Low].m_OutdoorTempDropDayFinal;
                        break;
                    case ChoiceDNLMH.Medium:
                        __instance.m_OutdoorTempDropCelsiusMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Medium].m_OutdoorTempDropCelsiusMax;
                        __instance.m_OutdoorTempDropDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Medium].m_OutdoorTempDropDayStart;
                        __instance.m_OutdoorTempDropDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Medium].m_OutdoorTempDropDayFinal;
                        break;
                    case ChoiceDNLMH.High:
                        __instance.m_OutdoorTempDropCelsiusMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.High].m_OutdoorTempDropCelsiusMax;
                        __instance.m_OutdoorTempDropDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.High].m_OutdoorTempDropDayStart;
                        __instance.m_OutdoorTempDropDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.High].m_OutdoorTempDropDayFinal;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("World Gets Colder Over Time OutdoorTempDropCelsiusMax NEW " + __instance.m_OutdoorTempDropCelsiusMax.ToString());
                //MelonLogger.Msg("World Gets Colder Over Time OutdoorTempDropDayStart NEW " + __instance.m_OutdoorTempDropDayStart.ToString());
                //MelonLogger.Msg("World Gets Colder Over Time OutdoorTempDropDayFinal NEW " + __instance.m_OutdoorTempDropDayFinal.ToString());

                // HEALTH
                // Calorie Burn Rate
                switch (Settings.settings.calorieBurnRate)
                {
                    case ChoiceDLMHVC.Low:
                        __instance.m_CalorieBurnScale = 0.5f;
                        break;
                    case ChoiceDLMHVC.Medium:
                        __instance.m_CalorieBurnScale = 0.8f;
                        break;
                    case ChoiceDLMHVC.High:
                        __instance.m_CalorieBurnScale = 0.9f;
                        break;
                    case ChoiceDLMHVC.VeryHigh:
                        __instance.m_CalorieBurnScale = 1.0f;
                        break;
                    case ChoiceDLMHVC.Custom:
                        __instance.m_CalorieBurnScale = Settings.settings.calorieBurnRateSlider;
                        break;
                    default:
                        break;
                }

                // Thirst
                if (Settings.settings.dehydrationRate != Dehydration.Default)
                {
                    __instance.m_ThirstRateScale = 1f;
                }

                // Fatigue Rate
                switch (Settings.settings.fatigueRate)
                {
                    case ChoiceDLMHVC.Low:
                        __instance.m_FatigueRateScale = 0.5f;
                        break;
                    case ChoiceDLMHVC.Medium:
                        __instance.m_FatigueRateScale = 0.8f;
                        break;
                    case ChoiceDLMHVC.High:
                        __instance.m_FatigueRateScale = 1.0f;
                        break;
                    case ChoiceDLMHVC.VeryHigh:
                        __instance.m_FatigueRateScale = 1.2f;
                        break;
                    case ChoiceDLMHVC.Custom:
                        __instance.m_FatigueRateScale = Settings.settings.fatigueRateSlider;
                        break;
                    default:
                        break;
                }

                // Freezing Rate
                switch (Settings.settings.freezingRate)
                {
                    case ChoiceDLMHVC.Low:
                        __instance.m_FreezingRateScale = 0.25f;
                        break;
                    case ChoiceDLMHVC.Medium:
                        __instance.m_FreezingRateScale = 1.0f;
                        break;
                    case ChoiceDLMHVC.High:
                        __instance.m_FreezingRateScale = 1.2f;
                        break;
                    case ChoiceDLMHVC.VeryHigh:
                        __instance.m_FreezingRateScale = 1.75f;
                        break;
                    case ChoiceDLMHVC.Custom:
                        __instance.m_FreezingRateScale = Settings.settings.freezingRateSlider;
                        break;
                    default:
                        break;
                }

                // At-Rest Condition Recovery Rate
                if (Settings.settings.restBonus == ChoiceDNY.No)
                {
                    switch (Settings.settings.asleepConditionRecovery)
                    {
                        case ConditionRecovery.OnePer24:
                            __instance.m_ConditonRecoveryFromRestScale = 0.02082325f;
                            break;
                        case ConditionRecovery.OnePer12:
                            __instance.m_ConditonRecoveryFromRestScale = 0.0416466f;
                            break;
                        case ConditionRecovery.OnePer8:
                            __instance.m_ConditonRecoveryFromRestScale = 0.06246976f;
                            break;
                        case ConditionRecovery.OnePer6:
                            __instance.m_ConditonRecoveryFromRestScale = 0.083293f;
                            break;
                        case ConditionRecovery.OnePer4:
                            __instance.m_ConditonRecoveryFromRestScale = 0.1249397f;
                            break;
                        case ConditionRecovery.OnePer2:
                            __instance.m_ConditonRecoveryFromRestScale = 0.249878f;
                            break;
                        case ConditionRecovery.OnePer1:
                            __instance.m_ConditonRecoveryFromRestScale = 0.49976f;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (Settings.settings.asleepConditionRecovery)
                    {
                        case ConditionRecovery.OnePer24:
                            __instance.m_ConditonRecoveryFromRestScale = 0.00554f;
                            break;
                        case ConditionRecovery.OnePer12:
                            __instance.m_ConditonRecoveryFromRestScale = 0.01107964f;
                            break;
                        case ConditionRecovery.OnePer8:
                            __instance.m_ConditonRecoveryFromRestScale = 0.0226690545f;
                            break;
                        case ConditionRecovery.OnePer6:
                            __instance.m_ConditonRecoveryFromRestScale = 0.0369422536f;
                            break;
                        case ConditionRecovery.OnePer4:
                            __instance.m_ConditonRecoveryFromRestScale = 0.071288f;
                            break;
                        case ConditionRecovery.OnePer2:
                            __instance.m_ConditonRecoveryFromRestScale = 0.20f;
                            break;
                        case ConditionRecovery.OnePer1:
                            __instance.m_ConditonRecoveryFromRestScale = 0.4995f;
                            break;
                        default:
                            break;
                    }
                }
                switch (Settings.settings.asleepConditionRecovery)
                {
                    case ConditionRecovery.None:
                        __instance.m_ConditonRecoveryFromRestScale = 0f;
                        break;
                    case ConditionRecovery.Low:
                        __instance.m_ConditonRecoveryFromRestScale = 0.25f;
                        break;
                    case ConditionRecovery.Medium:
                        __instance.m_ConditonRecoveryFromRestScale = 0.5f;
                        break;
                    case ConditionRecovery.High:
                        __instance.m_ConditonRecoveryFromRestScale = 1.0f;
                        break;
                    case ConditionRecovery.VeryHigh:
                        __instance.m_ConditonRecoveryFromRestScale = 2.0f;
                        break;
                    case ConditionRecovery.Custom:
                        __instance.m_ConditonRecoveryFromRestScale = Settings.settings.asleepConditionRecoverySlider;
                        break;
                    default:
                        break;
                }

                // Condition Recovery Rate
                switch (Settings.settings.awakeConditionRecovery)
                {
                    case ConditionRecovery.None:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0f;
                        break;
                    case ConditionRecovery.OnePer24:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.04f;
                        break;
                    case ConditionRecovery.OnePer12:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.08f;
                        break;
                    case ConditionRecovery.OnePer8:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.12f;
                        break;
                    case ConditionRecovery.OnePer6:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.16f;
                        break;
                    case ConditionRecovery.OnePer4:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.24f;
                        break;
                    case ConditionRecovery.OnePer2:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.48f;
                        break;
                    case ConditionRecovery.OnePer1:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.96f;
                        break;
                    case ConditionRecovery.Low:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.25f;
                        break;
                    case ConditionRecovery.Medium:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 0.5f;
                        break;
                    case ConditionRecovery.High:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 1.0f;
                        break;
                    case ConditionRecovery.VeryHigh:
                        __instance.m_ConditonRecoveryWhileAwakeScale = 2.0f;
                        break;
                    case ConditionRecovery.Custom:
                        __instance.m_ConditonRecoveryWhileAwakeScale = Settings.settings.awakeConditionRecoverySlider;
                        break;
                    default:
                        break;
                }

                // Hypothermia Recovery Rate
                switch (Settings.settings.hypothermiaRecovery)
                {
                    case ChoiceDLMHVC.Low:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 0.5f;
                        break;
                    case ChoiceDLMHVC.Medium:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 1.0f;
                        break;
                    case ChoiceDLMHVC.High:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 1.5f;
                        break;
                    case ChoiceDLMHVC.VeryHigh:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 2.0f;
                        break;
                    case ChoiceDLMHVC.Custom:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = Settings.settings.hypothermiaRecoverySlider;
                        break;
                    default:
                        break;
                }

                // GEAR
                // Item Decay
                switch (Settings.settings.decayRate)
                {
                    case ChoiceDLMHV.Low:
                        __instance.m_DecayScale = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableLMHV.Low].m_DecayScale;
                        break;
                    case ChoiceDLMHV.Medium:
                        __instance.m_DecayScale = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableLMHV.Medium].m_DecayScale;
                        break;
                    case ChoiceDLMHV.High:
                        __instance.m_DecayScale = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableLMHV.High].m_DecayScale;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __instance.m_DecayScale = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableLMHV.VeryHigh].m_DecayScale;
                        break;
                    default:
                        break;
                }

                // Item Spawn Chance
                //MelonLogger.Msg("Item Spawn Chance ORIGINAL " + __instance.m_GearSpawnChanceScale.ToString());
                switch (Settings.settings.looseItemAvailability)
                {
                    case ChoiceDLMHV.Low:
                        __instance.m_GearSpawnChanceScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Low)].m_GearSpawnChanceScale;
                        break;
                    case ChoiceDLMHV.Medium:
                        __instance.m_GearSpawnChanceScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Medium)].m_GearSpawnChanceScale;
                        break;
                    case ChoiceDLMHV.High:
                        __instance.m_GearSpawnChanceScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.High)].m_GearSpawnChanceScale;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __instance.m_GearSpawnChanceScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.VeryHigh)].m_GearSpawnChanceScale;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Item Spawn Chance NEW " + __instance.m_GearSpawnChanceScale.ToString());

                // Empty Container Chance
                //MelonLogger.Msg("Empty Container Chance ORIGINAL " + __instance.m_ChanceForEmptyContainer.ToString());
                switch (Settings.settings.emptyContainerChance)
                {
                    case ChoiceDNLMH.None:
                        __instance.m_ChanceForEmptyContainer = 0;
                        break;
                    case ChoiceDNLMH.Low:
                        __instance.m_ChanceForEmptyContainer = 25;
                        break;
                    case ChoiceDNLMH.Medium:
                        __instance.m_ChanceForEmptyContainer = 75;
                        break;
                    case ChoiceDNLMH.High:
                        __instance.m_ChanceForEmptyContainer = 90;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Empty Container Chance NEW " + __instance.m_ChanceForEmptyContainer.ToString());

                // Stick Branch Stone Respawn
                //MelonLogger.Msg("Stick Branch Stone Respawn RadialRespawnTimeScaleMax ORIGINAL " + __instance.m_RadialRespawnTimeScaleMax.ToString());
                //MelonLogger.Msg("Stick Branch Stone Respawn RadialRespawnTimeScaleDayStart ORIGINAL " + __instance.m_RadialRespawnTimeScaleDayStart.ToString());
                //MelonLogger.Msg("Stick Branch Stone Respawn RadialRespawnTimeScaleDayFinal ORIGINAL " + __instance.m_RadialRespawnTimeScaleDayFinal.ToString());
                switch (Settings.settings.stickBranchStoneRespawn)
                {
                    case ChoiceDLMHV.Low:
                        __instance.m_RadialRespawnTimeScaleMax = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Low)].m_RadialRespawnTimeScaleMax;
                        __instance.m_RadialRespawnTimeScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Low)].m_RadialRespawnTimeScaleDayStart;
                        __instance.m_RadialRespawnTimeScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Low)].m_RadialRespawnTimeScaleDayFinal;
                        break;
                    case ChoiceDLMHV.Medium:
                        __instance.m_RadialRespawnTimeScaleMax = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Medium)].m_RadialRespawnTimeScaleMax;
                        __instance.m_RadialRespawnTimeScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Medium)].m_RadialRespawnTimeScaleDayStart;
                        __instance.m_RadialRespawnTimeScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.Medium)].m_RadialRespawnTimeScaleDayFinal;
                        break;
                    case ChoiceDLMHV.High:
                        __instance.m_RadialRespawnTimeScaleMax = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.High)].m_RadialRespawnTimeScaleMax;
                        __instance.m_RadialRespawnTimeScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.High)].m_RadialRespawnTimeScaleDayStart;
                        __instance.m_RadialRespawnTimeScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.High)].m_RadialRespawnTimeScaleDayFinal;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __instance.m_RadialRespawnTimeScaleMax = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.VeryHigh)].m_RadialRespawnTimeScaleMax;
                        __instance.m_RadialRespawnTimeScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.VeryHigh)].m_RadialRespawnTimeScaleDayStart;
                        __instance.m_RadialRespawnTimeScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableLMHV.VeryHigh - CustomExperienceModeManager.CustomTunableLMHV.VeryHigh)].m_RadialRespawnTimeScaleDayFinal;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Stick Branch Stone Respawn RadialRespawnTimeScaleMax NEW " + __instance.m_RadialRespawnTimeScaleMax.ToString());
                //MelonLogger.Msg("Stick Branch Stone Respawn RadialRespawnTimeScaleDayStart NEW " + __instance.m_RadialRespawnTimeScaleDayStart.ToString());
                //MelonLogger.Msg("Stick Branch Stone Respawn RadialRespawnTimeScaleDayFinal NEW " + __instance.m_RadialRespawnTimeScaleDayFinal.ToString());

                // Container Density
                //MelonLogger.Msg("Container Density ORIGINAL " + __instance.m_ReduceMaxItemsInContainer.ToString());
                switch (Settings.settings.containerDensity)
                {
                    case ChoiceDNLH.None:
                        __instance.m_ReduceMaxItemsInContainer = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableNLH.None + 1)].m_ReduceMaxItemsInContainer;
                        break;
                    case ChoiceDNLH.Low:
                        __instance.m_ReduceMaxItemsInContainer = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableNLH.Low + 1)].m_ReduceMaxItemsInContainer;
                        break;
                    case ChoiceDNLH.High:
                        __instance.m_ReduceMaxItemsInContainer = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableNLH.High + 1)].m_ReduceMaxItemsInContainer;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Container Density NEW " + __instance.m_ReduceMaxItemsInContainer.ToString());

                // WILDLIFE SPAWNS
                // Fish Spawn
                //MelonLogger.Msg("Fish Spawn FishCatchTimeScaleMax ORIGINAL " + __instance.m_FishCatchTimeScaleMax.ToString());
                //MelonLogger.Msg("Fish Spawn FishCatchTimeScaleDayStart ORIGINAL " + __instance.m_FishCatchTimeScaleDayStart.ToString());
                //MelonLogger.Msg("Fish Spawn FishCatchTimeScaleDayFinal ORIGINAL " + __instance.m_FishCatchTimeScaleDayFinal.ToString());
                switch (Settings.settings.fishSpawn)
                {
                    case ChoiceDNLMHV.None:
                        __instance.m_FishCatchTimeScaleMax = 100000;
                        __instance.m_FishCatchTimeScaleDayStart = 0;
                        __instance.m_FishCatchTimeScaleDayFinal = 0;
                        break;
                    case ChoiceDNLMHV.Low:
                        __instance.m_FishCatchTimeScaleMax = 3;
                        __instance.m_FishCatchTimeScaleDayStart = 5;
                        __instance.m_FishCatchTimeScaleDayFinal = 10;
                        break;
                    case ChoiceDNLMHV.Medium:
                        __instance.m_FishCatchTimeScaleMax = 2;
                        __instance.m_FishCatchTimeScaleDayStart = 10;
                        __instance.m_FishCatchTimeScaleDayFinal = 50;
                        break;
                    case ChoiceDNLMHV.High:
                        __instance.m_FishCatchTimeScaleMax = 1;
                        __instance.m_FishCatchTimeScaleDayStart = 1;
                        __instance.m_FishCatchTimeScaleDayFinal = 2;
                        break;
                    case ChoiceDNLMHV.VeryHigh:
                        __instance.m_FishCatchTimeScaleMax = 0.5f;
                        __instance.m_FishCatchTimeScaleDayStart = 0;
                        __instance.m_FishCatchTimeScaleDayFinal = 0;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Fish Spawn FishCatchTimeScaleMax NEW " + __instance.m_FishCatchTimeScaleMax.ToString());
                //MelonLogger.Msg("Fish Spawn FishCatchTimeScaleDayStart NEW " + __instance.m_FishCatchTimeScaleDayStart.ToString());
                //MelonLogger.Msg("Fish Spawn FishCatchTimeScaleDayFinal NEW " + __instance.m_FishCatchTimeScaleDayFinal.ToString());

                // Reduce Wildlife Population
                //MelonLogger.Msg("Reduce Wildlife Population RespawnHoursScaleMax ORIGINAL " + __instance.m_RespawnHoursScaleMax.ToString());
                //MelonLogger.Msg("Reduce Wildlife Population RespawnHoursScaleDayStart ORIGINAL " + __instance.m_RespawnHoursScaleDayStart.ToString());
                //MelonLogger.Msg("Reduce Wildlife Population RespawnHoursScaleDayFinal ORIGINAL " + __instance.m_RespawnHoursScaleDayFinal.ToString());
                switch (Settings.settings.reduceWildlife)
                {
                    case ChoiceDNLMH.None:
                        __instance.m_RespawnHoursScaleMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.None].m_RespawnHoursScaleMax;
                        __instance.m_RespawnHoursScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.None].m_RespawnHoursScaleDayStart;
                        __instance.m_RespawnHoursScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.None].m_RespawnHoursScaleDayFinal;
                        break;
                    case ChoiceDNLMH.Low:
                        __instance.m_RespawnHoursScaleMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Low].m_RespawnHoursScaleMax;
                        __instance.m_RespawnHoursScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Low].m_RespawnHoursScaleDayStart;
                        __instance.m_RespawnHoursScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Low].m_RespawnHoursScaleDayFinal;
                        break;
                    case ChoiceDNLMH.Medium:
                        __instance.m_RespawnHoursScaleMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Medium].m_RespawnHoursScaleMax;
                        __instance.m_RespawnHoursScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Medium].m_RespawnHoursScaleDayStart;
                        __instance.m_RespawnHoursScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.Medium].m_RespawnHoursScaleDayFinal;
                        break;
                    case ChoiceDNLMH.High:
                        __instance.m_RespawnHoursScaleMax = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.High].m_RespawnHoursScaleMax;
                        __instance.m_RespawnHoursScaleDayStart = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.High].m_RespawnHoursScaleDayStart;
                        __instance.m_RespawnHoursScaleDayFinal = baseXPModesSortedByDifficultyAsc[(int)CustomExperienceModeManager.CustomTunableNLMH.High].m_RespawnHoursScaleDayFinal;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Reduce Wildlife Population RespawnHoursScaleMax NEW " + __instance.m_RespawnHoursScaleMax.ToString());
                //MelonLogger.Msg("Reduce Wildlife Population RespawnHoursScaleDayStart NEW " + __instance.m_RespawnHoursScaleDayStart.ToString());
                //MelonLogger.Msg("Reduce Wildlife Population RespawnHoursScaleDayFinal NEW " + __instance.m_RespawnHoursScaleDayFinal.ToString());

                // Wolf Spawn Distance
                //MelonLogger.Msg("Wolf Spawn Distance ORIGINAL " + __instance.m_ClosestSpawnDistanceAfterTransitionScale.ToString());
                switch (Settings.settings.wolfSpawnDistance)
                {
                    case Distance.Close:
                        __instance.m_ClosestSpawnDistanceAfterTransitionScale = baseXPModesSortedByDifficultyAsc[(int)((CustomExperienceModeManager.CustomTunableDistance)3 - CustomExperienceModeManager.CustomTunableDistance.Close)].m_ClosestSpawnDistanceAfterTransitionScale;
                        break;
                    case Distance.Medium:
                        __instance.m_ClosestSpawnDistanceAfterTransitionScale = baseXPModesSortedByDifficultyAsc[(int)((CustomExperienceModeManager.CustomTunableDistance)3 - CustomExperienceModeManager.CustomTunableDistance.Medium)].m_ClosestSpawnDistanceAfterTransitionScale;
                        break;
                    case Distance.Far:
                        __instance.m_ClosestSpawnDistanceAfterTransitionScale = baseXPModesSortedByDifficultyAsc[(int)((CustomExperienceModeManager.CustomTunableDistance)3 - CustomExperienceModeManager.CustomTunableDistance.Far)].m_ClosestSpawnDistanceAfterTransitionScale;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wolf Spawn Distance NEW " + __instance.m_ClosestSpawnDistanceAfterTransitionScale.ToString());

                // Wildlife Smell Range
                //MelonLogger.Msg("Wildlife Smell Range ORIGINAL " + __instance.m_SmellRangeScale.ToString());
                switch (Settings.settings.wildlifeSmellRange)
                {
                    case ChoiceDLMHV.Low:
                        __instance.m_SmellRangeScale = 0;
                        break;
                    case ChoiceDLMHV.Medium:
                        __instance.m_SmellRangeScale = 0.5f;
                        break;
                    case ChoiceDLMHV.High:
                        __instance.m_SmellRangeScale = 1;
                        break;
                    case ChoiceDLMHV.VeryHigh:
                        __instance.m_SmellRangeScale = 1.5f;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Wildlife Smell Range NEW " + __instance.m_SmellRangeScale.ToString());

                // WILDLIFE STRUGGLE
                // Struggle Bonus
                //MelonLogger.Msg("Struggle Bonus ORIGINAL " + __instance.m_StruggleTapStrengthScale.ToString());
                switch (Settings.settings.struggleBonus)
                {
                    case ChoiceDNLMH.None:
                        __instance.m_StruggleTapStrengthScale = baseXPModesSortedByDifficultyAsc[2].m_StruggleTapStrengthScale;
                        break;
                    case ChoiceDNLMH.Low:
                        __instance.m_StruggleTapStrengthScale = baseXPModesSortedByDifficultyAsc[3].m_StruggleTapStrengthScale;
                        break;
                    case ChoiceDNLMH.Medium:
                        __instance.m_StruggleTapStrengthScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableNLMH.High - CustomExperienceModeManager.CustomTunableNLMH.Medium)].m_StruggleTapStrengthScale;
                        break;
                    case ChoiceDNLMH.High:
                        __instance.m_StruggleTapStrengthScale = baseXPModesSortedByDifficultyAsc[(int)(CustomExperienceModeManager.CustomTunableNLMH.High - CustomExperienceModeManager.CustomTunableNLMH.High)].m_StruggleTapStrengthScale;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Struggle Bonus ORIGINAL " + __instance.m_StruggleTapStrengthScale.ToString());

                // Struggle Condition Damage Modifier
                //MelonLogger.Msg("Struggle Condition Damage Modifier ORIGINAL " + __instance.m_StrugglePlayerDamageReceivedScale.ToString());
                switch (Settings.settings.struggleDamage)
                {
                    case ChoiceDNLMH.None:
                        __instance.m_StrugglePlayerDamageReceivedScale = 1;
                        break;
                    case ChoiceDNLMH.Low:
                        __instance.m_StrugglePlayerDamageReceivedScale = 1.1f;
                        break;
                    case ChoiceDNLMH.Medium:
                        __instance.m_StrugglePlayerDamageReceivedScale = 1.25f;
                        break;
                    case ChoiceDNLMH.High:
                        __instance.m_StrugglePlayerDamageReceivedScale = 1.5f;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Struggle Condition Damage Modifier NEW " + __instance.m_StrugglePlayerDamageReceivedScale.ToString());

                // Struggle Clothing Damage Modifier
                //MelonLogger.Msg("Struggle Clothing Damage Modifier ORIGINAL " + __instance.m_StrugglePlayerClothingDamageScale.ToString());
                switch (Settings.settings.struggleDamage)
                {
                    case ChoiceDNLMH.None:
                        __instance.m_StrugglePlayerClothingDamageScale = 1;
                        break;
                    case ChoiceDNLMH.Low:
                        __instance.m_StrugglePlayerClothingDamageScale = 1.1f;
                        break;
                    case ChoiceDNLMH.Medium:
                        __instance.m_StrugglePlayerClothingDamageScale = 1.25f;
                        break;
                    case ChoiceDNLMH.High:
                        __instance.m_StrugglePlayerClothingDamageScale = 1.5f;
                        break;
                    default:
                        break;
                }
                //MelonLogger.Msg("Struggle Clothing Damage Modifier NEW " + __instance.m_StrugglePlayerClothingDamageScale.ToString());
            }
        }

        [HarmonyPatch(typeof(CustomExperienceMode), "GetWolfSpawnChance")]
        private static class UpdateWolfSpawnChance
        {
            private static void Postfix(CustomExperienceModeManager.CustomTunableNLMHV __result, WolfType wolfType)
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled) return;
                if (Settings.settings.timberwolfSpawn == ChoiceDNLMHV.Default && Settings.settings.wolfSpawn == ChoiceDNLMHV.Default) return;

                //MelonLogger.Msg("Wolf Spawn Chance ORIGINAL" + __result.ToString());
                if (Settings.settings.timberwolfSpawn != ChoiceDNLMHV.Default && wolfType != WolfType.Normal)
                {
                    switch (Settings.settings.timberwolfSpawn)
                    {
                        case ChoiceDNLMHV.None:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.None;
                            break;
                        case ChoiceDNLMHV.Low:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                            break;
                        case ChoiceDNLMHV.Medium:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                            break;
                        case ChoiceDNLMHV.High:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.High;
                            break;
                        case ChoiceDNLMHV.VeryHigh:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                            break;
                        default:
                            break;
                    }
                }
                else if (Settings.settings.wolfSpawn != ChoiceDNLMHV.Default)
                {
                    switch (Settings.settings.wolfSpawn)
                    {
                        case ChoiceDNLMHV.None:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.None;
                            break;
                        case ChoiceDNLMHV.Low:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.Low;
                            break;
                        case ChoiceDNLMHV.Medium:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.Medium;
                            break;
                        case ChoiceDNLMHV.High:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.High;
                            break;
                        case ChoiceDNLMHV.VeryHigh:
                            __result = CustomExperienceModeManager.CustomTunableNLMHV.VeryHigh;
                            break;
                        default:
                            break;
                    }
                }
                //MelonLogger.Msg("Wolf Spawn Chance NEW" + __result.ToString());
            }
        }

        [HarmonyPatch(typeof(Condition), "Update")]
        private static class UpdateConditionValues
        {
            private static bool Prefix()
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled) return true;


                if (Settings.settings.calorieBurnRate != ChoiceDLMHVC.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromStarving = Settings.settings.starvingDamage; // 25
                }
                if (Settings.settings.dehydrationRate != Dehydration.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromDehydration = Settings.settings.dehydrationDamage; // 50
                }
                if (Settings.settings.fatigueRate != ChoiceDLMHVC.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromExhaustion = Settings.settings.exhaustionDamage; // 25
                }
                if (Settings.settings.freezingRate != ChoiceDLMHVC.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromFreezing = Settings.settings.freezingDamage; // 450
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Hunger), "UpdateFatiguePenalty")]
        private static class UpdateFatiguePenalty
        {
            private static bool Prefix()
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled || Settings.settings.calorieBurnRate == ChoiceDLMHVC.Default) return true;

                int hoursBeforeStarvation = Mathf.RoundToInt((100f / Settings.settings.starvingDamage) * 24f);
                float phaselength = hoursBeforeStarvation - 36;
                float fatiguePenaltyPerHour = 50f / phaselength;

                if (hoursBeforeStarvation < 168) // < 1 week
                {
                    GameManager.GetHungerComponent().m_MaxFatiguePenalty = 50;
                    fatiguePenaltyPerHour = 50 / phaselength;
                }
                else if (hoursBeforeStarvation >= 168) // > 1 week
                {
                    GameManager.GetHungerComponent().m_MaxFatiguePenalty = 75;
                    fatiguePenaltyPerHour = 75 / phaselength;
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Thirst), "Update")]
        private static class ChangeThirstperDay
        {
            private static bool Prefix()
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled || Settings.settings.dehydrationRate == Dehydration.Default) return true;

                int hours = 24;

                switch (Settings.settings.dehydrationRate)
                {
                    case Dehydration.Default:
                        return true;
                    case Dehydration.SixHrs:
                        hours = 6;
                        break;
                    case Dehydration.EightHrs:
                        hours = 8;
                        break;
                    case Dehydration.TwelveHrs:
                        hours = 12;
                        break;
                    case Dehydration.TwentyFourHrs:
                        hours = 24;
                        break;
                    case Dehydration.Custom:
                        hours = Settings.settings.dehydrationSlider;
                        break;
                    default:
                        break;
                }

                float thirstBarInDays = hours / 24f;
                float increasePerDay = 1 / thirstBarInDays;
                int slightlyThirstyThreshold = Mathf.RoundToInt(1f / (hours / 4f) * 100f);
                int thirstyThreshold = Mathf.RoundToInt(1f / (hours / 6f) * 100f);
                int veryThirstyThreshold = Mathf.RoundToInt(1f / (hours / 8f) * 100f);
                int thirstIncreasePerDay = Mathf.RoundToInt(increasePerDay * 100f);
                int thirstQuenchedPerLiter = Mathf.RoundToInt(increasePerDay / Settings.settings.litresPerDay * 100f);

                GameManager.GetThirstComponent().m_ThirstIncreasePerDay = thirstIncreasePerDay;
                GameManager.GetThirstComponent().m_ThirstIncreasePerDayWhenResting = thirstIncreasePerDay;
                GameManager.GetThirstComponent().m_ThirstQuenchedPerLiter = thirstQuenchedPerLiter;
                GameManager.GetThirstComponent().m_SlightlyThirstyThreshold = Mathf.Clamp(slightlyThirstyThreshold, 17, 50);
                GameManager.GetThirstComponent().m_ThirstyThreshold = Mathf.Clamp(thirstyThreshold, 25, 70);
                GameManager.GetThirstComponent().m_VeryThirstyThreshold = Mathf.Clamp(veryThirstyThreshold, 34, 85);
                return true;
            }
        }

        // PlayerManager FirstAidConsumed -> prefix to update gi
        [HarmonyPatch(typeof(PlayerManager), "FirstAidConsumed")]
        private static class FirstAidConsumed_UpdateReduceThirst
        {
            private static bool Prefix(ref GearItem gi)
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled || Settings.settings.dehydrationRate == Dehydration.Default) return true;
                if (gi.m_FoodItem)
                {
                    if (gi.m_FoodItem.m_ReduceThirst != 0f)
                    {
                        //MelonLogger.Msg(gi.name.ToString() + " FirstAidConsumed_UpdateReduceThirst: ORIGINAL Thirst Value = " + gi.m_FoodItem.m_ReduceThirst.ToString());
                        float multiplier = GameManager.GetThirstComponent().m_ThirstQuenchedPerLiter / 150f;
                        float thirstValue = GetDefaultThirstValue(gi.name);
                        if (thirstValue == 0f)
                        {
                            MelonLogger.Msg("FirstAidConsumed_UpdateReduceThirst: " + gi.name + " has no FoodItem prefab!");
                            return true;
                        }
                        float newThirstValue = thirstValue * multiplier;
                        gi.m_FoodItem.m_ReduceThirst = newThirstValue;
                        // MelonLogger.Msg(gi.name.ToString() + " FirstAidConsumed_UpdateReduceThirst: NEW Thirst Value = " + gi.m_FoodItem.m_ReduceThirst.ToString());
                    }
                }
                return true;
            }
        }

        // PlayerManager UseFoodInventoryItem -> prefix to update gi
        [HarmonyPatch(typeof(PlayerManager), "UseFoodInventoryItem")]
        private static class UseFoodInventoryItem_UpdateReduceThirst
        {
            private static bool Prefix(ref GearItem gi)
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled || Settings.settings.dehydrationRate == Dehydration.Default) return true;
                if (gi.m_FoodItem)
                {
                    if (gi.m_FoodItem.m_ReduceThirst != 0f)
                    {
                        //MelonLogger.Msg(gi.name.ToString() + " UseFoodInventoryItem_UpdateReduceThirst: ORIGINAL Thirst Value = " + gi.m_FoodItem.m_ReduceThirst.ToString());
                        float multiplier = GameManager.GetThirstComponent().m_ThirstQuenchedPerLiter / 150f;
                        float thirstValue = GetDefaultThirstValue(gi.name);
                        if (thirstValue == 0f)
                        {
                            MelonLogger.Msg("UseFoodInventoryItem_UpdateReduceThirst: " + gi.name + " has no FoodItem prefab!");
                            return true;
                        }
                        float newThirstValue = thirstValue * multiplier;
                        gi.m_FoodItem.m_ReduceThirst = newThirstValue;
                        //MelonLogger.Msg(gi.name.ToString() + " UseFoodInventoryItem_UpdateReduceThirst: NEW Thirst Value = " + gi.m_FoodItem.m_ReduceThirst.ToString());
                    }
                }
                return true;
            }
        }

        [HarmonyPatch(typeof(Rest), "UpdateCondition")]
        private static class RemoveUninterruptedRestBonus
        {
            private static bool Prefix(Rest __instance)
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom || Settings.settings.modFunction == ModFunction.Disabled || Settings.settings.restBonus == ChoiceDNY.Default) return true;

                if (Settings.settings.restBonus == ChoiceDNY.No)
                {
                    __instance.m_Bed.m_UinterruptedRestPercentGainPerHour = 0;
                }
                return true;
            }
        }
        private static float GetDefaultThirstValue(string name) 
        {
            FoodItem foodItem = GetGearItemPrefab(name).GetComponent<FoodItem>();
            if (foodItem == null) return 0;
            return foodItem.m_ReduceThirst;
        }
        private static GearItem GetGearItemPrefab(string name) => Addressables.LoadAssetAsync<GameObject>(name).WaitForCompletion().GetComponent<GearItem>();

        //replace the function removed from the assembly
        private static System.Collections.Generic.List<ExperienceMode> GetBaseXPModesSortedByDifficultyAsc()
        {
            System.Collections.Generic.List<ExperienceMode> list = new System.Collections.Generic.List<ExperienceMode>();
            list.Add(ExperienceModeManager.Instance.GetSpecificExperienceMode(ExperienceModeType.Pilgrim));
            list.Add(ExperienceModeManager.Instance.GetSpecificExperienceMode(ExperienceModeType.Voyageur));
            list.Add(ExperienceModeManager.Instance.GetSpecificExperienceMode(ExperienceModeType.Stalker));
            list.Add(ExperienceModeManager.Instance.GetSpecificExperienceMode(ExperienceModeType.Interloper));
            return list;
        }

    }
}

