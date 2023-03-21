using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.InsiderTest
{
	public class MultiPolygonInsiderTests
	{
		public MultiPolygon _multiPolygon;
		public MultiPolygonInsiderTests() 
		{
			List<Point> points1 = new List<Point>();
			List<Point> points2 = new List<Point>();
			List<Point> points3 = new List<Point>();
			List<Point> points4 = new List<Point>();
			List<Point> points5 = new List<Point>();
			List<Point> points6 = new List<Point>();

			points1.Add(new Point(0, 0));
			points1.Add(new Point(0, 9));
			points1.Add(new Point(9, 9));
			points1.Add(new Point(9, 0));

			points2.Add(new Point(3, 3));
			points2.Add(new Point(3, 6));
			points2.Add(new Point(6, 6));
			points2.Add(new Point(6, 3));

			points3.Add(new Point(0, 10));
			points3.Add(new Point(0, 19));
			points3.Add(new Point(9, 19));
			points3.Add(new Point(9, 10));

			points4.Add(new Point(3, 13));
			points4.Add(new Point(6, 16));
			points4.Add(new Point(6, 16));
			points4.Add(new Point(6, 13));

			points5.Add(new Point(10, 10));
			points5.Add(new Point(10, 19));
			points5.Add(new Point(19, 19));
			points5.Add(new Point(19, 10));

			points6.Add(new Point(13, 13));
			points6.Add(new Point(13, 16));
			points6.Add(new Point(16, 16));
			points6.Add(new Point(16, 13));

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

			_multiPolygon = new MultiPolygon(polygons);
		}

		[Fact]
		public static void IsPointInsideMultiPolygon_Success()
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			Point pointTrue1 = new Point(8, 15);
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(pointTrue1);
			//Assert.
			Assert.True(t1);
		}

        [Theory]
		[InlineData(4, 14)]
        [InlineData(6, 15)]
        [InlineData(9, 15)]
        [InlineData(10, 9)]
        public static void IsPointInsideMultiPolygon_Failed(double x, double y)
        {
            //Arrange.
            MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
            Point pointFalse1 = new Point(x, y);
            //Act.
            Boolean f1 = tests._multiPolygon.IsInside(pointFalse1);
            //Assert.
            Assert.False(f1);
        }

        [Fact]
		public static void IsLineInsideMultiPolygon_Succes()
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			Line LineTrue1 = new Line(new Point(2, 7), new Point(7, 7));
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(LineTrue1);
			//Assert.
			Assert.True(t1);
		}

        [Theory]
		[InlineData(4, 14, 6, 14)]
        [InlineData(14, 14, 15, 14)]
        [InlineData(8, 11, 11, 11)]
        [InlineData(1, 5, 7, 5)]
        [InlineData(11, 9, 18, 9)]
        public static void IsLineInsideMultiPolygon_Failed(double x1, double y1, double x2, double y2)
        {
            //Arrange.
            MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
            Line LineFalse1 = new Line(new Point(x1, y1), new Point(x2, y2));
            //Act.
            Boolean f1 = tests._multiPolygon.IsInside(LineFalse1);
            //Assert.
            Assert.False(f1);
        }

        [Theory]
		[InlineData(1, 14, 1, 15, 2, 15, 2, 14)]
		[InlineData(11, 11, 11, 18, 18, 18, 18, 11)]
		public static void IsContourInsideMultiPolygon_Success(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			List<Point> points = new List<Point>
			{
				new Point(x1, y1),
				new Point(x2, y2),
				new Point(x3, y3),
				new Point(x4, y4)
			};
			Contour contour = new Contour(points);
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(contour);
			//Assert.
			Assert.True(t1);
		}

		[Theory]
		[InlineData(4, 7, 4, 9, 6, 9, 6, 7)]
		[InlineData(4, 14, 4, 15, 5, 15, 5, 14)]
		[InlineData(11, 14, 11, 16, 13, 16, 13, 14)]
		[InlineData(2.5, 4.5, 4.5, 6.5, 6, 9, 6, 7)]
		[InlineData(7, 14, 7, 16, 11, 16, 11, 14)]
		[InlineData(11, 5, 11, 7, 12, 7, 12, 5)]
		[InlineData(0, 0, 0, 9, 9, 9, 9, 0)]
		[InlineData(6, 14, 6, 15, 9, 15, 9, 14)]
		[InlineData(13, 13, 13, 16, 16, 16, 16, 13)]
		public static void IsContourInsideMultiPolygon_Failed(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			List<Point> points = new List<Point>
			{
				new Point(x1, y1),
				new Point(x2, y2),
				new Point(x3, y3),
				new Point(x4, y4)
			};
			Contour contour = new Contour(points);
			//Act.
			Boolean f1 = tests._multiPolygon.IsInside(contour);
			//Assert.
			Assert.False(f1);
		}


		[Theory]
		[InlineData(7, 15, 8, 15, 7, 14)]
		[InlineData(4, 8, 7, 14, 15, 12)]
		public static void IsMultiPointInsideMultiPolygon_Success(double x1, double y1, double x2, double y2, double x3, double y3)
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			List<Point> points = new List<Point>
			{
				new Point(x1, y1),
				new Point(x2, y2),
				new Point(x3, y3)
			};
			MultiPoint multiPoint = new MultiPoint(points);
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(multiPoint);
			//Assert.
			Assert.True(t1);
		}

		[Theory]
		[InlineData(4, 6, 4, 7, 5, 7)]
		[InlineData(7, 15, 10, 15, 7, 14)]
		[InlineData(15, 15, 17, 17, 17, 14)]
		[InlineData(4, 0, 4, 3, 4, 4)]
		[InlineData(7, 9, 7, 9, 9, 10)]
		[InlineData(13, 14, 17, 14, 20, 14)]
		[InlineData(4, 4, 6, 4, 9, 4)]
		[InlineData(1, 14, 3, 14, 5, 14)]
		[InlineData(14, 14, 17, 14, 19, 14)]
		[InlineData(4, 4, 9, 4, 10, 4)]
		[InlineData(6, 15, 7, 14, 9, 13)]
		[InlineData(16, 13, 17, 14, 20, 14)]
		public static void IsMultiPointInsideMultiPolygon_Failed(double x1, double y1, double x2, double y2, double x3, double y3)
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			List<Point> points = new List<Point>
			{
				new Point(x1, y1),
				new Point(x2, y2),
				new Point(x3, y3)
			};
			MultiPoint multiPoint = new MultiPoint(points);
			//Act.
			Boolean f1 = tests._multiPolygon.IsInside(multiPoint);
			//Assert.
			Assert.False(f1);
		}


		[Theory]
		[InlineData(2, 14, 2, 15, 4, 11, 5, 11)]
		[InlineData(1, 8, 8, 8, 8, 8, 8, 4)]
		[InlineData(1, 8, 5, 8, 1, 14, 1, 15)]
		public static void IsMultiLineInsideMultiPolygon_Success(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			List<Line> lines = new List<Line>();
			lines.Add(new Line(new Point(x1, y1), new Point(x2, y2)));
			lines.Add(new Line(new Point(x3, y3), new Point(x4, y4)));
			MultiLine multiLine = new MultiLine(lines);
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(multiLine);
			//Assert.
			Assert.True(t1);
		}

		[Theory]
		[InlineData(0, 0, 0, 2, 0, 2, 2, 4)]
		public static void IsMultiLineInsideMultiPolygon_Failed(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			List<Line> lines = new List<Line>();
			lines.Add(new Line(new Point(x1, y1), new Point(x2, y2)));
			lines.Add(new Line(new Point(x3, y3), new Point(x4, y4)));
			MultiLine multiLine = new MultiLine(lines);
			//Act.
			Boolean f1 = tests._multiPolygon.IsInside(multiLine);
			//Assert.
			Assert.False(f1);
		}
	}
}
