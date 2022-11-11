using GeometryModels.Visitors.Intersectors;

namespace GeometryModels.Extensions
{
    public class IntersectorExtension
    {
        public static bool Intersects(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Intersector(primitive1, primitive2).GetResult();
    }
}
