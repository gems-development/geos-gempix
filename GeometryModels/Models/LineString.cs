using GeometryModels;
using System;

public class LineString : IGeometryPrimitive
{
	public Point Point1 { get; private set; }
    public Point Point2 { get; private set; }

	public LineString(Point point1, Point point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    // ДУБЛИРОВАНИЕ КОДА (PointDistanceCalculator)
    public double GetLength()
    {
        return PointDistanceCalculator.GetDistance(Point1, Point2);
    } 

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
