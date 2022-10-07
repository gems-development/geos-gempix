using GeometryModels;
using GeometryModels.Interfaces.IModels;

public class LineDistanceCalculator : IModelDistanceCalculator
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
        _result = GetDistance(_line, point);
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
    public static double GetDistance(Line line, Point point)
    { 
        
        return 0;
    }

    //TODO: Расстояние между двумя отрезками
    public static double GetDistance(Line line1, Line line2)
    {
        if(!Line.IsIntersection(line1, line2))
        {
            double[] distances = new double[6];
            distances[0] = PointDistanceCalculator.GetDistance(line1.Point1, line2.Point1);
            distances[1] = PointDistanceCalculator.GetDistance(line1.Point1, line2.Point2);
            distances[2] = PointDistanceCalculator.GetDistance(line1.Point2, line2.Point1);
            distances[3] = PointDistanceCalculator.GetDistance(line1.Point2, line2.Point2);
            double k = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);
            double b = (line2.Point1.Y - k * line2.Point1.X);
            double xz1 = (line1.Point1.X * line2.Point2.X - line1.Point1.X * line2.Point1.X + 
                line1.Point1.Y * line2.Point2.Y - line1.Point1.Y - line2.Point1.Y + 
                line2.Point1.Y * b - line2.Point2.Y * b) / 
                (k * line2.Point2.Y - k * line2.Point1.Y + line2.Point2.X - line2.Point1.X);
            Point point1 = new Point(xz1, k * xz1 + b);
            distances[4] = PointDistanceCalculator.GetDistance(line1.Point1, point1);
            double xz2 = (line1.Point2.X * line2.Point2.X - line1.Point2.X * line2.Point1.X +
                line1.Point2.Y * line2.Point2.Y - line1.Point2.Y - line2.Point1.Y +
                line2.Point1.Y * b - line2.Point2.Y * b) / (k * line2.Point2.Y - k * line2.Point1.Y +
                line2.Point2.X - line2.Point1.X);
            Point point2 = new Point(xz2, k * xz2 + b);
            distances[5] = PointDistanceCalculator.GetDistance(line1.Point1, point2);
            return distances.Min();
        }
        return 0;
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
