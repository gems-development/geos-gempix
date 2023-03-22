using GeosGempix.Interfaces.IVisitors;

public interface IGeometryPrimitive
{
    public void Accept(IGeometryPrimitiveVisitor v);
    bool Equals(object obj);
}
