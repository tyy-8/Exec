using ExitGames.Client.Photon;
using Photon.Pun;
using TysMenu.Classes;
using TysMenu.Menu;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Overpowered
    {
        private static bool yesMute;
        private static float delayayayayayyayayay;
        public static void FreezeServer()
        {
            if (ControllerInputPoller.instance.rightControllerIndexFloat > 0.5 && Time.time > delayayayayayyayayay)
            {
                yesMute = !yesMute;
                foreach (GorillaPlayerScoreboardLine line in GorillaScoreboardTotalUpdater.allScoreboardLines)
                    GorillaPlayerScoreboardLine.MutePlayer(line.linePlayer.UserId, line.linePlayer.NickName, yesMute ? 1 : 0);
                delayayayayayyayayay = Time.time + 0.15f;
            }
        }
        
        
        
    }
}