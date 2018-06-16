using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int[] coordinates = new int[tokens.Length];
            for (int index = 0; index < tokens.Length; index++)
            {
                coordinates[index] = int.Parse(tokens[index]);
                }
            double[] deltaX = new double[3];

            deltaX[0] = Math.Abs(coordinates[0] - coordinates[2]);
            deltaX[1] = Math.Abs(coordinates[2] - coordinates[4]);
            deltaX[2] = Math.Abs(coordinates[0] - coordinates[4]);

            double[] coefficients = new double[3];
            for (int index = 0; index < 3; index++)
            {
                
                coefficients[index] = (double)coordinates[index * 2 + 1] / coordinates[index * 2];
                coefficients[index] = Math.Abs(coefficients[index] - Math.Truncate(coefficients[index]));
                if (coefficients[index] != 0)
                {
                    coefficients[index] = 1.0 / coefficients[index];
                    deltaX[index] = Math.Truncate(deltaX[index] / coefficients[index]);
                }
            }

            int treeCount = (int) (deltaX[0] + deltaX[1] + deltaX[2] - 6);
            Console.WriteLine(treeCount);
            Console.ReadKey();
        }
    }
}
