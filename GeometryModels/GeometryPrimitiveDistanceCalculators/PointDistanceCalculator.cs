using GeometryModels;
using System;



public class PointDistanceCalculator : IGeometryPrimitiveVisitor
{
    private Point _point;
    private double _result;
    public PointDistanceCalculator(Point point)
    { 
        _point = point;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(_point, point);
    }

    public void Visit(Line line)
    {
        _result = LineDistanceCalculator.GetDistance(_point, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = PolygonDistanceCalculator.GetDistance(polygon, _point);
    }

    public static double GetDistance(Point point1, Point point2)
    {
        return Math.Sqrt((point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y));
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _point);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _point);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _point);
    }
}
