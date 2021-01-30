using System;
using System.Collections.Generic;
using System.Linq;

namespace BetweenTwoSets
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

            int total = getTotalX(arr, brr);

            Console.WriteLine(total);
        }
        public static int getTotalX(List<int> a, List<int> b)
        {
            int counter = 0;
            int count = 0;
            int count1 = 0;
            int count2 = 0;

            while (counter<=b[0])
            {
                counter++;
                for (int i = 0; i < a.Count; i++)
                {
                    if (counter % a[i] == 0)
                    {
                        count1++;
                    }
                }
                if(count1 == a.Count) { count1 = 0; break; }
                else { count1 = 0; }
            }

            if (counter <= b[0])
            {
                while (counter <= b[0])
                {
                    for (int j = 0; j < b.Count; j++)
                    {
                        if (b[j] % counter == 0)
                        {
                            for(int i = 0; i < a.Count; i++)
                            {
                                if (counter % a[i] == 0)
                                {
                                    count2++;
                                }                                
                            }
                            if (count2 == a.Count) { count2 = 0; count1++; }
                            else { count2 = 0; }
                        }
                    }
                    if (count1 == b.Count) { count1 = 0; count++; }
                    else { count1 = 0; }
                    counter++;
                }
            }

            return count;

            //if (a.Count > 1)
            //{
            //    for (int i = 0; i < a.Count - 1; i++)
            //    {
            //        if (a[i + 1] % a[i] == 0)
            //        {              
            //            for (int j = 0; j < b.Count; j++)
            //            {
            //                if (b[j] % a[i] == 0)
            //                {
            //                    count1++;
            //                }
            //            }
            //        }
            //        if (count1 == b.Count) { count++; count1 = 0; }
            //        else { count1 = 0; }
            //    }
            //}
            //else
            //{
            //    for (int j = 0; j < b.Count; j++)
            //    {
            //        if (b[j] % a[0] == 0)
            //        {
            //            count1++;
            //        }
            //    }
            //    if (count1 == b.Count) { count++; }
            //}


            //return count;
        }

    }
}
