using System;
using Library_Functions;

namespace Задача_9
{

    class Задача37
    {
        static void ShowList(Point source)
        {
            if (source != null)
            {
                Console.WriteLine("\n\tСписок имеет вид:\n");
                Console.Write("\t");
                for (int index = 1; source != null; index++)
                {
                    if (source.Next != null)
                    {
                        Console.Write("[{0}] -> ", source.Number);
                    }
                    else
                    {
                        Console.Write("[{0}]\n", source.Number);
                    }

                    source = source.Next;
                }
            }
            else
            {
                Console.WriteLine("\n\tК сожалению, список пуст");
            }
        }

        public static void ListSeparator(ref Point head, out Point pos, out Point neg)
        {
            pos = null;
            neg = null;
            Point shelfPos = null;
            Point shelfNeg = null;
            Point shelfHead = null;
            Point shelfPoint = head;
            head = null;
            while (shelfPoint != null)
            {
                if (shelfPoint.Number == 0)
                {
                    if (shelfHead == null)
                    {
                        head = new Point(shelfPoint.Number);
                        shelfHead = head;
                    }
                    else
                    {
                        shelfHead.Next = new Point(shelfPoint.Number);
                        shelfHead = shelfHead.Next;
                    }
                }

                if (shelfPoint.Number > 0)
                {
                    if (shelfPos == null)
                    {
                        pos = new Point(shelfPoint.Number);
                        shelfPos = pos;
                    }
                    else
                    {
                        shelfPos.Next = new Point(shelfPoint.Number);
                        shelfPos = shelfPos.Next;
                    }
                }
                else
                {
                    if (shelfPoint.Number < 0)
                    {
                        if (shelfNeg == null)
                        {
                            neg = new Point(shelfPoint.Number);
                            shelfNeg = neg;
                        }
                        else
                        {
                            shelfNeg.Next = new Point(shelfPoint.Number);
                            shelfNeg = shelfNeg.Next;
                        }
                    }
                }

                shelfPoint = shelfPoint.Next;
            }
        }

        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n" + "\n\tВ программе построен линейный список.\n"
                                                                  + "\n\tНапишите процедуру, создающую два новых линейных списка:\n"
                                                                  + "\n\tсписок, включающий все положительные значения из элементов исходного списка,\n"
                                                                  + "\n\tи список, включающий все отрицательные значение из элементов исходного списка;\n"
                                                                  + "\n\tпри включении элементов в новые списки, они удаляются из исходного списка");
            Console.WriteLine("\n\tВвод длины начального списка");
            Functions.ReadNatural(out int lengthList);
            Point Head;
            Console.WriteLine("\n\tКаким образом заполнить список?");
            Console.WriteLine("\n\t1 - случайно");
            Console.WriteLine("\n\t2 - вручную");
            int answer = Functions.ReadAnswer(1, 2);
            if (answer == 1)
            {
                Head = new Point(Functions.Rnd.Next(-lengthList, lengthList + 1));
                Point shelfPoint = Head;
                for (int index = 1; index < lengthList; index++)
                {
                    shelfPoint.Next = new Point(Functions.Rnd.Next(-10, 10));
                    shelfPoint = shelfPoint.Next;
                }
            }
            else
            {
                Functions.ReadInteger(out int number);
                Head = new Point(number);
                Point shelfPoint = Head;
                for (int index = 1; index < lengthList; index++)
                {
                    Functions.ReadInteger(out number);
                    shelfPoint.Next = new Point(number);
                    shelfPoint = shelfPoint.Next;
                }
            }

            ShowList(Head);
            ListSeparator(ref Head, out Point Pos, out Point Neg);
            Console.WriteLine("\n\t<Начальный список>");
            ShowList(Head);
            Console.WriteLine("\n\t<Список положительных чисел>");
            ShowList(Pos);
            Console.WriteLine("\n\t<Список отрицатлеьных чисел>");
            ShowList(Neg);
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
