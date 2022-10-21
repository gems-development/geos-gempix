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
		public override bool Equals(Object obj)
		{
			//Check for null and compare run-time types.
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Point p = (Point)obj;
				return (X == p.X) && (Y == p.Y);
			}
		}

		public void Accept(IGeometryPrimitiveVisitor v)
		{
			v.Visit(this);
		}
	}
}