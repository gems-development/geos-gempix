namespace GeosGempix.Models
{
    public class Line : IGeometryPrimitive
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        public Line(Point point1, Point point2)
        {
            if (point1 == null)
                throw new ArgumentNullException("point1");
            if (point2 == null)
                throw new ArgumentNullException("point2");
            Point1 = point1;
            Point2 = point2;
        }

        public Line(Line line)
        {
            if (line == null)
                throw new ArgumentNullException("line");
            Point1 = new Point(line.Point1);
            Point2 = new Point(line.Point2);
        }
        public double GetLength()
        {
            return PointDistanceCalculator.GetDistance(Point1, Point2);
        }

        public (double a, double b, double c) GetEquationOfLine()
        {
            double deltaY = Point2.Y - Point1.Y;
            double deltaX = Point2.X - Point1.X;
            return (deltaY, -deltaX, Point1.Y * deltaX - Point1.X * deltaY);
        }

        public static (double a, double b, double c) GetEquationOfPerpendicularLine((double a, double b, double c) lineEq, Point point)
        {
            if (point == null)
                throw new ArgumentNullException("point");
            return (-lineEq.b, lineEq.a, lineEq.b * point.X - point.Y * lineEq.a);
        }

        public void Accept(IGeometryPrimitiveVisitor v)
        {
            if (v == null)
                throw new ArgumentNullException("v");
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