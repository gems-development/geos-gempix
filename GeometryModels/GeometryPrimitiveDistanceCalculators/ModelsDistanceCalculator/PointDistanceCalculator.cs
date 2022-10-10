using GeometryModels;
using GeometryModels.Interfaces.IModels;

public class PointDistanceCalculator : IModelDistanceCalculator
{
    private Point _point;
    private double _result;
    public PointDistanceCalculator(Point point)
    { 
        _point = point;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(_point, point);
    }

    public void Visit(Line line)
    {
        _result = LineDistanceCalculator.GetDistance(line, _point);
    }

    public void Visit(Polygon polygon)
    {
        _result = PolygonDistanceCalculator.GetDistance(polygon, _point);
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _point);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _point);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _point);
    }

    //Проверка на принадлежность точки отрезку
    public static bool IsBelong(Point point, Line line)
    {
        return GetDistance(point, line.Point1) + GetDistance(point, line.Point2) == line.GetLength();
    }

    public double GetResult()
    {
        return _result;
    }

    public static double GetDistance(Point point1, Point point2)
    {
        return Math.Sqrt((point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y));
    }

    public static double GetDistance(Point point, Line line) =>
        LineDistanceCalculator.GetDistance(line, point);

    public static double GetDistance(Point point, Polygon polygon) =>
        PolygonDistanceCalculator.GetDistance(polygon, point);

    public static double GetDistance(Point point, MultiLine multiLine) =>
        MultiLineDistanceCalculator.GetDistance(multiLine, point);

    public static double GetDistance(Point point, MultiPoint multiPoint) =>
        MultiPointDistanceCalculator.GetDistance(multiPoint, point);

    public static double GetDistance(Point point, MultiPolygon multiPolygon) =>
        MultiPolygonDistanceCalculator.GetDistance(multiPolygon, point);
}
