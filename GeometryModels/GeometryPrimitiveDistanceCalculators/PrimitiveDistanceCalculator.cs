using GeometryModels;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class PrimitiveDistanceCalculator : IGeometryPrimitiveVisitor
{
    private double _result;
	
    private IGeometryPrimitiveVisitor _calculator;

    public PrimitiveDistanceCalculator(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
    {
        _result = 0;
        primitive1.Accept(this);
        primitive2.Accept(_calculator);
    }

    public double GetResult() { return _result; }

    public void Visit(Point point)
    {
        _calculator = new PointDistanceCalculator(point);
    }

    public void Visit(LineString lineString)
    {
        _calculator = new LineStringDistanceCalculator(lineString);
    }

    public void Visit(Polygon polygon)
    {
        _calculator = new PolygonDistanceCalculator(polygon);
    }

 
}
