using System;

namespace FactoryPattern
{
    class Car
    {
        public string Engine { set; get; }
        public int Wheel { get; set; }
        public string Chassis { get; set; }

        public Car(string engine, int wheel, string chassis)
        {
            Engine = engine;
            Wheel = wheel;
            Chassis = Chassis;
        }
    }

    // 宝马
    class BMWCar : Car
    {
        public BMWCar(string engine, int wheel, string chassis) 
            : base(engine, wheel, chassis)
        {
            Console.WriteLine("生产了一辆宝马！");
        }
    }

    // 别克
    class BuickCar : Car
    {
        public BuickCar(string engine, int wheel, string chassis) 
            : base(engine, wheel, chassis)
        {
            Console.WriteLine("生产了一辆别克！");
        }
    }

    // 大众
    class VolkswagenCar : Car
    {
        public VolkswagenCar(string engine, int wheel, string chassis) 
            : base(engine, wheel, chassis)
        {
            Console.WriteLine("生产了一辆大众！");
        }
    }

}
