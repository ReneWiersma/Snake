using System;

namespace SnakeConsoleApp
{
    public class GetUser : IQuery<ICommand>
    {
        private readonly Func<Direction, ICommand> createSnakeDirectionCommand;

        public GetUser(Func<Direction, ICommand> createSnakeDirectionCommand)
        {
            this.createSnakeDirectionCommand = createSnakeDirectionCommand;

            Console.CursorVisible = false;
        }

        public ICommand Execute()
        {
            Console.SetCursorPosition(0, 25);

            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(intercept: true);
                return ProcessInput(input.KeyChar);
            }
            else
            {
                return new EmptyCommand();
            }
        }

        ICommand ProcessInput(char input) => input switch
        {
            's' => createSnakeDirectionCommand(Direction.Down),
            'a' => createSnakeDirectionCommand(Direction.Left),
            'd' => createSnakeDirectionCommand(Direction.Right),
            'w' => createSnakeDirectionCommand(Direction.Up),
            _ => new EmptyCommand()
        };
    }
}
