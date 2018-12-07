using System;
using System.Collections.Generic;
using System.Text;

namespace KmaOoad18.Final.P2
{
    public class Location
    {
        public Location(double x, double y, string label)
        {
            X = x;
            Y = y;
            Label = label;
        }

        public double X { get; }
        public double Y { get; }
        public string Label { get; }
    }
}
