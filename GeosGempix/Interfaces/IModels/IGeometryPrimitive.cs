using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Visitors.Validators;

public interface IGeometryPrimitive
{
    void Accept(IGeometryPrimitiveVisitor v);
    bool Equals(object obj);
}
