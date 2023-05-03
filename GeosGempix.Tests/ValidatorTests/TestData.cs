using GeosGempix.Models;

namespace GeosGempix.Tests.ValidatorTests
{
	internal static class TestData
	{
		public static IEnumerable<object[]> SquareWithHoleIntersectingTwoLinesTestData =>
			new List<object[]>
			{                // квадратный остров в левом нижнем углу
                new object[]
				{
					TestHelper.CreatePolygon(
						new List<Contour>
						{
							TestHelper.CreateContour(new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0))
						},
						new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0))
				},
                             // трапеция, у которой левая сторона полигона - это нижнее основание
				new object[]
				{
					TestHelper.CreatePolygon(
						new List<Contour>
						{
							TestHelper.CreateContour(new Point(0, 0), new Point(0, 3), new Point(2, 2), new Point(2, 1))
						},
						new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0))
				},
			};

		public static IEnumerable<object[]> HoleNotInsidePolygonTestData =>
			new List<object[]>
			{                // остров за пределами полигона
                new object[]
				{
					TestHelper.CreatePolygon(
						new List<Contour>
						{
							TestHelper.CreateContour(new Point(4, 4), new Point(4, 5), new Point(5, 5), new Point(5, 4))
						},
						new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0))
				},
                             // остров касается полигона правой грани полигона с внешней стороны
                new object[]
				{
					TestHelper.CreatePolygon(
						new List<Contour>
						{
							TestHelper.CreateContour(new Point(3, 0), new Point(3, 2), new Point(5, 2), new Point(5, 0))
						},
						new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0))
				},
			};
	}
}
