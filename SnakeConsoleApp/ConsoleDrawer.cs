using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class ConsoleDrawer
    {
        public void Draw(IList<Position> positions, string text) => 
            positions.ToList().ForEach(position => Draw(position, text));

        public void Draw(Position position, string text)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(text);
        }
    }
}