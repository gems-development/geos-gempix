using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators;
using GeosGempix.Visitors.Insiders;
using GeosGempix.Visitors.Intersectors;
using GeosGempix.Visitors.ShortestLineSearchers;

namespace GeosGempix.Extensions
{
    public static class PrimitiveExtension
    {
        public static double GetDistance(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new DistanceCalculator(primitive1, primitive2).GetResult();

        public static bool IsInside(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new Insider(primitive1, primitive2).GetResult();

        public static bool Intersects(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new Intersector(primitive1, primitive2).GetResult();

        public static Line GetShortestLine(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new ShortestLineSearcher(primitive1, primitive2).GetResult();

        public static bool IsTouching(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new Toucher(primitive1, primitive2).GetResult();
    }
}