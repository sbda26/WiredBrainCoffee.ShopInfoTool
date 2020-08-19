using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using WiredBrainCoffee.DataAccess;
using WiredBrainCoffee.DataAccess.Model;

namespace WiredBrainCoffee.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");

            Console.WriteLine("Write 'help' to list available coffee shop commands");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                string line = Console.ReadLine();
                IEnumerable<CoffeeShop> coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach (CoffeeShop coffeeShop in coffeeShops)
                        Console.WriteLine($"> {coffeeShop.Location}");
                }

            }
        }
    }
}