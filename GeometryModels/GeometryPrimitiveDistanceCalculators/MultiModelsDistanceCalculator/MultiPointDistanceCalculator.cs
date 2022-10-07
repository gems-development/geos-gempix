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
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _multiPoint);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _multiPoint);
    }

    internal static double GetDistance(MultiPoint multiPoint, MultiPolygon multiPolygon)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiPoint multiPoint, MultiLine multiLine)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiPoint multiPoint1, MultiPoint multiPoint2)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiPoint multiPoint, Polygon polygon)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiPoint multiPoint, Line line)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiPoint multiPoint, Point point)
    {
        throw new NotImplementedException();
    }
}