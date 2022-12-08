using GeosGempix.Models;
using GeosGempix.Extensions;

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
            Point pointTrue1 = new Point(3, 3);
            Point pointFalse1 = new Point(0, 3);
            Point pointFalse2 = new Point(10, 3);
            //Act.
            Boolean t1 = tests._contour.IsInside(pointTrue1);
            Boolean f1 = tests._contour.IsInside(pointFalse1);
            Boolean f2 = tests._contour.IsInside(pointFalse2);
            //Assert.
            Assert.True(t1);
            Assert.False(f1);
            Assert.False(f2);
        }
    }
}
