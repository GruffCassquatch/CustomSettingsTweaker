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
    public enum ChoiceDNY
    {
        Default, No, Yes
    }
    public enum ChoiceDRC
    {
        Default, Realistic, Custom
    }
    public enum Distance
    {
        Default, Close, Medium, Far
    }
    public enum ChoiceDLMH
    {
        Default, Low, Medium, High
    }
    public enum ChoiceDNLH
    {
        Default, None, Low, High
    }
    public enum ChoiceDLMHV
    {
        Default, Low, Medium, High, VeryHigh
    }
    public enum ChoiceDLMHVC
    {
        Default, Low, Medium, High, VeryHigh, Custom
    }
    public enum ChoiceDNLMH
    {
        Default, None, Low, Medium, High
    }
    public enum ChoiceDNLMHC
    {
        Default, None, Low, Medium, High, Custom
    }
    public enum ChoiceDNLMHV
    {
        Default, None, Low, Medium, High, VeryHigh
    }
    public enum ChoiceDNLMHVC
    {
        Default, None, Low, Medium, High, VeryHigh, Custom
    }
    public enum ChoiceD1234
    {
        Default, OneX, TwoX, ThreeX, FourX
    }
    public enum Dehydration
    {
        Default, SixHrs, EightHrs, TwelveHrs, TwentyFourHrs, Custom
    }
    public enum ConditionRecovery
    {
        Default, None, OnePer24, OnePer12, OnePer8, OnePer6, OnePer4, OnePer2, OnePer1, Low, Medium, High, VeryHigh, Custom
    }

    class CustomSettingsTweakerSettings : JsonModSettings
    {
        [Section("Custom Settings Tweaker")]
        [Name("Enable or Disable this mod")]
        [Description("Enable or Disable this mod")]
        [Choice("Disabled", "Enabled")]
        public ModFunction modFunction = ModFunction.Disabled;

        // GAME START
        // Baseline Resource Availability
        [Section("Game Start")]
        [Name("Baseline Resource Availability")]
        [Description("Choose from the standard game settings.\nThis cannot retroactively change things that have already been generated")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV resourceAvailability = ChoiceDLMHV.Default;

        // Survivor monologue
        [Name("Survivor Monologue")]
        [Description("Character voice over")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY survivorMonologue = ChoiceDNY.Default;


        // ENVIRONMENT
        // Length of day multiplier
        [Section("Environment")]
        [Name("Length of day multiplier")]
        [Description("Game Default is 1x")]
        [Choice("Unchanged", "1x", "2x", "3x", "4x")]
        public ChoiceD1234 lengthOfDay  = ChoiceD1234.Default;

        // Weather Variability
        [Name("Weather Variability")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV weatherVariability = ChoiceDLMHV.Default;

        // Blizzard Frequency
        [Name("Blizzard Frequency")]
        [Description("Choose from the standard game settings or use a custom value")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High", "Custom")]
        public ChoiceDNLMHVC blizzardFrequency = ChoiceDNLMHVC.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Blizzard Frequency:\nNone = 0, Low = 0.75, Medium = 1, High = 1.25, Very High = 2")]
        [Slider(0f, 3f, 13, NumberFormat = "{0:0.##}")]
        public float blizzardSlider = 1.0f;

        // World gets Colder Over Time
        [Name("World gets Colder Over Time")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH worldGetsColder = ChoiceDNLMH.Default;

        // Wind variability
        [Name("Wind Variability")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High")]
        public ChoiceDLMH windVariability = ChoiceDLMH.Default;

        // Aurora Frequency
        [Name("Aurora Frequency")]
        [Description("Choose from the standard game settings or a custom value")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH auroraFrequency = ChoiceDNLMH.Default;

        // Fire Overcomes Ambient air temp
        [Name("Fire Overcomes Ambient Air Temp")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY fireOvercomesAmbient = ChoiceDNY.Default;

        // Endless Night
        [Name("Endless Night")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY endlessNight = ChoiceDNY.Default;


        // HEALTH
        // Calorie Burn Rate
        [Section("Health")]
        [Name("Calorie Burn Rate")]
        [Description("Choose from the standard game settings or use a custom value")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High", "Custom")]
        public ChoiceDLMHVC calorieBurnRate = ChoiceDLMHVC.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Calorie Burn Rate:\nLow = 0.5, Medium = 0.8, High = 0.9, Very High = 1.0")]
        [Slider(0.25f, 2f, 176, NumberFormat = "{0:0.##}")]
        public float calorieBurnRateSlider = 1.0f;

        [Name("         Starving Damage")]
        [Description("Condition loss per day while Starving.\nGame Default Value is 25.\n25 = 4 days to die, 3 = approx. 33 days")]
        [Slider(3, 50)]
        public int starvingDamage = 25;

        // Thirst Reworked
        [Name("Thirst Rate")]
        [Description("Base number of hours to fully deplete Thirst bar and become Dehydrated")]
        [Choice("Unchanged", "6 Hours", "8 Hours", "12 Hours", "24 Hours", "Custom")]
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
        [Description("Condition loss per day while Dehydrated.\nGame Default Value is 50.\n100 = 24hrs to die, 35 = approx. 3 days")]
        [Slider(35, 100)]
        public int dehydrationDamage = 50;

        // Fatigue Rate
        [Name("Fatigue Rate")]
        [Description("Choose from the standard game settings or use a custom value")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High", "Custom")]
        public ChoiceDLMHVC fatigueRate = ChoiceDLMHVC.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Fatigue Rate:\nLow = 0.5, Medium = 0.8, High = 1.0, Very High = 1.2")]
        [Slider(0.25f, 2f, 176, NumberFormat = "{0:0.##}")]
        public float fatigueRateSlider = 1.0f;

        [Name("         Exhaustion Damage")]
        [Description("Condition loss per day while Exhausted.\nGame Default Value is 25.\n100 = 24hrs to die, 14 = approx. 1 week")]
        [Slider(14, 100)]
        public int exhaustionDamage = 25;

        // Freezing Rate
        [Name("Freezing Rate")]
        [Description("Choose from the standard game settings or use a custom value")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High", "Custom")]
        public ChoiceDLMHVC freezingRate = ChoiceDLMHVC.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Freezing Rate:\nLow = 0.25, Medium = 1.0, High = 1.2, Very High = 1.75")]
        [Slider(0.15f, 2f, 186, NumberFormat = "{0:0.##}")]
        public float freezingRateSlider = 1.0f;

        [Name("         Freezing Damage")]
        [Description("Condition loss per day while Freezing.\nGame Default Value is 450.\n100 = 24hrs to die, 2400 = 1hr")]
        [Slider(100, 2400)]
        public int freezingDamage = 450;

        // At-Rest Condition Recovery Rate
        [Name("At-Rest Condition Recovery Rate (Asleep)")]
        [Description("Choose from a preset value, the standard game settings, or use a custom value.")]
        [Choice("Unchanged", "None", "1 per 24 hours", "1 per 12 hours", "1 per 8 hours", "1 per 6 hours", "1 per 4 hours", "1 per 2 hours", "1 per hour", "Low", "Medium", "High", "Very High", "Custom")]
        public ConditionRecovery asleepConditionRecovery = ConditionRecovery.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Condition Recovery:\nLow = 0.25, Medium = 0.5, High = 1.0, Very High = 2.0")]
        [Slider(0f, 2f, 20001, NumberFormat = "{0:0.####}")]
        public float asleepConditionRecoverySlider = 0.0f;

        // Uninterrupted Rest Bonus
        [Name("Uninterrupted Rest Bonus")]
        [Description("YES: Receive the usual bonus to Condition Recovery from sleeping longer\nNO: Disable the bonus Condition Recovery, it will be a flat rate per hour of sleep")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY restBonus = ChoiceDNY.Default;

        // Condition Recovery Rate
        [Name("Condition Recovery Rate (Awake)")]
        [Description("Choose from a preset value, the standard game settings, or use a custom value")]
        [Choice("Unchanged", "None", "1 per 24 hours", "1 per 12 hours", "1 per 8 hours", "1 per 6 hours", "1 per 4 hours", "1 per 2 hours", "1 per hour", "Low", "Medium", "High", "Very High", "Custom")]
        public ConditionRecovery awakeConditionRecovery = ConditionRecovery.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Condition Recovery:\nLow = 0.25, Medium = 0.5, High = 1.0, Very High = 2.0")]
        [Slider(0f, 2f, 20001, NumberFormat = "{0:0.####}")]
        public float awakeConditionRecoverySlider = 0.0f;

        // Hypothermia Recovery Time
        [Name("Hypothermia Recovery Rate")]
        [Description("Choose from the standard game settings or use a custom value")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High", "Custom")]
        public ChoiceDLMHVC hypothermiaRecovery = ChoiceDLMHVC.Default;

        [Name("         Custom Selection")]
        [Description("Standard Game Settings for Hypothermia Recovery:\nLow = 0.5, Medium = 1.0, High = 1.5, Very High = 2.0")]
        [Slider(0.25f, 3f, 276, NumberFormat = "{0:0.##}")]
        public float hypothermiaRecoverySlider = 1.0f;

        // Frostbite Rate
        [Name("Frostbite Rate")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV frostbiteRate = ChoiceDNLMHV.Default;

        // Cabin Fever
        [Name("Cabin Fever")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY cabinFever = ChoiceDNY.Default;

        // Intestinal Parasites
        [Name("Intestinal Parasites")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY intestinalParasites = ChoiceDNY.Default;

        // Dysentry
        [Name("Dysentry")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY dysentry = ChoiceDNY.Default;

        // Sprains
        [Name("Sprains")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY sprains = ChoiceDNY.Default;

        // Food Poisoning
        [Name("Food Poisoning")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY foodPoisoning = ChoiceDNY.Default;

        // Broken Ribs
        [Name("Broken Ribs")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY brokenRibs = ChoiceDNY.Default;

        // Rest as a Resource
        [Name("Rest as a Resource")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY restAsResource = ChoiceDNY.Default;

        // Fires prevent Freezing
        [Name("Fires Prevent Freezing")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY firesPreventFreezing = ChoiceDNY.Default;

        // Wake up player when freezing near a fire
        [Name("Wake up player when freezing near a fire")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY wakeUpWhenFreezing = ChoiceDNY.Default;

        // Birch Bark Tea Crafting
        [Name("Birch Bark Tea Crafting")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY birchBarkTea = ChoiceDNY.Default;

        [Name("Cooking Skill affects Parasites/Food Poisoning")]
        [Description("Level 5 Cooking Skill removes risk of parasites & food poisoning in cooked food.\nYES: Game Default setting. NO: Disable this effect.")]
        public bool noParasitesOrFoodPoisoning = true;


        // GEAR
        // Item Decay Rate
        [Section("Gear")]
        [Name("Item Decay Rate")]
        [Description("Choose from the standard game settings.\nUse 'Gear Decay Modifier' mod if you want detailed settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV decayRate = ChoiceDLMHV.Default;

        // Loose Item Availability
        [Name("Loose Item Availability")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV looseItemAvailability = ChoiceDLMHV.Default;

        // Empty Container Chance Modifier
        [Name("Empty Container Chance Modifier")]
        [Description("Choose from the standard game settings.\nThis cannot retroactively change things that have already been generated")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH emptyContainerChance = ChoiceDNLMH.Default;

        // Stick, Branch and Stone Respawn Frequency
        [Name("Stick, Branch and Stone Respawn Frequency")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV stickBranchStoneRespawn = ChoiceDLMHV.Default;

        // Rifle Availability
        [Name("Rifle Availability")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY rifleAvailability = ChoiceDNY.Default;

        // Revolver Availability
        [Name("Revolver Availability")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY revolverAvailability = ChoiceDNY.Default;

        // Harvestable Plant Availability
        [Name("Harvestable Plant Availability")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High")]
        public ChoiceDLMH harvestablePlants = ChoiceDLMH.Default;

        // Reduce Container Item Density
        [Name("Reduce Container Item Density")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "High")]
        public ChoiceDNLH containerDensity = ChoiceDNLH.Default;


        // WILDLIFE SPAWNS
        // Fish Spawn Chance
        [Section("WILDLIFE SPAWNS")]
        [Name("Fish Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV fishSpawn = ChoiceDNLMHV.Default;

        // Wolf Spawn Chance
        [Name("Wolf Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV wolfSpawn = ChoiceDNLMHV.Default;

        // Timberwolf Spawn Chance
        [Name("Timberwolf Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV timberwolfSpawn = ChoiceDNLMHV.Default;

        // Deer Spawn Chance
        [Name("Deer Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV deerSpawn = ChoiceDNLMHV.Default;

        // Rabbit Spawn Chance
        [Name("Rabbit Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV rabbitSpawn = ChoiceDNLMHV.Default;

        // Bear Spawn Chance
        [Name("Bear Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV bearSpawn = ChoiceDNLMHV.Default;

        // Moose Spawn Chance
        [Name("Moose Spawn Chance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High", "Very High")]
        public ChoiceDNLMHV mooseSpawn = ChoiceDNLMHV.Default;

        // Time to Wildlife Respawn
        [Name("Time to Wildlife Respawn")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV wildlifeRespawn = ChoiceDLMHV.Default;

        // Reduce Wildlife Population Over Time
        [Name("Reduce Wildlife Population Over Time")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH reduceWildlife = ChoiceDNLMH.Default;

        // Wolf Spawn Distance
        [Name("Wolf Spawn Distance")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Close", "Medium", "Far")]
        public Distance wolfSpawnDistance = Distance.Default;


        // WILDLIFE BEHAVIOUR
        // Wildlife Smell Range
        [Section("WILDLIFE BEHAVIOUR")]
        [Name("Wildlife Smell Range")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV wildlifeSmellRange = ChoiceDLMHV.Default;

        // Scent Increase from Meat/Blood
        [Name("Scent Increase from Meat/Blood")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH scentIncrease = ChoiceDNLMH.Default;

        // Passive Wildlife
        [Name("Passive Wildlife")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY passiveWildlife = ChoiceDNY.Default;

        // Wildlife Attcks During Rest
        [Name("Wildlife Attcks During Rest")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "No", "Yes")]
        public ChoiceDNY wildlifeAttackResting = ChoiceDNY.Default;

        // Wolf Fear
        [Name("Wolf Fear")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH wolfFear = ChoiceDNLMH.Default;

        // Timberwolf Morale
        [Name("Timberwolf Morale")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High")]
        public ChoiceDLMH timberwolfMorale = ChoiceDLMH.Default;

        // Wildlife Detection Range
        [Name("Wildlife Detection Range")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Close", "Medium", "Far")]
        public Distance wildlifeDetectionRange = Distance.Default;


        // WILDLIFE STRUGGLE
        // Struggle Bonus
        [Name("Struggle Bonus")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH struggleBonus = ChoiceDNLMH.Default;

        // Struggle Condition Damage Modifier
        [Name("Struggle Condition Damage Modifier")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH struggleDamage = ChoiceDNLMH.Default;

        // Struggle Clothing Damage Modifier
        [Name("Struggle Clothing Damage Modifier")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "None", "Low", "Medium", "High")]
        public ChoiceDNLMH clothingDamage = ChoiceDNLMH.Default;

        // Struggle Damage Severity
        [Name("Struggle Damage Severity")]
        [Description("Choose from the standard game settings")]
        [Choice("Unchanged", "Low", "Medium", "High", "Very High")]
        public ChoiceDLMHV struggleSeverity = ChoiceDLMHV.Default;

        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            if (field.Name == nameof(modFunction) ||
                field.Name == nameof(blizzardFrequency) ||
                field.Name == nameof(auroraFrequency) ||
                field.Name == nameof(calorieBurnRate) ||
                field.Name == nameof(dehydrationRate) ||
                field.Name == nameof(fatigueRate) ||
                field.Name == nameof(freezingRate) ||
                field.Name == nameof(asleepConditionRecovery) ||
                field.Name == nameof(awakeConditionRecovery) ||
                field.Name == nameof(hypothermiaRecovery) ||
                field.Name == nameof(blizzardFrequency))
            {
                RefreshFields();
            }
        }
        internal void RefreshFields()
        {
            // Game Start
            SetFieldVisible(nameof(resourceAvailability), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(survivorMonologue), Settings.settings.modFunction != ModFunction.Disabled);
            // Environment
            SetFieldVisible(nameof(lengthOfDay), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(weatherVariability), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(blizzardFrequency), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(blizzardSlider), Settings.settings.modFunction != ModFunction.Disabled && blizzardFrequency == ChoiceDNLMHVC.Custom);
            SetFieldVisible(nameof(worldGetsColder), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(windVariability), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(auroraFrequency), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(fireOvercomesAmbient), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(endlessNight), Settings.settings.modFunction != ModFunction.Disabled);
            // Health
            SetFieldVisible(nameof(calorieBurnRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(calorieBurnRateSlider), Settings.settings.modFunction != ModFunction.Disabled && calorieBurnRate == ChoiceDLMHVC.Custom);
            SetFieldVisible(nameof(starvingDamage), Settings.settings.modFunction != ModFunction.Disabled && calorieBurnRate != ChoiceDLMHVC.Default);
            SetFieldVisible(nameof(dehydrationRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(dehydrationSlider), Settings.settings.modFunction != ModFunction.Disabled && dehydrationRate == Dehydration.Custom);
            SetFieldVisible(nameof(litresPerDay), Settings.settings.modFunction != ModFunction.Disabled && dehydrationRate != Dehydration.Default);
            SetFieldVisible(nameof(dehydrationDamage), Settings.settings.modFunction != ModFunction.Disabled && dehydrationRate != Dehydration.Default);
            SetFieldVisible(nameof(fatigueRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(fatigueRateSlider), Settings.settings.modFunction != ModFunction.Disabled && fatigueRate == ChoiceDLMHVC.Custom);
            SetFieldVisible(nameof(exhaustionDamage), Settings.settings.modFunction != ModFunction.Disabled && fatigueRate != ChoiceDLMHVC.Default);
            SetFieldVisible(nameof(freezingRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(freezingRateSlider), Settings.settings.modFunction != ModFunction.Disabled && freezingRate == ChoiceDLMHVC.Custom);
            SetFieldVisible(nameof(freezingDamage), Settings.settings.modFunction != ModFunction.Disabled && freezingRate != ChoiceDLMHVC.Default);
            SetFieldVisible(nameof(asleepConditionRecovery), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(asleepConditionRecoverySlider), Settings.settings.modFunction != ModFunction.Disabled && asleepConditionRecovery == ConditionRecovery.Custom);
            SetFieldVisible(nameof(restBonus), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(awakeConditionRecovery), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(awakeConditionRecoverySlider), Settings.settings.modFunction != ModFunction.Disabled && awakeConditionRecovery == ConditionRecovery.Custom);
            SetFieldVisible(nameof(hypothermiaRecovery), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(hypothermiaRecoverySlider), Settings.settings.modFunction != ModFunction.Disabled && hypothermiaRecovery == ChoiceDLMHVC.Custom);
            SetFieldVisible(nameof(frostbiteRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(cabinFever), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(intestinalParasites), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(dysentry), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(sprains), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(foodPoisoning), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(brokenRibs), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(restAsResource), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(firesPreventFreezing), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wakeUpWhenFreezing), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(birchBarkTea), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(noParasitesOrFoodPoisoning), Settings.settings.modFunction != ModFunction.Disabled);
            // Gear
            SetFieldVisible(nameof(decayRate), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(looseItemAvailability), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(emptyContainerChance), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(stickBranchStoneRespawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(rifleAvailability), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(revolverAvailability), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(harvestablePlants), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(containerDensity), Settings.settings.modFunction != ModFunction.Disabled);
            // Wildlife Spawns
            SetFieldVisible(nameof(fishSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wolfSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(timberwolfSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(rabbitSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(deerSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(bearSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(mooseSpawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wildlifeRespawn), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(reduceWildlife), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wolfSpawnDistance), Settings.settings.modFunction != ModFunction.Disabled);
            // Wildlife Behaviour
            SetFieldVisible(nameof(wildlifeSmellRange), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(scentIncrease), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(passiveWildlife), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wildlifeAttackResting), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wolfFear), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(timberwolfMorale), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(wildlifeDetectionRange), Settings.settings.modFunction != ModFunction.Disabled);
            // Wildlife Struggle
            SetFieldVisible(nameof(struggleBonus), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(struggleDamage), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(clothingDamage), Settings.settings.modFunction != ModFunction.Disabled);
            SetFieldVisible(nameof(struggleSeverity), Settings.settings.modFunction != ModFunction.Disabled);
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
