using System.Collections.Generic;

namespace SnakeConsoleApp
{
    public class MazeDrawer
    {
        const string wallSymbol = "*";

        private readonly ConsoleDrawer drawer;

        public MazeDrawer(ConsoleDrawer drawer)
        {
            this.drawer = drawer;
        }

        public void Draw(IList<Position> positions) => drawer.Draw(positions, wallSymbol);
    }
}
