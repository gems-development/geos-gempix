using GeosGempix.Models;
using GeosGempix.Visitors.Validators;

namespace GeosGempix.Tests.ValidatorTests
{
    public class PolygonTests
    {
        [Fact]
        public static void PolygonTest_Square_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 2));
            points.Add(new Point(2, 2));
            points.Add(new Point(2, 0));
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }

        [Fact]
        public static void PolygonTest_HourGlass_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 2));
            points.Add(new Point(2, 0));
            points.Add(new Point(2, 2));
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_FiveAngles_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 2));
            points.Add(new Point(2, 2));
            points.Add(new Point(2, 1));
            points.Add(new Point(1, 0));
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_StarSelfIntersecting_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(6, 2));
            points.Add(new Point(4, 0));
            points.Add(new Point(-6, 3));
            points.Add(new Point(6, 3));
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }

        [Fact]
        public static void PolygonTest_SquareWithHole_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 3));
            points.Add(new Point(3, 3));
            points.Add(new Point(3, 0));
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(0, 0));
            points1.Add(new Point(0, 1));
            points1.Add(new Point(1, 1));
            points1.Add(new Point(1, 0));
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_SquareWithHoleIntersecting_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 3));
            points.Add(new Point(3, 3));
            points.Add(new Point(3, 0));
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(0, 0));
            points1.Add(new Point(0, 1));
            points1.Add(new Point(1, 0));
            points1.Add(new Point(1, 1));
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_SquareWithHoleIntersectingTwoLines_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 3));
            points.Add(new Point(3, 3));
            points.Add(new Point(3, 0));
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(0, 0));
            points1.Add(new Point(1, 0));
            points1.Add(new Point(1, 1));
            points1.Add(new Point(1, 0));
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_SquareWithHolePartiallyOutOfBounds_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 3));
            points.Add(new Point(3, 3));
            points.Add(new Point(3, 0));
            List<Point> points1 = new List<Point>();
            points1.Add(new Point(-1, 1));
            points1.Add(new Point(-1, 2));
            points1.Add(new Point(2, 1));
            points1.Add(new Point(1, 1));
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }
    }
}
