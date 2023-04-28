using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using Point = GeosGempix.Point;

public class MultiPointDistanceCalculator : IModelDistanceCalculator
{
    private MultiPoint _multiPoint;
    private double _result;

    public MultiPointDistanceCalculator(MultiPoint multiPoint)
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

    public void Visit(Contour contour) =>
        _result = GetDistance(_multiPoint, contour);

    internal static double GetDistance(MultiPoint multiPoint, MultiPolygon multiPolygon) =>
        MultiPolygonDistanceCalculator.GetDistance(multiPolygon, multiPoint);

    internal static double GetDistance(MultiPoint multiPoint, MultiLine multiLine) =>
        MultiLineDistanceCalculator.GetDistance(multiLine, multiPoint);

    internal static double GetDistance(MultiPoint multiPoint1, MultiPoint multiPoint2) =>
         GetDistance(
             multiPoint1,
             multiPoint2,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, (MultiPoint)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Polygon polygon) =>
         GetDistance(
             multiPoint,
             polygon,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, (Polygon)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Line line) =>
         GetDistance(
             multiPoint,
             line,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, (Line)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Point point1) =>
         GetDistance(
             multiPoint,
             point1,
             (point, primitive) => PointDistanceCalculator.GetDistance(point, (Point)primitive));

    internal static double GetDistance(MultiPoint multiPoint, Contour contour) =>
        GetDistance(
            multiPoint,
            contour,
            (point, primitive) => PointDistanceCalculator.GetDistance(point, (Contour)primitive));

    internal static double GetDistance(
        MultiPoint multiPoint,
        IGeometryPrimitive primitive,
        Func<Point, IGeometryPrimitive, double> getDistance)
    {
        double result = double.MaxValue;
        foreach (Point point in multiPoint.GetPoints())
        {
            double distance = getDistance?.Invoke(point, primitive) ?? 0;
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

}