using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;
using System.Diagnostics;

namespace GeosGempix.Tests.ProductivityTest
{
    public class GetDistanceTests
    {
        [Fact]
        public static void IsPointInsideContour()
        {
            //Arrange.
            var sw1 = new Stopwatch();
            var sw2 = new Stopwatch();

            Point pointLine1 = new Point(0, 0);
            Point pointLine2 = new Point(5, 0);
            Line line = new Line(pointLine1, pointLine2);
            Point point1 = new Point(3, 6);
            Point point2 = new Point(0, 3);
            Point point3 = new Point(10, 3);
            List<Point> points = new List<Point>();
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            Contour contour = new Contour(points);
            //Act.
            sw1.Start();
            double d1 = ContourDistanceCalculator.GetDistanceWithSquares(contour, line);
            sw1.Stop();
            sw2.Start();
            double d2 = ContourDistanceCalculator.GetDistance(contour, line);
            sw2.Stop();
            //Assert.
            System.TimeSpan t1 = sw1.Elapsed;
            System.TimeSpan t2 = sw2.Elapsed;
        }
    }
}
