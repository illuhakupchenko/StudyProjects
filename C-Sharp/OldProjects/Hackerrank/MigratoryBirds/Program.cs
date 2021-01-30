using System;
using System.Collections.Generic;
using System.Linq;

namespace MigratoryBirds
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = migratoryBirds(arr);

            Console.WriteLine();
            //Console.WriteLine(result);
        }

        static int migratoryBirds(List<int> arr)
        {




            //int type = 0;
            //int count = 0;
            //List<int> types = new List<int>();

            //for (int i = 0; i < arr.Count; i++)
            //{
            //    for (int j = i + 1; j < arr.Count; j++)
            //    {
            //        if (arr[i] == arr[j])
            //        {
            //            count++;
            //        }
            //    }
            //    types.Add(count);
            //    count = 0;
            //}

            //for (int i = 0; i < arr.Count - 1; i++)
            //{
            //    if (types[i] > types[i + 1])
            //    {
            //        type = arr[i];
            //    }
            //}
            //return type;




            int[] ary = new int[arr.Count];
            for (int i = 0; i < arr.Count; i++)
                ary[arr[i]]++;
            int max = 0, maxpos = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (ary[i] > max)
                {
                    max = ary[i];
                    maxpos = i;
                }
            }
            return ary[arr[1]]++;


        }
    }
}

