using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using Point = GeosGempix.Point;

public class MultiPolygonShortestLineSearcher : IModelShortestLineSearcher
{
    private MultiPolygon _multiPolygon;
    private Line _result;

    public MultiPolygonShortestLineSearcher(MultiPolygon multiPolygon) =>
        _multiPolygon = multiPolygon;

    public Line GetResult() =>
        _result;

    public void Visit(Point point) =>
        _result = GetShortestLine(_multiPolygon, point);

    public void Visit(Line line) =>
        _result = GetShortestLine(_multiPolygon, line);

    public void Visit(Polygon polygon) =>
        _result = GetShortestLine(_multiPolygon, polygon);

    public void Visit(MultiPoint multiPoint) =>
        _result = GetShortestLine(_multiPolygon, multiPoint);

    public void Visit(MultiLine multiLine) =>
        _result = GetShortestLine(_multiPolygon, multiLine);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = GetShortestLine(_multiPolygon, multiPolygon);

    internal static Line GetShortestLine(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2) =>
        GetShortestLine(
            multiPolygon1,
            multiPolygon2,
            (polygon, primitive) => PolygonShortestLineSearcher.GetShortestLine(polygon, (MultiPolygon)primitive));

    internal static Line GetShortestLine(MultiPolygon multiPolygon, MultiLine multiLine) =>
        GetShortestLine(
            multiPolygon,
            multiLine,
            (polygon, primitive) => PolygonShortestLineSearcher.GetShortestLine(polygon, (MultiLine)primitive));

    internal static Line GetShortestLine(MultiPolygon multiPolygon, MultiPoint multiPoint) =>
        GetShortestLine(
            multiPolygon,
            multiPoint,
            (polygon, primitive) => PolygonShortestLineSearcher.GetShortestLine(polygon, (MultiPoint)primitive));

    internal static Line GetShortestLine(MultiPolygon multiPolygon, Polygon polygon1) =>
        GetShortestLine(
            multiPolygon,
            polygon1,
            (polygon, primitive) => PolygonShortestLineSearcher.GetShortestLine(polygon, (Polygon)primitive));

    internal static Line GetShortestLine(MultiPolygon multiPolygon, Line line) =>
        GetShortestLine(
            multiPolygon,
            line,
            (polygon, primitive) => PolygonShortestLineSearcher.GetShortestLine(polygon, (Line)primitive));


    internal static Line GetShortestLine(MultiPolygon multiPolygon, Point point) =>
        GetShortestLine(
            multiPolygon,
            point,
            (polygon, primitive) => PolygonShortestLineSearcher.GetShortestLine(polygon, (Point)primitive));

    internal static Line GetShortestLine(
        MultiPolygon multiPolygon,
        IGeometryPrimitive primitive,
        Func<Polygon, IGeometryPrimitive, Line> GetShortestLine)
    {
        Line result = new Line(new Point(0, 0), new Point(0, 0));
        Line distance = new Line(new Point(0, 0), new Point(0, 0));
        List<Polygon> polygons = multiPolygon.GetPolygons();
        foreach (Polygon polygon in polygons)
        {
            distance = GetShortestLine.Invoke(polygon, primitive);
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