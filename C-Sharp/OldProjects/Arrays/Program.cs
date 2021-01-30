using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3] { 1, 3, 5}; //определение массива
            int[] nums21 = new int[4] { 1, 2, 3, 5 };
            int[] nums31 = new int[] { 1, 2, 3, 5 };
            int[] nums41 = new[] { 1, 2, 3, 5 };
            int[] nums51 = { 1, 2, 3, 5 };

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            /*
            ДВУМЕРНЫЕ МАССИВЫ
            */

            int[,] nums1;
            int[,] nums2 = new int[2, 3];
            int[,] nums3 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums4 = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums5 = new[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums6 = { { 0, 1, 2 }, { 3, 4, 5 } };

            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };
            foreach (int i in mas)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine();

            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.Length / rows;
            // или так
            // int columns = mas.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas[i, j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            /*
                МАССИВ МАССИВОВ
            */
            int[][] nums = new int[3][];
            nums[0] = new int[2] { 1, 2 };          // выделяем память для первого подмассива
            nums[1] = new int[3] { 1, 2, 3 };       // выделяем память для второго подмассива
            nums[2] = new int[5] { 1, 2, 3, 4, 5 }; // выделяем память для третьего подмассива

            int[][,] nums22 = new int[3][,]
            {
                new int[,] { {1,2}, {3,4} },
                new int[,] { {1,2}, {3,6} },
                new int[,] { {1,2}, {3,5}, {8, 13} }
            };

            int[][] numbers1 = new int[3][];
            numbers1[0] = new int[] { 1, 2 };
            numbers1[1] = new int[] { 1, 2, 3 };
            numbers1[2] = new int[] { 1, 2, 3, 4, 5 };
            foreach (int[] row in numbers1)
            {
                foreach (int number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            // перебор с помощью цикла for
            for (int i = 0; i < numbers1.Length; i++)
            {
                for (int j = 0; j < numbers1[i].Length; j++)
                {
                    Console.Write($"{numbers1[i][j]} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Задача - инверсия массива, то есть переворот его в обратном порядке:

            int[] numbers2 = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

            int n = numbers2.Length; // длина массива
            int k = n / 2; //середина массива
            int temp;
            for (int i = 0; i < k; i++)
            {
                temp = numbers2[i];
                numbers2[i] = numbers2[n - 1 - i];
                numbers2[n - 1 - i] = temp;
            }
            foreach (int i in numbers2)
            {
                Console.Write($"{i} \t");
            }


            /*СОРТИРОВКА МАССИВА*/
            Console.WriteLine();
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = i; j < n-1; j++)
                {
                    if(numbers2[i]>numbers2[j+1])
                    {
                        temp = numbers2[i];
                        numbers2[i] = numbers2[j + 1];
                        numbers2[j + 1] = temp;
                    }
                }
            }

            foreach(int i in numbers2)
            {
                Console.WriteLine(i);
            }
        }
    }
}
