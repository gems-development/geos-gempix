using System;


public class GeometryPrimitiveDistanceExtencion
{
	private IGeometryPrimitiveVisitor _calculator;
	public double GetDistance(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
	{
		_calculator = new PrimitiveDistanceCalculator(primitive1, primitive2);
		return _calculator.GetResult();
	}
}
