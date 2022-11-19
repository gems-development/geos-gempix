namespace GeometryModels.Extensions
{
    public static class ToucherExtension
    {
        public static bool IsTouching(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Toucher(primitive1, primitive2).GetResult();
    }
}
