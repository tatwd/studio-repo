using System;

namespace AbstractFactoryPattern
{
    class Food
    {
        public string Name { set; get; }
        public string Taste { get; set; }

        public Food(string name, string taste)
        {
            Name = name;
            Taste = taste;

            Console.WriteLine($"{ Name }\t{ Taste }");
        }
    }
}
