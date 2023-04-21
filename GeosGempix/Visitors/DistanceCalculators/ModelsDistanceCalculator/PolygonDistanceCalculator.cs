using GeosGempix;
using GeosGempix.GeometryPrimitiveInsiders;
using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;
using GeosGempix.MultiModels;
using GeosGempix.Extensions;

public class PolygonDistanceCalculator : IModelDistanceCalculator
{
    private Polygon _polygon;
    private double _result;

    public PolygonDistanceCalculator(Polygon polygon)
    {
        _polygon = polygon;
        _result = 0;
    }

    public double GetResult() =>
        _result;

    public void Visit(Point point) =>
        _result = GetDistance(_polygon, point);

    public void Visit(Line line) =>
        _result = GetDistance(_polygon, line);

    public void Visit(Polygon polygon) =>
        _result = GetDistance(_polygon, polygon);

    public void Visit(MultiPoint multiPoint) =>
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _polygon);

    public void Visit(MultiLine multiLine) =>
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _polygon);

    public void Visit(MultiPolygon multiPolygon) =>
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _polygon);

    public void Visit(Contour contour) =>
        _result = GetDistance(_polygon, contour);

    internal static double GetDistance(Polygon polygon, Point point)
    {
        if (PolygonInsider.IsInside(polygon, point))
            return 0;
        double result = double.MaxValue;
        double distance = 0;
        List<Point> points = polygon.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
            lines.Add(new Line(points[i], points[i + 1]));
        
        foreach (Line line in lines)
        {
            distance = LineDistanceCalculator.GetDistance(line, point);
            if (distance < result)
                result = distance;
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon, Line line)
    {
        if (polygon.Intersects(line))
            return 0;
        double result = double.MaxValue;
        double distance = 0;
        List<Line> lines = polygon.GetLines();
        
        foreach (Line line1 in lines)
        {
            distance = LineDistanceCalculator.GetDistance(line1, line);
            if (distance < result)
                result = distance;
        }

        foreach (Contour hole in polygon.GetHoles())
        { // где метод вычисления расстояния до внутренней точки контура?
          // почему до сих пор не написан?
            distance = ContourDistanceCalculator.GetDistance(hole, line);
            if (distance < result)
                result = distance;
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon1, Polygon polygon2)
    {
        if (PolygonInsider.IsInside(polygon1, polygon2) || PolygonInsider.IsInside(polygon2, polygon1))
            return 0;
        double result = double.MaxValue;
        double distance;
        List<Point> points = polygon2.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
            lines.Add(new Line(points[i], points[i + 1]));

        foreach (Line line in lines)
        {
            distance = GetDistance(polygon1, line);
            if (distance < result)
                result = distance;
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon, MultiLine multiLine)
    {
        if (PolygonInsider.IsInside(polygon, multiLine))
            return 0;
        return MultiLineDistanceCalculator.GetDistance(multiLine, polygon);
    }

    internal static double GetDistance(Polygon polygon, MultiPoint multiPoint)
    {
        if (PolygonInsider.IsInside(polygon, multiPoint))
            return 0;
        return MultiPointDistanceCalculator.GetDistance(multiPoint, polygon);;
    }

    internal static double GetDistance(Polygon polygon, MultiPolygon multiPolygon)
    {
        if (PolygonInsider.IsInside(polygon, multiPolygon))
            return 0;
        return MultiPolygonDistanceCalculator.GetDistance(multiPolygon, polygon);;
    }

    internal static double GetDistance(Polygon polygon, Contour contour)
    {
        if (PolygonIntersector.Intersects(polygon, contour))
            return 0;
        if (PolygonInsider.IsInside(polygon, contour))
            return 0;
        if (ContourInsider.IsInside(contour, polygon))
            return 0;

        double result = double.MaxValue;
        double distance;
        List<Contour> holes = new List<Contour>(polygon.GetHoles());
        holes.Add(new Contour(polygon.GetPoints()));
        foreach (var hole in holes)
        {
            List<Point> points = hole.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
                lines.Add(new Line(points[i], points[i + 1]));

            foreach (Line line in lines)
            {
                distance = ContourDistanceCalculator.GetDistance(hole, line);
                if (distance < result)
                    result = distance;
            }
        }
        return result;
    }
}
