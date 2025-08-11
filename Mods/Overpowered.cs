using TysMenu.Classes;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Overpowered
    {
        public static void FlingGun() // PLEASE WORK WITHOUT GUARDIAN
        {
            GunLib.RenderGunPlayer();
            if (GunLib.Shooting)
                RoomSystem.LaunchPlayer(GunLib.rig.Creator, Vector3.up * 50);
        }
    }
}