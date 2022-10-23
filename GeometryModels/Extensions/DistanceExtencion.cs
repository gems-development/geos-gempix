public class DistanceExtencion
{
	internal static double GetDistance(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
		new DistanceCalculator(primitive1, primitive2).GetResult();
}
