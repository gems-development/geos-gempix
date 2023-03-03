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
			Assert.Equal(1, contour.GetDistance(pointA));
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
		
		// Проверка на расстояние между полигоном и точками, лежащими на нём
		[Fact]
		public void GetDistanceBetweenMatchPointAndPolygon()
		{
			//Arrange.
			var pointA = new Point(3, 4.5);
			var pointB = new Point(5, 2);
			
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

			//Act. + Assert.
			Assert.Equal(0, polygon.GetDistance(pointA));
			Assert.Equal(0, polygon.GetDistance(pointB));
		}
	}
}
