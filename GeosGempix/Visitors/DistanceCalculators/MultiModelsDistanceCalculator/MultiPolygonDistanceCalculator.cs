using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using Point = GeosGempix.Point;

public class MultiPolygonDistanceCalculator : IModelDistanceCalculator
{
    private MultiPolygon _multiPolygon;
    private double _result;

    public MultiPolygonDistanceCalculator(MultiPolygon multiPolygon) =>
        _multiPolygon = multiPolygon;

    public double GetResult() =>
        _result;

    public void Visit(Point point) =>
        _result = GetDistance(_multiPolygon, point);

    public void Visit(Line line) =>
        _result = GetDistance(_multiPolygon, line);

    public void Visit(Polygon polygon) =>
        _result = GetDistance(_multiPolygon, polygon);

    public void Visit(MultiPoint multiPoint) =>
        _result = GetDistance(_multiPolygon, multiPoint);

    public void Visit(MultiLine multiLine) =>
        _result = GetDistance(_multiPolygon, multiLine);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = GetDistance(_multiPolygon, multiPolygon);
    public void Visit(Contour contour) =>
        _result = GetDistance(_multiPolygon, contour);

    internal static double GetDistance(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2) =>
        GetDistance(
            multiPolygon1,
            multiPolygon2,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (MultiPolygon)primitive));

    internal static double GetDistance(MultiPolygon multiPolygon, MultiLine multiLine) =>
        GetDistance(
            multiPolygon,
            multiLine,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (MultiLine)primitive));

    internal static double GetDistance(MultiPolygon multiPolygon, MultiPoint multiPoint) =>
        GetDistance(
            multiPolygon,
            multiPoint,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (MultiPoint)primitive));

    internal static double GetDistance(MultiPolygon multiPolygon, Polygon polygon1) =>
        GetDistance(
            multiPolygon,
            polygon1,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (Polygon)primitive));

    internal static double GetDistance(MultiPolygon multiPolygon, Line line) =>
        GetDistance(
            multiPolygon,
            line,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (Line)primitive));


    internal static double GetDistance(MultiPolygon multiPolygon, Point point) =>
        GetDistance(
            multiPolygon,
            point,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (Point)primitive));

    internal static double GetDistance(MultiPolygon multiPolygon, Contour contour) =>
        GetDistance(
            multiPolygon,
            contour,
            (polygon, primitive) => PolygonDistanceCalculator.GetDistance(polygon, (Contour)primitive));

    internal static double GetDistance(
        MultiPolygon multiPolygon,
        IGeometryPrimitive primitive,
        Func<Polygon, IGeometryPrimitive, double> getDistance)
    {
        double result = 0;
        double distance;
        List<Polygon> polygons = multiPolygon.GetPolygons();
        foreach (Polygon polygon in polygons)
        {
            distance = getDistance?.Invoke(polygon, primitive) ?? 0;
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }
}