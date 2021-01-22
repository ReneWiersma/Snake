using System.Threading.Tasks;

namespace SnakeConsoleApp
{
    public class Engine : IAsyncCommand
    {
        private readonly IQuery<bool> updateGameState;
        private readonly IAsyncCommand gameDelay;
        private readonly IQuery<ICommand> getUserCommand;
        private readonly ICommand notifyLoss;

        public Engine(IQuery<bool> updateGameState, IAsyncCommand gameDelay, IQuery<ICommand> getUserCommand, ICommand notifyLoss)
        {
            this.updateGameState = updateGameState;
            this.gameDelay = gameDelay;
            this.getUserCommand = getUserCommand;
            this.notifyLoss = notifyLoss;
        }

        public async Task Execute()
        {
            while (updateGameState.Execute())
            {
                await gameDelay.Execute();

                var userCommand = getUserCommand.Execute();

                userCommand.Execute();
            }

            notifyLoss.Execute();
        }
    }
}