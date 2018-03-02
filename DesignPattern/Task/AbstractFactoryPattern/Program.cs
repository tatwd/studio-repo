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
            FoodFactory.GetFood("江西", "宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
            FoodFactory.GetFood("四川", "宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
            FoodFactory.GetFood("广东", "宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
            FoodFactory.GetFood("上海", "宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
        }
    }
}
