using GeometryModels;
using System;

public class PolygonDistanceCalculator : IGeometryPrimitiveVisitor
{
    private Polygon _polygon;
    private double _result;

    public PolygonDistanceCalculator(Polygon polygon)
    {
        _polygon = polygon;
        _result = 0;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(_polygon, point);
    }

    public void Visit(Line line)
    {
        _result = GetDistance(_polygon, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = GetDistance(_polygon, polygon);
    }

    //TODO: Расстояние между точкой и полигоном
    internal static double GetDistance(Polygon polygon, Point point)
    {
        return 0;
    }


    //TODO: Расстояние между отрезком и полигоном
    internal static double GetDistance(Polygon polygon, Line line)
    {
        return 0;
    }

    //TODO: Расстояние между двумя полигонами
    internal static double GetDistance(Polygon polygon1, Polygon polygon2)
    {
        return 0;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _polygon);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _polygon);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _polygon);
    }
}
