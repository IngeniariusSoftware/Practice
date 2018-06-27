using System;
using Library_Functions;

namespace Задача_10
{
    class Задача12
    {
        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n"
                + "\n\tданы натуральное число n, действительные числа x1, ..., хn.\n"
                + "\n\tВычислить: а) х1 * хn + x2 * xn-1 + ... + хn * x1");
            Console.WriteLine("\n\tВвод длины последовательности чисел");
            Functions.ReadNatural(out int sequenceLength);
            double[] sequence = new double[sequenceLength];
            for (int index = 0; index < sequenceLength; index++)
            {
                Console.WriteLine("\n\tВвод {0} члена последовательности", index + 1);
                Functions.ReadDouble(out sequence[index]);
            }

            Console.WriteLine("\n\tПоследовательность имеет вид:\n");
            Console.Write("\t" + "");
            for (int index = 0; index < sequenceLength; index++)
            {
                Console.Write("[{0}] ", sequence[index]);
            }

            Console.WriteLine();
            double sum = 0;
            for (int index = 0; index < (sequenceLength) / 2; index++)
            {
                sum += sequence[index] * sequence[sequenceLength - 1 - index] * 2;
            }

            if (sequenceLength % 2 == 1)
            {
                sum += sequence[sequenceLength / 2] * sequence[sequenceLength / 2];
            }

            Console.WriteLine("\n\tСумма произведений равна: {0}", sum);
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
