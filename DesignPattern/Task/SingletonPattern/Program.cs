using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateID g1 = GenerateID.GetInstance();
            GenerateID g2 = GenerateID.GetInstance();

            Console.WriteLine(
                $"{ g1.GetId() } { g1.GetId() }");
        }
    }
}