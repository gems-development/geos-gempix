using GeometryModels.Visitors.Insiders;

namespace GeometryModels.Extensions
{
    public static class InsiderExtension
    {
        public static bool IsInside(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Insider(primitive1, primitive2).GetResult();
    }
}
