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
        GetDistance(point, _polygon);
    }

    public void Visit(LineString lineString)
    {
        GetDistance(lineString, _polygon);
    }

    public void Visit(Polygon polygon)
    {
        GetDistance(_polygon, polygon);
    }

    //TODO: Расстояние между точкой и полигоном
    internal static double GetDistance(Point point1, Polygon point2)
    {
        return 0;
    }


    //TODO: Расстояние между отрезком и полигоном
    internal static double GetDistance(LineString lineString, Polygon polygon)
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
}
