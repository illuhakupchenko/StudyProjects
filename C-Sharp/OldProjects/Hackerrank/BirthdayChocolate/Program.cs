using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayChocolate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string[] dm = Console.ReadLine().TrimEnd().Split(' ');

            int d = Convert.ToInt32(dm[0]);

            int m = Convert.ToInt32(dm[1]);

            int result = birthday(s, d, m);

            Console.WriteLine(result);
        }

        static int birthday(List<int> s, int d, int m)
        {

            int temp = 0;
            int count = 0;

            for (int i = 0; i <= s.Count - m; i++)
            {
                for (int j = i; j < m+i; j++)
                {
                    temp += s[j];
                }
                if (temp == d)
                {
                    count++;
                    temp = 0;
                }
                else
                {
                    temp = 0;
                }
            }
            if(m == 1) { return 1; }
            return count;

        }
    }
}
