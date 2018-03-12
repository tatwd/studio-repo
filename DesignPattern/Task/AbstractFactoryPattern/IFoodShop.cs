using System.Collections.Generic;

namespace AbstractFactoryPattern
{
    interface IFoodShop
    {
        IList<Food> Foods { get; set; }
        IList<Food> CookFoods(params string[] foodNames);
    }
}
