using GeosGempix.Models;
using GeosGempix.Visitors.Validators;

namespace GeosGempix.Tests.ValidatorTests
{
    public class CountourTests
    {
        [Fact]
        public static void ContourTest1_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 2));
            points.Add(new Point(2, 2));
            points.Add(new Point(2, 0));
            Contour contour = new Contour(points);
            var validator = new Validator(contour);
            //Assert.
            Assert.True(validator.Validate());
        }

        [Fact]
        public static void ContourTest1_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 2));
            points.Add(new Point(2, 0));
            points.Add(new Point(2, 2));
            Contour contour = new Contour(points);
            var validator = new Validator(contour);
            //Assert.
            Assert.False(validator.Validate());
        }


        [Fact]
        public static void ContourTest2_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 2));
            points.Add(new Point(2, 2));
            points.Add(new Point(2, 1));
            points.Add(new Point(1, 0));
            Contour contour = new Contour(points);
            var validator = new Validator(contour);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void ContourTest2_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(6, 2));
            points.Add(new Point(4, 0));
            points.Add(new Point(-6, 3));
            points.Add(new Point(6, 3));
            Contour contour = new Contour(points);
            var validator = new Validator(contour);
            //Assert.
            Assert.False(validator.Validate());
        }
    }
}
