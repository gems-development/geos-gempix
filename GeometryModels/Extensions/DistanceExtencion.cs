namespace GeometryModels.Extensions
{
	public class DistanceExtencion
	{
		public static double GetDistance(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
			new Visitors.DistanceCalculators.DistanceCalculator(primitive1, primitive2).GetResult();
	}
}