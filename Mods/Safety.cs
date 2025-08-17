using Photon.Pun;
using TysMenu.Menu;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Safety
    {
        public static void RpcProc()
        {
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.QuickResends = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.OnPlayerLeftRoom(NetworkSystem.Instance.LocalPlayer);
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            PhotonNetwork.MaxResendsBeforeDisconnect = int.MaxValue;
            PhotonNetwork.SendAllOutgoingCommands();
        }

        public static void AntiReport()
        {
            foreach (var line in MenuUtilities.GetPlayerScoreboardLines(NetworkSystem.Instance.LocalPlayer))
            {
                foreach (var rig in GorillaParent.instance.vrrigs)
                {
                    if (Vector3.Distance(rig.leftHandTransform.position, line.reportButton.transform.position) <= 0.4f ||
                        Vector3.Distance(rig.rightHandTransform.position, line.reportButton.transform.position) <= 0.4f)
                    {
                        NetworkSystem.Instance.ReturnToSinglePlayer();
                        return;
                    }
                }
            }
        }

    }
}