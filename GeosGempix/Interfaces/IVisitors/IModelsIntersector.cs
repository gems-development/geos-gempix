namespace GeosGempix.Interfaces.IVisitors
{
    public interface IModelsIntersector : IGeometryPrimitiveVisitor
    {
        public bool GetResult();
    }
}
