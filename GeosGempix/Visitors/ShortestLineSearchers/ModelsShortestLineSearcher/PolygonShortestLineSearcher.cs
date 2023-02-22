using GeosGempix;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using GeosGempix.MultiModels;
using GeosGempix.Visitors.Insiders;
using GeosGempix.Extensions;


public class PolygonShortestLineSearcher : IModelShortestLineSearcher
{
    private Polygon _polygon;
    private Line _result;

    public PolygonShortestLineSearcher(Polygon polygon)
    {
        _polygon = polygon;
        _result = new Line(new Point(0, 0), new Point(0, 0));
    }

    public void Visit(Point point) =>
        _result = GetShortestLine(_polygon, point);

    public void Visit(Line line) =>
        _result = GetShortestLine(_polygon, line);

    public void Visit(Polygon polygon) =>
        _result = GetShortestLine(_polygon, polygon);

    public Line GetResult() =>
        _result;

    public void Visit(MultiPoint multiPoint) =>
        _result = MultiPointShortestLineSearcher.GetShortestLine(multiPoint, _polygon);

    public void Visit(MultiLine multiLine) =>
        _result = MultiLineShortestLineSearcher.GetShortestLine(multiLine, _polygon);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, _polygon);

    // добавление ? избавляет от warnings связанным с возможным возвратом null
    internal static Line? GetShortestLine(Polygon polygon, Point point)

    internal static Line GetShortestLine(Polygon polygon, Point point)
    {
        Line shortLine = new Line(new Point(0, 0), new Point(0, 0));
        Line curLine = new Line(new Point(0, 0), new Point(0, 0));
        foreach (Contour contour in polygon.GetHoles()){
            if (contour.Intersects(point))
                return null;
        }
        List<Point> points = polygon.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));
        foreach (Line line in lines)
        {
            curLine = LineShortestLineSearcher.GetShortestLine(line, point);
            if (curLine.GetLength() < shortLine.GetLength())
            {
				shortLine = new Line(curLine);
            }
        }
        return shortLine;
    }


    internal static Line GetShortestLine(Polygon polygon, Line line)
    {
        Line shortLine = new Line(new Point(0, 0), new Point(0, 0));
        Line curLine = new Line(new Point(0, 0), new Point(0, 0));
        foreach (Contour contour in polygon.GetHoles()){
            if (contour.Intersects(line))
                return null;
        }
        List<Point> points = polygon.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));
        foreach (Line line1 in lines)
        {
            curLine = LineShortestLineSearcher.GetShortestLine(line1, line);
            if (curLine.GetLength() < shortLine.GetLength())
            {
				shortLine = new Line(curLine);
            }
        }
        return shortLine;
    }

    internal static Line GetShortestLine(Polygon polygon1, Polygon polygon2)
    {
        Line shortLine = new Line(new Point(0, 0), new Point(0, 0));
        Line curLine = new Line(new Point(0, 0), new Point(0, 0));
        // проверка если полигон ВНУТРИ полигона... какой внутри какого?))) Думаю любой внутри любого
        foreach (Contour contour in polygon1.GetHoles()){
            if (contour.Intersects(polygon2))
                return null;
        }
        foreach (Contour contour in polygon2.GetHoles()){
            if (contour.Intersects(polygon1))
                return null;
        }
        List<Point> points = polygon2.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));

        foreach (Line line in lines)
        {
            curLine = GetShortestLine(polygon1, line);
            if (curLine.GetLength() < shortLine.GetLength())
            {
				shortLine = new Line(curLine);
            }
        }
        return shortLine;
    }

    internal static Line GetShortestLine(Polygon polygon, MultiLine multiLine) =>
        MultiLineShortestLineSearcher.GetShortestLine(multiLine, polygon);

    internal static Line GetShortestLine(Polygon polygon, MultiPoint multiPoint) =>
        MultiPointShortestLineSearcher.GetShortestLine(multiPoint, polygon);

    internal static Line GetShortestLine(Polygon polygon, MultiPolygon multiPolygon) =>
        MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, polygon);

    internal static Line GetShortestLine(Polygon polygon, Contour contour)
    {
        Line shortLine = new Line(new Point(0, 0), new Point(0, 0));
        Line curLine = new Line(new Point(0, 0), new Point(0, 0));
        // проверка если контур ВНУТРИ полигона... или полигон внутри контура
        List<Point> points = contour.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));

        foreach (Line line in lines)
        {
            curLine = GetShortestLine(polygon, line);
            if (curLine.GetLength() < shortLine.GetLength())
            {
                shortLine = new Line(curLine);
            }
        }
        return shortLine;
    }
}
