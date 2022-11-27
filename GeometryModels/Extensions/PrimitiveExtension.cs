using GeometryModels.Models;
using GeometryModels.Visitors.DistanceCalculators;
using GeometryModels.Visitors.Insiders;
using GeometryModels.Visitors.Intersectors;
using GeometryModels.Visitors.ShortestLineSearchers;

namespace GeometryModels.Extensions
{
    public class PrimitiveExtension
    {
        public static double GetDistance(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new DistanceCalculator(primitive1, primitive2).GetResult();

        public static bool IsInside(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new Insider(primitive1, primitive2).GetResult();

        public static bool Intersects(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new Intersector(primitive1, primitive2).GetResult();

        public static Line GetShortestLine(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new ShortestLineSearcher(primitive1, primitive2).GetResult();

        public static bool IsTouching(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
                new Toucher(primitive1, primitive2).GetResult();
    }
}