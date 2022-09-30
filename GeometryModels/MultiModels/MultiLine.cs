/// <summary>
/// Summary description for Class1
/// </summary>
public class MultiLine : IGeometryPrimitive
{
    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
