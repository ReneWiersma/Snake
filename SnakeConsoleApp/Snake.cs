using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class Snake
    {
        private readonly List<Position> parts = new List<Position>();

        public Snake(Position position, int length)
        {
            for (int i = 0; i < length; i++)
                parts.Add(position.Down(i));
        }

        public Position CurrentPosition => parts[0];

        public Snake Grow(Position position)
        {
            parts.Insert(0, position);
            return this;
        }

        public bool IsAt(Position nextPosition) => 
            parts.Any(position => position.Equals(nextPosition));

        internal void Draw(string snakeHead)
        {
            foreach (var pos in parts)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("#");
            }
        }

        public void MoveTo(Position position)
        {
            parts.Insert(0, position);
            parts.RemoveAt(parts.Count - 1);
        }
    }
}
