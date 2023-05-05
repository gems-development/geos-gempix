using GeosGempix.Models;
using System.Collections;

namespace GeosGempix.Tests.ValidatorTests.TestData
{
	internal class SquareWithHoleIntersectingTwoLinesTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			// квадратный остров в левом нижнем углу
			yield return new object[]
			{
					TestHelper.CreatePolygon(
						new List<Contour>
						{
							TestHelper.CreateContour(new Point(0, 0), new Point(0, 1), new Point(1, 1), 
													 new Point(1, 0), new Point(0, 0))
						},
						new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0))
			};
			// трапеция, у которой левая сторона полигона - это нижнее основание
			yield return new object[]
			{
					TestHelper.CreatePolygon(
						new List<Contour>
						{
							TestHelper.CreateContour(new Point(0, 0), new Point(0, 3), new Point(2, 2), 
													 new Point(2, 1), new Point(0, 0))
						},
						new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0))
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	}
}
