using Liv.Lck.GorillaTag;
using TysMenu.Classes;
using TysMenu.Menu;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Fun
    {
        static GameObject bug;
        public static void GetBugOwnership()
        {
            if (bug == null) 
                bug = GameObject.Find("Floating Bug Holdable");

            if (bug.GetComponent<ThrowableBug>().OwningPlayer() != NetworkSystem.Instance.LocalPlayer)
            {
                GorillaTagger.Instance.offlineVRRig.enabled  = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = bug.transform.position;
                bug.GetComponent<ThrowableBug>().OnOwnershipRequest(NetworkSystem.Instance.LocalPlayer);
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }
        public static void PhysicsBug()
        {
            if (bug == null) 
                bug = GameObject.Find("Floating Bug Holdable");

            GetBugOwnership();
            bug.GetComponent<ThrowableBug>().shouldUseGravity = true;
            bug.GetComponent<ThrowableBug>().rigidbodyInstance.useGravity = true;
        }
        public static void OffPhysicsBug()
        {
            if (bug == null) 
                bug = GameObject.Find("Floating Bug Holdable");

            GetBugOwnership();
            bug.GetComponent<ThrowableBug>().shouldUseGravity = true;
            bug.GetComponent<ThrowableBug>().rigidbodyInstance.useGravity = true;
        }
        

        // -- Cameras -- 
        public static LckSocialCamera GetCamera()
        {
            return GorillaTagger.Instance.myVRRig.gameObject.transform.Find("LCKNetworkedSocialCamera").GetComponent<LckSocialCamera>();
        }

        public static void CameraHand()
        {
            SetCameraActive(true);
            LckSocialCameraManager._instance._socialCameraInstance.transform.position = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position +
                                             new Vector3(0, 0.1f, 0);
        }
        public static void CameraAura()
        {
            SetCameraActive(true);
            LckSocialCameraManager._instance._socialCameraInstance.transform.position = MenuUtilities.Aura(VRRig.LocalRig.transform.position, 1f);
        }
        public static void CameraAuraGun()
        {
            GunLib.RenderGunPlayer();
            if (GunLib.Shooting)
            {
                SetCameraActive(true);
                LckSocialCameraManager._instance._socialCameraInstance.transform.position = MenuUtilities.Aura(GunLib.rig.transform.position, 1f);
            }
        }

        public static void SetCameraActive(bool active)
        {
            GetCamera().visible = active;
            GetCamera().visible = active;
            GetCamera().recording = active;

            GetCamera().CoconutCamera.SetVisualsActive(active);
            GetCamera().CoconutCamera.SetRecordingState(active);
        }
        public static void CameraBracelet()
        {
            SetCameraActive(true);
            LckSocialCameraManager._instance._socialCameraInstance.transform.position = MenuUtilities.Aura(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position, 0.1f, 'Y');
        }
        public static void NoCamera()
        {
            SetCameraActive(false);
        }
    }
}