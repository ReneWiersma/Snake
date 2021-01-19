using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class SnakeBodyDrawer
    {
        public void Draw(IList<Position> positions, string snakeHead)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                var pos = positions[i];

                Console.SetCursorPosition(pos.X, pos.Y);

                if (i == 0)
                    Console.Write(snakeHead);
                else
                    Console.Write("#");
            }
        }

        public void Clear(IList<Position> positions)
        {
            foreach (var position in positions)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write(" ");
            }
        }
    }

    public class SnakeBody
    {
        private readonly List<Position> parts = new List<Position>();
        private readonly SnakeBodyDrawer drawer;

        public SnakeBody(Position startPosition, int snakeLength, SnakeBodyDrawer drawer)
        {
            this.drawer = drawer;

            for (int i = 0; i < snakeLength; i++)
                parts.Add(startPosition.Down(i));
        }

        public Position CurrentPosition => parts[0];

        public void Grow(Position position) => parts.Insert(0, position);

        public bool IsAt(Position other) => parts.Any(position => position.Equals(other));

        public void MoveTo(string snakeHead, Position position)
        {
            drawer.Clear(parts);
            UpdatePosition(position);
            drawer.Draw(parts, snakeHead);
        }

        private void UpdatePosition(Position position)
        {
            parts.Insert(0, position);
            parts.RemoveAt(parts.Count - 1);
        }
    }
}
