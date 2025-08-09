using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace TysMenu.Classes
{
    public class GunLib : MonoBehaviour
    {
        public static bool middleWide;
        public static VRRig rig;
        public static Vector3 gunPos;
        public static RaycastHit hit;
        public static Collider hitCld;
        public static bool Shooting;

        private static GameObject PointerObj;

        private static readonly int TransparentFX = LayerMask.NameToLayer("TransparentFX");
        private static readonly int IgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        private static readonly int Zone = LayerMask.NameToLayer("Zone");
        private static readonly int GorillaTrigger = LayerMask.NameToLayer("Gorilla Trigger");
        private static readonly int GorillaBoundary = LayerMask.NameToLayer("Gorilla Boundary");
        private static readonly int GorillaCosmetics = LayerMask.NameToLayer("GorillaCosmetics");
        private static readonly int GorillaParticle = LayerMask.NameToLayer("GorillaParticle");

        public static int NoInvisLayerMask() =>
            ~(1 << TransparentFX | 1 << IgnoreRaycast | 1 << Zone | 1 << GorillaTrigger | 1 << GorillaBoundary | 1 << GorillaCosmetics | 1 << GorillaParticle);

        public static (Vector3 position, Quaternion rotation, Vector3 up, Vector3 forward, Vector3 right) TrueRightHand()
        {
            Quaternion rot = GorillaTagger.Instance.rightHandTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandRotOffset;
            return (
                GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.rightHandTransform.rotation * GorillaLocomotion.GTPlayer.Instance.rightHandOffset,
                rot,
                rot * Vector3.up,
                rot * Vector3.forward,
                rot * Vector3.right
            );
        }

        private static void EnsurePointer()
        {
            if (PointerObj != null) return;

            PointerObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Destroy(PointerObj.GetComponent<Collider>());
            Destroy(PointerObj.GetComponent<Rigidbody>());

            var mat = new Material(Shader.Find("GUI/Text Shader"));
            mat.color = new Color32(110, 110, 110, 255);
            PointerObj.GetComponent<Renderer>().material = mat;

            var line = PointerObj.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("GUI/Text Shader"));
            line.startWidth = 0.01f;
            line.endWidth = 0.01f;
            line.numCapVertices = 15;
            line.numCornerVertices = 15;
            PointerObj.transform.localScale = Vector3.one * 0.1f;
        }

        private static Vector3 smoothedMid = Vector3.zero;
        private static Vector3 midVelocity = Vector3.zero;

        private static void UpdatePointer(Vector3 start, Vector3 end)
        {
            var line = PointerObj.GetComponent<LineRenderer>();
            int segments = 20;
            line.positionCount = segments;

            Vector3 targetMid = (start + end) * 0.5f;

            Vector3 dir = (end - start).normalized;
            Vector3 perp = Vector3.Cross(dir, Vector3.up).normalized;
            targetMid += perp * 0.2f;

            float smoothTime = 0.1f;
            smoothedMid = Vector3.SmoothDamp(smoothedMid, targetMid, ref midVelocity, smoothTime);

            for (int i = 0; i < segments; i++)
            {
                float t = i / (float)(segments - 1);
                Vector3 point = Mathf.Pow(1 - t, 2) * start
                                + 2 * (1 - t) * t * smoothedMid
                                + Mathf.Pow(t, 2) * end;
                line.SetPosition(i, point);
            }

            if (middleWide)
            {
                line.widthCurve = new AnimationCurve(
                    new Keyframe(0f, 0.01f),
                    new Keyframe(0.5f, 0.03f),
                    new Keyframe(1f, 0.01f)
                );
            }

            var color = Shooting ? new Color32(210, 110, 110, 255) : new Color32(110, 110, 110, 255);
            PointerObj.GetComponent<Renderer>().material.color = color;
        }



        public static void RenderGun()
        {
            EnsurePointer();

            bool grip = ControllerInputPoller.GripFloat(XRNode.RightHand) == 1f || Mouse.current.rightButton.isPressed;
            bool trigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) == 1f || Mouse.current.leftButton.isPressed;

            RaycastHit gunHit;
            if (grip)
            {
                Vector3 rayOrigin;
                Vector3 rayDir;

                if (Mouse.current.rightButton.isPressed)
                {
                    Ray ray = GorillaTagger.Instance.thirdPersonCamera.GetComponent<Camera>().ScreenPointToRay(Mouse.current.position.ReadValue());
                    rayOrigin = ray.origin - new Vector3(0,0.1f,0);
                    rayDir = ray.direction;
                    trigger = Mouse.current.leftButton.isPressed;
                }
                else
                {
                    rayOrigin = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    rayDir = TrueRightHand().forward;
                }

                Physics.Raycast(rayOrigin, rayDir, out gunHit, 512, NoInvisLayerMask());
                PointerObj.SetActive(true);
                PointerObj.transform.position = gunHit.point;

                UpdatePointer(rayOrigin, gunHit.point);

                if (trigger)
                {
                    Shooting = true;
                    gunPos = gunHit.point;
                    hit = gunHit;
                    hitCld = hit.collider;
                }
                else
                {
                    Shooting = false;
                }
            }
            else
            {
                PointerObj.SetActive(false);
                hitCld = null;
                Shooting = false;
            }
        }

        public static void RenderGunPlayer()
        {
            EnsurePointer();

            bool grip = ControllerInputPoller.GripFloat(XRNode.RightHand) == 1f || Mouse.current.rightButton.isPressed;
            bool trigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) == 1f || Mouse.current.leftButton.isPressed;

            RaycastHit gunHit;
            if (grip)
            {
                Vector3 rayOrigin;
                Vector3 rayDir;

                if (Mouse.current.rightButton.isPressed)
                {
                    Ray ray = GorillaTagger.Instance.thirdPersonCamera.GetComponent<Camera>().ScreenPointToRay(Mouse.current.position.ReadValue());
                    rayOrigin = ray.origin - new Vector3(0,-0.2f,0);
                    rayDir = ray.direction;
                    trigger = Mouse.current.leftButton.isPressed;
                }
                else
                {
                    rayOrigin = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                    rayDir = TrueRightHand().forward;
                }

                Physics.Raycast(rayOrigin, rayDir, out gunHit, 512, NoInvisLayerMask());

                PointerObj.SetActive(true);
                Vector3 end = gunHit.point;

                if (trigger)
                {
                    if (gunHit.transform.TryGetComponent<VRRig>(out var hitRig) && hitRig != GorillaTagger.Instance.offlineVRRig)
                    {
                        rig = hitRig;
                        Shooting = true;
                    }
                }
                else
                {
                    Shooting = false;
                }

                PointerObj.transform.position = rig != null ? rig.transform.position : end;
                UpdatePointer(rayOrigin, rig != null ? rig.transform.position : end);
            }
            else
            {
                PointerObj.SetActive(false);
                rig = null;
                Shooting = false;
            }
        }
    }
}
