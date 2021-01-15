namespace SnakeConsoleApp
{
    partial class Program
    {
        public class Cell
        {
            public string Val
            {
                get;
                set;
            }
            public int X
            {
                get;
                set;
            }
            public int Y
            {
                get;
                set;
            }
            public bool Visited
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
                    Visited = false;
                    Val = " ";
                }
            }

            public void Clear()
            {
                Val = " ";
            }

            public void Set(string newVal)
            {
                Val = newVal;
            }
        }
    }
}