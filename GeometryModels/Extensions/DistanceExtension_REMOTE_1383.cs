using GeometryModels.Visitors.DistanceCalculators;

namespace GeometryModels.Extensions
{
	public class DistanceExtension
	{
		public static double GetDistance(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
			new DistanceCalculator(primitive1, primitive2).GetResult();
	}
}