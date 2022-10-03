using GeometryModels;


public class LineDistanceCalculator : IGeometryPrimitiveVisitor
{
    private Line _line;
    private double _result;

    public LineDistanceCalculator(Point point1, Point point2)
    {
        _line = new Line(point1, point2);
    }

    public LineDistanceCalculator(Line line)
    {
        _line = line;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(point, _line);
    }

    public void Visit(Line line)
    {
        _result = GetDistance(_line, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = PolygonDistanceCalculator.GetDistance(polygon, _line);
    }

    //Расстояние между точкой и отрезком
    public static double GetDistance(Point point, Line line)
    { 
        double res;
        double a = PointDistanceCalculator.GetDistance(point, line.Point1);
        double b = PointDistanceCalculator.GetDistance(point, line.Point2);
        double c = PointDistanceCalculator.GetDistance(line.Point1, line.Point2);
        if (a * a > b * b + c * c || b * b > a * a + c * c)
        {
            res = Math.Min(a, b);
        }
        else
        {
            double P = line.Point2.Y - line.Point1.Y;
            double Q = line.Point1.X - line.Point2.X;
            double R = -line.Point1.X * P + line.Point1.Y * (line.Point2.X - line.Point1.X);
            res = Math.Abs(P * point.X + Q * point.Y + R) / Math.Sqrt(P * P + Q * Q);
        }
        return res;
    }

    //TODO: Расстояние между двумя отрезками
    public double GetDistance(Line line1, Line line2)
    {
        double min = 0;
        double distance = 0;

        foreach (Point point2 in new Point[] { line2.Point1, line2.Point2 })
        {
            distance = GetDistance(point2, line1);
            if (distance > min)
            {
                min = distance;
            }
        }

        foreach (Point point1 in new Point[] { line1.Point1, line1.Point2 })
        {
            distance = GetDistance(point1, line2);
            if (distance > min)
            {
                min = distance;
            }
        }
        return min;
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _line);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _line);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _line);
    }
}
