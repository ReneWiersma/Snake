using System;

namespace SnakeConsoleApp
{
    public class Food
    {
        private Position position;
        private readonly FreePositions freePositions;

        public Food(FreePositions freePositions)
        {
            this.freePositions = freePositions;
            
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
            position = freePositions.GetRandom();
            Draw();
        }
    }
}
