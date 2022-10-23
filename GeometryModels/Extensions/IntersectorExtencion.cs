using GeometryModels.Visitors.Intersectors;

namespace GeometryModels.Extensions
{
    public class IntersectorExtencion
    {
        internal static bool Intersects(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Intersector(primitive1, primitive2).GetResult();
    }
}
