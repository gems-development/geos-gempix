using GeosGempix;
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
        if (PolygonIntersector.Intersects(polygon, point))
            return 0;
        double result = double.MaxValue;
        List<Line> lines = polygon.GetLines();
        
        foreach (Line line in lines)
        {
            double distance = LineDistanceCalculator.GetDistance(line, point);
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
        List<Line> lines = polygon.GetLines();
        
        foreach (Line line1 in lines)
        {
            double distance = LineDistanceCalculator.GetDistance(line1, line);
            if (distance < result)
                result = distance;
        }

        foreach (Contour hole in polygon.GetHoles())
        { // где метод вычисления расстояния до внутренней точки контура?
          // почему до сих пор не написан?
            double distance = ContourDistanceCalculator.GetDistance(hole, line);
            if (distance < result)
                result = distance;
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon1, Polygon polygon2)
    {
        if (PolygonIntersector.Intersects(polygon1, polygon2))
            return 0;
        double result = double.MaxValue;
        List<Line> lines = polygon2.GetLines();

        foreach (Line line in lines)
        {
            double distance = GetDistance(polygon1, line);
            if (distance < result)
                result = distance;
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon, MultiLine multiLine)
    {
        if (MultiLineIntersector.Intersects(multiLine, polygon))
            return 0;
        return MultiLineDistanceCalculator.GetDistance(multiLine, polygon);
    }

    internal static double GetDistance(Polygon polygon, MultiPoint multiPoint)
    {
        if (MultiPointIntersector.Intersects(multiPoint, polygon))
            return 0;
        return MultiPointDistanceCalculator.GetDistance(multiPoint, polygon);;
    }

    internal static double GetDistance(Polygon polygon, MultiPolygon multiPolygon)
    {
        if (MultiPolygonIntersector.Intersects(multiPolygon, polygon))
            return 0;
        return MultiPolygonDistanceCalculator.GetDistance(multiPolygon, polygon);;
    }

    internal static double GetDistance(Polygon polygon, Contour contour)
    {
        if (PolygonIntersector.Intersects(polygon, contour))
            return 0;

        double result = double.MaxValue;
        List<Contour> contours = new List<Contour>(polygon.GetHoles());
        contours.Add(new Contour(polygon.GetPoints()));
        foreach (var c in contours)
        {
            List<Line> lines = c.GetLines();

            foreach (Line line in lines)
            {
                double distance = ContourDistanceCalculator.GetDistance(c, line);
                if (distance < result)
                    result = distance;
            }
        }
        return result;
    }
    
    internal static double GetDistanceInside(Polygon polygon, Contour contour)
    {
        double result = double.MaxValue;
        List<Contour> contours = new List<Contour>(polygon.GetHoles());
        contours.Add(new Contour(polygon.GetPoints()));
        foreach (var c in contours)
        {
            var distance = ContourDistanceCalculator.GetDistanceInside(contour, c);
            if (distance < result)
                result = distance;
        }
        return result;
    }
}
