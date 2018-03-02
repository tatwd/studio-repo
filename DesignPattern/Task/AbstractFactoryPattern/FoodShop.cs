using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    // 江西
    class JxFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public JxFoodShop(params string[] foodNames)
        {
            Foods = new List<Food>();
            Area = "江西";

            Console.WriteLine($"=={ Area }==");

            // add to food list
            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏辣"));
            }
        }
    }

    // 四川
    class ScFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public ScFoodShop(params string[] foodNames)
        {
            Foods = new List<Food>();
            Area = "四川";

            Console.WriteLine($"=={ Area }==");

            // add to food list
            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏麻"));
            }
        }
    }

    // 广东
    class GdFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public GdFoodShop(params string[] foodNames)
        {
            Foods = new List<Food>();
            Area = "广东";

            Console.WriteLine($"=={ Area }==");

            // add to food list
            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏淡"));
            }
        }
    }

    // 上海
    class ShFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public ShFoodShop(params string[] foodNames)
        {
            Foods = new List<Food>();
            Area = "上海";

            Console.WriteLine($"=={ Area }==");

            // add to food list
            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏甜"));
            }
        }
    }
}
