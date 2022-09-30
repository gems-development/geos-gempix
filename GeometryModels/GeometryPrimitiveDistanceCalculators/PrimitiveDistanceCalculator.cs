using GeometryModels;

/// <summary>
/// Summary description for Class1
/// </summary>
public class PrimitiveDistanceCalculator : IGeometryPrimitiveVisitor
{
    private double _result;
	
    private IGeometryPrimitiveVisitor _calculator;

    public PrimitiveDistanceCalculator(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
    {
        primitive1.Accept(this);
        primitive2.Accept(_calculator);
        _result = _calculator.GetResult();
    }

    public double GetResult() { return _result; }

    public void Visit(Point point)
    {
        _calculator = new PointDistanceCalculator(point);
    }

    public void Visit(Line line)
    {
        _calculator = new LineDistanceCalculator(line);
    }

    public void Visit(Polygon polygon)
    {
        _calculator = new PolygonDistanceCalculator(polygon);
    }

    public void Visit(MultiPoint multiPoint)
    {
        _calculator = new MultiPointDistanceCalculator(multiPoint);
    }
    public void Visit(MultiLine multiLine)
    {
        _calculator = new MultiLineDistanceCalculator(multiLine);
    }
    public void Visit(MultiPolygon multiPolygon)
    {
        _calculator = new MultiPolygonDistanceCalculator(multiPolygon);
    }


}
