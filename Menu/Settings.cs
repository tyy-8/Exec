using TysMenu.Classes;
using UnityEngine;
using static TysMenu.Menu.Main;

namespace TysMenu
{
    internal class Settings
    {
        public static ExtGradient backgroundColor = new ExtGradient {colors = GetSolidGradient(new Color32(50, 50, 120, 255)) };

        public static ExtGradient[] buttonColors = new ExtGradient[]
        {
            new ExtGradient
            {
                colors = GetSolidGradient(new Color32(70, 70, 140, 255)) // Disabled
            },
            new ExtGradient
            {
                colors = GetSolidGradient(new Color32(110, 110, 240, 255)) // Enabled
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
        public static Vector3 wideMenuSize = new Vector3(0.1f, 1.5f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 8;
    }
}
