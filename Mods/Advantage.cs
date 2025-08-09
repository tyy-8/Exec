using GorillaGameModes;
using Photon.Pun;
using TysMenu.Classes;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Advantage
    {
        public static float cooldownThing;
        public static void TagPlayer(VRRig plr)
        {
            if (Time.time > cooldownThing)
            {
                GorillaTagger.Instance.maxTagDistance = float.MaxValue;
                var yes = (GorillaTagManager)GorillaGameManager.instance;
                yes.ReportTag(plr.Creator, PhotonNetwork.LocalPlayer);
                GorillaTagger.Instance.maxTagDistance = 1.2f;
                cooldownThing = Time.time + 0.2f;
            }
        }
        
        
        public static void TagGun()
        {
            GunLib.RenderGunPlayer();
            if (GunLib.Shooting)
            {
                TagPlayer(GunLib.rig);
            }
        }
        public static void TagAll()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.3f)
            {
                foreach (var rig in GorillaParent.instance.vrrigs)
                    TagPlayer(rig);
            }
        }
    }
}