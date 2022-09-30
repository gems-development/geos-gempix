/// <summary>
/// Summary description for Class1
/// </summary>
public class MultiPolygon : IGeometryPrimitive
{
    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
