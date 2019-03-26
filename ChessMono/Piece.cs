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
        public bool isWhite = true;
        public Piece()
        {
            isEmpty = true;
        }
        public Piece(string t, bool isWhite)
        {
            type = t;
            color = isWhite ? "white" : "black";
            this.isWhite = isWhite;
        }
        public bool isPawnFirstMove = true;
        public List<Vector2> getMoves(Vector2 position, Piece[,] map)
        {
            List<Vector2> tiles = new List<Vector2>();

            if(type == "pawn")
            {
                if (color == "white") {
                    if (position.Y == 0) return tiles;
                    if (isWhite != map[(int)position.X - 1, (int)position.Y - 1].isWhite && !map[(int)position.X - 1, (int)position.Y - 1].isEmpty)
                        tiles.Add(new Vector2((int)position.X - 1, (int)position.Y - 1));
                    if (isWhite != map[(int)position.X + 1, (int)position.Y - 1].isWhite && !map[(int)position.X + 1, (int)position.Y - 1].isEmpty)
                        tiles.Add(new Vector2((int)position.X + 1, (int)position.Y - 1));
                    if (map[(int)position.X, (int)position.Y - 1].isEmpty)
                        tiles.Add(new Vector2(position.X, position.Y - 1));
                    else return tiles;
                    if (map[(int)position.X, (int)position.Y - 2].isEmpty && isPawnFirstMove)
                        tiles.Add(new Vector2(position.X, position.Y - 2));

                }
                if (color == "black")
                {
                    if (position.Y == 7) return tiles;
                    if (isWhite != map[(int)position.X - 1, (int)position.Y + 1].isWhite && !map[(int)position.X - 1, (int)position.Y + 1].isEmpty)
                        tiles.Add(new Vector2((int)position.X - 1, (int)position.Y + 1));
                    if (isWhite != map[(int)position.X + 1, (int)position.Y + 1].isWhite && !map[(int)position.X + 1, (int)position.Y + 1].isEmpty)
                        tiles.Add(new Vector2((int)position.X + 1, (int)position.Y + 1));
                    if (map[(int)position.X, (int)position.Y + 1].isEmpty)
                        tiles.Add(new Vector2(position.X, position.Y + 1));
                    else return tiles;
                    if (map[(int)position.X, (int)position.Y + 2].isEmpty && isPawnFirstMove)
                        tiles.Add(new Vector2(position.X, position.Y + 2));
                }
            }
            //END Pawn
            if(type == "knight")
            {
                if (checkTile(new Vector2(position.X - 2, position.Y - 1), map))
                    tiles.Add(new Vector2(position.X - 2, position.Y - 1));
                if (checkTile(new Vector2(position.X - 1, position.Y - 2), map))
                    tiles.Add(new Vector2(position.X - 1, position.Y - 2));
                if (checkTile(new Vector2(position.X + 2, position.Y - 1), map))
                    tiles.Add(new Vector2(position.X + 2, position.Y - 1));
                if (checkTile(new Vector2(position.X + 1, position.Y - 2), map))
                    tiles.Add(new Vector2(position.X + 1, position.Y - 2));
                if (checkTile(new Vector2(position.X - 2, position.Y + 1), map))
                    tiles.Add(new Vector2(position.X - 2, position.Y + 1));
                if (checkTile(new Vector2(position.X - 1, position.Y + 2), map))
                    tiles.Add(new Vector2(position.X - 1, position.Y + 2));
                if (checkTile(new Vector2(position.X + 1, position.Y + 2), map))
                    tiles.Add(new Vector2(position.X + 1, position.Y + 2));
                if (checkTile(new Vector2(position.X + 2, position.Y + 1), map))
                    tiles.Add(new Vector2(position.X + 2, position.Y + 1));
            }
            if(type == "king")
            {
                tiles = checkAndAdd(new Vector2(position.X - 1, position.Y - 1), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X, position.Y - 1), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X + 1, position.Y - 1), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X - 1, position.Y ), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X + 1, position.Y ), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X -1, position.Y + 1), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X + 1, position.Y + 1), map, tiles);
                tiles = checkAndAdd(new Vector2(position.X, position.Y + 1), map, tiles);
            }
            return tiles;
        }
        public bool checkTile(Vector2 position , Piece[,] map)
        {
            if (position.X > 7 || position.X < 0) return false;
            if (position.Y > 7 || position.Y < 0) return false;
            
            if (isWhite != map[(int)position.X, (int)position.Y].isWhite || map[(int)position.X, (int)position.Y].isEmpty) { return true; }
            return false;
        }
        public List<Vector2> checkAndAdd(Vector2 position, Piece[,] map,List<Vector2> tiles)
        {
            if (checkTile(position, map))
                tiles.Add(position);
            return tiles;
        }
    }
}
