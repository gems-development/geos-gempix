using GeosGempix.Models;
using GeosGempix.Extensions;

namespace GeosGempix.Tests.InsiderTest
{
    public class ContourInsiderTests
    {       
        public Contour _contour;
        public ContourInsiderTests()
        {
            List<Point> points = new List<Point>();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(9, 0);
            Point point3 = new Point(9, 9);
            Point point4 = new Point(0, 9);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            _contour = new Contour(points);
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

        [Fact]
        public static void IsLineInsideContour()
        {
            //Arrange.
            ContourInsiderTests tests = new ContourInsiderTests();
            Line lineTrue = new Line(new Point(1, 1), new Point(8, 8));
            Line lineFalse1 = new Line(new Point(5, 5), new Point(10, 5));
            Line lineFalse2 = new Line(new Point(3, 0), new Point(6, 0));
            Line lineFalse3 = new Line(new Point(3, 10), new Point(6, 10));
            //Act.
            Boolean t1 = tests._contour.IsInside(lineTrue);
            Boolean f1 = tests._contour.IsInside(lineFalse1);
            Boolean f2 = tests._contour.IsInside(lineFalse2);
            Boolean f3 = tests._contour.IsInside(lineFalse3);
            //Assert.
            Assert.True(t1);
            Assert.False(f1);
            Assert.False(f2);
            Assert.False(f3);
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
            Point point3 = new Point(10 ,7);
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
    }
}
