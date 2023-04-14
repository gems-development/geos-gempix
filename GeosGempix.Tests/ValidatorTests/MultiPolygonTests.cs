using GeosGempix.Visitors.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Tests.ValidatorTests
{
	public class MultiPolygonTests
	{

		[Fact]
		public static void IsNotPolygonIntersectsInMultiPolygon_Success()
		{ // Проверка на непересечение полигонов в мультиполигоне (успех)
			//Arrange. + Act. 
			List<Point> points1 = new List<Point>()
			{
				new Point(0, 0),
				new Point(0, 3),
				new Point(3, 3),
				new Point(3, 0)
			};

			List<Point> points2 = new List<Point>()
			{
				new Point(4, 4),
				new Point(4, 5),
				new Point(5, 5),
				new Point(5, 4)
			};

			List<Polygon> polygons = new List<Polygon>()
			{
				new Polygon(points1),
				new Polygon(points2)
			};
			MultiPolygon multiPolygon = new MultiPolygon(polygons);
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.True(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonIntersectsInMultiPolygon_Failed()
		{ // Проверка на непересечение полигонов в мультиполигоне (провал)
			//Arrange. + Act. 
			List<Point> points1 = new List<Point>()
			{
				new Point(0, 0),
				new Point(0, 3),
				new Point(3, 3),
				new Point(3, 0)
			};

			List<Point> points2 = new List<Point>()
			{
				new Point(2, 2),
				new Point(2, 4),
				new Point(4, 4),
				new Point(4, 2)
			};

			List<Polygon> polygons = new List<Polygon>()
			{
				new Polygon(points1),
				new Polygon(points2)
			};
			MultiPolygon multiPolygon = new MultiPolygon(polygons);
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonInsideInMultiPolygon_Failed()
		{ // Проверка на ненахождение одного полигона внутри другого в мультиполигоне (провал)
			//Arrange. + Act. 
			List<Point> points1 = new List<Point>()
			{
				new Point(0, 0),
				new Point(0, 3),
				new Point(3, 3),
				new Point(3, 0)
			};

			List<Point> points2 = new List<Point>()
			{
				new Point(1, 1),
				new Point(1, 2),
				new Point(2, 2),
				new Point(2, 1)
			};

			List<Polygon> polygons = new List<Polygon>()
			{
				new Polygon(points1),
				new Polygon(points2)
			};
			MultiPolygon multiPolygon = new MultiPolygon(polygons);
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonTouchingInMultiPolygon_Failed()
		{   // Проверка на касание полигонов друг друга в мультиполигоне (провал)
			//Arrange. + Act. 
			List<Point> points1 = new List<Point>()
			{
				new Point(0, 0),
				new Point(0, 3),
				new Point(3, 3),
				new Point(3, 0)
			};

			List<Point> points2 = new List<Point>()
			{
				new Point(3, 0),
				new Point(3, 3),
				new Point(6, 3),
				new Point(6, 0)
			};

			List<Polygon> polygons = new List<Polygon>()
			{
				new Polygon(points1),
				new Polygon(points2)
			};
			MultiPolygon multiPolygon = new MultiPolygon(polygons);
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.False(validator.Validate());
		}


		[Fact]
		public static void IsNotPolygonsConnectingInMultiPolygon_Success()
		{   // Проверка на соединение полигонов в двух точках в мультиполигоне (успех)
			//Arrange. + Act. 
			List<Point> points1 = new List<Point>()
			{
				new Point(0, 0),
				new Point(0, 3),
				new Point(2, 2),
				new Point(3, 3),
				new Point(3, 0)
			};

			List<Point> points2 = new List<Point>()
			{
				new Point(0, 3),
				new Point(0, 5),
				new Point(3, 5),
				//new Point(3, 3),
				new Point(2, 4)
			};

			List<Polygon> polygons = new List<Polygon>()
			{
				new Polygon(points1),
				new Polygon(points2)
			};
			MultiPolygon multiPolygon = new MultiPolygon(polygons);
			var validator = new Validator(multiPolygon);
			//Assert.
			Assert.True(validator.Validate());
		}
	}
}
