using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;

namespace GeosGempix.Tests.ShortestLineSearcherTest
{
	public class LineShortestSearcherTests
	{
		[Fact]
		public static void GetShortestLineBetweenLineAndPoint()
		{
			//Arrange.
			Line line = new Line(new Point(-3,-3), new Point(3,3));
			Point point = new Point(0, 2);
			//Act.
			Line shortLine = LineShortestLineSearcher.GetShortestLine(line, point);
			//Assert.
			Assert.Equal(Math.Sqrt(2), shortLine.GetLength());
		}

		[Fact]
		public static void GetShortestLineBetweenLines()
		{
			//Arrange.
			Line line1 = new Line(new Point(0, 0), new Point(0, 3));
			Line line2 = new Line(new Point(3, 0), new Point(3, 3));
			//Act.
			Line shortLine = LineShortestLineSearcher.GetShortestLine(line1, line2);
			//Assert.
			Assert.Equal(3, shortLine.GetLength());
		}
	}
}
