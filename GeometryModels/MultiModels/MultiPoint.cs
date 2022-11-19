using GeometryModels;
using System.Diagnostics.CodeAnalysis;

public class MultiPoint : IGeometryPrimitive
{
    List<Point> points;

    public MultiPoint([NotNull] List<Point> points)
    {
        this.points = points;
    }

    public List<Point> GetPoints()
    {
        return points;
    }

    public void Accept([NotNull] IGeometryPrimitiveVisitor v)
    {

        v.Visit(this);
    }
}
