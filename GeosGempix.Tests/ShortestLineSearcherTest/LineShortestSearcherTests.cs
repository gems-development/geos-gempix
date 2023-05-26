using GeosGempix.Models;
using GeosGempix.Tests.ShortestLineSearcherTest.TestData;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;

namespace GeosGempix.Tests.ShortestLineSearcherTest
{
	public class LineShortestSearcherTests
	{
		[Theory]
		[MemberData(nameof(LineShortestSearcherTestData.LineAndPoint), MemberType = typeof(LineShortestSearcherTestData))]
		public static void GetShortestLineBetweenLineAndPoint(Line line, Point point)
		{
			//Act.
			var shortestLine = LineShortestLineSearcher.GetShortestLine(line, point)!;
			//Assert.
			Assert.Equal(Math.Sqrt(2), shortestLine.GetLength());
		}

		[Theory]
		[MemberData(nameof(LineShortestSearcherTestData.LineAndLine), MemberType = typeof(LineShortestSearcherTestData))]
		public static void GetShortestLineBetweenLines(Line line1, Line line2)
		{
			//Act.
			var shortestLine = LineShortestLineSearcher.GetShortestLine(line1, line2)!;
			//Assert.
			Assert.Equal(3, shortestLine.GetLength());
		}
	}
}
