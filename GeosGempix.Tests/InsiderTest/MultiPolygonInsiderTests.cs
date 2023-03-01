using GeosGempix.Extensions;
using GeosGempix.Models;

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
		public static void IsPointInsideMultiPolygon()
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			Point pointTrue1 = new Point(8, 15);
			Point pointFalse1 = new Point(4, 14);
			Point pointFalse2 = new Point(6, 15);
			Point pointFalse3 = new Point(9, 15);
			Point pointFalse4 = new Point(10, 9);
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(pointTrue1);
			Boolean f1 = tests._multiPolygon.IsInside(pointFalse1);
			Boolean f2 = tests._multiPolygon.IsInside(pointFalse2);
			Boolean f3 = tests._multiPolygon.IsInside(pointFalse3);
			Boolean f4 = tests._multiPolygon.IsInside(pointFalse4);
			//Assert.
			Assert.True(t1);
			Assert.False(f1);
			Assert.False(f2);
			Assert.False(f3);
			Assert.False(f4);
		}

		[Fact]
		public static void IsLineInsideMultiPolygon()
		{
			//Arrange.
			MultiPolygonInsiderTests tests = new MultiPolygonInsiderTests();
			Line LineTrue1 = new Line(new Point(2, 7), new Point(7, 7));
			Line LineFalse1 = new Line(new Point(4, 14), new Point(6, 14));
			Line LineFalse2 = new Line(new Point(14, 14), new Point(15, 14));
			Line LineFalse3 = new Line(new Point(8, 11), new Point(11, 11));
			Line LineFalse4 = new Line(new Point(1, 5), new Point(7, 5));
			Line LineFalse5 = new Line(new Point(11, 9), new Point(18, 9));
			//Act.
			Boolean t1 = tests._multiPolygon.IsInside(LineTrue1);
			Boolean f1 = tests._multiPolygon.IsInside(LineFalse1);
			Boolean f2 = tests._multiPolygon.IsInside(LineFalse2);
			Boolean f3 = tests._multiPolygon.IsInside(LineFalse3);
			Boolean f4 = tests._multiPolygon.IsInside(LineFalse4);
			Boolean f5 = tests._multiPolygon.IsInside(LineFalse5);
			//Assert.
			Assert.True(t1);
			Assert.False(f1);
			Assert.False(f2);
			Assert.False(f3);
			Assert.False(f4);
			Assert.False(f5);
		}
	}
}
