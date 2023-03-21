using GeosGempix.Models;
using GeosGempix.Extensions;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.InsiderTest
{
    public class ContourInsiderTests
    {
        public Contour _contour;
        public ContourInsiderTests()
        {
            List<Point> points = new List<Point>();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 9);
            Point point3 = new Point(9, 9);
            Point point4 = new Point(9, 0);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            _contour = new Contour(points);
        }

        [Fact]
        public static void IsPointInsideContour_Success()
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

        [Theory]
        [InlineData(0,3)]
        [InlineData(10, 3)]
        public static void IsPointInsideContour_Failed(double x, double y)
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            Point pointFalse = new Point(x, y);
            //Act.
            Boolean f1 = tests._contour.IsInside(pointFalse);
            //Assert.
            Assert.False(f1);
        }

        [Fact]
        public static void IsLineInsideContour_Success()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            Line lineTrue = new Line(new Point(1, 1), new Point(8, 8));
            //Act.
            Boolean t1 = tests._contour.IsInside(lineTrue);
            //Assert.
            Assert.True(t1);
        }

        [Theory]
        [InlineData(5, 5, 10, 5)]
        [InlineData(3, 0, 6, 0)]
        [InlineData(3, 10, 6, 10)]
        public static void IsLineInsideContour_Failed(double x1, double y1, double x2, double y2)
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            Line lineFalse1 = new Line(new Point(x1, y1), new Point(x2, y2));
            //Act.
            Boolean f1 = tests._contour.IsInside(lineFalse1);
            //Assert.
            Assert.False(f1);
        }


        [Fact]
        public static void IsContourInsideContour1()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(3, 3);
            Point point2 = new Point(3, 6);
            Point point3 = new Point(6, 6);
            Point point4 = new Point(6, 3);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Contour contour = new Contour(points);
            //Act.
            Boolean t = tests._contour.IsInside(contour);
            //Assert.
            Assert.True(t);
        }

        [Fact]
        public static void IsContourInsideContour2()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(7, 3);
            Point point2 = new Point(7, 6);
            Point point3 = new Point(10, 6);
            Point point4 = new Point(10, 3);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Contour contour = new Contour(points);
            //Act.
            Boolean f = tests._contour.IsInside(contour);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsContourInsideContour3()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(3, 10);
            Point point2 = new Point(3, 13);
            Point point3 = new Point(6, 10);
            Point point4 = new Point(6, 13);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Contour contour = new Contour(points);
            //Act.
            Boolean f = tests._contour.IsInside(contour);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsContourInsideContour4()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(3, 9);
            Point point2 = new Point(3, 12);
            Point point3 = new Point(6, 9);
            Point point4 = new Point(6, 12);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Contour contour = new Contour(points);
            //Act.
            Boolean f = tests._contour.IsInside(contour);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsContourInsideContour5()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(3, 6);
            Point point2 = new Point(3, 9);
            Point point3 = new Point(6, 9);
            Point point4 = new Point(6, 6);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            Contour contour = new Contour(points);
            //Act.
            Boolean f = tests._contour.IsInside(contour);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsMultiPointInsideContour1()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(3, 5);
            Point point2 = new Point(7, 5);
            Point point3 = new Point(5, 3);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            MultiPoint multiPoint = new MultiPoint(points);
            //Act.
            Boolean t = tests._contour.IsInside(multiPoint);
            //Assert.
            Assert.True(t);
        }

        [Fact]
        public static void IsMultiPointInsideContour2()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(8, 8);
            Point point2 = new Point(10, 8);
            Point point3 = new Point(10, 7);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            MultiPoint multiPoint = new MultiPoint(points);
            //Act.
            Boolean f = tests._contour.IsInside(multiPoint);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsMultiPointInsideContour3()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points = new List<Point>();
            Point point1 = new Point(8, 8);
            Point point2 = new Point(9, 7);
            Point point3 = new Point(8, 6);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            MultiPoint multiPoint = new MultiPoint(points);
            //Act.
            Boolean f = tests._contour.IsInside(multiPoint);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsMultiLineInsideContour1_Success()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Line> lines = new List<Line>();
            Point point1 = new Point(2, 2);
            Point point2 = new Point(2, 6);
            Point point3 = new Point(4, 6);
            Point point4 = new Point(3, 3);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point2, point3);
            Line line3 = new Line(point3, point4);
            lines.Add(line1);
            lines.Add(line2);
            lines.Add(line3);
            MultiLine multiLine = new MultiLine(lines);
            //Act.
            Boolean f = tests._contour.IsInside(multiLine);
            //Assert.
            Assert.True(f);
        }

        [Fact]
        public static void IsMultiLineInsideContour2_Success()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Line> lines = new List<Line>();
            Point point1 = new Point(2, 6);
            Point point2 = new Point(4, 6);
            Point point3 = new Point(4, 4);
            Point point4 = new Point(4, 1);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point3, point4);
            lines.Add(line1);
            lines.Add(line2);
            MultiLine multiLine = new MultiLine(lines);
            //Act.
            Boolean f = tests._contour.IsInside(multiLine);
            //Assert.
            Assert.True(f);
        }

        [Theory]
        [InlineData(8, 2, 8, 6, 10, 6, 9, 3)]
        [InlineData(10, 2, 10, 6, 12, 6, 11, 3)]
        [InlineData(9, 2, 9, 6, 11, 6, 10, 3)]
        public static void IsMultiLineInsideContour1_Failed(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Line> lines = new List<Line>();
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point2, point3);
            Line line3 = new Line(point3, point4);
            lines.Add(line1);
            lines.Add(line2);
            lines.Add(line3);
            MultiLine multiLine = new MultiLine(lines);
            //Act.
            Boolean f = tests._contour.IsInside(multiLine);
            //Assert.
            Assert.False(f);
        }

        [Theory]
        [InlineData(10, 3, 10, 6, 11, 3, 11, 6)]
        [InlineData(3, 3, 6, 3, 5, 10, 10, 5)]
        [InlineData(3, 3, 6, 3, 6, 6, 11, 6)]
        [InlineData(0, 6, 9, 6, 4, 9, 4, 0)]
        public static void IsMultiLineInsideContour2_Failed(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Line> lines = new List<Line>();
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point3, point4);
            lines.Add(line1);
            lines.Add(line2);
            MultiLine multiLine = new MultiLine(lines);
            //Act.
            Boolean f = tests._contour.IsInside(multiLine);
            //Assert.
            Assert.False(f);
        }

        [Fact]
        public static void IsPolygonInsideContour1_Success()
        {
			//Arrange.
			ContourInsiderTests tests = new ContourInsiderTests();
			List<Point> points1 = new List<Point>();
			points1.Add(new Point(1, 1));
			points1.Add(new Point(1, 4));
			points1.Add(new Point(4, 4));
			points1.Add(new Point(4, 1));
			Polygon polygon1 = new Polygon(points1);
			//Act.
			Boolean t1 = tests._contour.IsInside(polygon1);
			//Assert.
			Assert.True(t1);
		}

		[Theory]
		[InlineData(0, 0, 0, 4, 4, 4, 4, 0)]
		[InlineData(7, 7, 7, 12, 12, 12, 12, 7)]
		public static void IsPolygonInsideContour1_Failed(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			//Arrange.
			ContourInsiderTests tests = new ContourInsiderTests();
			List<Point> points1 = new List<Point>();
			points1.Add(new Point(x1, y1));
			points1.Add(new Point(x2, y2));
			points1.Add(new Point(x3, y3));
			points1.Add(new Point(x4, y4));
			Polygon polygon1 = new Polygon(points1);
			//Act.
			Boolean f1 = tests._contour.IsInside(polygon1);
			//Assert.
			Assert.False(f1);
		}



		[Fact]
        public static void IsMultiPolygonInsideContour1_Success()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            List<Point> points1 = new List<Point>();
            List<Point> points2 = new List<Point>();
            List<Point> points3 = new List<Point>();
            List<Point> points4 = new List<Point>();
            List<Point> points5 = new List<Point>();
            List<Point> points6 = new List<Point>();

            points1.Add(new Point(1, 1));
            points1.Add(new Point(1, 4));
            points1.Add(new Point(4, 4));
            points1.Add(new Point(4, 1));

            points2.Add(new Point(2, 2));
            points2.Add(new Point(2, 3));
            points2.Add(new Point(3, 3));
            points2.Add(new Point(3, 2));

            points3.Add(new Point(5, 1));
            points3.Add(new Point(5, 4));
            points3.Add(new Point(8, 4));
            points3.Add(new Point(8, 1));

            points4.Add(new Point(6, 2));
            points4.Add(new Point(6, 3));
            points4.Add(new Point(7, 3));
            points4.Add(new Point(7, 2));

            points5.Add(new Point(5, 5));
            points5.Add(new Point(5, 8));
            points5.Add(new Point(8, 8));
            points5.Add(new Point(8, 5));

            points6.Add(new Point(6, 6));
            points6.Add(new Point(6, 7));
            points6.Add(new Point(7, 7));
            points6.Add(new Point(7, 6));

            Contour hole1 = new Contour(points2);
            Contour hole2 = new Contour(points4);
            Contour hole3 = new Contour(points6);

            Polygon polygon1 = new Polygon(points1);
            polygon1.Add(hole1);
            Polygon polygon2 = new Polygon(points3);
            polygon2.Add(hole2);
            Polygon polygon3 = new Polygon(points5);
            polygon3.Add(hole3);
            List<Polygon> polygons = new List<Polygon>();
            polygons.Add(polygon1);
            polygons.Add(polygon2);
            polygons.Add(polygon3);

            MultiPolygon multiPolygon = new MultiPolygon(polygons);
            //Act.
            Boolean f = tests._contour.IsInside(multiPolygon);
            //Assert.
            Assert.True(f);
        }

        [Theory]
        [InlineData(5, 1, 5, 4, 8, 4, 8, 1, 10, 1, 10, 4, 13, 4, 13, 1, 10, 5, 10, 8, 13, 8, 13, 5)]
		[InlineData(6, 1, 6, 4, 9, 4, 9, 1, 10, 1, 10, 4, 13, 4, 13, 1, 10, 5, 10, 8, 13, 8, 13, 5)]
		[InlineData(14, 1, 14, 4, 17, 4, 17, 1, 10, 1, 10, 4, 13, 4, 13, 1, 10, 5, 10, 8, 13, 8, 13, 5)]
		[InlineData(1, 1, 1, 4, 4, 4, 4, 1, 5, 1, 5, 4, 8, 4, 8, 1, 6, 5, 6, 8, 10, 8, 10, 5)]
		[InlineData(1, 1, 1, 4, 4, 4, 4, 1, 5, 1, 5, 4, 8, 4, 8, 1, 8.5, 5, 8.5, 8, 12.5, 8, 12.5, 5)]

		public static void IsMultiPolygonInsideContour1_Failed(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4,
                                                                double x5, double y5, double x6, double y6, double x7, double y7, double x8, double y8,
                                                                double x9, double y9, double x10, double y10, double x11, double y11, double x12, double y12)
        {

			//Arrange.
			ContourInsiderTests tests = new ContourInsiderTests();
			List<Point> points1 = new List<Point>();
			List<Point> points2 = new List<Point>();
			List<Point> points3 = new List<Point>();
			List<Point> points4 = new List<Point>();
			List<Point> points5 = new List<Point>();
			List<Point> points6 = new List<Point>();

			points1.Add(new Point(x1, y1));
			points1.Add(new Point(x2, y2));
			points1.Add(new Point(x3, y3));
			points1.Add(new Point(x4, y4));

			points2.Add(new Point(x1+1, y1+1));
			points2.Add(new Point(x2+1, y2-1));
			points2.Add(new Point(x3-1, y3-1));
			points2.Add(new Point(x4-1, y4+1));

			points3.Add(new Point(x5, y5));
			points3.Add(new Point(x6, y6));
			points3.Add(new Point(x7, y7));
			points3.Add(new Point(x8, y8));

			points4.Add(new Point(x5+1, y5+1));
			points4.Add(new Point(x6+1, y6-1));
			points4.Add(new Point(x7-1, y7-1));
			points4.Add(new Point(x8-1, y8+1));

			points5.Add(new Point(x9, y9));
			points5.Add(new Point(x10, y10));
			points5.Add(new Point(x11, y11));
			points5.Add(new Point(x12, y12));

			points6.Add(new Point(x9+1, y9+1));
			points6.Add(new Point(x10+1, y10-1));
			points6.Add(new Point(x11-1, y11-1));
			points6.Add(new Point(x12-1, y12+1));

			Contour hole1 = new Contour(points2);
			Contour hole2 = new Contour(points4);
			Contour hole3 = new Contour(points6);

			Polygon polygon1 = new Polygon(points1);
			polygon1.Add(hole1);
			Polygon polygon2 = new Polygon(points3);
			polygon2.Add(hole2);
			Polygon polygon3 = new Polygon(points5);
			polygon3.Add(hole3);
			List<Polygon> polygons = new List<Polygon>();
			polygons.Add(polygon1);
			polygons.Add(polygon2);
			polygons.Add(polygon3);

			MultiPolygon multiPolygon = new MultiPolygon(polygons);
			//Act.
			Boolean f = tests._contour.IsInside(multiPolygon);
			//Assert.
			Assert.False(f);
		}
    }

}