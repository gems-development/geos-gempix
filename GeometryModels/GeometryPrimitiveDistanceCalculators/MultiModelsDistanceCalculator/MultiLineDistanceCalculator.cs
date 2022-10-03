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
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiLine multiLine, Line line)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiLine multiLine, Point point)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiLine multiLine1, MultiLine multiLine2)
    {
        throw new NotImplementedException();
    }

    internal static double GetDistance(MultiLine multiLine, MultiPoint multiPoint)
    {
        throw new NotImplementedException();
    }
}