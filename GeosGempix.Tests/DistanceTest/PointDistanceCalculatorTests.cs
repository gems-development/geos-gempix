using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.DistanceTest
{
	public class PointDistanceCalculatorTests
	{
		// Проверка на расстояние между совпадающими точками
		[Fact]
		public void GetDistanceBetweenMatchPoints()
		{
			//Arrange.
			var point1 = new Point(1, 1);
			var point2 = new Point(1, 1);

			//Act. + Assert.
			Assert.Equal(0, point1.GetDistance(point2));
		}
		
		// Проверка на расстояние между двумя точками
		[Fact]
		public void GetDistanceBetweenPointAndPoint_Success()
		{
			//Arrange.
			var point1 = new Point(1, 1);
			var point2 = new Point(5, 4);

			//Act. + Assert.
			Assert.Equal(5, point1.GetDistance(point2));
		}
		
		// Проверка на расстояние между прямой и точкой, лежащей на ней
		[Fact]
		public void GetDistanceBetweenMatchPointAndLine()
		{
			//Arrange.
			var point = new Point(1, 1);
			
			var point1 = new Point(1, 1);
			var point2 = new Point(5, 1);
			var line = new Line(point1, point2);

			//Act. + Assert.
			Assert.Equal(0, line.GetDistance(point));
		}
		
		// Проверка на расстояние между точкой и прямой
		[Fact]
		public void GetDistanceBetweenPointAndLine_Success()
		{
			//Arrange.
			var point1 = new Point(1, 1);
			var point2 = new Point(5, 1);
			var lineA = new Line(point1, point2);
			var point3 = new Point(4, 0);
			var point4 = new Point(8, 0);
			var lineB = new Line(point3, point4);
			
			//Первый случай
			var pointA = new Point(1, 3);
			
			//Второй случай
			var pointB = new Point(3, 3);

			//Третий случай
			var pointС = new Point(0, 3);
			
			//Act. + Assert.
			Assert.Equal(2, lineA.GetDistance(pointA));
			Assert.Equal(2, lineA.GetDistance(pointB));
			Assert.Equal(5, lineB.GetDistance(pointС));
		}
		
		// Проверка на расстояние между контуром и точкой, лежащей на нём
		[Fact]
		public void GetDistanceBetweenMatchPointAndContour()
		{
			//Arrange.
			var point = new Point(3, 0);
			
			var point1 = new Point(0, 0);
			var point2 = new Point(0, 3);
			var point3 = new Point(3, 3);
			var point4 = new Point(3, 0);
			var point5 = new Point(0, 0);
			var points = new List<Point>
			{
				point1,
				point2,
				point3,
				point4,
				point5
			};
			var contour = new Contour(points);

			//Act. + Assert.
			Assert.Equal(0, contour.GetDistance(point));
		}
		
		// Проверка на расстояние между точкой и контуром
		[Fact]
		public void GetDistanceBetweenPointAndContour_Success()
		{
			//Arrange.
			var point1 = new Point(0, 0);
			var point2 = new Point(0, 3);
			var point3 = new Point(3, 3);
			var point4 = new Point(3, 0);
			var point5 = new Point(0, 0);
			var points = new List<Point>
			{
				point1,
				point2,
				point3,
				point4,
				point5
			};
			var contour = new Contour(points);
			
			//Первый случай
			var pointA = new Point(1, 1);
			
			//Второй случай
			var pointB = new Point(5, 1);
			
			//Третий случай
			var pointC = new Point(7, 6);

			//Act. + Assert.
			Assert.Equal(0, contour.GetDistance(pointA));
			Assert.Equal(2, contour.GetDistance(pointB));
			Assert.Equal(5, contour.GetDistance(pointC));
		}
		
		// Проверка на расстояние между мультиточкой и точкой, лежащей на ней
		[Fact]
		public void GetDistanceBetweenMatchPointAndMultiPoint()
		{
			//Arrange.
			var point = new Point(2, 0);
			
			var point1 = new Point(0, 0);
			var point2 = new Point(1, 2);
			var point3 = new Point(2, 0);
			var points = new List<Point>
			{
				point1,
				point2,
				point3
			};
			var multiPoint = new MultiPoint(points);

			//Act. + Assert.
			Assert.Equal(0, multiPoint.GetDistance(point));
		}
		
		// Проверка на расстояние между точкой и мультиточкой
		[Fact]
		public void GetDistanceBetweenPointAndMultiPoint_Success()
		{
			//Arrange.
			var point = new Point(1, 1);

			//Первый случай
			var point1 = new Point(0, 1);
			var point2 = new Point(1, 2);
			var point3 = new Point(1, 0);
			var pointsA = new List<Point>
			{
				point1,
				point2,
				point3
			};
			var multiPointA = new MultiPoint(pointsA);
			
			//Второй случай
			var point4 = new Point(0, 0);
			var point5 = new Point(1, 2);
			var point6 = new Point(2, 0);
			var pointsB = new List<Point>
			{
				point4,
				point5,
				point6
			};
			var multiPointB = new MultiPoint(pointsB);

			//Act. + Assert.
			Assert.Equal(1, multiPointA.GetDistance(point));
			Assert.Equal(1, multiPointB.GetDistance(point));
		}
		
		// Проверка на расстояние между мультилинией и точкой, лежащей на ней
		[Fact]
		public void GetDistanceBetweenMatchPointAndMultiLine()
		{
			//Arrange.
			var point = new Point(6, 1);
			
			var point1 = new Point(0, 0);
			var point2 = new Point(3, 0);
			var line1 = new Line(point1, point2);
			var point3 = new Point(4, 0);
			var point4 = new Point(4, 2);
			var line2 = new Line(point3, point4);
			var point5 = new Point(5, 1);
			var point6 = new Point(8, 1);
			var line3 = new Line(point5, point6);
			
			var lines = new List<Line>
			{
				line1,
				line2,
				line3
			};
			var multiLine = new MultiLine(lines);

			//Act. + Assert.
			Assert.Equal(0, multiLine.GetDistance(point));
		}
		
		// Проверка на расстояние между точкой и мультилинией
		[Fact]
		public void GetDistanceBetweenPointAndMultiLine_Success()
		{
			//Arrange.
			var point = new Point(12, 4);
			
			var point1 = new Point(0, 0);
			var point2 = new Point(3, 0);
			var line1 = new Line(point1, point2);
			var point3 = new Point(4, 0);
			var point4 = new Point(4, 2);
			var line2 = new Line(point3, point4);
			var point5 = new Point(5, 1);
			var point6 = new Point(8, 1);
			var line3 = new Line(point5, point6);
			
			var lines = new List<Line>
			{
				line1,
				line2,
				line3
			};
			var multiLine = new MultiLine(lines);

			//Act. + Assert.
			Assert.Equal(5, multiLine.GetDistance(point));
		}
		
		// Проверка на расстояние между точкой и полигоном
		[Fact]
		public void GetDistanceBetweenPointAndPolygon_Success()
		{
			//Arrange.
			var point1 = new Point(0, 0);
			var point2 = new Point(0, 5);
			var point3 = new Point(5, 5);
			var point4 = new Point(5, 0);
			var point5 = new Point(0, 0);
			var points1 = new List<Point>
			{
				point1,
				point2,
				point3,
				point4,
				point5
			};
			
			var point6 = new Point(1, 1);
			var point7 = new Point(1, 4);
			var point8 = new Point(4, 4);
			var point9 = new Point(4, 1);
			var point10 = new Point(1, 1);
			var points2 = new List<Point>
			{
				point6,
				point7,
				point8,
				point9,
				point10
			};

			var contour = new Contour(points2);
			var contours = new List<Contour>
			{
				contour
			};
			var polygon = new Polygon(points1, contours);
			
			//Первый случай
			var pointA = new Point(3, 4.5);
			var pointB = new Point(5, 2);
			
			//Второй случай
			var pointC = new Point(2, 2);
			
			//Третий случай
			var pointD = new Point(9, 8);
			var pointE = new Point(8, 1);

			//Act. + Assert.
			Assert.Equal(0, polygon.GetDistance(pointA));
			Assert.Equal(0, polygon.GetDistance(pointB));
			Assert.Equal(2, polygon.GetDistance(pointC));
			Assert.Equal(5, polygon.GetDistance(pointD));
			Assert.Equal(3, polygon.GetDistance(pointE));
		}
		
		// Проверка на расстояние между точкой и мультиполигоном
		[Fact]
		public void GetDistanceBetweenPointAndMultiPolygon_Success()
		{
			//Arrange.
			//Набор точек для внешних контуров
			var point1 = new Point(0, 0);
			var point2 = new Point(0, 5);
			var point3 = new Point(5, 5);
			var point4 = new Point(5, 0);
			var point5 = new Point(0, 0);
			
			var point11 = new Point(0, 6);
			var point21 = new Point(0, 11);
			var point31 = new Point(5, 11);
			var point41 = new Point(5, 6);
			var point51 = new Point(0, 6);
			
			var point61 = new Point(6, 6);
			var point71 = new Point(6, 11);
			var point81 = new Point(11, 11);
			var point91 = new Point(11, 6);
			var point101 = new Point(6, 6);
			
			var points11 = new List<Point>
			{
				point1,
				point2,
				point3,
				point4,
				point5
			};
			var points21 = new List<Point>
			{
				point11,
				point21,
				point31,
				point41,
				point51
			};
			var points31 = new List<Point>
			{
				point61,
				point71,
				point81,
				point91,
				point101
			};
			
			//Набор точек для внутренних контуров
			var point32 = new Point(1, 1);
			var point42 = new Point(1, 4);
			var point52 = new Point(4, 4);
			var point62 = new Point(4, 1);
			var point72 = new Point(1, 1);
			
			var point33 = new Point(1, 7);
			var point43 = new Point(1, 10);
			var point53 = new Point(4, 10);
			var point63 = new Point(4, 7);
			var point73 = new Point(1, 7);
			
			var point34 = new Point(7, 7);
			var point44 = new Point(7, 10);
			var point54 = new Point(10, 10);
			var point64 = new Point(10, 7);
			var point74 = new Point(7, 7);
			
			var points41 = new List<Point>
			{
				point32,
				point42,
				point52,
				point62,
				point72
			};
			var points51 = new List<Point>
			{
				point33,
				point43,
				point53,
				point63,
				point73
			};
			var points61 = new List<Point>
			{
				point34,
				point44,
				point54,
				point64,
				point74
			};
			
			var contour1 = new Contour(points41);
			var contours1 = new List<Contour>
			{
				contour1
			};
			var polygon1 = new Polygon(points11, contours1);
			
			var contour2 = new Contour(points51);
			var contours2 = new List<Contour>
			{
				contour2
			};
			var polygon2 = new Polygon(points21, contours2);
			
			var contour3 = new Contour(points61);
			var contours3 = new List<Contour>
			{
				contour3
			};
			var polygon3 = new Polygon(points31, contours3);

			var polygons = new List<Polygon>
			{
				polygon1,
				polygon2,
				polygon3
			};
			var multiPolygon = new MultiPolygon(polygons);
			
			//Второй случай
			var pointA = new Point(4.5, 8);
			var pointB = new Point(11, 9);
			var pointC = new Point(2, 9);
			var pointD = new Point(8, 2);
			var pointE = new Point(14, 2);

			//Act. + Assert.
			Assert.Equal(0, multiPolygon.GetDistance(pointA));
			Assert.Equal(0, multiPolygon.GetDistance(pointB));
			Assert.Equal(2, multiPolygon.GetDistance(pointC));
			Assert.Equal(3, multiPolygon.GetDistance(pointD));
			Assert.Equal(5, multiPolygon.GetDistance(pointE));
		}
	}
}
