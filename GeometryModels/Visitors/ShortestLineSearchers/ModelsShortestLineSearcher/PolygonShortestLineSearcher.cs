﻿using GeometryModels;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeometryModels.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;

public class PolygonShortestLineSearcher : IModelShortestLineSearcher
{
	private Polygon _polygon;
	private Line _result;

	public PolygonShortestLineSearcher(Polygon polygon)
	{
		_polygon = polygon;
		_result = new Line(new Point(0,0), new Point(0,0));
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

	internal static Line GetShortestLine(Polygon polygon, Point point)
	{
		Line shortLine = new Line(new Point(0, 0), new Point(0, 0));
		Line curLine = new Line(new Point(0,0), new Point(0,0));
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

	public void Visit(Contour contour) =>
		throw new NotImplementedException();
}
