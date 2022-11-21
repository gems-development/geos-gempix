using GeometryModels;
using System.Diagnostics.CodeAnalysis;

public class MultiPoint : IGeometryPrimitive
{
    private List<Point> _points;

    public MultiPoint([NotNull] List<Point> points)
    {
        if (points == null)
            throw new ArgumentNullException("points");
        if (points.Capacity == 0)
            throw new ArgumentException("Длина списка points = 0");
        foreach (Point point in points)
            if (point == null)
                throw new ArgumentNullException("points", "Один из элементов списка points равен null");
        _points = points;
    }

    public List<Point> GetPoints()
    {
        return _points;
    }

    public void Accept([NotNull] IGeometryPrimitiveVisitor v)
    {
        if (v == null)
            throw new ArgumentNullException("v");
        v.Visit(this);
    }
}
