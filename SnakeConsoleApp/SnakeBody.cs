using System;
using System.Collections.Generic;

namespace SnakeConsoleApp
{
    public class SnakeBody
    {
        private readonly List<Position> parts = new List<Position>();

        public SnakeBody(Position startPosition, int snakeLength)
        {
            for (int i = 0; i < snakeLength; i++)
                parts.Add(startPosition.Down(i));
        }

        public Position CurrentPosition => parts[0];

        public void Grow(Position position) => parts.Insert(0, position);

        public bool IsAt(Position other) => parts.Any(position => position.Equals(other));

        public void MoveTo(string snakeHead, Position position)
        {
            Clear();
            UpdatePosition(position);
            Draw(snakeHead);
        }

        private void UpdatePosition(Position position)
        {
            parts.Insert(0, position);
            parts.RemoveAt(parts.Count - 1);
        }

        private void Clear()
        {
            foreach (var pos in parts)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write(" ");
            }
        }

        private void Draw(string snakeHead)
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
    }
}
