using GorillaGameModes;
using Photon.Pun;
using TysMenu.Classes;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Advantage
    {
        public static void TagPlayer(VRRig plr)
        {
            GorillaTagger.Instance.maxTagDistance = float.MaxValue;
            GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position = plr.transform.position;
            GorillaTagger.Instance.maxTagDistance = 1.2f;
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