using GeosGempix.Models;
using System.Diagnostics.CodeAnalysis;

namespace GeosGempix
{
    public class Point : IGeometryPrimitive
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(Point point)
        {
            if (point == null)
                throw new ArgumentNullException("point");
            X = point.X;
            Y = point.Y;
        }

        public void Accept(IGeometryPrimitiveVisitor v)
        {
            if (v == null)
                throw new ArgumentNullException("v");
            v.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }
    }
}