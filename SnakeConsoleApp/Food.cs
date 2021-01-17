using System;

namespace SnakeConsoleApp
{
    public class Food
    {
        private Position position;
        private readonly Grid grid;

        public Food(Grid grid)
        {
            this.grid = grid;

            New();
        }

        public bool IsAt(Position other) => position.Equals(other);

        void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write('%');
        }

        public void New()
        {
            position = grid.RandomPosition;
            Draw();
        }
    }
}
