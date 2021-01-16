namespace SnakeConsoleApp
{
    public class Cell
    {
        public string Val
        {
            get;
            set;
        }

        public bool IsSnakeTail
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
                IsSnakeTail = false;
                Val = " ";
            }
        }
    }
}