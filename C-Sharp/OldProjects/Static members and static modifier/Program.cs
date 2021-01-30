using System;
using System.Text;

namespace Static_members_and_static_modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            User user1 = new User(); // здесь сработает статический конструктор
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            User user5 = new User();

            User.DisplayCounter(); // 5

            Console.ReadKey();
        }
    }
   
    class User
    {

        public static int counter = 0;
        static User()
        {
            Console.WriteLine("Создан первый пользователь");
        }

        public User()
        {
            counter++;
        }
        public static void DisplayCounter()
        {
            Console.WriteLine(counter);
        }
    }
}
