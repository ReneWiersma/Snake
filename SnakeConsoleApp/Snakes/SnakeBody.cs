using System.Collections.Generic;
using System.Linq;

namespace SnakeConsoleApp
{
    public class SnakeBody
    {
        private readonly List<Position> parts = new List<Position>();
        private readonly SnakeBodyDrawer drawer;

        public SnakeBody(Position startPosition, int snakeLength, SnakeBodyDrawer drawer)
        {
            this.drawer = drawer;

            for (int i = 0; i < snakeLength; i++)
                parts.Add(startPosition.Down(i));
        }

        public Position CurrentPosition => parts[0];

        public void Grow(Position position) => parts.Insert(0, position);

        public bool IsAt(Position other) => parts.Any(position => position.Equals(other));

        public void MoveTo(Position position)
        {
            MoveHead(position);
            RemoveTail();
            
            drawer.Draw(parts);
        }

        private void MoveHead(Position position) => parts.Insert(0, position);

        private void RemoveTail() => parts.RemoveAt(parts.Count - 1);
    }
}
