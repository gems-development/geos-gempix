using GeometryModels.Interfaces.IModels;
using Point = GeometryModels.Point;

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

    internal static double GetDistance(MultiLine multiLine, Polygon polygon) =>
         GetDistance(
             multiLine,
             polygon,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, primitive as Polygon));

    internal static double GetDistance(MultiLine multiLine, Line line1) =>
         GetDistance(
             multiLine,
             line1,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, primitive as Line));

    internal static double GetDistance(MultiLine multiLine, Point point) =>
         GetDistance(
             multiLine,
             point,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, primitive as Point));

    internal static double GetDistance(MultiLine multiLine1, MultiLine multiLine2) =>
         GetDistance(
             multiLine1,
             multiLine2,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, primitive as MultiLine));

    internal static double GetDistance(MultiLine multiLine, MultiPoint multiPoint) =>
         GetDistance(
             multiLine,
             multiPoint,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, primitive as MultiPoint));
    internal static double GetDistance(
        MultiLine multiLine,
        IGeometryPrimitive primitive,
        Func<Line, IGeometryPrimitive, double> getDistance)
    {
        double result = 0;
        double distance;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line in lines)
        {
            distance = getDistance?.Invoke(line, primitive) ?? 0;
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }
}