using System;
using System.Collections.Generic;

namespace SnakeConsoleApp
{
    public class MazeDrawer
    {
        public void Draw(IList<Position> positions)
        {
            foreach (var position in positions)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write("*");
            }
        }
    }
}
