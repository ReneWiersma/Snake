using System;
using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Engine
    {
        private readonly GameState gameState;
        readonly GameTimer timer;
        readonly Input input;

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
                await timer.Pause();

                if (input.TryGetDirection(out var direction))
                    gameState.ChangeSnakeDirection(direction);

                gameState.Update();
            }

            Console.WriteLine("You lost!");
            Console.ReadKey();
        }
    }
}