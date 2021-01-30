using System;

namespace TimeFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = timeConversion(s);

            Console.WriteLine(result);
        }

        static string timeConversion(string s)
        {
            string[]kek = s.Split(':');
        
            int hours = Convert.ToInt32(kek[0]);
            if (kek[2].Contains('P'))
            {
                hours += 12;
            }
            else { if (hours == 12) hours = 00; }
            int seconds = Convert.ToInt32(kek[2].Remove(2));
            if (hours == 24) { hours = 12; }
            kek[0] = hours.ToString();
            if (hours < 10) { kek[0] = (hours.ToString()).Insert(0, "0"); }
            kek[2] = seconds.ToString();
            if (seconds < 10) { kek[2] = (seconds.ToString()).Insert(0, "0"); }


            return kek[0]+":"+kek[1]+":"+kek[2];
        }
    }
}
