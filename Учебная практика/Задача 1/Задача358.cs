using System;

namespace Задача_1
{
    class Задача358
    {
        static int Nod(Int32 number1, Int32 number2)
        {
            if (number1 == number2)
            {
                return number1;
            }
            else
            {
                if (number1 > number2)
                {
                    int shelf = number1;
                    number1 = number2;
                    number2 = shelf;
                }

                return Nod(number1, number2 - number1);
            }
        }

        static void Main()

        {
            string[] tokens = Console.ReadLine().Split(' ');
            Int32[] coordinates = new Int32[tokens.Length];
            for (int index = 0; index < tokens.Length; index++)
            {
                coordinates[index] = Int32.Parse(tokens[index]);
            }

            Int32[] deltaX = new Int32[3];
            Int32[] deltaY = new Int32[3];
            deltaX[0] = Math.Abs(coordinates[0] - coordinates[2]);
            deltaX[1] = Math.Abs(coordinates[2] - coordinates[4]);
            deltaX[2] = Math.Abs(coordinates[0] - coordinates[4]);
            deltaY[0] = Math.Abs(coordinates[1] - coordinates[3]);
            deltaY[1] = Math.Abs(coordinates[3] - coordinates[5]);
            deltaY[2] = Math.Abs(coordinates[1] - coordinates[5]);
            decimal[] coefficients = new decimal[3];
            bool isTriangle = true;

            for (int index = 0; index < 3; index++)
            {
                if (deltaX[index] != 0)
                {
                    coefficients[index] = deltaY[index] / deltaX[index];
                }
            }

            if (coefficients[0] == coefficients[1] && coefficients[0] == coefficients[2])
            {
                isTriangle = false;
            }

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
                        coefficients[index] = Nod(deltaX[index], deltaY[index]);
                    }
                }
            }

            Int64 treeCount;
            Array.Sort(coefficients);
            if (isTriangle)
            {
                treeCount = (Int64)(coefficients[0] + coefficients[1] + coefficients[2]);
            }
            else
            {
                treeCount = (Int64)coefficients[2] + 1;
            }

            Console.WriteLine(treeCount);
        }
    }
}
