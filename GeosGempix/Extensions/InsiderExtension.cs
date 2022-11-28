using GeosGempix.Visitors.Insiders;

namespace GeosGempix.Extensions
{
    public class InsiderExtension
    {
        public static bool IsInside(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Insider(primitive1, primitive2).GetResult();
    }
}
