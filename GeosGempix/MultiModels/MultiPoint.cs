using GeosGempix;

public class MultiPoint : IGeometryPrimitive
{
    private List<Point> _points;

    
    public MultiPoint(IReadOnlyCollection<Point> points)
    {
        if (points == null)
            throw new ArgumentNullException(nameof(points), "points");
        if (points.Count == 0)
            throw new ArgumentException(nameof(points), "Длина списка points = 0");
        foreach (Point point in points)
            if (point == null)
                throw new ArgumentNullException(nameof(points), "Один из элементов списка points равен null");
        _points = points.ToList();
    }

    public IReadOnlyCollection<Point> GetPoints() => _points;

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        if (v == null)
            throw new ArgumentNullException("v");
        v.Visit(this);
    }
}
