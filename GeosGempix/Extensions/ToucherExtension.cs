namespace GeosGempix.Extensions
{
    public class ToucherExtension
    {
        public static bool IsTouching(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Toucher(primitive1, primitive2).GetResult();
    }
}
