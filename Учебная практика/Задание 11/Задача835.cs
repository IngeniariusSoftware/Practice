using System;
using Library_Functions;
using System.Text.RegularExpressions;

namespace Задание_11
{

    class Задача835
    {
        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n"
                + "\n\tМожно обобщить способ шифровки, изложенный в предыдущей задаче—сдвиг\n"
                + "\n\tпроизводится не на одну букву, а на п букв, где п—данное натуральное число\n"
                + "\n\t(можно представлять себе, что буквы выписаны по кругу, как цифры на циферблате).\n"
                + "\n\tВыполнить задания а), б) предыдущей задачи, используя это обобщение.");
            Console.WriteLine("\n\tПожалуйста, введите текст на русском языке");
            char[] input = Console.ReadLine().ToCharArray();
            Console.WriteLine("\n\tВвод количества сдвигов для букв");
            Functions.ReadNatural(out int shift);
            Regex rusReg = new Regex(@"[а-яА-я]{1}");
            if (shift >= 32)
            {
                shift = shift % 32;
            }

            Console.WriteLine("\n\tШифрование");
            for (int index = 0; index < input.Length; index++)
            {
                if (rusReg.IsMatch(input[index].ToString()))
                {
                    int code = input[index] + shift;
                    if (input[index] <= 1071 && code > 1071 || input[index] <= 1103 && code > 1103)
                    {
                        code -= 32;
                    }

                    input[index] = (char)code;
                }
            }

            Console.WriteLine("\n\tСтрока имеет вид:\n");
            Console.Write("\t");
            foreach (char symbol in input)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
            Console.WriteLine("\n\tДешифровка");
            for (int index = 0; index < input.Length; index++)
            {
                if (rusReg.IsMatch(input[index].ToString()))
                {
                    int code = input[index] - shift;
                    if (input[index] <= 1071 && code < 1040 || input[index] <= 1103 && code < 1072)
                    {
                        code += 32;
                    }

                    input[index] = (char)code;
                }
            }

            Console.WriteLine("\n\tСтрока имеет вид:\n");
            Console.Write("\t");
            foreach (char symbol in input)
            {
                Console.Write(symbol);
            }

            Console.WriteLine();
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
