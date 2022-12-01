namespace GeometryModels.Models
{
    public class Line : IGeometryPrimitive
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        public Line(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public Line(Line line)
        {
            Point1 = new Point(line.Point1);
            Point2 = new Point(line.Point2);
        }
        public double GetLength()
        {
            return Math.Sqrt(GetSquareLength());
        }
        public double GetSquareLength()
        {
			return PointDistanceCalculator.GetSquareDistance(Point1, Point2);
		}
        public double[] GetEquationOfLine()
        {
            double[] ABC = new double[3];
            double deltaY = Point2.Y - Point1.Y;
            double deltaX = Point2.X - Point1.X;
            ABC[0] = deltaY;
            ABC[1] = -deltaX;
            ABC[2] = Point1.Y * deltaX - Point1.X * deltaY;
            return ABC;
        }

        public static double[] GetEquationOfPerpendicularLine(double[] lineEq, Point point)
        {
            double[] ABC = new double[3];
            ABC[0] = -lineEq[0];
            ABC[1] = lineEq[1];
            ABC[2] = lineEq[1] * point.X - point.Y * lineEq[0];
            return ABC;
        }

        public void Accept(IGeometryPrimitiveVisitor v)
        {
            v.Visit(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Point1, Point2);
        }

        public override bool Equals(object? obj)
        {
            return obj is Line line &&
                   EqualityComparer<Point>.Default.Equals(Point1, line.Point1) &&
                   EqualityComparer<Point>.Default.Equals(Point2, line.Point2);
        }
    }
}