/// <summary>
/// Summary description for Class1
/// </summary>
public class MultiPolygon : IGeometryPrimitive
{
	List<Polygon> polygons;

	public MultiPolygon(List<Polygon> polygons)
	{
		this.polygons = polygons;
	}

	public List<Polygon> GetPolygons()
	{
		return polygons;
	}

	public void Accept(IGeometryPrimitiveVisitor v)
	{
		v.Visit(this);
	}
}
