using TysMenu.Classes;
using TysMenu.Mods;
using static TysMenu.Settings;

namespace TysMenu.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Movement", isTogglable = false, method =() => Global.SwitchPage(5)},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile Settings", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Projectile Settings [4]
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },
            
            new ButtonInfo[] { // Movement [5]
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Platforms", method =() => Movement.Platforms(), toolTip = "Spawns blocks that lets you walk in air with."},
                new ButtonInfo { buttonText = "Sticky Platforms", method =() => Movement.FakeStickyPlatforms(), toolTip = "Fake sticky plats (not bothered to make real ones)."},
                new ButtonInfo { buttonText = "Hand Fly", method =() => Movement.Fly(0,false), toolTip = "Allows you to fly with Right Grip."},
                new ButtonInfo { buttonText = "Physics Hand Fly", method =() => Movement.Fly(0,true), toolTip = "Allows you to fly with Right Grip."},
                new ButtonInfo { buttonText = "Head Fly", method =() => Movement.Fly(1,false), toolTip = "Allows you to fly with Right Grip."},
                new ButtonInfo { buttonText = "Physics Head Fly", method =() => Movement.Fly(1,true), toolTip = "Allows you to fly with Right Grip."},
                new ButtonInfo { buttonText = "Pull", method = Movement.Pull, toolTip = "Makes you go further when hitting the ground."},
            },
        };
    }
}
