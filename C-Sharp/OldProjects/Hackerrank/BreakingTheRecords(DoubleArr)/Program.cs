using System;

namespace BreakingTheRecords_DoubleArr_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int[] result = breakingRecords(scores);

            Console.WriteLine(string.Join(" ", result));
        }

        static int[] breakingRecords(int[] scores)
        {
            int[] arr = new int[2];
            int positive = 0, negative = 0;
            int temppos = scores[0];
            int tempneg = scores[0];


            for (int i = 1; i < scores.Length; i++)
            {
                if (temppos < scores[i])
                {
                    temppos = scores[i];
                    positive++;
                }


                if (tempneg > scores[i])
                {
                    tempneg = scores[i];
                    negative++;
                }
            }

            arr[0] = positive;
            arr[1] = negative;
        
            return arr;
        }

    }
}
