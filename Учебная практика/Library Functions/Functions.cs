using System;

namespace Library_Functions
{
    public class Functions
    {
        public static Random Rnd = new Random();

        public static void ReadNatural(out int numberNatural)
        {
            bool rightNatural;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите натуральное число");
                rightNatural = int.TryParse(Console.ReadLine(), out numberNatural) && numberNatural > 0;
                if (!rightNatural)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось натуральное число");
                    Console.WriteLine("\n\tЭто целое число, которое больше 0");
                }
            }
            while (!rightNatural);
        }

        public static void ReadNonNegative(out int numberZahlen)
        {
            bool rightNonNegative;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите неотрицательное число");
                rightNonNegative = int.TryParse(Console.ReadLine(), out numberZahlen);
                if (numberZahlen < 0)
                {
                    rightNonNegative = false;
                }

                if (!rightNonNegative)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось неотрицательное число");
                    Console.WriteLine("\n\tЭто целое число, которое больше или равняется 0");
                }
            }
            while (!rightNonNegative);
        }

        public static void ReadDouble(out double numberDouble)
        {
            bool rightDouble;
            do
            {
                Console.WriteLine("\n\tПожалуйста, введите действительное число");
                rightDouble = double.TryParse(Console.ReadLine(), out numberDouble);
                if (!rightDouble)
                {
                    Console.WriteLine("\n\t\aК сожалению, вы ввели что-то не так. Ожидалось действительное число");
                    Console.WriteLine("\n\tЭто любое число без посторонних символов, кроме символа ',' для ввода дробных чисел и '-' для ввода отрицательных чисел");
                }
            }
            while (!rightDouble);
        }

        public static int ReadAnswer(int firstPositionOfAnswer, int lastPositionOfAnswer)
        {
            bool rightAnswer;
            int numberOfAnswer;
            if (firstPositionOfAnswer > lastPositionOfAnswer)
            {
                int shelf = firstPositionOfAnswer;
                firstPositionOfAnswer = lastPositionOfAnswer;
                lastPositionOfAnswer = shelf;
            }

            do
            {
                Console.WriteLine(
                    "\n\tПожалуйста, введите номер ответа. Это целое число от {0} до {1} включительно",
                    firstPositionOfAnswer,
                    lastPositionOfAnswer);
                rightAnswer = int.TryParse(Console.ReadLine(), out numberOfAnswer)
                              & numberOfAnswer <= lastPositionOfAnswer & numberOfAnswer >= firstPositionOfAnswer;
                if (!rightAnswer)
                {
                    Console.WriteLine(
                        "\n\t\aНеверный ввод. Ожидалось целое число от {0} до {1} включительно",
                        firstPositionOfAnswer,
                        lastPositionOfAnswer);
                }
            }
            while (!rightAnswer);

            return numberOfAnswer;
        }
    }
}
