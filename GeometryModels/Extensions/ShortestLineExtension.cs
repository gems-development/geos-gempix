using GeometryModels.Models;
using GeometryModels.Visitors.ShortestLineSearchers;

namespace GeometryModels.Extensions
{
    public static class ShortestLineExtension
    {
        public static Line GetShortestLine(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new ShortestLineSearcher(primitive1, primitive2).GetResult();
    }
}
