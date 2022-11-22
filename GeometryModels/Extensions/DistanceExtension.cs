using GeometryModels.Visitors.DistanceCalculators;

namespace GeometryModels.Extensions
{
  public static class DistanceExtension
	{
		public static double GetDistance(this IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
			new DistanceCalculator(primitive1, primitive2).GetResult();
	}
}
