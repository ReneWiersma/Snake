namespace SnakeConsoleApp
{
    public class Food
    {
        private Position position;
        private readonly FreePositions freePositions;
        private readonly FoodDrawer drawer;

        public Food(FreePositions freePositions, FoodDrawer drawer)
        {
            this.freePositions = freePositions;
            this.drawer = drawer;

            Regenerate();
        }

        public bool IsAt(Position other) => position.Equals(other);

        public void Regenerate()
        {
            position = freePositions.GetRandom();
            drawer.Draw(position);
        }
    }
}
