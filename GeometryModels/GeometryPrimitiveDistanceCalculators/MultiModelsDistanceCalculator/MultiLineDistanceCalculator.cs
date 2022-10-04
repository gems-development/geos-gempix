using GeometryModels;
using GeometryModels.Interfaces.IModels;

internal class MultiLineDistanceCalculator : IModelDistanceCalculator
{
    private MultiLine _multiLine;
    private double _result;

    public MultiLineDistanceCalculator(MultiLine multiLine)
    {
        _multiLine = multiLine;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(_multiLine, point);
    }

    public void Visit(Line line)
    {
        _result = GetDistance(_multiLine, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = GetDistance(_multiLine, polygon);
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = GetDistance(_multiLine, multiPoint);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = GetDistance(_multiLine, multiLine);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _multiLine);
    }

    internal static double GetDistance(MultiLine multiLine, Polygon polygon)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line in lines)
        {
            distance = PolygonDistanceCalculator.GetDistance(polygon, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiLine multiLine, Line line)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line1 in lines)
        {
            distance = LineDistanceCalculator.GetDistance(line1, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiLine multiLine, Point point)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line in lines)
        {
            distance = LineDistanceCalculator.GetDistance(line, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiLine multiLine1, MultiLine multiLine2)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine1.GetLines();
        foreach (Line line in lines)
        {
            distance = GetDistance(multiLine2, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(MultiLine multiLine, MultiPoint multiPoint)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line in lines)
        {
            distance = MultiPointDistanceCalculator.GetDistance(multiPoint, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }
}