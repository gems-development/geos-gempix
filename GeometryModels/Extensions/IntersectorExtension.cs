using GeometryModels.Visitors.Intersectors;

namespace GeometryModels.Extensions
{
    public static class IntersectorExtension
    {
        public static bool Intersects(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Intersector(primitive1, primitive2).GetResult();
    }
}
