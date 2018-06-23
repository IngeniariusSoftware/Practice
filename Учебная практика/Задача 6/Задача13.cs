using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Functions;

namespace Задача_6
{
    class Задача13
    {
        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу: ввести а1, а2, а3, М, N.\n"
                + "\n\tПостроить последовательность чисел ак = 2 * | ак–1 – ак-2 | +  ак–3.\n"
                + "\n\tПостроить N элементов последовательности, либо найти первые M ее элементов,\n"
                + "\n\tкратных трем (в зависимости от того, что выполнится раньше).\n"
                + "\n\tНапечатать последовательность и причину остановки.\n"
                + "\n\tЗелёным цветом выделены члены последовательности кратные 3");

            Console.WriteLine("\n\tВвод N");
            Functions.ReadNatural(out int lengthSequence);
            int[] members = new int[lengthSequence + 3];
            int currentCountMultipleMembers = 0;
            for (int index = 0; index < 3; index++)
            {
                Console.WriteLine("\n\tВвод a{0}", index + 1);
                Functions.ReadInteger(out members[index]);
                if (members[index] % 3 == 0)
                {
                    currentCountMultipleMembers++;
                }
            }

            Console.WriteLine("\n\tВвод M");
            Functions.ReadNonNegative(out int countMultipleMembers);
            int currentPosition;
            for (currentPosition = 3;
                 currentPosition < lengthSequence && countMultipleMembers > currentCountMultipleMembers;
                 currentPosition++)
            {
                members[currentPosition] = 2 * Math.Abs(members[currentPosition - 1] - members[currentPosition - 2])
                                           + members[currentPosition - 3];
                if (members[currentPosition] % 3 == 0)
                {
                    currentCountMultipleMembers++;
                }
            }

            if (currentPosition >= lengthSequence && currentCountMultipleMembers == countMultipleMembers)
            {
                Console.WriteLine(
                    "\n\tПостроение элементов последовательности закончено, т.к. программа дошла до последнего члена\n"
                    + "последовательности, а также построила нужное количество чисел кратных 3");

            }
            else
            {
                if (currentCountMultipleMembers == countMultipleMembers)
                {
                    Console.WriteLine(
                        "\n\tПостроение элементов последовательности закончено, т.к. программа построила нужное количество чисел кратных 3");
                }
                else
                {
                    Console.WriteLine(
                        "\n\tПостроение элементов последовательности закончено, т.к. программа дошла до последнего члена последовательности");
                }
            }

            for (int index = 0; index < currentPosition; index++)
            {
                if (members[index] % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine("\n\t[a{0}] - {1}", index + 1, members[index]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine("\n\tКоличество построенных элементов: {0}", currentPosition);
            Console.WriteLine("\n\tКоличество элементов кратных 3: {0}", currentCountMultipleMembers);
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
