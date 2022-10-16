using GeometryModels;

public class Line : IGeometryPrimitive
{
	public Point Point1 { get; private set; }
    public Point Point2 { get; private set; }

	public Line(Point point1, Point point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    public double GetLength()
    {
        return PointDistanceCalculator.GetDistance(Point1, Point2);
    }
    
    //Проверка на пересечение двух отрезков
    public static bool IsIntersection(Line line1, Line line2)
    {
        double delta =  (line1.Point2.X - line1.Point1.X) * (line2.Point1.Y - line2.Point2.Y) - 
            (line1.Point2.Y - line1.Point1.Y) * (line2.Point1.X - line2.Point2.X);
        double delta1 = (line1.Point2.X - line1.Point1.X) * (line2.Point1.Y - line1.Point1.Y) - 
            (line1.Point2.Y - line1.Point1.Y) * (line2.Point1.X - line1.Point1.X);
        double delta2 = (line2.Point1.X - line1.Point1.X) * (line2.Point1.Y - line2.Point2.Y) - 
            (line2.Point1.Y - line1.Point1.Y) * (line2.Point1.X - line2.Point2.X);

        return ((delta != 0) && (delta1/delta >= 0) && (delta1/delta <= 1) && (delta2/delta >= 0) && (delta2/delta <= 1));
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
            Line p = (Line)obj;
            return Point1.Equals(p.Point1) && Point2.Equals(p.Point2);
        }
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
        ABC[2] = lineEq[1]*point.X -point.Y * lineEq[0];
        return ABC;
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
