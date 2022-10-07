using GeometryModels;
using GeometryModels.Interfaces.IModels;

internal class MultiPointDistanceCalculator : IModelDistanceCalculator
{
    private MultiPoint _multiPoint;
    private double _result;

    public MultiPointDistanceCalculator(MultiPoint multiPoint)
    {
        _multiPoint = multiPoint;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(_multiPoint, point);
    }

    public void Visit(Line line)
    {
        _result = GetDistance(_multiPoint, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = GetDistance(_multiPoint, polygon);
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = GetDistance(_multiPoint, multiPoint);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = GetDistance(_multiPoint, multiLine);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = GetDistance(_multiPoint, multiPolygon);
    }

    internal static double GetDistance(MultiPoint multiPoint, MultiPolygon multiPolygon)
    {
        return MultiPolygonDistanceCalculator.GetDistance(multiPolygon, multiPoint);
    }

    internal static double GetDistance(MultiPoint multiPoint, MultiLine multiLine)
    {
        return MultiLineDistanceCalculator.GetDistance(multiLine, multiPoint);
    }

    internal static double GetDistance(MultiPoint multiPoint1, MultiPoint multiPoint2)
    {
        double result = 0;
        double distance;
        foreach (Point point in multiPoint2.GetPoints())
        {
            distance = GetDistance(multiPoint1, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPoint multiPoint, Polygon polygon)
    {
        double result = 0;
        double distance;
        foreach (Point point in multiPoint.GetPoints())
        {
            distance = PolygonDistanceCalculator.GetDistance(polygon, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPoint multiPoint, Line line)
    {
        double result = 0;
        double distance;
        foreach (Point point in multiPoint.GetPoints())
        {
            distance = LineDistanceCalculator.GetDistance(line, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPoint multiPoint, Point point1)
    {
        double result = 0;
        double distance;
        foreach (Point point in multiPoint.GetPoints())
        {
            distance = PointDistanceCalculator.GetDistance(point, point1);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }
}