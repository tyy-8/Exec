using TysMenu.Classes;
using UnityEngine;
using static TysMenu.Menu.Main;

namespace TysMenu
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient {colors = GetSolidGradient(new Color32(120, 30, 40, 255)) };

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient
            {
                colors = GetSolidGradient(new Color32(140, 70, 70, 255)) // Disabled
            },
            new ExtGradient
            {
                colors = GetSolidGradient(new Color32(240, 110, 110, 255)) // Enabled
            }
        };

        public static Color[] textColors = new Color[]
        {
            Color.white, // Disabled
            Color.white // Enabled
        };

        public static Font currentFont = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = false;

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 8;
    }
}
