namespace SnakeConsoleApp
{
    public class Cell
    {
        public string Symbol
        {
            get;
            set;
        }

        public bool IsSnake
        {
            get;
            set;
        }

        public int Decay
        {
            get;
            set;
        }

        public void DecaySnake()
        {
            Decay -= 1;
            if (Decay == 0)
            {
                IsSnake = false;
                Symbol = " ";
            }
        }
    }
}