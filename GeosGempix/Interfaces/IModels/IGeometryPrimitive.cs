using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Visitors.Validators;

public interface IGeometryPrimitive
{
    public void Accept(IGeometryPrimitiveVisitor v);
    void Accept(Validator validator);
    bool Equals(object obj);
}
