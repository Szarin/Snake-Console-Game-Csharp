using System;
using System.Collections.Generic;
namespace snake_project
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() 
        {
            X = default;
            Y = default;
        }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;
            Point point = (Point)obj;
            return point.X == X && point.Y == Y;
        }
    }

}
