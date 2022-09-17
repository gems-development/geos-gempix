using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class PrimitiveDistanceCalculator
{
	public double Result { get; private set; }
	
    private PointDistanceCalculator pointDistanceCalculator;
	
    private LineStringDistanceCalculator lineStringDistanceCalculator;
	
    private PolygonDistanceCalculator PolygonDistanceCalculator;
	
    private IGeometryDistanceCalculator actualCalculator;
	
    //Расстояние между двумя точками
    public double GetDistance(Point A, Point B)
	{
        Result = Math.sqrt((B.X - A.X) * (B.X - A.X) - (B.Y - A.Y) * (B.Y - A.Y));
        return Result;
	}
    
    //Расстояние между точкой и отрезком
    public double GetDistance(Point A, LineString B)
    {
        double a = DistanceCalculator.GetDistance(A, B.A);
        double b = DistanceCalculator.GetDistance(A, B.B);
        double c = DistanceCalculator.GetDistance(B.A, B.B);
        if (a * a > b * b + c * c || b * b > a * a + c * c)
        {
            Result = Math.Min(a, b);
        }
        else
        {
            double P = B.B.Y - B.A.Y;
            double Q = B.A.X - B.B.X;
            double R = -B.A.X * P + B.A.Y * (B.B.X - B.A.X);
            Result = Math.Abs(P * A.X + Q * A.Y + R) / Math.Sqrt(P * P + Q * Q);
        }
        return Result;
    }
    
    //Расстояние между точкой и полигоном
    public double GetDistance(Point A, Polygon B)
    {
        return Result;
    }
    
    //Расстояние между двумя отрезками
    public double GetDistance(LineString A, LineString B)
    {
        return Result;
    }
    
    //Расстояние между отрезком и полигоном
    public double GetDistance(LineStirng A, Polygon B)
    {
        return Result;
    }

    //Расстояние между двумя полигонами
    public double GetDistance(Polygon A, Polygon B)
    {
        return Result;
    }
}
