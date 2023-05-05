using GeosGempix.Models;

namespace GeosGempix.Interfaces.IVisitors
{
    public interface IModelShortestLineSearcher : IGeometryPrimitiveVisitor
    {
        public Line? GetResult();
    }
}
