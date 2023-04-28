using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest
{
    public class CountourDistanceCalculatorTriangleTests
    {
        [Fact]
        public void GetDistanceBetweenContourAndContourTriangle()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(8167287.0091716265, 7359039.0859560855));
            points.Add(new Point(8167396.8873997889, 7359472.3921513548));
            points.Add(new Point(8167824.4570267573, 7359496.3317170413));
            points.Add(new Point(8167287.0091716265, 7359039.0859560855));
            var contour0 = new Contour(points);
            List<Point> points2 = new List<Point>();
            points2.Add(new Point(8167779.0725412127, 7358665.6285971552));
            points2.Add(new Point(8167728.9107414037, 7359091.7530131396));
            points2.Add(new Point(8168261.5812822646, 7359086.9650989315));
            points2.Add(new Point(8167779.0725412127, 7358665.6285971552));
            var contour1 = new Contour(points2);

            Assert.Equal(246.23392637306685, contour1.GetDistance(contour0));
        }
        [Fact]
        public void GetDistanceBetweenContourAndContourTriangle2()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 1));
            points.Add(new Point(1, 0));
            points.Add(new Point(0, 0));
            var contour0 = new Contour(points);
            List<Point> points2 = new List<Point>();
            points2.Add(new Point(2, 2));
            points2.Add(new Point(2, 3));
            points2.Add(new Point(3, 2));
            points2.Add(new Point(2, 2));
            var contour1 = new Contour(points2);

            Assert.Equal(2.1213203435596424, contour1.GetDistance(contour0));
        }
    }
}
