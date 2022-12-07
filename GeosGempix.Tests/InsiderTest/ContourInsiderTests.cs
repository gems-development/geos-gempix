using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Tests.ShortestLineSearcherTest
{
    public class ContourInsiderTests
    {       
        public Contour _contour;
        public ContourInsiderTests()
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
        public static void IsPointInsideContour()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            Point point = new Point(3, 3);
            //Act.
            //Boolean b = tests._contour
            //Assert.
            //Assert.Equal(Math.Sqrt(2), shortLine.GetLength());
        }
    }
}
