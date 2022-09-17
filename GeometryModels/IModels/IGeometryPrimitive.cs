using System;


public interface IGeometryPrimitive
{
	public void Accept(IGeometryPrimitiveVisitor v);
}
