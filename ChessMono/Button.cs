using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessMono
{
    class Button : IDrawable, IUpdateable
    {

        public event Action mouseLeftClick;
        public event Action mouseLeftHold;

        public string Text;
        public Rectangle Size;
        public Button(string text, Rectangle size)
        {
            Text = text;
            Size = size;
        }
        public Button(string text, int x, int y, int width, int height)
        {
            Text = text;
            Size = new Rectangle(x, y, width, height);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(Game1.textures["button"], Size, Color.White);
            sprite.DrawString(Game1.fonts["font"], Text, new Vector2(Size.X + 60, Size.Y + 15), Color.White);
        }
        bool isClicked;
        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            if (Size.Contains(mouse.Position) && mouse.LeftButton == ButtonState.Pressed)
            {
                mouseLeftHold?.Invoke();
                if (!isClicked)
                {
                    mouseLeftClick?.Invoke();
                    isClicked = true;
                }
            }
            if (mouse.LeftButton == ButtonState.Released)
                isClicked = false;

        }
    }
}
