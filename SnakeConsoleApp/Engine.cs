using System;
using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Engine
    {
        private readonly GameState gameState;
        private readonly GameTimer timer;
        private readonly Input input;

        public Engine(GameState gameState, GameTimer timer, Input input)
        {
            this.gameState = gameState;
            this.timer = timer;
            this.input = input;
        }

        public async Task Run()
        {
            while (gameState.Continue)
            {
                await timer.Delay();

                if (input.TryGetDirection(out var direction))
                    gameState.ChangeSnakeDirection(direction);

                gameState.Update();
            }

            Console.WriteLine("You lost!");
            Console.ReadKey();
        }
    }
}