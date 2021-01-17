using System;

namespace SnakeConsoleApp
{
    public class Food
    {
        private Position position;
        private readonly Maze maze;

        public Food(Maze maze)
        {
            this.maze = maze;

            Regenerate();
        }

        public bool IsAt(Position other) => position.Equals(other);

        void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write('%');
        }

        public void Regenerate()
        {
            position = maze.RandomPosition;
            Draw();
        }
    }
}
