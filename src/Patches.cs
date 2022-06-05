using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace CustomSettingsTweaker
{
    internal static class Patches
    {
        [HarmonyPatch(typeof(Condition), "Update")]
        private static class UpdateValues
        {
            private static bool Prefix()
            {
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom) return true;
                if (Settings.settings.modFunction == ModFunction.Disabled) return true;

                if (Settings.settings.calorieBurnRate != Choice.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromStarving = Settings.settings.starvingDamage; // 25
                }
                if (Settings.settings.dehydrationRate != Dehydration.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromDehydration = Settings.settings.dehydrationDamage; // 50
                }
                if (Settings.settings.fatigueRate != Choice.Default)
                {
                    GameManager.GetConditionComponent().m_HPDecreasePerDayFromExhaustion = Settings.settings.exhaustionDamage; // 25
                }
                if (Settings.settings.freezingRate != Choice.Default)
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
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom) return true;
                if (Settings.settings.modFunction == ModFunction.Disabled) return true;
                if (Settings.settings.calorieBurnRate == Choice.Default) return true;

                int hoursBeforeStarvation = Mathf.RoundToInt((100f / Settings.settings.starvingDamage) * 24f);
                float phaselength = hoursBeforeStarvation - 36;
                float fatiguePenaltyPerHour = 50f / phaselength;

                MelonLogger.Msg("Fatigue penalty per hour increase " + GameManager.GetHungerComponent().m_FatiguePenaltyPerHourIncrease.ToString());

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
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom) return true;
                if (Settings.settings.modFunction == ModFunction.Disabled) return true;
                if (Settings.settings.dehydrationRate == Dehydration.Default) return true;

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


        [HarmonyPatch(typeof(CustomExperienceMode), "UpdateBaseValues")]
        private static class TweakConditonRecoveryScale
        {
            private static void Postfix(ExperienceMode __instance)
            {
                if (GameManager.m_ActiveScene == "MainMenu") return;
                if (ExperienceModeManager.GetCurrentExperienceModeType() != ExperienceModeType.Custom) return;
                if (Settings.settings.modFunction == ModFunction.Disabled) return;

                // Calorie Burn Rate
                switch (Settings.settings.calorieBurnRate)
                {
                    case Choice.Default:
                        break;
                    case Choice.Low:
                        __instance.m_CalorieBurnScale = 0.5f;
                        break;
                    case Choice.Medium:
                        __instance.m_CalorieBurnScale = 0.8f;
                        break;
                    case Choice.High:
                        __instance.m_CalorieBurnScale = 0.9f;
                        break;
                    case Choice.VeryHigh:
                        __instance.m_CalorieBurnScale = 1.0f;
                        break;
                    case Choice.Custom:
                        __instance.m_CalorieBurnScale = Settings.settings.calorieBurnRateSlider;
                        break;
                    default:
                        break;
                }

                // Thirst Overhaul
                if (Settings.settings.dehydrationRate != Dehydration.Default)
                {
                    __instance.m_ThirstRateScale = 1f;
                }

                // Fatigue Rate
                switch (Settings.settings.fatigueRate)
                {
                    case Choice.Default:
                        break;
                    case Choice.Low:
                        __instance.m_FatigueRateScale = 0.5f;
                        break;
                    case Choice.Medium:
                        __instance.m_FatigueRateScale = 0.8f;
                        break;
                    case Choice.High:
                        __instance.m_FatigueRateScale = 1.0f;
                        break;
                    case Choice.VeryHigh:
                        __instance.m_FatigueRateScale = 1.2f;
                        break;
                    case Choice.Custom:
                        __instance.m_FatigueRateScale = Settings.settings.fatigueRateSlider;
                        break;
                    default:
                        break;
                }

                // Freezing Rate
                switch (Settings.settings.freezingRate)
                {
                    case Choice.Default:
                        break;
                    case Choice.Low:
                        __instance.m_FreezingRateScale = 0.25f;
                        break;
                    case Choice.Medium:
                        __instance.m_FreezingRateScale = 1.0f;
                        break;
                    case Choice.High:
                        __instance.m_FreezingRateScale = 1.2f;
                        break;
                    case Choice.VeryHigh:
                        __instance.m_FreezingRateScale = 1.75f;
                        break;
                    case Choice.Custom:
                        __instance.m_FreezingRateScale = Settings.settings.freezingRateSlider;
                        break;
                    default:
                        break;
                }

                // At-Rest Condition Recovery Rate
                switch (Settings.settings.asleepConditionRecovery)
                {
                    case ConditionRecovery.Default:
                        break;
                    case ConditionRecovery.None:
                        __instance.m_ConditonRecoveryFromRestScale = 0f;
                        break;
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
                    case ConditionRecovery.Default:
                        break;
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
                    case Choice.Default:
                        break;
                    case Choice.Low:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 0.5f;
                        break;
                    case Choice.Medium:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 1.0f;
                        break;
                    case Choice.High:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 1.5f;
                        break;
                    case Choice.VeryHigh:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = 2.0f;
                        break;
                    case Choice.Custom:
                        __instance.m_NumHoursWarmForHypothermiaCureScale = Settings.settings.hypothermiaRecoverySlider;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

