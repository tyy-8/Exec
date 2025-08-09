using static TysMenu.Menu.Main;

namespace TysMenu.Mods
{
    internal class Global
    {
        public static void ReturnHome()
        {
            buttonsType = 0;
            pageNumber = 0;
        }
        public static void SwitchPage(int i)
        {
            buttonsType = i;
            pageNumber = 0;
        }
    }
}
