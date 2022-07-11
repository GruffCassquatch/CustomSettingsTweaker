using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace CustomSettingsTweaker
{
    public class Implementation : MelonMod
    {
        // Default hydration values for food items without FoodItem prefab:
        public const float defaultAirlineFoodHydration = 5f;
        public const float defaultBeansHydration = -5f;
        public const float defaultPeachesHydration = 20f;
        public const float defaultMREHydration = 5f;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}
