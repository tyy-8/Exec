using System.Collections;
using BepInEx;
using System.ComponentModel;
using UnityEngine;

namespace TysMenu.Patches
{
    [Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        public static HarmonyPatches instance;
        
        public static Coroutine RunCoroutine(IEnumerator enumerator) =>
            instance.StartCoroutine(enumerator);

        public static void EndCoroutine(Coroutine enumerator) =>
            instance.StopCoroutine(enumerator);
        
        private void OnEnable()
        {
            instance = this;
            Menu.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            instance = null;
            Menu.RemoveHarmonyPatches();
        }
    }
}
