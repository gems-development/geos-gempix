using GeometryModels;
using System;


public class LineStringDistanceCalculator : IGeometryPrimitiveVisitor
{
    private LineString _lineString;
    private double _result;

    public LineStringDistanceCalculator(Point point1, Point point2)
    {
        _lineString = new LineString(point1, point2);
    }

    public LineStringDistanceCalculator(LineString lineString)
    {
        _lineString = lineString;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(point, _lineString);
    }

    public void Visit(LineString lineString)
    {
        _result = GetDistance(_lineString, lineString);
    }

    public void Visit(Polygon polygon)
    {
        _result = PolygonDistanceCalculator.GetDistance(_lineString, polygon);
    }

    //Расстояние между точкой и отрезком
    internal static double GetDistance(Point point, LineString lineString)
    { 
        double res;
        double a = PointDistanceCalculator.GetDistance(point, lineString.Point1);
        double b = PointDistanceCalculator.GetDistance(point, lineString.Point2);
        double c = PointDistanceCalculator.GetDistance(lineString.Point1, lineString.Point2);
        if (a * a > b * b + c * c || b * b > a * a + c * c)
        {
            res = Math.Min(a, b);
        }
        else
        {
            double P = lineString.Point2.Y - lineString.Point1.Y;
            double Q = lineString.Point1.X - lineString.Point2.X;
            double R = -lineString.Point1.X * P + lineString.Point1.Y * (lineString.Point2.X - lineString.Point1.X);
            res = Math.Abs(P * point.X + Q * point.Y + R) / Math.Sqrt(P * P + Q * Q);
        }
        return res;
    }

    //TODO: Расстояние между двумя отрезками
    public double GetDistance(LineString line1, LineString line2)
    {
        return 0;
    }

}
