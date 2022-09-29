using System;


public class GeometryPrimitiveDistanceExtencion
{
	public static double GetDistance(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
	{
		return new PrimitiveDistanceCalculator(primitive1, primitive2).GetResult();
	}
}
