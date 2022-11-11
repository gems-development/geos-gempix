using GeometryModels;
using GeometryModels.Interfaces.IModels;
using GeometryModels.Models;
using GeometryModels.Visitors.DistanceCalculators.ModelsDistanceCalculator;

public class PointShortestLineSearcher : IModelDistanceCalculator
{
	private Point _point;
	private double _result;
	public PointShortestLineSearcher(Point point) =>
		_point = point;

	public void Visit(Point point) =>
		_result = GetDistance(_point, point);

	public void Visit(Line line) =>
		_result = LineShortestLineSearcher.GetDistance(line, _point);

	public void Visit(Polygon polygon) =>
		_result = PolygonShortestLineSearcher.GetDistance(polygon, _point);

	public void Visit(MultiPoint multiPoint) =>
		_result = MultiPointShortestLineSearcher.GetDistance(multiPoint, _point);

	public void Visit(MultiLine multiLine) =>
		_result = MultiLineShortestLineSearcher.GetDistance(multiLine, _point);

	public void Visit(MultiPolygon multiPolygon) =>
		_result = MultiPolygonShortestLineSearcher.GetDistance(multiPolygon, _point);

	public double GetResult() =>
		_result;

	internal static double GetDistance(Point point1, Point point2) =>
		Math.Sqrt((point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y));

	internal static double GetDistance(Point point, Line line) =>
		LineShortestLineSearcher.GetDistance(line, point);

	internal static double GetDistance(Point point, Polygon polygon) =>
		PolygonShortestLineSearcher.GetDistance(polygon, point);

	internal static double GetDistance(Point point, MultiLine multiLine) =>
		MultiLineShortestLineSearcher.GetDistance(multiLine, point);

	internal static double GetDistance(Point point, MultiPoint multiPoint) =>
		MultiPointShortestLineSearcher.GetDistance(multiPoint, point);

	internal static double GetDistance(Point point, MultiPolygon multiPolygon) =>
		MultiPolygonShortestLineSearcher.GetDistance(multiPolygon, point);

	public void Visit(Contour contour) =>
		throw new NotImplementedException();
}
