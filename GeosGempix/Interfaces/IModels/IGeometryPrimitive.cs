public interface IGeometryPrimitive
{
    void Accept(IGeometryPrimitiveVisitor v);
    bool Equals(object obj);
}
