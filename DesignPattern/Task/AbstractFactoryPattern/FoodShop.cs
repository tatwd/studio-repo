using System;
using System.Collections.Generic;

namespace AbstractFactoryPattern
{
    // 江西
    class JxFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }

        public JxFoodShop()
        {
            Foods = new List<Food>();
            Console.WriteLine("所在地区：江西");
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {

            foreach (var foodName in foodNames)
            {
                Foods.Add(
                    new Food(foodName, "偏辣"));
            }

            return Foods;
        }
    }

    // 四川
    class ScFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }

        public ScFoodShop()
        {
            Foods = new List<Food>();
            Console.WriteLine("所在地区：四川");
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {

            foreach (var foodName in foodNames)
            {
                Foods.Add(
                    new Food(foodName, "偏麻"));
            }

            return Foods;
        }
    }

    // 广东
    class GdFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }

        public GdFoodShop()
        {
            Foods = new List<Food>();
            Console.WriteLine("所在地区：广东");
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {
            foreach (var foodName in foodNames)
            {
                Foods.Add(
                    new Food(foodName, "偏淡"));
            }

            return Foods;
        }
    }

    // 上海
    class ShFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }

        public ShFoodShop()
        {
            Foods = new List<Food>();
            Console.WriteLine("所在地区：上海");
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {
            foreach (var foodName in foodNames)
            {
                Foods.Add(
                    new Food(foodName, "偏甜"));
            }

            return Foods;
        }
    }
}
