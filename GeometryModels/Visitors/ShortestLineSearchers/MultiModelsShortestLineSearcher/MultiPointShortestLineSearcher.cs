using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeometryModels.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using Point = GeometryModels.Point;

public class MultiPointShortestLineSearcher : IModelShortestLineSearcher
{
    private MultiPoint _multiPoint;
    private Line _result;

    public MultiPointShortestLineSearcher(MultiPoint multiPoint)
    {
        _multiPoint = multiPoint;
    }

    public Line GetResult() =>
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

    internal static Line GetShortestLine(MultiPoint multiPoint, MultiPolygon multiPolygon) =>
        MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, multiPoint);

    internal static Line GetShortestLine(MultiPoint multiPoint, MultiLine multiLine) =>
        MultiLineShortestLineSearcher.GetShortestLine(multiLine, multiPoint);

    internal static Line GetShortestLine(MultiPoint multiPoint1, MultiPoint multiPoint2) =>
         GetShortestLine(
             multiPoint1,
             multiPoint2,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (MultiPoint)primitive));

    internal static Line GetShortestLine(MultiPoint multiPoint, Polygon polygon) =>
         GetShortestLine(
             multiPoint,
             polygon,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Polygon)primitive));

    internal static Line GetShortestLine(MultiPoint multiPoint, Line line) =>
         GetShortestLine(
             multiPoint,
             line,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Line)primitive));

    internal static Line GetShortestLine(MultiPoint multiPoint, Point point1) =>
         GetShortestLine(
             multiPoint,
             point1,
             (point, primitive) => PointShortestLineSearcher.GetShortestLine(point, (Point)primitive));

    internal static Line GetShortestLine(
        MultiPoint multiPoint,
        IGeometryPrimitive primitive,
        Func<Point, IGeometryPrimitive, Line> GetShortestLine)
    {
        Line result = new Line(new Point(0, 0), new Point(0, 0));
        Line distance = new Line(new Point(0, 0), new Point(0, 0));
        foreach (Point point in multiPoint.GetPoints())
        {
            distance = GetShortestLine.Invoke(point, primitive);
            if (distance.GetLength() < result.GetLength())
            {
                result = new Line(distance);
            }
        }
        return result;
    }

    public void Visit(Contour contour) =>
        throw new NotImplementedException();
}