using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
// using System.Reflection;

namespace AbstractFactoryPattern
{
    class FoodFactory
    {
        public static IList<Food> GetFoods(string area, params string[] foodNames)
        {
            string _area = ConfigurationManager.AppSettings[area];
            Type type = Type.GetType($"AbstractFactoryPattern.{ _area }FoodShop");

            return ((IFoodShop)Activator.CreateInstance(type, foodNames)).Foods;
        }
    }
}
