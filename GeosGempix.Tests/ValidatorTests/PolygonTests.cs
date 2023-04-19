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
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 2),
                new Point(2, 2),
                new Point(2, 0)
            };
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }

        [Fact]
        public static void PolygonTest_HourGlass_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 2),
                new Point(2, 0),
                new Point(2, 2)
            };
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_FiveAngles_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 2),
                new Point(2, 2),
                new Point(2, 1),
                new Point(1, 0)
            };
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.True(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_StarSelfIntersecting_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(6, 2),
                new Point(4, 0),
                new Point(-6, 3),
                new Point(6, 3)
            };
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }

        [Fact]
        public static void PolygonTest_SquareWithHole_Success()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 3),
                new Point(3, 3),
                new Point(3, 0)
            };
            List<Point> points1 = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 1),
                new Point(1, 1),
                new Point(1, 0)
            };
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
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 3),
                new Point(3, 3),
                new Point(3, 0)
            };
            List<Point> points1 = new List<Point>
            {
                new Point(1, 1),
                new Point(1, 2),
                new Point(2, 1),
                new Point(2, 2)
            };
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            polygon.Add(hole);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }


        [Theory]
        //[InlineData(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0))]
		//[InlineData(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(0, 0), new Point(0, 3), new Point(2, 2), new Point(2, 1))]
		[InlineData(0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 1, 1, 1, 1, 0)] // квадратный остров в левом нижнем углу
		[InlineData(0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 3, 2, 2, 2, 1)] // трапеция, у которой левая сторона полигона - это нижнее основание
		public static void PolygonTest_SquareWithHoleIntersectingTwoLines_Failed(double x11, double y11, double x12, double y12,
																				 double x21, double y21, double x22, double y22,
																				 double x31, double y31, double x32, double y32,
																				 double x41, double y41, double x42, double y42)

		//public static void PolygonTest_SquareWithHoleIntersectingTwoLines_Failed(Point point1, Point point2, Point point3, Point point4,
		//	                                                                     Point point5, Point point6, Point point7, Point point8)
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                //point1, point2, point3, point4
                new Point(x11, y11),
                new Point(x12, y12),
                new Point(x21, y21),
                new Point(x22, y22)
            };
            List<Point> points1 = new List<Point>
            {
                //point5, point6, point7, point8
                new Point(x31, y31),
                new Point(x32, y32),
                new Point(x41, y41),
                new Point(x42, y42)
            };
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            polygon.Add(hole);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }


        [Fact]
        public static void PolygonTest_SquareWithHolePartiallyOutOfBounds_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 3),
                new Point(3, 3),
                new Point(3, 0)
            };
            List<Point> points1 = new List<Point>
            {
                new Point(-1, 1),
                new Point(-1, 2),
                new Point(2, 1),
                new Point(1, 1)
            };
            Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            polygon.Add(hole);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }

        [Theory]
		//[InlineData(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(4, 4), new Point(4, 5), new Point(5, 5), new Point(5, 4))]
		//[InlineData(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0), new Point(3, 0), new Point(3, 2), new Point(5, 2), new Point(5, 0))]
		[InlineData(0, 0, 0, 3, 3, 3, 3, 0, 4, 4, 4, 5, 5, 5, 5, 4)] // остров за пределами полигона
		[InlineData(0, 0, 0, 3, 3, 3, 3, 0, 3, 0, 3, 2, 5, 2, 5, 0)] // остров касается полигона правой грани полигона с внешней стороны
		public static void PolygonTest_HoleNotInsideInPolygon_Failed(double x11, double y11, double x12, double y12,
																	 double x21, double y21, double x22, double y22,
																	 double x31, double y31, double x32, double y32,
																	 double x41, double y41, double x42, double y42)

		//public static void PolygonTest_HoleNotInsideInPolygon_Failed(Point point1, Point point2, Point point3, Point point4,
		//											                   Point point5, Point point6, Point point7, Point point8)
		{
			//Arrange. + Act.
			List<Point> points = new List<Point>
			{
                //point1, point2, point3, point4
                new Point(x11, y11),
				new Point(x12, y12),
				new Point(x21, y21),
				new Point(x22, y22)
			};
			List<Point> points1 = new List<Point>
			{
                //point5, point6, point7, point8
                new Point(x31, y31),
				new Point(x32, y32),
				new Point(x41, y41),
				new Point(x42, y42)
			};
			Contour hole = new Contour(points1);
            Polygon polygon = new Polygon(points);
            polygon.Add(hole);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }

        [Fact]
        public static void PolygonTest_LineIintersectPolygon_Failed()
        {
            //Arrange. + Act.
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, 2),
                new Point(2, 2),
                new Point(2, 0),
                new Point(5, 0)
            };
            Polygon polygon = new Polygon(points);
            var validator = new Validator(polygon);
            //Assert.
            Assert.False(validator.Validate());
        }
    }
}
