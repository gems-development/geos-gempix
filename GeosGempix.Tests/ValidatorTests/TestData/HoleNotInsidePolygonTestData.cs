using GeosGempix.Models;
using System.Collections;

namespace GeosGempix.Tests.ValidatorTests.TestData
{
	internal class HoleNotInsidePolygonTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			// остров за пределами полигона
			yield return new object[]
			{
				TestHelper.CreatePolygon(
					new List<Contour>
					{
						TestHelper.CreateContour(new Point(4, 4), new Point(4, 5), new Point(5, 5), 
												 new Point(5, 4), new Point(4, 4))
					},
					new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0))
			};
			// остров касается полигона правой грани полигона с внешней стороны
			yield return new object[]
			{
				TestHelper.CreatePolygon(
					new List<Contour>
					{
						TestHelper.CreateContour(new Point(3, 0), new Point(3, 2), new Point(5, 2), 
												 new Point(5, 0), new Point(3, 0))
					},
					new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0))
			};
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	}
}
