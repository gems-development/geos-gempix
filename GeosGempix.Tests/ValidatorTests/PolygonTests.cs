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

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {                // квадратный остров в левом нижнем углу
                new object[] {new Polygon(
								new List<Point>{new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0)},
								new List<Contour>{
									new Contour(
										new List<Point>{new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0)}
											   )
												 }
										 )
							 },
                             // трапеция, у которой левая сторона полигона - это нижнее основание
               new object[] {new Polygon(
								new List<Point>{new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0)},
								new List<Contour>{
									new Contour(
										new List<Point>{ new Point(0, 0), new Point(0, 3), new Point(2, 2), new Point(2, 1)}
											   )
												 }
										 )
							 },
            };

        [Theory]
        [MemberData(nameof(Data))]
		public static void PolygonTest_SquareWithHoleIntersectingTwoLines_Failed(Polygon polygon)
        {
            //Arrange. + Act.
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


        public static IEnumerable<object[]> Data1 =>
            new List<object[]>
            {                // остров за пределами полигона
                new object[] {new Polygon(
								new List<Point>{new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0)},
								new List<Contour>{
									new Contour(
										new List<Point>{ new Point(4, 4), new Point(4, 5), new Point(5, 5), new Point(5, 4)}
											   )
												 }
										  )
							 },
                             // остров касается полигона правой грани полигона с внешней стороны
                new object[] {new Polygon(
								new List<Point>{new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0)},
								new List<Contour>{
									new Contour(
										new List<Point>{new Point(3, 0), new Point(3, 2), new Point(5, 2), new Point(5, 0)}
											   )
												 }
										 )
							 },
            };

        [Theory]
		[MemberData(nameof(Data1))]
        public static void PolygonTest_HoleNotInsideInPolygon_Failed(Polygon polygon)
		{
			//Arrange. + Act.
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
