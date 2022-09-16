using System;


public interface IGeometryPrimitive
{
	public void Accept(PointDistanceCalculator v);
	public void Accept(LineStringDistanceCalculator v);
	public void Accept(PolygonDistanceCalculator v);
}
