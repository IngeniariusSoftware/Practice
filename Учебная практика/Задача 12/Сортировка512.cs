using System;
using Library_Functions;

namespace Задача_12
{
    class Сортировка512
    {
        public static int CountComparison = 0;

        public static int CountSwap = 0;

        public static int[] Mas = new int[1000];

        public static int CurrentPostion = 0;

        public static void Qsort(int[] massif, int size, int leftBoard, int rightBoard)
        {
            int shelf, leftIndex, middle, rightIndex;
            leftIndex = leftBoard;
            rightIndex = rightBoard;
            middle = massif[(rightBoard - leftBoard) / 2 + leftBoard];
            while (leftIndex <= rightIndex)
            {
                CountComparison++;
                while (massif[leftIndex] < middle)
                {
                    leftIndex++;
                    CountComparison++;
                }

                while (massif[rightIndex] > middle)
                {
                    rightIndex--;
                    CountComparison++;
                }

                if (leftIndex <= rightIndex)
                {
                    shelf = massif[leftIndex];
                    massif[leftIndex] = massif[rightIndex];
                    massif[rightIndex] = shelf;
                    rightIndex--;
                    leftIndex++;
                    CountSwap++;
                }
            }

            if (rightIndex > leftBoard)
                Qsort(massif, size, leftBoard, rightIndex);
            if (rightBoard > leftBoard)
                Qsort(massif, size, leftIndex, rightBoard);
        }

        public class BinaryTree
        {
            public int Value;

            public BinaryTree Left, Right;

            public BinaryTree(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

            public BinaryTree()
            {
                Value = 0;
                Left = null;
                Right = null;
            }
        }

        public static void Add(BinaryTree root, int number)
        {
            BinaryTree shelfRoot = root;

            if (shelfRoot.Value > number)
            {
                CountComparison++;
                if (shelfRoot.Left == null)
                {
                    shelfRoot.Left = new BinaryTree(number);
                    CountSwap++;
                }
                else
                {
                    shelfRoot = shelfRoot.Left;
                    Add(shelfRoot, number);
                }
            }
            else
            {
                CountComparison++;
                if (shelfRoot.Right == null)
                {
                    shelfRoot.Right = new BinaryTree(number);
                    CountSwap++;
                }
                else
                {
                    shelfRoot = shelfRoot.Right;
                    Add(shelfRoot, number);
                }
            }
        }

        public static void BinarySort()
        {
            BinaryTree root = new BinaryTree(Mas[0]);
            for (int index = 1; index < Mas.Length; index++)
            {
                Add(root, Mas[index]);
            }
            TraversalTree(root);
            CurrentPostion = 0;
        }

        public static void TraversalTree(BinaryTree root) // Обход дерева
        {
            if (root != null)
            {
                TraversalTree(root.Left);
                Mas[CurrentPostion] = root.Value;
                CurrentPostion++;
                CountSwap++;
                TraversalTree(root.Right);
            }
        }


        public static void Show()
        {
            Console.WriteLine("\n");
            foreach (int element in Mas)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            for (int index = 0; index < Mas.Length; index++)
            {
                Mas[index] = Functions.Rnd.Next(-100, 100);
            }

            Console.WriteLine("\n\tМассив до сортировки:");
            Show();
            Console.WriteLine("\n\tБыстрая сортировка");
            Qsort(Mas, Mas.Length, 0, Mas.Length - 1);
            Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
            Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
            Console.WriteLine("\n\tОтсортированный массив: ");
            Show();
            for (int index = 0; index < Mas.Length; index++)
            {
                Mas[index] = Functions.Rnd.Next(-100, 100);
            }

            Console.WriteLine("\n\tМассив до сортировки:");
            Show();
            Console.WriteLine("\n\tДвоичное дерево");
            BinarySort();
            Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
            Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
            Console.WriteLine("\n\tОтсортированный массив: ");
            Show();
            for (int index = 0; index < Mas.Length; index++)
            {
                Mas[index] = index + 1;
            }

            Console.WriteLine("\n\tМассив до сортировки:");
            Show();
            Console.WriteLine("\n\tБыстрая сортировка");
            Qsort(Mas, Mas.Length, 0, Mas.Length - 1);
            Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
            Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
            Console.WriteLine("\n\tОтсортированный массив: ");
            Show();
            for (int index = 0; index < Mas.Length; index++)
            {
                Mas[index] = index + 1;
            }

            Console.WriteLine("\n\tМассив до сортировки:");
            Show();
            Console.WriteLine("\n\tДвоичное дерево");
            BinarySort();
            Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
            Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
            Console.WriteLine("\n\tОтсортированный массив: ");
            Show();
            for (int index = 0; index < Mas.Length; index++)
            {
                Mas[index] = Mas.Length - index;
            }

            Console.WriteLine("\n\tМассив до сортировки:");
            Show();
            Console.WriteLine("\n\tБыстрая сортировка");
            Qsort(Mas, Mas.Length, 0, Mas.Length - 1);
            Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
            Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
            Console.WriteLine("\n\tОтсортированный массив: ");
            Show();
            for (int index = 0; index < Mas.Length; index++)
            {
                Mas[index] = Mas.Length - index;
            }

            Console.WriteLine("\n\tМассив до сортировки:");
            Show();
            Console.WriteLine("\n\tДвоичное дерево");
            BinarySort();
            Console.WriteLine("\n\tКол-во сравнений: {0}", CountComparison);
            Console.WriteLine("\n\tКол-во перестановок: {0}", CountSwap);
            Console.WriteLine("\n\tОтсортированный массив: ");
            Show();
            Console.WriteLine("\n\tДля завершения работы нажмите на любую клавишу . . .");
            Console.ReadKey();
        }
    }
}

