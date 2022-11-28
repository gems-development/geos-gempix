using GeosGempix;
using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;
using GeosGempix.MultiModels;

public class PointDistanceCalculator : IModelDistanceCalculator
{
    private Point _point;
    private double _result;
    public PointDistanceCalculator(Point point) =>
        _point = point;

    public void Visit(Point point) =>
        _result = GetDistance(_point, point);

    public void Visit(Line line) =>
        _result = LineDistanceCalculator.GetDistance(line, _point);

    public void Visit(Polygon polygon) =>
        _result = PolygonDistanceCalculator.GetDistance(polygon, _point);

    public void Visit(MultiPoint multiPoint) =>
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _point);

    public void Visit(MultiLine multiLine) =>
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _point);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _point);

    public void Visit(Contour contour) =>
        _result = ContourDistanceCalculator.GetDistance(contour, _point);

    public double GetResult() =>
        _result;

    internal static double GetDistance(Point point1, Point point2) =>
        Math.Sqrt(GetSquareDistance(point1, point2));

    internal static double GetSquareDistance(Point point1, Point point2) =>
        ((point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y));

    internal static double GetDistance(Point point, Line line) =>
        LineDistanceCalculator.GetDistance(line, point);

    internal static double GetDistance(Point point, Polygon polygon) =>
        PolygonDistanceCalculator.GetDistance(polygon, point);

    internal static double GetDistance(Point point, MultiLine multiLine) =>
        MultiLineDistanceCalculator.GetDistance(multiLine, point);

    internal static double GetDistance(Point point, MultiPoint multiPoint) =>
        MultiPointDistanceCalculator.GetDistance(multiPoint, point);

    internal static double GetDistance(Point point, MultiPolygon multiPolygon) =>
        MultiPolygonDistanceCalculator.GetDistance(multiPolygon, point);

    internal static double GetDistance(Point point, Contour contour) =>
        ContourDistanceCalculator.GetDistance(contour, point);
}
