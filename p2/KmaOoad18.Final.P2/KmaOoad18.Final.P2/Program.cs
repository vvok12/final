using System;

namespace KmaOoad18.Final.P2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = {
                new Product("A", 13),
                new Product("B", 17),
                new Product("C", 23)
            };

            Location l1 = new Location(0,0,"start");
            Location l2 = new Location(10, -10, "end");
            Consumer c = new Consumer
            {
                MyLocation = l1,
                ShippingLocation = l1
            };

            c.AddProduct(products[0], 1);
            Console.WriteLine(c.GetCurrentShoppingCart()+ " -> total = "+ c.CalculateTotalCost());
            c.AddProduct(products[0], 5).AddProduct(products[1], 3);
            Console.WriteLine(c.GetCurrentShoppingCart() + " -> total = " + c.CalculateTotalCost());
            c.AddProduct(products[2], 2).AddProduct(products[1], 3);
            Console.WriteLine(c.GetCurrentShoppingCart() + " -> total = " + c.CalculateTotalCost());

            Console.ReadKey();
        }
    }
}
