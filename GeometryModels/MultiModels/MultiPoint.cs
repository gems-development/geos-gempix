using GeometryModels;

public class MultiPoint : IGeometryPrimitive
{
    List<Point> points;

    public MultiPoint(List<Point> points)
    {
        this.points = points;
    }

    public List<Point> GetPoints()
    {
        return points;
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {

        v.Visit(this);
    }
}
