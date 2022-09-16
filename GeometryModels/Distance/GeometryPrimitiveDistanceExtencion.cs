using System;


public class GeometryPrimitiveDistanceExtencion
{
	private IGeometryPrimitiveVisitor calculator;
	public double GetDistance(IGeometryPrimitive A, IGeometryPrimitive B)
	{
		calculator = new PrimitiveDistanceCalculator();
		calculator.Visit(A);
		calculator.Visit(B);
		return calculator.Result;
	}
}
