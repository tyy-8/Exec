using Photon.Pun;

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
    }
}