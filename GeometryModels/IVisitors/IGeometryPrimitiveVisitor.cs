using GeometryModels;
using System;


public interface IGeometryPrimitiveVisitor
{
	public void Visit(Point point);
    public void Visit(LineString lineString);
    public void Visit(Polygon polygon);

    public double GetResult();
}
