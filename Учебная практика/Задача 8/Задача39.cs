using System;
using System.Collections.Generic;
using Library_Functions;
using System.Text.RegularExpressions;

namespace Задача_8
{
    using System.Linq;

    class Задача39
    {
        public static int LengthPath;

        public static List<int>[] Graph;

        public static bool FindCycle;

        public static void SearchSimpleCycle(List<int> path)
        {
            if (path.Count == LengthPath)
            {
                if (Graph[path.Last()].Contains(path[0]))
                {
                    Console.WriteLine("\n\tНайден следующий простой цикл длины {0}", LengthPath);
                    foreach (int vertex in path)
                    {
                        Console.Write("{0} -> ", vertex + 1);
                    }

                    Console.Write(path[0] + 1);
                    FindCycle = true;
                }
            }
            else
            {
                if (path.Count < LengthPath)
                {
                    foreach (int vertex in Graph[path.Last()])
                    {
                        if (!path.Contains(vertex))
                        {
                            List<int> newPath = new List<int>(path) { vertex };
                            SearchSimpleCycle(newPath);
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n" + "\n\tграф задан матрицей списком вершин и ребер.\n"
                                                                  + "\n\tНайти в нем какой-либо простой цикл из K вершин.");
            Console.WriteLine("\n\tВвод количества всех вершин графа");
            Functions.ReadNatural(out int lengthGraph);
            Console.WriteLine("\n\tВвод длины простого цикла");
            Functions.ReadNatural(out LengthPath);
            Console.WriteLine(
                "\n\tВводите ребра графа как 'вершина1 вершина2'.\n"
                + "\n\tЧтобы закончить ввод, введите пустую строку\n" + "\n\tВершины начинают нумероваться с 1");
            Regex reg = new Regex(@"[0-9]+");
            Graph = new List<int>[lengthGraph];
            for (int index = 0; index < lengthGraph; index++)
            {
                Graph[index] = new List<int>();
            }
            Console.WriteLine("\n\tКаким образом заполнить массив?");
            Console.WriteLine("\n\t1 - случайно");
            Console.WriteLine("\n\t2 - вручную");
            int answer = Functions.ReadAnswer(1, 2);
            if (answer == 1)
            {
                for (int indexY = 0; indexY < lengthGraph; indexY++)
                {
                    for (int indexX = 0; indexX < lengthGraph; indexX++)
                    {
                        int rndVertex = Functions.Rnd.Next(0, lengthGraph);
                        if (!Graph[indexY].Contains(rndVertex))
                        {
                            Graph[indexY].Add(rndVertex);
                        }
                    }
                }
            }
            else
            {
                string input = null;
                while (input != "")
                {
                    Console.WriteLine("\n\tПожалуйста, введите ребро графа как 'вершина1 вершина2'");
                    input = Console.ReadLine();
                    var vertices = reg.Matches(input);
                    if (vertices.Count >= 2)
                    {
                        int firstVertex = int.Parse(vertices[0].ToString()) - 1;
                        int secondVertex = int.Parse(vertices[1].ToString()) - 1;
                        if (firstVertex <= lengthGraph && firstVertex > -1)
                        {
                            if (secondVertex <= lengthGraph && secondVertex > -1)
                            {
                                if (Graph[firstVertex].Contains(secondVertex))
                                {
                                    Console.WriteLine("\n\tТакое ребро уже существует");
                                }
                                else
                                {
                                    Graph[firstVertex].Add(secondVertex);
                                    Console.WriteLine(
                                        "\n\tРебро '{0}' - '{1}' успешно добавлено",
                                        firstVertex + 1,
                                        secondVertex + 1);
                                }
                            }
                            else
                            {
                                Console.WriteLine(
                                    "\n\tК сожалению, вершины '{0}' не существует в графе",
                                    secondVertex + 1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tК сожалению, вершины '{0}' не существует в графе", firstVertex + 1);
                        }
                    }
                    else
                    {
                        if (input == "")
                        {
                            Console.WriteLine("\n\tВвод закончен");
                        }
                        else
                        {
                            Console.WriteLine(
                                "\n\tК сожалению, вы ввели что-то не так. Ожидалось два натуральных числа, разделенные пробелом");
                        }
                    }
                }
            }

            Console.WriteLine("\n\tМатрица инцидентности графа имеет вид:\n");
            for (int indexY = -1; indexY < lengthGraph; indexY++)
            {
                if (indexY == -1)
                {
                    Console.Write("\t ");
                    for (int indexVertex = 0; indexVertex < lengthGraph; indexVertex++)
                    {
                        Console.Write(" {0}", indexVertex + 1);
                    }
                }
                else
                {
                    for (int indexX = -1; indexX < lengthGraph; indexX++)
                    {
                        if (indexX == -1)
                        {
                            Console.Write("\t{0} ", indexY + 1);
                        }
                        else
                        {
                            if (Graph[indexY].Contains(indexX))
                            {
                                Console.Write("1 ");
                            }
                            else
                            {
                                Console.Write("0 ");
                            }
                        }
                    }
                }

                Console.WriteLine();
            }

            for (int index = 0; index < lengthGraph; index++)
            {
                List<int> initialPath = new List<int> { index };
                SearchSimpleCycle(initialPath);
            }

            if (!FindCycle)
            {
                Console.WriteLine("\n\tК сожалению, в графе не было найдено ни одного простого цикла указанной длины");
            }

            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}

