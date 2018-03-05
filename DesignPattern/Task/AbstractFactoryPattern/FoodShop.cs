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

        public JxFoodShop()
        {
            Foods = new List<Food>();
            Area = "江西";
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {
            Console.WriteLine("所在地区：{0}", Area);

            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏辣"));
            }

            return Foods;
        }
    }

    // 四川
    class ScFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public ScFoodShop()
        {
            Foods = new List<Food>();
            Area = "四川";
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {
            Console.WriteLine("所在地区：{0}", Area);

            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏麻"));
            }

            return Foods;
        }
    }

    // 广东
    class GdFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public GdFoodShop()
        {
            Foods = new List<Food>();
            Area = "广东";
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {
            Console.WriteLine("所在地区：{0}", Area);

            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏淡"));
            }

            return Foods;
        }
    }

    // 上海
    class ShFoodShop : IFoodShop
    {
        public IList<Food> Foods { get; set; }
        public string Area { get; set; }

        public ShFoodShop()
        {
            Foods = new List<Food>();
            Area = "上海";
        }

        public IList<Food> CookFoods(params string[] foodNames)
        {
            Console.WriteLine("所在地区：{0}", Area);

            foreach (var foodName in foodNames)
            {
                Foods.Add(new Food(foodName, "偏甜"));
            }

            return Foods;
        }
    }
}
