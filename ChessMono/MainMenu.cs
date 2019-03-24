using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMono
{
    class MainMenu : IDrawable
    {
        public Button startButton = new Button("Start", 20, 20, 150, 50);
        public Button quitButton = new Button("Quit", 20, 80, 150, 50);

        public void Init()
        {
            startButton.mouseLeftClick += StartButton_mouseLeftClick;
            quitButton.mouseLeftClick += QuitButton_mouseLeftClick;
        }

        private void QuitButton_mouseLeftClick()
        {
            Environment.Exit(0);
        }

        private void StartButton_mouseLeftClick()
        {
            
        }

        public void Draw(SpriteBatch sprite)
        {
            startButton.Draw(sprite);
            quitButton.Draw(sprite);
        }
    }
}
