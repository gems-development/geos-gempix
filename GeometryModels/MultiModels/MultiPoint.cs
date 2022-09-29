using System;

public class MultiPoint : IGeometryPrimitive
{
    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
