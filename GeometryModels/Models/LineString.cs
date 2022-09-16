using GeometryModels;
using System;

public class LineString : IGeometryPrimitive
{
	public Point A { get; private set; }
    public Point B { get; private set; }

	public LineString(Point point1, Point point2)
    {
        A = point1;
        B = point2;
    }

    public double GetLength()
    { 
        return Math.sqrt((B.X-A.X)* (B.X - A.X)- (B.Y - A.Y)* (B.Y - A.Y)); 
    }
    public double GetDistance(IGeometryPrimitive B)
    {
        double distance = 0;
        return distance;
    }
}
