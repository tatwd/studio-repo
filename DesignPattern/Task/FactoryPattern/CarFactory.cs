namespace FactoryPattern
{
    // 宝马
    class BMWCarFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new BMWCar("宝马发动机", 4, "宝马底盘");
        }
    }

    // 别克
    class BuickCarFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new BuickCar("别克发动机", 4, "别克底盘");
        }
    }

    // 大众
    class VolkswagenCarFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new VolkswagenCar("大众发动机", 4, "大众底盘");
        }
    }
}
