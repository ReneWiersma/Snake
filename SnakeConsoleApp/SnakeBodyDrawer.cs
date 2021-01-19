using System;
using System.Collections.Generic;

namespace SnakeConsoleApp
{
    public class SnakeBodyDrawer
    {
        private readonly SnakeDirection snakeDirection;

        public SnakeBodyDrawer(SnakeDirection snakeDirection)
        {
            this.snakeDirection = snakeDirection;
        }

        public void Draw(IList<Position> positions)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                var pos = positions[i];

                Console.SetCursorPosition(pos.X, pos.Y);

                if (i == 0)
                    Console.Write(snakeDirection.SnakeHead);
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
}
