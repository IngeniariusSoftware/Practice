using System;

namespace Задача_4
{
    class Задача587
    {
        public static int[] TransferringNumber(double numberX, int radix)
        {
            int[] numbers = new int[5];
            for (int index = 0; index < numbers.Length; index++)
            {
                numberX = (numberX - (int)numberX) * radix;
                numbers[index] = (int)numberX;
            }

            return numbers;
        }

        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n"
                + "\n\tДаны действительное число х, натуральное число q (0 <= х < 1, q >= 2).\n"
                + "\n\tПолучить пять цифр q-ичного представления числа х,\n"
                + "\n\tт. е. получить последовательность целых неотрицательных a(-1), ... a(-5) такую,\n"
                + "\n\tчто x = a(-1) * q^-1 + ... + a(-5) * q^-5 + r, (r < q^-5).");
            Console.WriteLine("\n\tВвод числа x");
            double number;
            bool rightX;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите действительное число в диапозоне [0;1)");
                rightX = double.TryParse(Console.ReadLine(), out number) && number >= 0 && number < 1;
                if (!rightX)
                {
                    Console.WriteLine(
                        "\n\t\aК сожалению, вы ввели что-то не так. Ожидалось действительное число в диапозоне [0;1)");
                    Console.WriteLine("\n\tЭто любое число меньшее 1 и большее или равное 0");
                }
            }
            while (!rightX);

            Console.WriteLine("\n\tВвод основания системы счисления");
            int radix;
            bool rightRadix;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите целое число большее 1");
                rightRadix = int.TryParse(Console.ReadLine(), out radix) && radix > 1;
                if (!rightRadix)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось целое число большее 1");
                }
            }
            while (!rightRadix);

            int[] numbers = TransferringNumber(number, radix);
            string strNumber = "";
            foreach (int num in numbers)
            {
                strNumber += num;
            }

            Console.WriteLine(
                "\n\tЧисло {0} в {1} - ичном представлении с точностью в 5 разрядов: 0,{2}",
                number,
                radix,
                strNumber);

            Console.WriteLine("\n\tИное представление:");
            for (int index = 0; index < numbers.Length; index++)
            {
                Console.Write("\n\t[a{0}] = {1}\n", index + 1, numbers[index]);
            }

            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
