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
        static void Main(string[] args)
        {
            int[]members = new int[3];
            for (int index = 0; index < members.Length; index++)
            {
                Console.WriteLine("Ввод a{0}", index + 1);
                Functions.ReadWhole(out members[index]);
            }
            2 * | а к–1 – а к - 2 | +а к–3
            Console.WriteLine("Ввод N");
            Functions.ReadNatural(out int lengthSequence);
            Functions.ReadNatural(out int countMultipleMembers);

            int currentPosition;
            for (currentPosition = 0; currentPosition < lengthSequence && countMultipleMembers > 0; currentPosition++)
            {
                members[currentPosition] = 2 * Math.Abs(members[currentPosition - 1] - members[currentPosition - 2]) + members[currentPosition - 3];
                if (members[currentPosition] % 3 == 0)
                {
                    countMultipleMembers--;
                }
            }

            if (currentPosition == lengthSequence)
            {
                Console.WriteLine("\n\tПостроение элементов последовательности закончено, т.к. программа дошла до последнего члена последовательности");
            }

            if (countMultipleMembers == 0)
            {

            }
        }
    }
}
