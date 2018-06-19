using System;

namespace Задача_2
{
    class Задача552
    {
        static void Main()
        {
            Int64 countAnimalsTypes = Int64.Parse(Console.ReadLine());
            string[] numbers = Console.ReadLine().Split(' ');
            int[] countAnimals = new int[numbers.Length];
            for (int index = 0; index < numbers.Length; index++)
            {
                countAnimals[index] = int.Parse(numbers[index]);
            }

            Int64[] combinations = new Int64[3];
            if (countAnimalsTypes > 2)
            {
                for (int index = 0; index < countAnimalsTypes; index++)
                {
                    combinations[2] = combinations[2] + combinations[1] * countAnimals[index];
                    combinations[1] = combinations[1] + combinations[0] * countAnimals[index];
                    combinations[0] = combinations[0] + countAnimals[index];
                }
            }

            Console.WriteLine(combinations[2]);
        }
    }
}
