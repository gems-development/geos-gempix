using GeometryModels;
using GeometryModels.Interfaces.IModels;
using System.Drawing;
using System.Reflection;
using Point = GeometryModels.Point;

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

    internal static double GetDistance(MultiPoint multiPoint1, MultiPoint multiPoint2) =>
         GetDistance(
             multiPoint1,
             multiPoint2,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, primitive as MultiPoint));

    internal static double GetDistance(MultiPoint multiPoint, Polygon polygon) =>
         GetDistance(
             multiPoint,
             polygon,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, primitive as Polygon));

    internal static double GetDistance(MultiPoint multiPoint, Line line) =>
         GetDistance(
             multiPoint,
             line,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, primitive as Line));

    internal static double GetDistance(MultiPoint multiPoint, Point point1) =>
         GetDistance(
             multiPoint,
             point1,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, primitive as Point));

    internal static double GetDistance(
        MultiPoint multiPoint,
        IGeometryPrimitive primitive,
        Func<Point, IGeometryPrimitive, double> getDistance)
    {
        double result = 0;
        double distance;
        foreach (Point point in multiPoint.GetPoints())
        {
            distance = getDistance?.Invoke(point, primitive) ?? 0;
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }
}