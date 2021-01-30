using System;

namespace Properties_and_Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FirstExample = "Tom";
            person.Age = 18;
            Console.WriteLine(person.Age);
            person.Age = -23;
            person.Age = 22000;
            person.Age = 20;
            Console.WriteLine(person.Age);
            
            string name = person.FirstExample;
            Console.WriteLine(name);
            person.FirstName = "Mister";
            person.LastName = "Bin";
            Console.WriteLine("Full name: " + person.fullName);
            Console.ReadKey();
        }
    }

    class Person
    {

        public int Height { get; set; } = 173;//cвойство по умолчанию

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if(value >=0 && value <=100)
                    age = value;
            }
        }

        private string firstExample;
        public string FirstExample
        {
            get { return firstExample; }
            set { firstExample = value; }
        }

        private string firstName;
        public string FirstName
        {
            set { firstName = value; }
        }


        private string lastName;
        public string LastName
        {
            set { lastName = value; }
        }

        public string fullName
        {
            get { return $"{firstName} {lastName}"; }
        }
    }
}
