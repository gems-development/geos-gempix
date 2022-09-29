using GeometryModels;
using System;

public class Line : IGeometryPrimitive
{
	public Point Point1 { get; private set; }
    public Point Point2 { get; private set; }

	public Line(Point point1, Point point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    // ДУБЛИРОВАНИЕ КОДА (PointDistanceCalculator)
    public double GetLength()
    {
        return PointDistanceCalculator.GetDistance(Point1, Point2);
    }
    
    //Проверка на пересечение двух отрезков
    public static bool IsIntersection(Line line1, Line line2)
    {
        double delta =  (line1.Point2.X - line1.Point1.X) * (line2.Point1.Y - line2.Point2.Y) - 
            (line1.Point2.Y - line1.Point1.Y) * (line2.Point1.X - line2.Point2.X);
        double delta1 = (line1.Point2.X - line1.Point1.X) * (line2.Point1.Y - line1.Point1.Y) - 
            (line1.Point2.Y - line1.Point1.Y) * (line2.Point1.X - line1.Point1.X);
        double delta2 = (line2.Point1.X - line1.Point1.X) * (line2.Point1.Y - line2.Point2.Y) - 
            (line2.Point1.Y - line1.Point1.Y) * (line2.Point1.X - line2.Point2.X);

        return ((delta != 0) && (delta1/delta >= 0) && (delta1/delta <= 1) && (delta2/delta >= 0) && (delta2/delta <= 1));
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
