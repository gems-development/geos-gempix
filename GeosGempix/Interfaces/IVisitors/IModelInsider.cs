namespace GeosGempix.Interfaces.IVisitors
{
    public interface IModelInsider : IGeometryPrimitiveVisitor
    {
        public bool GetResult();
    }
}
