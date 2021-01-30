using System;

namespace ACM_ICPC_Team
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);
            string[] topic = new string[n];

            for (int i = 0; i < n; i++)
            {
                string topicItem = Console.ReadLine();
                topic[i] = topicItem;
            }

            int[] result = acmTeam(topic);

            Console.WriteLine(string.Join("\n", result));

        }

        static int[] acmTeam(string[] topic)
        {
            string temp, temp2;
            int count, max = 0, max1 = 0;
            string stroka = "";

            for (int i = 0; i < topic.Length - 1; i++)
            {
                temp = topic[i];

                for (int j = i + 1; j < topic.Length; j++)
                {
                    count = 0;
                    temp2 = topic[j];

                    for (int d = 0; d < temp2.Length; d++)
                    {
                        if (temp[d] == '1' || temp2[d] == '1')
                        {
                            count++;
                        }
                    }

                    stroka += count;

                    if (max <= count)
                    {
                        max = count;
                    }
                }

                if (i == 0)
                {
                    max1 = max;
                }
                else if (max1 < max)
                {
                    max1 = max;
                }
            }

            count = 0;

            for (int i = 0; i < stroka.Length; i++)
            {
                if (stroka[i].ToString() == max1.ToString())
                {
                    count++;
                }
            }

            int[] res = { max1, count };
            return res;
        }
    }
}
