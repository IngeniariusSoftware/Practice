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
            double[] deltaY = new double[3];
            deltaX[0] = Math.Abs(coordinates[0] - coordinates[2]);
            deltaX[1] = Math.Abs(coordinates[2] - coordinates[4]);
            deltaX[2] = Math.Abs(coordinates[0] - coordinates[4]);
            deltaY[0] = Math.Abs(coordinates[1] - coordinates[3]); 
            deltaY[1] = Math.Abs(coordinates[3] - coordinates[5]);
            deltaY[2] = Math.Abs(coordinates[1] - coordinates[5]);
            double[] coefficients = new double[3];





            for (int index = 0; index < 3; index++)
            {
                if (deltaX[index] == 0)
                {
                    coefficients[index] = deltaY[index];
                }
                else
                {
                    if (deltaY[index] == 0)
                    {
                        coefficients[index] = deltaX[index];
                    }
                    else
                    {
                        coefficients[index] = deltaY[index] / deltaX[index];
                        coefficients[index] = Math.Abs(coefficients[index] - Math.Truncate(coefficients[index]));
                        if (coefficients[index] != 0)
                        {
                            coefficients[index] = 1.0 / coefficients[index];
                            if (coefficients[index] - Math.Truncate(coefficients[index]) > 0)
                            {
                                coefficients[index] = 1;
                            }
                            else
                            {
                            coefficients[index] = Math.Truncate(deltaX[index] / coefficients[index]);
                            }
                        }
                        else
                        {
                            coefficients[index] = deltaX[index];
                        }
                    }
                }

            }

            int treeCount = (int)(coefficients[0] + coefficients[1] + coefficients[2]);
            Console.WriteLine(treeCount);
        }
    }
}
