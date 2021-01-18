using System;

namespace SnakeConsoleApp
{
    public class UserIO
    {
        public UserIO()
        {
            Console.CursorVisible = false;
        }

        public bool TryGetDirection(out Direction direction)
        {
            Console.SetCursorPosition(0, 25);

            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(intercept: true);
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

        public void NotifyLoss()
        {
            Console.WriteLine("You lost!");
            Console.ReadKey();
        }
    }
}
