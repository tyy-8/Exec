using GorillaLocomotion;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Movement
    {
        public static void Fly(int flyMode, bool physics) // 0 is hand fly, 1 is head fly
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                switch (flyMode)
                {
                    case 0:
                        if (physics)
                            GorillaLocomotion.GTPlayer.Instance.AddForce(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.forward * 10 + new Vector3(0,9.81f,0), ForceMode.Acceleration);
                        if (!physics)
                            GorillaLocomotion.GTPlayer.Instance.transform.position +=
                                GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.forward * 1.1f;
                        break;
                    
                    case 1:
                        if (physics)
                            GorillaLocomotion.GTPlayer.Instance.AddForce(Camera.main.transform.forward * 10 + new Vector3(0,9.81f,0), ForceMode.Acceleration);
                        if (!physics)
                            GorillaLocomotion.GTPlayer.Instance.transform.position +=
                                Camera.main.transform.forward * 1.1f;

                        break;
                }
            }
        }
        public static void Pull() // I've never actually made one of these, prob will suck ass.
        {
            if (GTPlayer.Instance.IsHandTouching(false) ||
                GTPlayer.Instance.IsHandTouching(true))
            {
                GTPlayer.Instance.transform.position += new Vector3(GorillaTagger.Instance.rigidbody.velocity.x * 0.04f, 0, GorillaTagger.Instance.rigidbody.velocity.z * 0.04f);
            }
        }


        public static GameObject platL;
        public static GameObject platR;
        public static void Platforms()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (platR == null)
                {
                    platR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platR.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    platR.transform.position = GTPlayer.Instance.rightControllerTransform.position;
                    platR.transform.rotation = GTPlayer.Instance.rightControllerTransform.rotation;
                }
            }
            else
            {
                if (platR != null) GameObject.DestroyImmediate(platR);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (platL == null)
                {
                    platL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    platL.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                    platL.transform.position = GTPlayer.Instance.leftControllerTransform.position;
                    platL.transform.rotation = GTPlayer.Instance.leftControllerTransform.rotation;
                }
            }
            else
            {
                if (platL != null) GameObject.DestroyImmediate(platL);
            }
        }


        public static Vector3 fakePlatL;
        public static Vector3 fakePlatR;

        private static Vector3 lastRightPos;
        private static Vector3 lastLeftPos;

        public static void FakeStickyPlatforms() // im not bothered to make real sticky plats
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                if (fakePlatR == Vector3.zero)
                {
                    lastRightPos = GTPlayer.Instance.rightControllerTransform.position;
                }
                else
                {
                    Vector3 delta = GTPlayer.Instance.rightControllerTransform.position - lastRightPos;
                    GTPlayer.Instance.transform.position += delta;
                    lastRightPos = GTPlayer.Instance.rightControllerTransform.position;
                }
                fakePlatR = GTPlayer.Instance.rightControllerTransform.position;
            }
            else
            {
                fakePlatR = Vector3.zero;
            }
    
            if (ControllerInputPoller.instance.leftGrab)
            {
                if (fakePlatL == Vector3.zero)
                {
                    lastLeftPos = GTPlayer.Instance.leftControllerTransform.position;
                }
                else
                {
                    Vector3 delta = GTPlayer.Instance.leftControllerTransform.position - lastLeftPos;
                    GTPlayer.Instance.transform.position += delta;
                    lastLeftPos = GTPlayer.Instance.leftControllerTransform.position;
                }
                fakePlatL = GTPlayer.Instance.leftControllerTransform.position;
            }
            else
            {
                fakePlatL = Vector3.zero;
            }
        }
    }
}