using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using GeosGempix.MultiModels;
using Point = GeosGempix.Point;
using GeosGempix.Extensions;

public class MultiPointShortestLineSearcher : IModelShortestLineSearcher
{
    private MultiPoint _multiPoint;
    private Line? _result;

    public MultiPointShortestLineSearcher(MultiPoint multiPoint)
    {
        _multiPoint = multiPoint;
    }

    public Line? GetResult() =>
        _result;

    public void Visit(Point point) =>
        _result = GetShortestLine(_multiPoint, point);

    public void Visit(Line line) =>
        _result = GetShortestLine(_multiPoint, line);

    public void Visit(Polygon polygon) =>
        _result = GetShortestLine(_multiPoint, polygon);

    public void Visit(MultiPoint multiPoint) =>
        _result = GetShortestLine(_multiPoint, multiPoint);

    public void Visit(MultiLine multiLine) =>
        _result = GetShortestLine(_multiPoint, multiLine);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = GetShortestLine(_multiPoint, multiPolygon);

    public void Visit(Contour contour) =>
        _result = GetShortestLine(_multiPoint, contour);

    internal static Line? GetShortestLine(MultiPoint multiPoint, MultiPolygon multiPolygon) =>
        MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, multiPoint);

    internal static Line? GetShortestLine(MultiPoint multiPoint, MultiLine multiLine) =>
        MultiLineShortestLineSearcher.GetShortestLine(multiLine, multiPoint);

    internal static Line? GetShortestLine(MultiPoint multiPoint1, MultiPoint multiPoint2) =>
         GetShortestLine(
             multiPoint1,
             multiPoint2,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (MultiPoint)primitive));

    internal static Line? GetShortestLine(MultiPoint multiPoint, Polygon polygon)
    {
        if (polygon.IsInside(multiPoint))
            return null;
        return GetShortestLine(
             multiPoint,
             polygon,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Polygon)primitive));
    }
         

    internal static Line? GetShortestLine(MultiPoint multiPoint, Line line) =>
         GetShortestLine(
             multiPoint,
             line,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Line)primitive));

    internal static Line? GetShortestLine(MultiPoint multiPoint, Point point1) =>
         GetShortestLine(
             multiPoint,
             point1,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Point)primitive));

    internal static Line? GetShortestLine(MultiPoint multiPoint, Contour contour) =>
         GetShortestLine(
             multiPoint,
             contour,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Contour)primitive));

    internal static Line? GetShortestLine(
        MultiPoint multiPoint,
        IGeometryPrimitive primitive,
        Func<Point, IGeometryPrimitive, Line> getShortestLine)
    {
        Line shortLine = new Line(new Point(0, 0), new Point(double.MaxValue, double.MaxValue));
        Line curLine = new Line(new Point(0, 0), new Point(0, 0));
        foreach (Point point in multiPoint.GetPoints())
        {
            curLine = getShortestLine(point, primitive);
            if (curLine.GetLength() < shortLine.GetLength())
            {
                shortLine = new Line(curLine);
            }
        }
        return shortLine;
    }
}