using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest
{
	public class LineIntersectorTests
	{
		// Проверка на пересечение отрезков
		[Theory]
		[InlineData(1, 1, 2, 1, 0, 0, 3, 0)]
		[InlineData(0, 0, 0, 3, 4, 0, 4, 3)]
		public void IsLineIntersection_Failed(double x11, double y11, double x12, double y12,
														double x21, double y21, double x22, double y22)
		{
			//Arrange.
			Line line1 = new Line(new Point(x11, y11), new Point(x12, y12));
			Line line2 = new Line(new Point(x21, y21), new Point(x22, y22));
			//Act. + Assert.
			Assert.False(LineIntersector.Intersects(line1, line2));
		}

		// Проверка на пересечение отрезков
		[Theory]
		[InlineData(1, 1, 3, -2, 4, 3, -2, -4)]
        [InlineData(0, 0, 0, 2, 0, 2, 2, 2)]
        public void IsIntersection_Success(double x11, double y11, double x12, double y12,
                                                        double x21, double y21, double x22, double y22)
		{
            //Arrange.
            Line line1 = new Line(new Point(x11, y11), new Point(x12, y12));
			Line line2 = new Line(new Point(x21, y21), new Point(x22, y22));
			//Act. + Assert.
			Assert.True(LineIntersector.Intersects(line1, line2));
		}
	}
}
