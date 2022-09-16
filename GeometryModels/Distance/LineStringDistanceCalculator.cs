using System;


public class LineStringDistanceCalculator
{
	
    public Point LineStringField { get; private set; }

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
