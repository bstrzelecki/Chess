using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMono
{
    class Piece
    {
        public string type;
        public string color;
        public bool isEmpty;
        public Piece()
        {
            isEmpty = true;
        }
        public Piece(string t, bool isWhite)
        {
            type = t;
            color = isWhite ? "white" : "black";
        }
        private bool isPawnFirstMove = true;
        public List<Vector2> getMoves(Vector2 position, Piece[,] map)
        {
            List<Vector2> tiles = new List<Vector2>();

            if(type == "pawn")
            {
                if (color == "white") {
                    if (map[(int)position.X, (int)position.Y - 1].isEmpty)
                        tiles.Add(new Vector2(position.X, position.Y - 1));
                    else return tiles;
                    if (map[(int)position.X, (int)position.Y - 2].isEmpty)
                        tiles.Add(new Vector2(position.X, position.Y - 2));
                }
                if (color == "black")
                {
                    if (map[(int)position.X, (int)position.Y + 1].isEmpty)
                        tiles.Add(new Vector2(position.X, position.Y + 1));
                    else return tiles;
                    if (map[(int)position.X, (int)position.Y + 2].isEmpty)
                        tiles.Add(new Vector2(position.X, position.Y + 2));
                }
            }

            return tiles;
        }
    }
}
