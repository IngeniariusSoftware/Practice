using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class TaskSolution
    {
        static void Main()
        {
            int countAnimalsTypes = int.Parse(Console.ReadLine());
            char[] countAnimals = Console.ReadLine().ToCharArray();
            int[] combinations = new int [3];
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
            Console.ReadKey();
        }
    }
}
