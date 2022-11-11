using GeometryModels.Interfaces.IModels;
using GeometryModels.Models;
using Point = GeometryModels.Point;

public class MultiPointShortestLineSearcher : IModelDistanceCalculator
{
    private MultiPoint _multiPoint;
    private double _result;

    public MultiPointShortestLineSearcher(MultiPoint multiPoint)
    {
        _multiPoint = multiPoint;
    }

    public double GetResult() =>
        _result;

    public void Visit(Point point) =>
        _result = GetDistance(_multiPoint, point);

    public void Visit(Line line) =>
        _result = GetDistance(_multiPoint, line);

    public void Visit(Polygon polygon) =>
        _result = GetDistance(_multiPoint, polygon);

    public void Visit(MultiPoint multiPoint) =>
        _result = GetDistance(_multiPoint, multiPoint);

    public void Visit(MultiLine multiLine) =>
        _result = GetDistance(_multiPoint, multiLine);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = GetDistance(_multiPoint, multiPolygon);

    internal static double GetDistance(MultiPoint multiPoint, MultiPolygon multiPolygon) =>
        MultiPolygonShortestLineSearcher.GetDistance(multiPolygon, multiPoint);

    internal static double GetDistance(MultiPoint multiPoint, MultiLine multiLine) =>
        MultiLineShortestLineSearcher.GetDistance(multiLine, multiPoint);

    internal static double GetDistance(MultiPoint multiPoint1, MultiPoint multiPoint2) =>
         GetDistance(
             multiPoint1,
             multiPoint2,
             (point, primitive) => PointShortestLineSearcher.GetDistance(point, (MultiPoint)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Polygon polygon) =>
         GetDistance(
             multiPoint,
             polygon,
             (point, primitive) => PointShortestLineSearcher.GetDistance(point, (Polygon)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Line line) =>
         GetDistance(
             multiPoint,
             line,
             (point, primitive) => PointShortestLineSearcher.GetDistance(point, (Line)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Point point1) =>
         GetDistance(
             multiPoint,
             point1,
             (point, primitive) => PointShortestLineSearcher.GetDistance(point, (Point)primitive));

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

    public void Visit(Contour contour) =>
        throw new NotImplementedException();
}