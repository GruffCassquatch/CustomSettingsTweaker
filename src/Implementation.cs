using MelonLoader;
using UnityEngine;

namespace CustomSettingsTweaker
{
    public class Implementation : MelonMod
    {
        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
        }
    }
}
