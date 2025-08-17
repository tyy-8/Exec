using Photon.Pun;
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
                new ButtonInfo { buttonText = "Movement", isTogglable = false, method =() => Global.SwitchPage(5), toolTip = "Opens the movement page for the menu."},
                new ButtonInfo { buttonText = "Advantage", isTogglable = false, method =() => Global.SwitchPage(6), toolTip = "Opens the advantage page for the menu."},
                new ButtonInfo { buttonText = "Overpowered", isTogglable = false, method =() => Global.SwitchPage(7), toolTip = "Opens the overpowered page for the menu."},
                new ButtonInfo { buttonText = "Safety", isTogglable = false, method =() => Global.SwitchPage(8), toolTip = "Opens the safety page for the menu."},
                new ButtonInfo { buttonText = "Fun", isTogglable = false, method =() => Global.SwitchPage(9), toolTip = "Opens the fun page for the menu."},
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
                new ButtonInfo { buttonText = "Rounding", enableMethod =() => MenuUtilities.ChangeSetting(ref Main.rounding, true), disableMethod =() => MenuUtilities.ChangeSetting(ref Main.rounding, false), enabled = Main.rounding, toolTip = "Toggles the menu's rounding."},
                new ButtonInfo { buttonText = "Wide Menu", enableMethod =() => MenuUtilities.ChangeSetting(ref Main.wideMenu, true), disableMethod =() => MenuUtilities.ChangeSetting(ref Main.wideMenu, false), enabled = Main.wideMenu, toolTip = "Toggles the menu width."},
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
            
            new ButtonInfo[] { // Advantage [6]
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Tag Gun", method = Advantage.TagGun, toolTip = "Tags whoever you choose."},
                new ButtonInfo { buttonText = "Tag All", method = Advantage.TagAll, toolTip = "Tags everyone when holding right trigger."},
            },
            
            new ButtonInfo[] { // OP [7]
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Freeze Server", method =() => Overpowered.FreezeServer(), isTogglable = true, toolTip = "Freezes the entire server."},
            },
            
            new ButtonInfo[] { // Safety [8]
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Anti-Report [W?]", method =() => Safety.AntiReport(), isTogglable = true, toolTip = "Attempts to stop people from reporting you."},
            },
            
            new ButtonInfo[] { // Fun [9]
                new ButtonInfo { buttonText = "Return", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Opens the main page for the menu."},
                new ButtonInfo { buttonText = "Physics Doug [NW]", method =() => Fun.PhysicsBug(), disableMethod = Fun.OffPhysicsBug, isTogglable = true, toolTip = "Get ownership of the bug then this will work."},
                new ButtonInfo { buttonText = "Camera Hand", method =() => Fun.CameraHand(), isTogglable = true, toolTip = "Puts the LIV camera into your hand (SS). Grab camera first."},
                new ButtonInfo { buttonText = "Camera Aura", method =() => Fun.CameraAura(), isTogglable = true, toolTip = "Puts the LIV camera around you (SS). Grab camera first."},
                new ButtonInfo { buttonText = "Camera Aura Gun", method =() => Fun.CameraAuraGun(), isTogglable = true, toolTip = "Puts the LIV camera around others (SS). Grab camera first."},
                new ButtonInfo { buttonText = "Camera Bracelet", method =() => Fun.CameraBracelet(), isTogglable = true, toolTip = "Puts the LIV camera around your hand (SS). Grab camera first."},
                new ButtonInfo { buttonText = "Hide Camera", method =() => Fun.NoCamera(), isTogglable = true, toolTip = "Hides the LIV camera (SS). Grab camera first."},
            },
        };
    }
}
