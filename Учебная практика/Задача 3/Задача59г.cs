using System;
using Library_Functions;

namespace Задача_3
{
    class Задача59г
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tДанная программа определяет принадлежит ли ваша точка заданной области");
            Console.WriteLine("\n\tЕсли точка принадлежит области или лежит вне её, программа выдаст соотвествующее сообщение об этом");
            Console.WriteLine("\n\tВвод координаты x");
            Functions.ReadDouble(out double x);
            Console.WriteLine("\n\tВвод координаты y");
            Functions.ReadDouble(out double y);
            if (x >= -1 &&
                x <= 1 &&
                y >= -1 &&
                y <= 1 &&
                x + y >= -1 &&
                x + y <= 1)
            {
                Console.WriteLine("\n\tТочка ({0} , {1}) принадлежит заданной области", x, y);
            }
            else
            {
                Console.WriteLine("\n\tТочка ({0} , {1}) не лежит в заданной области", x, y);
            }

            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
