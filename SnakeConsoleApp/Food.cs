﻿using System;

namespace SnakeConsoleApp
{
    public class Food
    {
        private Position position;

        public Food(Position position)
        {
            this.position = position;

            Draw();
        }

        public bool IsAt(Position other) => position.Equals(other);

        public void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write('%');
        }

        public void Update(Position newPosition)
        {
            position = newPosition;
        }
    }
}
