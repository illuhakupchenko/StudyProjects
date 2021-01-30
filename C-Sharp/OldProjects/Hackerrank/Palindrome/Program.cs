using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            int result = shortPalindrome(s);
            Console.WriteLine(result);
        }

        static int shortPalindrome(string s)
        {
            int m = 1000000007;
            int counter = 0;
            char[] arr = s.ToCharArray();

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i+2; j < arr.Length; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        for(int a = i+1; a < j; a++)
                        {
                            for(int d = a+1; d< j; d++)
                            {
                                if (arr[a] == arr[d])
                                {
                                    counter += 1;
                                }
                            }
                        }
                    }
                }
            }

            return counter%m;
        }

    }
}
