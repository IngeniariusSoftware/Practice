using System;
using System.Collections.Generic;
using Library_Functions;

namespace Задача_8
{
    using System.Runtime.Remoting.Channels;
    using System.Text.RegularExpressions;

    class Задача39
    {
        static void
        static void Main()
        {
            Console.WriteLine(
                "\n\tДанная программа решает следующую задачу:\n" 
                + "\n\tграф задан матрицей списком вершин и ребер.\n"
                + "\n\tНайти в нем какой-либо простой цикл из K вершин.");
            Console.WriteLine("\n\tВвод количества всех вершин графа");
            Functions.ReadNatural(out int lengthGraph);
            Console.WriteLine("\n\tВводите ребра графа как 'вершина1 вершина2'.\n"
                              + "\n\tЧтобы закончить ввод, введите пустую строку\n"
                              + "\n\tВершины начинают нумероваться с 1");
            Regex reg = new Regex(@"[0-9]+");
            List<List<int>> graph = new List<List<int>>(lengthGraph);
            string input = null;
            while (input != "")
            {
                Console.WriteLine("\n\tПожалуйста, введите ребро графа как 'вершина1 вершина2'");
                input = Console.ReadLine();
                var vertices = reg.Matches(input);
                if (vertices.Count >= 2)
                {
                    int firstVertex = int.Parse(vertices[0].ToString());
                    int secondVertex = int.Parse(vertices[1].ToString());
                    if (firstVertex <= lengthGraph)
                    {
                        if (secondVertex <= lengthGraph)
                        {
                            if (graph[firstVertex].BinarySearch(secondVertex) > -1)
                            {
                                Console.WriteLine("\n\tТакое ребро уже существует");
                            }
                            else
                            {
                                graph[firstVertex].Add(secondVertex);
                                Console.WriteLine(
                                    "\n\tРебро '{0}' - '{1}' успешно добавлено",
                                    firstVertex,
                                    secondVertex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\tК сожалению, вершины '{0}' не существует в графе", secondVertex);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\tК сожалению, вершины '{0}' не существует в графе", firstVertex);
                    }
                }
                else
                {
                    if (input == "")
                    {
                        Console.WriteLine("Ввод закончен");
                    }
                    else
                    {
                        Console.WriteLine(
                            "\n\tК сожалению, вы ввели что-то не так. Ожидалось два натуральных числа, разделенные пробелом");
                    }
                }
            }

            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}
