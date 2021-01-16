using System;

namespace SnakeConsoleApp
{
    public class Food
    {
        private readonly Position position;

        public Food(Position position)
        {
            this.position = position;
        }

        public bool IsAt(Position other) => position.Equals(other);

        public void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write('%');
        }
    }
}
