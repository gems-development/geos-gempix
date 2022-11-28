public interface IGeometryPrimitive
{
    public void Accept(IGeometryPrimitiveVisitor v);
    bool Equals(object obj);
}
