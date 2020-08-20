using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("Write 'help' to list available coffee shop commands, " +
                "write 'quit' to exit application");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                string line = Console.ReadLine();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                    break;
                else
                {
                    IEnumerable<CoffeeShop> coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                    if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("> Available coffee shop commands:");
                        foreach (CoffeeShop coffeeShop in coffeeShops)
                            Console.WriteLine($"> {coffeeShop.Location}");
                    }
                    else
                    {
                        List<CoffeeShop> foundCoffeeShops = coffeeShops
                            .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        if (foundCoffeeShops.Count == 0)
                            Console.WriteLine($"> Command '{line}' not found");
                        else if (foundCoffeeShops.Count == 1)
                        {
                            var coffeeShop = foundCoffeeShops.Single();
                            Console.WriteLine($"> Location: {coffeeShop.Location}");
                            Console.WriteLine($"> Beans in stock: {coffeeShop.BeansInStockInKg} kg");
                        }
                        else
                        {
                            Console.WriteLine($"> Multiple matching coffee shop commands found:");
                            foreach (CoffeeShop coffeeType in foundCoffeeShops)
                                Console.WriteLine($"> {coffeeType.Location}");
                        }
                    }
                }
            }
        }
    }
}