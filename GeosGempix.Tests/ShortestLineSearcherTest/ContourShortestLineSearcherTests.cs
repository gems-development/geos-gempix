using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Tests.ShortestLineSearcherTest
{
    public class ContourShortestLineSearcherTests
    {       
        private Contour _contour;
        public ContourShortestLineSearcherTests()
        {
            List<Point> _points = new List<Point>();
            Point _point1 = new Point(0, 0);
            Point _point2 = new Point(9, 0);
            Point _point3 = new Point(9, 9);
            Point _point4 = new Point(0, 9);
            _points.Add(_point1);
            _points.Add(_point2);
            _points.Add(_point3);
            _points.Add(_point4);
            _contour = new Contour(_points);
        }

        [Fact]
        public static void GetShortestLineBetweenContourAndPoint()
        {
            //Arrange.
            Line line = new Line(new Point(0, 0), new Point(3, 3));
            Point point = new Point(0, 2);
            //Act.
            Line shortLine = LineShortestLineSearcher.GetShortestLine(line, point);
            //Assert.
            Assert.Equal(Math.Sqrt(2), shortLine.GetLength());
        }
    }
}
