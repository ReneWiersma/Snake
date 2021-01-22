using System;

namespace SnakeConsoleApp
{
    public class NotifyLoss : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("You lost!");
            Console.ReadKey();
        }
    }
}
