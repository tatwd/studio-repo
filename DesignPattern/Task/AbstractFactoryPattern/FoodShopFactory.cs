using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
// using System.Reflection;

namespace AbstractFactoryPattern
{
    class FoodShopFactory
    {
        private static string area = ConfigurationManager.AppSettings["Area"];
        private static string assembly = ConfigurationManager.AppSettings["Assembly"];

        public static IFoodShop GetFoodShop()
        {
            Type type = Type.GetType($"{ assembly }.{ area }FoodShop");

            return (IFoodShop)Activator.CreateInstance(type);
        }
    }
}
