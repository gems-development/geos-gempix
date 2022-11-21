using System.Diagnostics.CodeAnalysis;

public class MultiPolygon : IGeometryPrimitive
{
    private List<Polygon> _polygons;

    public MultiPolygon(List<Polygon> polygons)
    {
        if (polygons == null)
            throw new ArgumentNullException("polygons");
        if (polygons.Capacity == 0)
            throw new ArgumentException("Длина списка polygons = 0");
        foreach (Polygon polygon in polygons)
            if (polygon == null)
                throw new ArgumentNullException("polygons", "Один из элементов списка polygons равен null");
        _polygons = polygons;
    }

    public List<Polygon> GetPolygons()
    {
        return _polygons;
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        if (v == null)
            throw new ArgumentNullException("v");
        v.Visit(this);
    }
}
