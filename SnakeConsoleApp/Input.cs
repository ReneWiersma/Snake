using System;

namespace SnakeConsoleApp
{
    public class Input
    {
        public Input()
        {
            Console.CursorVisible = false;
        }

        public bool TryGetDirection(out Direction direction)
        {
            Console.SetCursorPosition(0, 25);

            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey();
                direction = ProcessInput(input.KeyChar);
                return true;
            }
            else
            {
                direction = Direction.Up;
                return false;
            }
        }

        Direction ProcessInput(char input) => input switch
        {
            's' => Direction.Down,
            'a' => Direction.Left,
            'd' => Direction.Right,
            'w' => Direction.Up,
            _ => Direction.Up,
        };
    }
}
