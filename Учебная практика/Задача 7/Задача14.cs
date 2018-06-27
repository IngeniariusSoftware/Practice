using System;
using Library_Functions;

namespace Задача_7
{
    class Задача14
    {
        public static int VectorLength;

        public static bool FindFunction = false;

        public static void CheackLinearFunction(string vector)
        {
            string lastVector = vector;
            string valuesFunction = lastVector.Substring(0, 1);
            for (int index = 0; index < vector.Length - 1; index++)
            {
                string nextVector = "";
                for (int indexVector = 0; indexVector < lastVector.Length - 1; indexVector++)
                {
                    if (lastVector[indexVector] == lastVector[indexVector + 1])
                    {
                        nextVector += 0;
                    }
                    else
                    {
                        nextVector += 1;
                    }
                }

                valuesFunction += nextVector[0];
                lastVector = nextVector;
            }

            bool find = false;
            for (int index = 3; index < valuesFunction.Length && !find; index++)
            {
                if (valuesFunction[index] == '1' && (index & (index - 1)) != 0)
                {
                    FindFunction = true;
                    Console.WriteLine("\n\t{0}", vector);
                    find = true;
                }
            }
        }

        public static void FillingFunction(string vector)
        {
            if (vector.Contains("-"))
            {
                int position = vector.IndexOf("-");
                char[] str = vector.ToCharArray();
                str[position] = '0';
                FillingFunction(new string(str));
                str[position] = '1';
                FillingFunction(new string(str));
            }
            else
            {
                CheackLinearFunction(vector);
            }
        }

        public static string CheckFunction(string vector)
        {
            string formattedVector = "";
            for (int index = 0; index < vector.Length && formattedVector.Length < VectorLength; index++)
            {
                if (vector[index] == '0' || vector[index] == '1' || vector[index] == '-')
                {
                    formattedVector += vector[index];
                }
            }

            if (formattedVector.Length == VectorLength)
            {
                return formattedVector;
            }
            else
            {
                return null;
            }
        }

        static void Main()
        {
            Console.WriteLine(
                "\n\tДоопределить заданную булеву функцию всеми возможными\n"
                + "\n\tспособами так, чтобы она была не линейной.\n"
                + "\n\tВыписать все вектора в лексикографическом порядке.");
            Console.WriteLine("\n\tВвод количества аргументов булевой функции");
            Functions.ReadNatural(out int countArguments);
            VectorLength = (int)Math.Pow(2, countArguments);
            bool rightVector = false;
            do
            {
                Console.WriteLine(
                    "\n\tПожалуйста, введите булеву функцию, для обозначения пропусков используйте символ '-'\n"
                    + "\n\tНапример, функция для 2 аргументов может иметь такой вид: 0-01");
                string functionVector = CheckFunction(Console.ReadLine());
                if (functionVector != null)
                {
                    Console.WriteLine("\n\tВаша функция имеет вид: {0}", functionVector);
                    if (functionVector.Contains("-"))
                    {
                        Console.WriteLine();
                        FillingFunction(functionVector);
                        if (FindFunction)
                        {
                            Console.WriteLine("\n\tЭто все получившиеся нелинейные функции из начальной");
                        }
                        else
                        {
                            Console.WriteLine("\n\tК сожалению, не было найдено ни одной линейной функции");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\tК сожалению, данную функцию невозможно дополнить");
                    }

                    rightVector = true;
                }
                else
                {
                    Console.WriteLine("\n\tК сожалению, вы ввели что-то не так, попробуйте заново.");
                }
            }
            while (!rightVector);

            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}

