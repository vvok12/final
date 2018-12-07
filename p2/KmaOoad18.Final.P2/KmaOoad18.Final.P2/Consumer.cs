using System;
using System.Collections.Generic;

using KmaOoad18.Final.P2;
namespace KmaOoad18.Final.P2
{
    public class Consumer
    {
        public Consumer()
        {
            ShoppingCart = new List<(Product p, int amo)>();
        }

        public string GetCurrentShoppingCart()
        {
            string s = "{";
            foreach (var e in ShoppingCart)
                s += "(" + e.p + "," + e.amo + ")";
            s += "}";
            return s;
        }

        public Consumer AddProduct(Product p, int amo)
        {
            (Product p, int amo) toDel = (null, 0);
            foreach (var ass in ShoppingCart)
                if (ass.p == p)
                {
                    toDel = ass;
                    break;
                }
            if (toDel.p != null)
            {
                amo += toDel.amo;
                ShoppingCart.Remove(toDel);
                ShoppingCart.Add((p, amo));
                amo = 0;
            }
            if (amo != 0)
                ShoppingCart.Add((p, amo));
            return this;
        }

        private List<(Product p, int amo)> ShoppingCart { get; }

        public double GetPromocode()
        {
            return _promocode;
        }
        public void SetPromocode(double ins)
        {
            if (ins >= 0 && ins <= 1)
                _promocode = ins;
            else throw new System.Exception("Promocode should be a number beetwen 0 and 1");
        }
        private double _promocode;

        public Location MyLocation { get; set; }
        public Location ShippingLocation { get; set; }

        private int CalculateProductTotalCost()
        {
            int sum = 0;
            foreach(var pr in ShoppingCart)
            {
                sum += pr.amo * pr.p.Cost;
            }
            return sum;
        }

        public int CalculateTotalCost()
        {
            return (int)(Math.Ceiling(CalculateProductTotalCost() * (1 - _promocode))) + CalculateTransportingTotal();
        }

        private int CalculateTransportingTotal()
        {
            if (MyLocation == null || ShoppingCart == null)
                throw new System.Exception("Locations are not initialized");

            return relocationCostCoef * (int)Math.Ceiling(
                Math.Pow(MyLocation.X-ShippingLocation.X, 2) + 
                Math.Pow(MyLocation.Y - ShippingLocation.Y, 2)) ;
        }

        private int relocationCostCoef;

        //shopping cart
        //promocode
        //shipping adress
        //my location
    }
}
