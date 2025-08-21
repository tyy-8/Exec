using GorillaLocomotion;
using TysMenu.Menu;
using UnityEngine;

namespace TysMenu.Mods
{
    public class Movement
    {
        public static void Fly(int flyMode) // 0 is hand fly, 1 is head fly
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                bool physics = Main.GetIndex("Physics Fly").enabled;
                switch (flyMode)
                {
                    case 0:
                        if (physics)
                            GorillaLocomotion.GTPlayer.Instance.AddForce(GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.forward * 10 + new Vector3(0,9.81f,0), ForceMode.Acceleration);
                        if (!physics)
                            GorillaLocomotion.GTPlayer.Instance.transform.position +=
                                GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.forward * 0.3f;
                        break;
                    
                    case 1:
                        if (physics)
                            GorillaLocomotion.GTPlayer.Instance.AddForce(Camera.main.transform.forward * 10 + new Vector3(0,9.81f,0), ForceMode.Acceleration);
                        if (!physics)
                            GorillaLocomotion.GTPlayer.Instance.transform.position +=
                                Camera.main.transform.forward * 0.3f;

                        break;
                }
            }
        }
        static bool lastTouch;
        public static void Pull() // I've never actually made one of these, prob will suck ass.
        {
            if (GTPlayer.Instance.IsHandTouching(false) ||
                GTPlayer.Instance.IsHandTouching(true))
            {
                if (!lastTouch)
                {
                    GTPlayer.Instance.transform.position += new Vector3(GorillaTagger.Instance.rigidbody.velocity.x * 0.04f, 0, GorillaTagger.Instance.rigidbody.velocity.z * 0.04f);
                    lastTouch = true;
                }
            }
            else
            {
                lastTouch = false;
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
                    platR.GetComponent<Renderer>().material.color = Color.gray;
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
                    platL.GetComponent<Renderer>().material.color = Color.gray;
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

        public static void FakeStickyPlatforms()
        {
            Vector3 totalDelta = Vector3.zero;

            if (ControllerInputPoller.instance.rightGrab)
            {
                Vector3 currentRight = GTPlayer.Instance.rightControllerTransform.position;
                if (fakePlatR == Vector3.zero)
                {
                    lastRightPos = currentRight;
                }
                else
                {
                    totalDelta += currentRight - lastRightPos;
                    lastRightPos = currentRight;
                }
                fakePlatR = currentRight;
            }
            else
            {
                fakePlatR = Vector3.zero;
            }

            if (ControllerInputPoller.instance.leftGrab)
            {
                Vector3 currentLeft = GTPlayer.Instance.leftControllerTransform.position;
                if (fakePlatL == Vector3.zero)
                {
                    lastLeftPos = currentLeft;
                }
                else
                {
                    totalDelta += currentLeft - lastLeftPos;
                    lastLeftPos = currentLeft;
                }
                fakePlatL = currentLeft;
            }
            else
            {
                fakePlatL = Vector3.zero;
            }

            if (totalDelta != Vector3.zero)
            {
                GTPlayer.Instance.transform.position += totalDelta;
            }
        }

    }
}