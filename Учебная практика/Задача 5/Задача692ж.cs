using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Functions;

namespace Задача_5
{

    class Задача692ж
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\n\tДанная программа ищет максимальный элемент в заданной области данной матрицы");
            Console.WriteLine("\n\tВвод размера матрицы");
            Functions.ReadNatural(out int masSize);
            double[,] mas = new double[masSize, masSize];

            Console.WriteLine("\n\tКаким образом заполнить массив?");
            Console.WriteLine("\n\t1 - случайно");
            Console.WriteLine("\n\t2 - вручную");
            int answer = Functions.ReadAnswer(1, 2);
            if (answer == 1)
            {
                Console.WriteLine("\n\tЗаоплнение элементов массива случайным образом");
                for (int indexY = 0; indexY < masSize; indexY++)
                {
                    for (int indexX = 0; indexX < masSize; indexX++)
                    {
                        mas[indexY, indexX] = Functions.Rnd.Next(-100, 101);
                    }
                }

                Console.WriteLine("\n\tМассив успешно заполнен");
            }
            else
            {
                Console.WriteLine("\n\tВвод элементов матрицы вручную");
                for (int indexY = 0; indexY < masSize; indexY++)
                {
                    for (int indexX = 0; indexX < masSize; indexX++)
                    {
                        Functions.ReadDouble(out mas[indexY, indexX]);
                    }
                }
            }

            Console.WriteLine("\n\t Зелёным цветом отмечена заданная область");
            Console.WriteLine("\n\tМассив имеет вид:\n");
            for (int indexY = 0; indexY < masSize; indexY++)
            {
                Console.Write("\t");
                for (int indexX = 0; indexX < masSize; indexX++)
                {
                    if (indexY <= masSize / 2 && indexX > indexY
                        || indexY > masSize / 2 && indexX > masSize - indexY - 1)
                    {
                        Console.Write("{0,5} ", mas[indexY, indexX]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0,5} ", mas[indexY, indexX]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }

                Console.WriteLine("\n");
            }

            double max = mas[0, 0];
            for (int indexY = 0; indexY < masSize; indexY++)
            {
                if (indexY <= masSize / 2)
                {
                    for (int indexX = 0; indexX <= indexY; indexX++)
                    {
                        if (max < mas[indexY, indexX])
                        {
                            max = mas[indexY, indexX];
                        }
                    }
                }
                else
                {
                    for (int indexX = 0; indexX <= masSize - indexY - 1; indexX++)
                    {
                        if (max < mas[indexY, indexX])
                        {
                            max = mas[indexY, indexX];
                        }
                    }
                }
            }

            Console.WriteLine($"\n\tМаксимальный элемент в заданной области данной матрице: {max}");
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
