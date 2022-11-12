using GeometryModels;
using GeometryModels.Interfaces.IModels;
using GeometryModels.Models;
using GeometryModels.Visitors.DistanceCalculators.ModelsDistanceCalculator;

public class PolygonDistanceCalculator : IModelDistanceCalculator
{
    private Polygon _polygon;
    private double _result;

	public PolygonDistanceCalculator(Polygon polygon)
    {
        _polygon = polygon;
        _result = 0;
    }

    public void Visit(Point point) =>
        _result = GetDistance(_polygon, point);

    public void Visit(Line line) =>
        _result = GetDistance(_polygon, line);

    public void Visit(Polygon polygon) =>
        _result = GetDistance(_polygon, polygon);

    public double GetResult() =>
        _result;

    public void Visit(MultiPoint multiPoint) =>
		_result = MultiPointDistanceCalculator.GetDistance(multiPoint, _polygon);

    public void Visit(MultiLine multiLine) =>
		_result = MultiLineDistanceCalculator.GetDistance(multiLine, _polygon);

    public void Visit(MultiPolygon multiPolygon) =>
		_result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _polygon);

    internal static double GetDistance(Polygon polygon, Point point)
    {
        double result = 0;
        double distance = 0;
        // проверка если точка ВНУТРИ полигона... то расстояние должно быть ноль О_О
        List<Point> points = polygon.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));
        foreach (Line line in lines)
        {
			distance = LineDistanceCalculator.GetDistance(line, point);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }


    internal static double GetDistance(Polygon polygon, Line line)
    {
        double result = 0;
        double distance = 0;
        // проверка если отрезок ВНУТРИ полигона... 
        List<Point> points = polygon.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));
        foreach (Line line1 in lines)
        {
			distance = LineDistanceCalculator.GetDistance(line1, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon1, Polygon polygon2)
    {
        double result = 0;
        double distance;
        // проверка если полигон ВНУТРИ полигона... какой внутри какого?)))
        List<Point> points = polygon2.GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));

        foreach (Line line in lines)
        {
            distance = GetDistance(polygon1, line);
            if (distance < result)
            {
                result = distance;
            }
        }
        return result;
    }

    internal static double GetDistance(Polygon polygon, MultiLine multiLine) =>
		MultiLineDistanceCalculator.GetDistance(multiLine, polygon);

    internal static double GetDistance(Polygon polygon, MultiPoint multiPoint) =>
		MultiPointDistanceCalculator.GetDistance(multiPoint, polygon);

    internal static double GetDistance(Polygon polygon, MultiPolygon multiPolygon) =>
		MultiPolygonDistanceCalculator.GetDistance(multiPolygon, polygon);

    public void Visit(Contour contour) =>
        throw new NotImplementedException();
}
