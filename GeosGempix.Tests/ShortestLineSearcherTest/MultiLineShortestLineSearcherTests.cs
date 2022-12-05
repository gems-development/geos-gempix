using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Tests.ShortestLineSearcherTest
{
	public class MultiLineShortestLineSearcherTests
	{
		[Fact]
		public static void GetShortestLineBetweenPointAndMultiLine()
		{
			//Arrage.
			Point point = new Point(0, 0);
			Line line1 = new Line(new Point(2, 0), new Point(2, 3));
			Line line2 = new Line(new Point(2, 3), new Point(3, 3));
			List<Line> lines = new List<Line>();
			lines.Add(line1);
			lines.Add(line2);
			MultiLine multiLine = new MultiLine(lines);
			//Act.
			MultiLineShortestLineSearcher multiLineShortestLineSearcher = new MultiLineShortestLineSearcher(multiLine);
			multiLineShortestLineSearcher.Visit(point);
			Line line = multiLineShortestLineSearcher.GetResult();
			//Assert.
			Assert.Equal(2, line.GetLength());
		}
	}
}
