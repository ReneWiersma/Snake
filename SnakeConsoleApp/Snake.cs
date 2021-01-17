using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class Snake
    {
        private readonly List<Position> parts = new List<Position>();

        private Direction direction = Direction.Up;

        public Snake(Position position, int length)
        {
            for (int i = 0; i < length; i++)
                parts.Add(position.Down(i));
        }

        Position CurrentPosition => parts[0];

        public Snake Grow()
        {
            parts.Insert(0, NextPosition);
            return this;
        }

        public bool IsAt(Position nextPosition) => 
            parts.Any(position => position.Equals(nextPosition));

        public void Draw()
        {
            for (int i = 0; i < parts.Count; i++)
            {
                var pos = parts[i];

                Console.SetCursorPosition(pos.X, pos.Y);

                if (i == 0)
                    Console.Write(SnakeHead);
                else
                    Console.Write("#");
            }
        }

        public bool Eats(Food food) => food.IsAt(NextPosition);

        public bool Collides(Grid grid) => grid.IsWallAt(NextPosition) || this.IsAt(NextPosition);

        public void ChangeDirection(Direction newDirection)
        {
            if (RightAngled(newDirection))
                direction = newDirection;
        }

        bool RightAngled(Direction newDirection) => direction switch
        {
            Direction.Left or Direction.Right => newDirection is Direction.Up or Direction.Down,
            Direction.Up or Direction.Down => newDirection is Direction.Left or Direction.Right,
            _ => false,
        };

        Position NextPosition => direction switch
        {
            Direction.Left => CurrentPosition.Left(),
            Direction.Down => CurrentPosition.Down(),
            Direction.Right => CurrentPosition.Right(),
            _ => CurrentPosition.Up(),
        };

        string SnakeHead => direction switch
        {
            Direction.Left => "<",
            Direction.Down => "v",
            Direction.Right => ">",
            _ => "^",
        };

        public void Move()
        {
            parts.Insert(0, NextPosition);
            parts.RemoveAt(parts.Count - 1);
        }

        public void Clear()
        {
            foreach (var pos in parts)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write(" ");
            }
        }
    }
}
