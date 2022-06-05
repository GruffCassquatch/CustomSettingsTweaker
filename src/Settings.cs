using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ModSettings;

namespace CustomSettingsTweaker
{
    public enum ModFunction
    {
        Disabled, Enabled
    }
    public enum Choice
    {
        Default, Low, Medium, High, VeryHigh, Custom
    }
    public enum Dehydration
    {
        Default, SixHrs, EightHrs, TwelveHrs, TwentyFourHrs, Custom
    }
    public enum ConditionRecovery
    {
        Default, None, OnePer24, OnePer12, OnePer8, OnePer6, OnePer4, Low, Medium, High, VeryHigh, Custom
    }

    class CustomSettingsTweakerSettings : JsonModSettings
    {
        [Section("Custom Settings Tweaker")]
        [Name("Enable or Disable this mod")]
        [Description("Enable or Disable this mod")]
        [Choice("Disabled", "Enabled")]
        public ModFunction modFunction = ModFunction.Disabled;


        // Calorie Burn Rate
        [Section("Health")]
        [Name("Calorie Burn Rate")]
        [Description("Choose from the standard game settings or use a custom value\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "Low", "Medium", "High", "Very High", "Custom")]
        public Choice calorieBurnRate = Choice.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Calorie Burn Rate:\nLow = 0.5, Medium = 0.8, High = 0.9, Very High = 1.0")]
        [Slider(0.25f, 2f, 176, NumberFormat = "{0:0.##}")]
        public float calorieBurnRateSlider = 1.0f;

        [Name("         Starving Damage")]
        [Description("Condition loss per day while Starving\nGame Default Value is 25\n25 = 4 days to die, 3 = approx. 33 days")]
        [Slider(3, 25)]
        public int starvingDamage = 25;


        // Thirst Reworked
        [Name("Thirst Rate")]
        [Description("Base number of hours to fully deplete Thirst bar and become Dehydrated\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "6 Hours", "8 Hours", "12 Hours", "24 Hours", "Custom")]
        public Dehydration dehydrationRate = Dehydration.Default;

        [Name("         Custom Selection")]
        [Description("How many hours to fully deplete Thirst bar and become dehydrated")]
        [Slider(4, 24)]
        public int dehydrationSlider = 8;

        [Name("         Litres per Day")]
        [Description("Base number of Litres per Day you need to drink to avoid dehydration")]
        [Slider(1f, 5f, 17, NumberFormat = "{0:0.##}")]
        public float litresPerDay = 3.0f;

        [Name("         Dehydration Damage")]
        [Description("Condition loss per day while Dehydrated\nGame Default Value is 50\n100 = 24hrs to die, 35 = approx. 3 days")]
        [Slider(35, 100)]
        public int dehydrationDamage = 50;


        // Fatigue Rate
        [Name("Fatigue Rate")]
        [Description("Choose from the standard game settings or use a custom value\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "Low", "Medium", "High", "Very High", "Custom")]
        public Choice fatigueRate = Choice.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Fatigue Rate:\nLow = 0.5, Medium = 0.8, High = 1.0, Very High = 1.2")]
        [Slider(0.25f, 2f, 176, NumberFormat = "{0:0.##}")]
        public float fatigueRateSlider = 1.0f;

        [Name("         Exhaustion Damage")]
        [Description("Condition loss per day while Exhausted\nGame Default Value is 25\n100 = 24hrs to die, 14 = approx. 1 week")]
        [Slider(14, 100)]
        public int exhaustionDamage = 25;


        // Freezing Rate
        [Name("Freezing Rate")]
        [Description("Choose from the standard game settings or use a custom value\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "Low", "Medium", "High", "Very High", "Custom")]
        public Choice freezingRate = Choice.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Freezing Rate:\nLow = 0.25, Medium = 1.0, High = 1.2, Very High = 1.75")]
        [Slider(0.15f, 2f, 186, NumberFormat = "{0:0.##}")]
        public float freezingRateSlider = 1.0f;

        [Name("         Freezing Damage")]
        [Description("Condition loss per day while Freezing\nGame Default Value is 450\n100 = 24hrs to die, 2400 = 1hr")]
        [Slider(100, 2400)]
        public int freezingDamage = 450;


        // At-Rest Condition Recovery Rate
        [Name("At-Rest Condition Recovery Rate (Asleep)")]
        [Description("Choose from a preset value*, the standard game settings, or use a custom value\n* Based on sleeping in a single stretch (2x12hr stretches for '1 per 24hrs')\n* You recover less Condition if you sleep in shorter stretches\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "None", "1 per 24 hours", "1 per 12 hours", "1 per 8 hours", "1 per 6 hours", "1 per 4 hours", "Low", "Medium", "High", "Very High", "Custom")]
        public ConditionRecovery asleepConditionRecovery = ConditionRecovery.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Condition Recovery:\nLow = 0.25, Medium = 0.5, High = 1.0, Very High = 2.0")]
        [Slider(0f, 2f, 20001, NumberFormat = "{0:0.####}")]
        public float asleepConditionRecoverySlider = 0.0f;


        // Condition Recovery Rate
        [Name("Condition Recovery Rate (Awake)")]
        [Description("Choose from a preset value, the standard game settings, or use a custom value\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "None", "1 per 24 hours", "1 per 12 hours", "1 per 8 hours", "1 per 6 hours", "1 per 4 hours", "Low", "Medium", "High", "Very High", "Custom")]
        public ConditionRecovery awakeConditionRecovery = ConditionRecovery.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Condition Recovery:\nLow = 0.25, Medium = 0.5, High = 1.0, Very High = 2.0")]
        [Slider(0f, 2f, 20001, NumberFormat = "{0:0.####}")]
        public float awakeConditionRecoverySlider = 0.0f;


        // Hypothermia Recovery Time
        [Name("Hypothermia Recovery Rate")]
        [Description("Choose from the standard game settings or use a custom value\nGAME DEFAULT will leave this unchanged")]
        [Choice("Game Default", "Low", "Medium", "High", "Very High", "Custom")]
        public Choice hypothermiaRecovery = Choice.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Hypothermia Recovery:\nLow = 0.5, Medium = 1.0, High = 1.5, Very High = 2.0")]
        [Slider(0.25f, 3f, 276, NumberFormat = "{0:0.##}")]
        public float hypothermiaRecoverySlider = 1.0f;


        // Frostbite Rate

        // Cabin Fever

        // Intestinal Parasites

        // Dysentry

        // Sprains

        // Food Poisoning

        // Broken Ribs

        // Rest as a Resource

        // Fires prevent Freezing

        // Wake up playuer when freezing near a fire

        // Birch Bark Tea Crafting

        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            if (field.Name == nameof(modFunction) ||
                field.Name == nameof(calorieBurnRate) ||
                //field.Name == nameof(thirstRate) ||
                field.Name == nameof(dehydrationRate) ||
                field.Name == nameof(fatigueRate) ||
                field.Name == nameof(freezingRate) ||
                field.Name == nameof(asleepConditionRecovery) ||
                field.Name == nameof(awakeConditionRecovery) ||
                field.Name == nameof(hypothermiaRecovery))
            {
                RefreshFields();
            }
        }
        internal void RefreshFields()
        {
            // Calories
            SetFieldVisible(nameof(calorieBurnRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(calorieBurnRateSlider), Settings.settings.modFunction != ModFunction.Disabled && calorieBurnRate == Choice.Custom);
            SetFieldVisible(nameof(starvingDamage), Settings.settings.modFunction != ModFunction.Disabled && calorieBurnRate != Choice.Default);
            // Thirst
            //SetFieldVisible(nameof(thirstRate), Settings.settings.modFunction != ModFunction.Disabled);
            //SetFieldVisible(nameof(thirstRateSlider), Settings.settings.modFunction != ModFunction.Disabled && thirstRate == Choice.Custom);
            SetFieldVisible(nameof(dehydrationRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(dehydrationSlider), Settings.settings.modFunction != ModFunction.Disabled && dehydrationRate == Dehydration.Custom);
            SetFieldVisible(nameof(litresPerDay), Settings.settings.modFunction != ModFunction.Disabled && dehydrationRate != Dehydration.Default);
            SetFieldVisible(nameof(dehydrationDamage), Settings.settings.modFunction != ModFunction.Disabled && dehydrationRate != Dehydration.Default);

            // Fatigue
            SetFieldVisible(nameof(fatigueRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(fatigueRateSlider), Settings.settings.modFunction != ModFunction.Disabled && fatigueRate == Choice.Custom);
            SetFieldVisible(nameof(exhaustionDamage), Settings.settings.modFunction != ModFunction.Disabled && fatigueRate != Choice.Default);
            // Freezing
            SetFieldVisible(nameof(freezingRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(freezingRateSlider), Settings.settings.modFunction != ModFunction.Disabled && freezingRate == Choice.Custom);
            SetFieldVisible(nameof(freezingDamage), Settings.settings.modFunction != ModFunction.Disabled && freezingRate != Choice.Default);
            // Condition
            SetFieldVisible(nameof(asleepConditionRecovery), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(asleepConditionRecoverySlider), Settings.settings.modFunction != ModFunction.Disabled && asleepConditionRecovery == ConditionRecovery.Custom);
            SetFieldVisible(nameof(awakeConditionRecovery), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(awakeConditionRecoverySlider), Settings.settings.modFunction != ModFunction.Disabled && awakeConditionRecovery == ConditionRecovery.Custom);
            // Hypothermia
            SetFieldVisible(nameof(hypothermiaRecovery), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(hypothermiaRecoverySlider), Settings.settings.modFunction != ModFunction.Disabled && hypothermiaRecovery == Choice.Custom);
        } 
    }
    internal static class Settings
    {
        public static CustomSettingsTweakerSettings settings;

        public static void OnLoad()
        {
            settings = new CustomSettingsTweakerSettings();
            settings.AddToModSettings("Custom Settings Tweaker");
            settings.RefreshFields();
        }
    }
}
