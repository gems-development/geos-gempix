using System;


public interface IGeometryPrimitiveVisitor
{
	public void Visit(Point B);
    public void Visit(LineString B);
    public void Visit(Polygon B);
}
