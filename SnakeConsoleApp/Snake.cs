using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class Snake
    {
        const int startLength = 5;

        private readonly List<Position> parts = new List<Position>();
        private readonly SnakeDirection snakeDirection = new SnakeDirection();
        private readonly Maze maze;

        public Snake(Maze maze)
        {
            this.maze = maze;

            var startPosition = maze.Center;

            for (int i = 0; i < startLength; i++)
                parts.Add(startPosition.Down(i));
        }

        Position CurrentPosition => parts[0];

        public void Grow() => parts.Insert(0, NextPosition);

        public bool IsAt(Position nextPosition) =>
            parts.Any(position => position.Equals(nextPosition));

        private void Draw()
        {
            for (int i = 0; i < parts.Count; i++)
            {
                var pos = parts[i];

                Console.SetCursorPosition(pos.X, pos.Y);

                if (i == 0)
                    Console.Write(snakeDirection.SnakeHead);
                else
                    Console.Write("#");
            }
        }

        public bool Eats(Food food) => food.IsAt(NextPosition);

        public bool Collides => maze.IsWallAt(NextPosition) || this.IsAt(NextPosition);

        public void ChangeDirection(Direction newDirection) => snakeDirection.Change(newDirection);

        Position NextPosition => snakeDirection.NextPosition(CurrentPosition);

        public void Move()
        {
            Clear();
            UpdatePosition();
            Draw();
        }

        private void UpdatePosition()
        {
            parts.Insert(0, NextPosition);
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
    }
}
