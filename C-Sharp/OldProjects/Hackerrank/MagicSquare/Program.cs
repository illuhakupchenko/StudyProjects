using System;

namespace MagicSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] s = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
            }

            int result = formingMagicSquare(s);

            Console.WriteLine(result);
        }

        static int formingMagicSquare(int[][] s)
        {

            int row1 = 0;
            int row2 = 0;
            int col = 0;
            int diag = 0;

         

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    row1 += s[i][j];
                    col += s[j][i];
                    diag += s[i][i];
                    row2 += s[i][2-j];
                }
            }

            



            return 1;

        }

        public int diagonalFirst(int[][]s)
        {
            for (int j = 0; j < 3; j++)
            {
                s[j][j] 
            }
                return 
        }
    }
}
