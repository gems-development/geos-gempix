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
    
    //Проверка на пересечение двух отрезков
    public static bool IsIntersection(LineString lineString1, LineString lineString2)
    {
        double delta =  (lineString1.Point2.X - lineString1.Point1.X) * (lineString2.Point1.Y - lineString2.Point2.Y) - 
            (lineString1.Point2.Y - lineString1.Point1.Y) * (lineString2.Point1.X - lineString2.Point2.X);
        double delta1 = (lineString1.Point2.X - lineString1.Point1.X) * (lineString2.Point1.Y - lineString1.Point1.Y) - 
            (lineString1.Point2.Y - lineString1.Point1.Y) * (lineString2.Point1.X - lineString1.Point1.X);
        double delta2 = (lineString2.Point1.X - lineString1.Point1.X) * (lineString2.Point1.Y - lineString2.Point2.Y) - 
            (lineString2.Point1.Y - lineString1.Point1.Y) * (lineString2.Point1.X - lineString2.Point2.X);

        return ((delta != 0) && (delta1/delta >= 0) && (delta1/delta <= 1) && (delta2/delta >= 0) && (delta2/delta <= 1));
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
