﻿using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Engine
    {
        private readonly GameState gameState;
        private readonly GameTimer gameTimer;
        private readonly UserIO userIO;

        public Engine(GameState gameState, GameTimer gameTimer, UserIO userIO)
        {
            this.gameState = gameState;
            this.gameTimer = gameTimer;
            this.userIO = userIO;
        }

        public async Task Run()
        {
            while (gameState.Continue)
            {
                await gameTimer.Delay();

                var userCommand = userIO.GetUserCommand();

                userCommand.Execute();

                gameState.Update();
            }

            userIO.NotifyLoss();
        }
    }
}