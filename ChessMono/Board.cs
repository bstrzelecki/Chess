using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ChessMono
{
    class Board : IDrawable, IUpdateable
    {
        public Piece[,] map = new Piece[8, 8];
        public Vector2 offset = new Vector2(22, 22);
        public Vector2 selectedPiece;
        bool isWhiteTurn = true;
        public void Init()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    map[x, y] = new Piece();
                }
            }
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if(y == 0)
                    {
                        map[0, y] = new Piece("rook", false);
                        map[1, y] = new Piece("knight", false);
                        map[2, y] = new Piece("bishop", false);
                        map[3, y] = new Piece("queen", false);
                        map[4, y] = new Piece("king", false);
                        map[5, y] = new Piece("bishop", false);
                        map[6, y] = new Piece("knight", false);
                        map[7, y] = new Piece("rook", false);
                    }
                    if(y == 1)
                    {
                        map[x, y] = new Piece("pawn", false);
                    }
                    if(y == 6)
                    {
                        map[x, y] = new Piece("pawn", true);
                    }
                    if(y == 7)
                    {
                        map[0, y] = new Piece("rook", true);
                        map[1, y] = new Piece("knight", true);
                        map[2, y] = new Piece("bishop", true);
                        map[3, y] = new Piece("queen", true);
                        map[4, y] = new Piece("king", true);
                        map[5, y] = new Piece("bishop", true);
                        map[6, y] = new Piece("knight", true);
                        map[7, y] = new Piece("rook", true);
                    }
                }
            }
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(Game1.textures["numbers"], new Vector2(0, 10), Color.White);
            sprite.Draw(Game1.textures["board"], new Vector2(7, 0), Color.White);
            sprite.Draw(Game1.textures["text"], new Vector2(16, 180), Color.White);
            for (int x = 0; x < 8; x++) {
                for (int y = 0; y < 8; y++) {
                    Piece piece = map[x, y]??new Piece();
                    if (!piece.isEmpty)
                    {
                        if (isPicking && selectedPiece == new Vector2(x, y))
                        {
                            sprite.Draw(Game1.textures[piece.color + "_" + piece.type], new Vector2(this.x * offset.X + 6,this.y *offset.Y + 4), Color.White);
                        }
                        else
                        {
                            sprite.Draw(Game1.textures[piece.color + "_" + piece.type], new Vector2(12 + offset.X * x, 4 + offset.Y * y), Color.White);
                        }
                        
                    }
                }
            }
            foreach (Vector2 pos in moves)
            {
                sprite.Draw(Game1.textures["dot"], new Vector2(16 + offset.X * pos.X, 8 + offset.Y * pos.Y), Color.White);
            }
        }
        int x, y;
        bool isPicking;
        protected List<Vector2> moves = new List<Vector2>();
        public void Update()
        {
            if (Registry.currentScene != 1) return;
            MouseState mouse = Mouse.GetState();
            x = mouse.X;
            y = mouse.Y;

            x = (x - 10) / 22;
            y = (y - 2) /  22;

            if(mouse.LeftButton == ButtonState.Pressed && !isPicking)
            {
                if ((isWhiteTurn && map[x, y].isWhite)||(!isWhiteTurn && !map[x, y].isWhite)) {
                    moves = map[x, y].getMoves(new Vector2(x, y), map);
                    selectedPiece = new Vector2(x, y);
                    isPicking = true;
                }
            }

            if (mouse.LeftButton == ButtonState.Released && isPicking)
            {
                if(moves.Contains(new Vector2(x, y)))
                {
                    map[x, y] = map[(int)selectedPiece.X, (int)selectedPiece.Y];
                    map[(int)selectedPiece.X, (int)selectedPiece.Y] = new Piece();
                    map[x, y].isPawnFirstMove = false;
                    isWhiteTurn = !isWhiteTurn;
                }
                moves = new List<Vector2>();
                isPicking =false;
            }

        }
    }
}
