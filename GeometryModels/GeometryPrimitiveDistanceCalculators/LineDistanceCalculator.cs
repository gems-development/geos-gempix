using GeometryModels;


public class LineDistanceCalculator : IGeometryPrimitiveVisitor
{
    private Line _line;
    private double _result;

    public LineDistanceCalculator(Point point1, Point point2)
    {
        _line = new Line(point1, point2);
    }

    public LineDistanceCalculator(Line line)
    {
        _line = line;
    }

    public double GetResult()
    {
        return _result;
    }

    public void Visit(Point point)
    {
        _result = GetDistance(point, _line);
    }

    public void Visit(Line line)
    {
        _result = GetDistance(_line, line);
    }

    public void Visit(Polygon polygon)
    {
        _result = PolygonDistanceCalculator.GetDistance(polygon, _line);
    }

    //Расстояние между точкой и отрезком
    public static double GetDistance(Point point, Line line)
    { 
        
        return 0;
    }

    //TODO: Расстояние между двумя отрезками
    public double GetDistance(Line line1, Line line2)
    {
        return 0;
    }

    public void Visit(MultiPoint multiPoint)
    {
        _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _line);
    }

    public void Visit(MultiLine multiLine)
    {
        _result = MultiLineDistanceCalculator.GetDistance(multiLine, _line);
    }

    public void Visit(MultiPolygon multiPolygon)
    {
        _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _line);
    }
}
