using GeometryModels;
using GeometryModels.Interfaces.IModels;

internal class MultiPolygonDistanceCalculator : IModelDistanceCalculator
{
    private MultiPolygon _multiPolygon;
    private double _result;

    public MultiPolygonDistanceCalculator(MultiPolygon multiPolygon)
    {
        _multiPolygon = multiPolygon;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(_multiPolygon, point);
    }

    public void Visit(Line line)
    {
        _result = GetDistance(_multiPolygon, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = GetDistance(_multiPolygon, polygon);
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = GetDistance(_multiPolygon, multiPoint);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = GetDistance(_multiPolygon, multiLine);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = GetDistance(_multiPolygon, multiPolygon);
    }

    internal static double GetDistance(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
    {
        double result = 0;
        double distance;
        List<Polygon> polygons = multiPolygon2.GetPolygons();
        foreach (Polygon polygon in polygons)
        {
            distance = GetDistance(multiPolygon1, polygon);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPolygon multiPolygon, MultiLine multiLine)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line in lines)
        {
            distance = GetDistance(multiPolygon, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPolygon multiPolygon, MultiPoint multiPoint)
    {
        double result = 0;
        double distance;
        List<Point> points = multiPoint.GetPoints();
        foreach (Point point in points)
        {
            distance = GetDistance(multiPolygon, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPolygon multiPolygon, Polygon polygon1)
    {
        double result = 0;
        double distance;
        List<Polygon> polygons = multiPolygon.GetPolygons();
        foreach (Polygon polygon in polygons)
        {
            distance = PolygonDistanceCalculator.GetDistance(polygon, polygon1);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPolygon multiPolygon, Line line)
    {
        double result = 0;
        double distance;
        List<Polygon> polygons = multiPolygon.GetPolygons();
        foreach (Polygon polygon in polygons)
        {
            distance = PolygonDistanceCalculator.GetDistance(polygon, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiPolygon multiPolygon, Point point)
    {
        double result = 0;
        double distance;
        List<Polygon> polygons = multiPolygon.GetPolygons(); 
        foreach (Polygon polygon in polygons)
        {
            distance = PolygonDistanceCalculator.GetDistance(polygon, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }
}