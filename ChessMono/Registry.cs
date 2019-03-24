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
            mainMenu.board.Init();
        } 
        public static void LoadContent(Game1 game)
        {
            game.Load("button");
            game.Load("black_bishop");
            game.Load("black_king");
            game.Load("black_knight");
            game.Load("black_pawn");
            game.Load("black_queen");
            game.Load("black_rook");
            game.Load("white_bishop");
            game.Load("white_king");
            game.Load("white_pawn");
            game.Load("white_queen");
            game.Load("white_rook");
            game.Load("white_knight");
            game.Load("board");
            game.Load("numbers");
            game.Load("text");
            game.Load("bg");
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
