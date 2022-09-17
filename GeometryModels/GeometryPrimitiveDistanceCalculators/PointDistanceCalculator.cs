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

    public void Visit(LineString lineString)
    {
        LineStringDistanceCalculator.GetDistance(_point, lineString);
    }

    public void Visit(Polygon polygon)
    {
        PolygonDistanceCalculator.GetDistance(_point, polygon);
    }

    internal static double GetDistance(Point point1, Point point2)
    {
        return Math.Sqrt((point2.X - point1.X) * (point2.X - point1.X) - (point2.Y - point1.Y) * (point2.Y - point1.Y));
    }

    public double GetResult()
    {
        return _result;
    }
}
