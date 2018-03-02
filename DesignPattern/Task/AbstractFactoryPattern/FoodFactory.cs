using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Reflection;

namespace AbstractFactoryPattern
{
    class FoodFactory
    {
        public static IList<IFood> GetFood(string area, params string[] foods)
        {
            IList<IFood> foodList = new List<IFood>();

            foreach (var food in foods)
            {
                string _area = ConfigurationManager.AppSettings[area];
                Type type = Type.GetType($"AbstractFactoryPattern.{ _area }FoodShop");

                foodList.Add((IFood)Activator.CreateInstance(type, food)); // add to list
            }

            return foodList;
        }
    }
}
