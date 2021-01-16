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

        public void Draw(string snakeHead)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                var pos = parts[i];

                Console.SetCursorPosition(pos.X, pos.Y);

                if (i == 0)
                    Console.Write(snakeHead);
                else
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
