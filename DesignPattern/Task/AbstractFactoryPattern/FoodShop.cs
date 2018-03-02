using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    // 江西
    class JxFoodShop: IFood
    {
        public string Name { get; set; }
        public string Taste { get; set; }
        public string Area { get; set; }

        public JxFoodShop(string name)
        {
            Name = name;
            Taste = "偏辣";
            Area = "江西";

            Console.WriteLine($"菜名：{ Name } 口味：{ Taste } 地区：{ Area }");
        }
    }

    // 四川
    class ScFoodShop : IFood
    {
        public string Name { get; set; }
        public string Taste { get; set; }
        public string Area { get; set; }

        public ScFoodShop(string name)
        {
            Name = name;
            Taste = "偏麻";
            Area = "四川";

            Console.WriteLine($"菜名：{ Name } 口味：{ Taste } 地区：{ Area }");
        }
    }

    // 广东
    class GdFoodShop : IFood
    {
        public string Name { get; set; }
        public string Taste { get; set; }
        public string Area { get; set; }

        public GdFoodShop(string name)
        {
            Name = name;
            Taste = "偏淡";
            Area = "广东";

            Console.WriteLine($"菜名：{ Name } 口味：{ Taste } 地区：{ Area }");
        }
    }

    // 上海
    class ShFoodShop : IFood
    {
        public string Name { get; set; }
        public string Taste { get; set; }
        public string Area { get; set; }

        public ShFoodShop(string name)
        {
            Name = name;
            Taste = "偏甜";
            Area = "上海";

            Console.WriteLine($"菜名：{ Name } 口味：{ Taste } 地区：{ Area }");
        }
    }
}
