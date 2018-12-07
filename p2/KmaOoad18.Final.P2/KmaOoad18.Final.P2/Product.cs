using System;
using System.Collections.Generic;
using System.Text;

namespace KmaOoad18.Final.P2
{
    public class Product
    {
        public Product(string name, int cost)
        {
            Cost = cost;
            Name = name;
        }

        public string Name { get; }
        public int Cost { get; }
        /*
        public Product Clone()
        {
            return new Product(Name, Cost);
        }*/
        public override string ToString()
        {
            return "("+Name+" : "+Cost+")";
        }
    }
}
