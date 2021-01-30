using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            /*char[] k = (Console.ReadLine()).ToCharArray();
            char[] s = new char[k.Length*2];
            for(int i = 0; i < k.Length; i++)
            {
                s[i] = k[i]; 
                s[k.Length * 2 - 1-i] = k[i];
            }
            foreach(char i in s)
            {
                Console.Write(i);
            }
            Console.WriteLine();*/

            Console.WriteLine("Enter your polinom: ");

            char[] arr = (Console.ReadLine()).ToCharArray();
            int count = 0;
            //char[] ke = new char[arr.Length];

            //for(int i = 0; i < arr.Length; i++)
            //{
            //    ke[i] = '#';
            //    if(arr[i] == arr[arr.Length - 1])
            //    {
            //        ke[i] = Convert.ToChar(i.ToString());

            //    }
            //}

            //Console.WriteLine(ke);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr[arr.Length - 1])
                {
                    for (int j = i + 1; j < arr.Length - 1; j++)
                    {
                        for (int d = j; d < arr.Length - 2; d++)
                        {
                            if (arr[j] == arr[d + 1])
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[0] == arr[i])
                {
                    for (int j = i - 1; j > 0; j--)
                    {
                        for (int d = j; d > 1; d--)
                        {
                            if (arr[j] == arr[d - 1])
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
