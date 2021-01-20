using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class SnakeBodyDrawer
    {
        const string snakeSymbol = "#";

        private readonly SnakeDirection snakeDirection;
        private readonly ConsoleDrawer drawer;

        public SnakeBodyDrawer(SnakeDirection snakeDirection, ConsoleDrawer drawer)
        {
            this.snakeDirection = snakeDirection;
            this.drawer = drawer;
        }

        public void Draw(IList<Position> positions)
        {
            drawer.Draw(positions[0], snakeDirection.SnakeHead);
            drawer.Draw(positions.Skip(1).ToList(), snakeSymbol);
        }

        public void Clear(IList<Position> positions) => drawer.Draw(positions, " ");
    }
}
