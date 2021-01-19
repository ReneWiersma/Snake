using System;

namespace SnakeConsoleApp
{
    public class FoodDrawer 
    {
        public void Draw(Position position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write('%');
        }
    }
}
