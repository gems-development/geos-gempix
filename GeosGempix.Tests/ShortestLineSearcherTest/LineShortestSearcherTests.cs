using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;

namespace GeosGempix.Tests.ShortestLineSearcherTest
{
	public class LineShortestSearcherTests
	{
		[Fact]
		public static void GetShortestLineBetweenLineAndPoint()
		{
			//Arrage.
			Line line = new Line(new Point(0,0), new Point(3,3));
			Point point = new Point(0,2);
			//Act.
			Line shortLine = LineShortestLineSearcher.GetShortestLine(line, point);
			//Assert.
			Assert.Equal(2, shortLine.GetLength());
		}
	}
}
