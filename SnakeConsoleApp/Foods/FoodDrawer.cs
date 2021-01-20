namespace SnakeConsoleApp
{
    public class FoodDrawer 
    {
        const string foodSymbol = "%";
        
        private readonly ConsoleDrawer drawer;

        public FoodDrawer(ConsoleDrawer drawer)
        {
            this.drawer = drawer;
        }

        public void Draw(Position position) => drawer.Draw(position, foodSymbol);
    }
}
