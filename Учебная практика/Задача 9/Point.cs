using System;

namespace Задача_9
{
    class Point
    {
        private int _number;

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public Point Next;

        public Point()
        {
            Next = null;
            Number = 0;
        }

        public Point(int number)
        {
            Next = null;
            Number = number;
        }
    }
}
