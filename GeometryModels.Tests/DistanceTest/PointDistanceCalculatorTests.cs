using GeometryModels;
using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Models;
using GeometryModels.Visitors.Intersectors;

public class PointDistanceCalculatorTests
{
	// Проверка на принадлежность точки отрезку
	[Fact]
	public void ProofPointIsBelongInLine_Succes()
	{
		//Arrage.
		Point point1 = new Point(0, 0);
		Point point2 = new Point(3, 0);
		Point point3 = new Point(-3, 0);
		Line line = new Line(point2, point3);
		//Act. + Assert.
		Assert.True(LineIntersector.Intersects(line, point1));
	}
}
