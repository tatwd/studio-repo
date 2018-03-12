namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory;

            // 生产宝马
            carFactory = new BMWCarFactory();
            carFactory.CreateCar();

            // 生产别克
            carFactory = new BuickCarFactory();
            carFactory.CreateCar();

            // 生产大众
            carFactory = new VolkswagenCarFactory();
            carFactory.CreateCar();
        }
    }
}
