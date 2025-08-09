using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ExitGames.Client.Photon;
using GorillaGameModes;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using TysMenu.Classes;
using TysMenu.Patches;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Advantage
    {
        public static void SendSerialize(PhotonView pv, RaiseEventOptions options = null, int timeOffset = 0) // creds to iidk
        {
            if (!PhotonNetwork.InRoom)
                return;

            if (pv == null)
            {
                return;
            }

            List<object> serializedData = PhotonNetwork.OnSerializeWrite(pv);

            PhotonNetwork.RaiseEventBatch raiseEventBatch = new PhotonNetwork.RaiseEventBatch();

            bool mixedReliable = pv.mixedModeIsReliable;
            raiseEventBatch.Reliable =
                pv.Synchronization == ViewSynchronization.ReliableDeltaCompressed || mixedReliable;
            raiseEventBatch.Group = pv.Group;

            System.Collections.IDictionary dictionary = PhotonNetwork.serializeViewBatches;

            PhotonNetwork.SerializeViewBatch serializeViewBatch =
                new PhotonNetwork.SerializeViewBatch(raiseEventBatch, 2);

            if (!dictionary.Contains(raiseEventBatch))
                dictionary[raiseEventBatch] = serializeViewBatch;

            serializeViewBatch.Add(serializedData);

            RaiseEventOptions sendOptions = PhotonNetwork.serializeRaiseEvOptions;
            RaiseEventOptions finalOptions = options != null
                ? new RaiseEventOptions
                {
                    CachingOption = sendOptions.CachingOption,
                    Flags = sendOptions.Flags,
                    InterestGroup = sendOptions.InterestGroup,
                    TargetActors = options.TargetActors,
                    Receivers = options.Receivers
                }
                : sendOptions;

            bool reliable = serializeViewBatch.Batch.Reliable;
            List<object> objectUpdate = serializeViewBatch.ObjectUpdates;
            byte currentLevelPrefix = PhotonNetwork.currentLevelPrefix;

            objectUpdate[0] = PhotonNetwork.ServerTimestamp + timeOffset;
            objectUpdate[1] = currentLevelPrefix != 0 ? (object)currentLevelPrefix : null;

            PhotonNetwork.NetworkingClient.OpRaiseEvent((byte)(reliable ? 206 : 201), objectUpdate, finalOptions,
                reliable ? SendOptions.SendReliable : SendOptions.SendUnreliable);

        }
        
        public static void TagPlayer(VRRig plr)
        {
            if (!RigManager.PlayerIsTagged(VRRig.LocalRig) || RigManager.PlayerIsTagged(plr))
                return;

            Vector3 archiveRigPosition = VRRig.LocalRig.transform.position;
            VRRig.LocalRig.transform.position = plr.transform.position;

            SendSerialize(GorillaTagger.Instance.myVRRig.GetView, new RaiseEventOptions { TargetActors = new int[] { PhotonNetwork.MasterClient.ActorNumber } });
            GameMode.ReportTag(plr.Creator);

            VRRig.LocalRig.transform.position = archiveRigPosition;

            Safety.RpcProc();
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