using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessMono
{
    class Board : IDrawable, IUpdateable
    {
        public Piece[,] map = new Piece[8, 8];
        public Vector2 offset = new Vector2(18, 18);
        public void Init()
        {

        }
        public void Draw(SpriteBatch sprite)
        {
            for (int x = 0; x < 8; x++) {
                for (int y = 0; y < 0; y++) {
                    Piece piece = map[x, y];
                    sprite.Draw(Game1.textures[piece.color + "_" + piece.type], offset, Color.White);
                }
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
