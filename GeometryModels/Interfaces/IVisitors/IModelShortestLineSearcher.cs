using GeometryModels.Models;

namespace GeometryModels.Interfaces.IVisitors
{
    public interface IModelShortestLineSearcher : IGeometryPrimitiveVisitor
    {
        public Line GetResult();
    }
}
