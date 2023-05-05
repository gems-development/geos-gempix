using GeosGempix.Models;
using GeosGempix.MultiModels;
namespace GeosGempix.Tests;

public static class TestHelper
{
	public static Line CreateLine(double x1, double x2, double x3, double x4)
	{
		return new Line(new Point(x1, x2), new Point(x3, x4));
	}

	public static Contour CreateContour(params Point[] points)
	{
		var pointList = new List<Point>();
		pointList.AddRange(points);
		return new Contour(pointList);
	}

	public static Polygon CreatePolygon(List<Contour> contours, params Point[] points)
	{
		var pointList = new List<Point>();
		pointList.AddRange(points);
		return new Polygon(pointList, contours);
	}
	
	public static Polygon CreatePolygon(params Point[] points)
	{
		var pointList = new List<Point>();
		pointList.AddRange(points);
		return new Polygon(pointList);
	}

	public static MultiPoint CreateMultiPoint(params Point[] points)
	{
		var pointList = new List<Point>();
		pointList.AddRange(points);
		return new MultiPoint(pointList);
	}

	public static MultiLine CreateMultiLine(params Line[] lines)
	{
		var lineList = new List<Line>();
		lineList.AddRange(lines);
		return new MultiLine(lineList);
	}

	public static MultiPolygon CreateMultiPolygon(params Polygon[] polygons)
	{
		var polygonList = new List<Polygon>();
		polygonList.AddRange(polygons);
		return new MultiPolygon(polygonList);
	}
}