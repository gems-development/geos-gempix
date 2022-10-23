namespace GeometryModels
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
			X = point.X;
			Y = point.Y;
		}

		public void Accept(IGeometryPrimitiveVisitor v)
		{
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