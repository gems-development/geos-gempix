using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;
using GeosGempix.MultiModels;
using Point = GeosGempix.Point;

public class MultiLineDistanceCalculator : IModelDistanceCalculator
{
    private MultiLine _multiLine;
    private double _result;

    public MultiLineDistanceCalculator(MultiLine multiLine) =>
        _multiLine = multiLine;

    public double GetResult() =>
        _result;

    public void Visit(Point point) =>
        _result = GetDistance(_multiLine, point);

    public void Visit(Line line) =>
        _result = GetDistance(_multiLine, line);

    public void Visit(Polygon polygon) =>
        _result = GetDistance(_multiLine, polygon);

    public void Visit(MultiPoint multiPoint) =>
        _result = GetDistance(_multiLine, multiPoint);

    public void Visit(MultiLine multiLine) =>
        _result = GetDistance(_multiLine, multiLine);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _multiLine);

    public void Visit(Contour contour) =>
        _result = GetDistance(_multiLine, contour);

    internal static double GetDistance(MultiLine multiLine, Polygon polygon) =>
         GetDistance(
             multiLine,
             polygon,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, (Polygon)primitive));

    internal static double GetDistance(MultiLine multiLine, Line line1) =>
         GetDistance(
             multiLine,
             line1,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, (Line)primitive));

    internal static double GetDistance(MultiLine multiLine, Point point) =>
         GetDistance(
             multiLine,
             point,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, (Point)primitive));

    internal static double GetDistance(MultiLine multiLine1, MultiLine multiLine2) =>
         GetDistance(
             multiLine1,
             multiLine2,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, (MultiLine)primitive));

    internal static double GetDistance(MultiLine multiLine, MultiPoint multiPoint) =>
         GetDistance(
             multiLine,
             multiPoint,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, (MultiPoint)primitive));
    internal static double GetDistance(
        MultiLine multiLine,
        IGeometryPrimitive primitive,
        Func<Line, IGeometryPrimitive, double> getDistance)
    {
        double result = Double.MaxValue;
        List<Line> lines = multiLine.GetLines();
        foreach (Line line in lines)
        {
            double distance = getDistance?.Invoke(line, primitive) ?? 0;
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }


    internal static double GetDistance(MultiLine multiLine, Contour contour) =>
         GetDistance(
             multiLine,
             contour,
             (line, primitive) => LineDistanceCalculator.GetDistance(line, (Contour)primitive));
    
    internal static double GetDistanceInside(MultiLine multiLine, Contour contour) =>
        GetDistance(
            multiLine,
            contour,
            (line, primitive) => LineDistanceCalculator.GetDistanceInside(line, (Contour)primitive));
}