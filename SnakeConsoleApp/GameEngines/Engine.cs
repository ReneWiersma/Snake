using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Engine
    {
        private readonly GameState gameState;
        private readonly GameTimer gameTimer;
        private readonly IQuery<ICommand> getUserCommand;
        private readonly NotifyLossCommand notifyLoss;

        public Engine(GameState gameState, GameTimer gameTimer, IQuery<ICommand> getUserCommand, NotifyLossCommand notifyLoss)
        {
            this.gameState = gameState;
            this.gameTimer = gameTimer;
            this.getUserCommand = getUserCommand;
            this.notifyLoss = notifyLoss;
        }

        public async Task Run()
        {
            while (gameState.Continue)
            {
                await gameTimer.Delay();

                var userCommand = getUserCommand.Execute();

                userCommand.Execute();

                gameState.Update();
            }

            notifyLoss.Execute();
        }
    }
}