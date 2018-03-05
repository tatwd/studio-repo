using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IFoodShop foodShop = FoodShopFactory.GetFoodShop();

            foodShop.CookFoods("宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
            
            // FoodFactory.GetFoods("四川", "宫爆鸡丁", "鱼香茄子");
            // FoodFactory.GetFoods("广东", "宫爆鸡丁", "鱼香茄子", "西红柿炒蛋");
            // FoodFactory.GetFoods("上海", "宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
        }
    }
}
