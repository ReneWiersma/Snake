using System;

namespace SnakeConsoleApp
{
    public class Snake
    {
        public static Snake Create() => new Snake(length: 5);
        
        public int Length { get; }

        Snake(int length)
        {
            Length = length;
        }

        public Snake Grow() => new Snake(Length + 1);
    }
}
