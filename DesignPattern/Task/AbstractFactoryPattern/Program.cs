namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IFoodShop foodShop = FoodShopFactory.GetFoodShop();

            if (foodShop == null)
                return;

            foodShop.CookFoods("宫爆鸡丁");
            foodShop.CookFoods("宫爆鸡丁", "鱼香茄子");
            foodShop.CookFoods("宫爆鸡丁", "鱼香茄子", "西红柿炒蛋");
            foodShop.CookFoods("宫爆鸡丁", "鱼香茄子", "西红柿炒蛋", "麻婆豆腐");
        }
    }
}
