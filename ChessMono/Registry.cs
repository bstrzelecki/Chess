using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMono
{
    class Registry
    {
        static MainMenu mainMenu = new MainMenu();

        public static void Init()
        {
            mainMenu.Init();
        } 
        public static void LoadContent(Game1 game)
        {
            game.Load("button");
            game.LoadFont("font");
        }
        public static void RegisterUpdates()
        {
            Game1.RegisterUpdate(mainMenu.startButton);
            Game1.RegisterUpdate(mainMenu.quitButton);
        }
        public static void RegisterRenderers()
        {
            Game1.RegisterRenderer(mainMenu);
        }
    }
}
