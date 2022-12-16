using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace GeosGempix.Tests.DistanceTest
{
	public class LineDistanceCalcutatorTests
	{
		// Проверка на расстояние между точкой и отрезком
		[Fact]
		public void GetDistanceBetweenPointAndline_Success()
		{
			//Arrange.
			Point point1 = new Point(2, 3);
			Point point2 = new Point(7, 3);
			Point point3 = new Point(5, 0);
			//Act.
			Line line = new Line(point1, point2);
			//Assert.
			Assert.Equal(3, line.GetDistance(point3));
		}

	}
}
