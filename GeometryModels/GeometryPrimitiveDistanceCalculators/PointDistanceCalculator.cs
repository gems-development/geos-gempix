using GeometryModels;
using System;



public class PointDistanceCalculator
{
    public Point PointField { get; private set; }

    public void Visit(Point B)
    {
        B.accept(this);
    }

    public void Visit(LineString B)
    {
        B.accept(this);
    }

    public void Visit(Polygon B)
    {
        B.accept(this);
    }
}
