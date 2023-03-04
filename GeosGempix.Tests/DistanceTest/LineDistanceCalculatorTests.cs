using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace GeosGempix.Tests.DistanceTest
{
	public class LineDistanceCalcutatorTests
	{
		// Проверка на расстояние между отрезком и отрезком с общими точками
		[Fact]
		public void GetDistanceBetweenMatchLines()
		{
			//Arrange.
			//Первый случай
			var point1 = new Point(0, 0);
			var point2 = new Point(4, 0);
			var point3 = new Point(0, 0);
			var point4 = new Point(4, 0);
			
			//Второй случай
			var point5 = new Point(2, 2);
			var point6 = new Point(7, 2);
			var point7 = new Point(6, 0);
			var point8 = new Point(6, 4);
			
			//Третий случай
			var point9 = new Point(0, 0);
			var point10 = new Point(2, 0);
			var point11 = new Point(2, 0);
			var point12 = new Point(2, 1);
			
			var line1 = new Line(point1, point2);
			var line2 = new Line(point3, point4);
			var line3 = new Line(point5, point6);
			var line4 = new Line(point7, point8);
			var line5 = new Line(point9, point10);
			var line6 = new Line(point11, point12);
			
			//Act. + Assert.
			Assert.Equal(0,line1.GetDistance(line2));
			Assert.Equal(0,line3.GetDistance(line4));
			Assert.Equal(0,line5.GetDistance(line6));
		}
		
		// Проверка на расстояние между отрезком и отрезком
		[Fact]
		public void GetDistanceBetweenLineAndLine_Success()
		{
			//Arrange.
			//Первый случай
			var point1 = new Point(0, 0);
			var point2 = new Point(4, 0);
			var point3 = new Point(0, 2);
			var point4 = new Point(4, 2);
			
			//Второй случай
			var point5 = new Point(0, 0);
			var point6 = new Point(1, 0);
			var point7 = new Point(5, 3);
			var point8 = new Point(5, 4);
			
			var line1 = new Line(point1, point2);
			var line2 = new Line(point3, point4);
			var line3 = new Line(point5, point6);
			var line4 = new Line(point7, point8);

			//Act. + Assert.
			Assert.Equal(2,line1.GetDistance(line2));
			Assert.Equal(5,line3.GetDistance(line4));
		}
		
		// Проверка на расстояние между отрезком и контуром
		[Fact]
		public void GetDistanceBetweenLineAndContour_Success()
		{
			//Arrange.
			var point1 = new Point(0, 0);
			var point2 = new Point(0, 4);
			var point3 = new Point(4, 4);
			var point4 = new Point(4, 0);
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
			
			//1 случай
			var pointA = new Point(1,0);
			var pointB = new Point(3,0);
			var line1 = new Line(pointA, pointB);
			
			//2 случай
			var pointC = new Point(2,2);
			var pointD = new Point(6,2);
			var line2 = new Line(pointC, pointD);
			
			//3 случай
			var pointE = new Point(4,3);
			var pointF = new Point(7,3);
			var line3 = new Line(pointE, pointF);
			
			//4 случай
			var pointG = new Point(1,1);
			var pointH = new Point(1,2);
			var line4 = new Line(pointG, pointH);
			
			//5 случай
			var pointI = new Point(5,1);
			var pointJ = new Point(7,4);
			var line5 = new Line(pointI, pointJ);
			
			//6 случай
			var pointK = new Point(8,7);
			var pointL = new Point(9,6);
			var line6 = new Line(pointK, pointL);

			//Act. + Assert.
			Assert.Equal(0,line1.GetDistance(contour));
			Assert.Equal(0,line2.GetDistance(contour));
			Assert.Equal(0,line3.GetDistance(contour));
			Assert.Equal(1,line4.GetDistance(contour));
			Assert.Equal(1,line5.GetDistance(contour));
			Assert.Equal(5,line6.GetDistance(contour));
		}
		
		// Проверка на расстояние между отрезком и мультиточкой
		[Fact]
		public void GetDistanceBetweenLineAndMultiPoint_Success()
		{
			var point1 = new Point(0, 0);
			var point2 = new Point(1, 3);
			var point3 = new Point(2, 0);
			var points = new List<Point>
			{
				point1,
				point2,
				point3
			};
			var multiPoint = new MultiPoint(points);
			
			//1 случай
			var pointA = new Point(0,3);
			var pointB = new Point(3,3);
			var line1 = new Line(pointA, pointB);
			
			//2 случай
			var pointC = new Point(0,2);
			var pointD = new Point(3,2);
			var line2 = new Line(pointC, pointD);
			
			//3 случай
			var pointE = new Point(5,6);
			var pointF = new Point(6,6);
			var line3 = new Line(pointE, pointF);
			
			//Act. + Assert.
			Assert.Equal(0,line1.GetDistance(multiPoint));
			Assert.Equal(1,line2.GetDistance(multiPoint));
			Assert.Equal(5,line3.GetDistance(multiPoint));
		}
		
		// Проверка на расстояние между отрезком и мультилинией
		[Fact]
		public void GetDistanceBetweenLineAndMultiLine_Success()
		{
			var point1 = new Point(1, 0);
			var point2 = new Point(1, 3);
			var point3 = new Point(2, 3);
			var point4 = new Point(4, 3);
			var point5 = new Point(5, 0);
			var point6 = new Point(5, 2);

			var lineA = new Line(point1, point2);
			var lineB = new Line(point3, point4);
			var lineC = new Line(point5, point6);
			
			var lines = new List<Line>
			{
				lineA,
				lineB,
				lineC
			};
			var multiLine = new MultiLine(lines);
			
			//1 случай
			var pointA = new Point(0,1);
			var pointB = new Point(6,1);
			var line1 = new Line(pointA, pointB);
			
			//2 случай
			var pointC = new Point(4,1);
			var pointD = new Point(6,1);
			var line2 = new Line(pointC, pointD);
			
			//3 случай
			var pointE = new Point(4,3);
			var pointF = new Point(5,3);
			var line3 = new Line(pointE, pointF);
			
			//4 случай
			var pointG = new Point(3,0);
			var pointH = new Point(4,0);
			var line4 = new Line(pointG, pointH);
			
			//5 случай
			var pointI = new Point(7,1);
			var pointJ = new Point(7,4);
			var line5 = new Line(pointI, pointJ);
			
			//Act. + Assert.
			Assert.Equal(0,line1.GetDistance(multiLine));
			Assert.Equal(0,line2.GetDistance(multiLine));
			Assert.Equal(0,line3.GetDistance(multiLine));
			Assert.Equal(1,line4.GetDistance(multiLine));
			Assert.Equal(2,line5.GetDistance(multiLine));
		}
		
		// Проверка на расстояние между отрезком и полигоном
		[Fact]
		public void GetDistanceBetweenLineAndPolygon_Success()
		{
			//Arrange.
			var point1 = new Point(0, 0);
			var point2 = new Point(0, 7);
			var point3 = new Point(7, 7);
			var point4 = new Point(7, 0);
			var point5 = new Point(0, 0);
			var points1 = new List<Point>
			{
				point1,
				point2,
				point3,
				point4,
				point5
			};
			
			var point6 = new Point(2, 2);
			var point7 = new Point(2, 5);
			var point8 = new Point(5, 5);
			var point9 = new Point(5, 2);
			var point10 = new Point(2, 2);
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
			
			//1 случай
			var pointA = new Point(1,1);
			var pointB = new Point(1,6);
			var line1 = new Line(pointA, pointB);
			
			//2 случай
			var pointC = new Point(-1,4);
			var pointD = new Point(3,4);
			var line2 = new Line(pointC, pointD);
			
			//3 случай
			var pointE = new Point(1,4);
			var pointF = new Point(6,4);
			var line3 = new Line(pointE, pointF);
			
			//4 случай
			var pointG = new Point(3,3);
			var pointH = new Point(4,4);
			var line4 = new Line(pointG, pointH);
			
			//5 случай
			var pointI = new Point(9,5);
			var pointJ = new Point(11,3);
			var line5 = new Line(pointI, pointJ);
			
			//6 случай
			var pointK = new Point(9,0);
			var pointL = new Point(12,0);
			var line6 = new Line(pointK, pointL);
			
			//7 случай
			var pointM = new Point(11,10);
			var pointN = new Point(11,12);
			var line7 = new Line(pointM, pointN);
			
			//Act. + Assert.
			Assert.Equal(0,line1.GetDistance(contour));
			Assert.Equal(0,line2.GetDistance(contour));
			Assert.Equal(0,line3.GetDistance(contour));
			Assert.Equal(1,line4.GetDistance(contour));
			Assert.Equal(2,line5.GetDistance(contour));
			Assert.Equal(2,line6.GetDistance(contour));
			Assert.Equal(2,line7.GetDistance(contour));
		}
		
		// Проверка на расстояние между отрезком и мультиполигоном
		[Fact]
		public void GetDistanceBetweenLineAndMultiPolygon_Success()
		{
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
			
			//1 случай
			var pointA = new Point(3,9);
			var pointB = new Point(6,9);
			var line1 = new Line(pointA, pointB);
			
			//2 случай
			var pointC = new Point(4.5,6.5);
			var pointD = new Point(4.5,10.5);
			var line2 = new Line(pointC, pointD);
			
			//3 случай
			var pointE = new Point(4.5,10.5);
			var pointF = new Point(5.5,11.5);
			var line3 = new Line(pointE, pointF);
			
			//4 случай
			var pointG = new Point(2,8);
			var pointH = new Point(3,8);
			var line4 = new Line(pointG, pointH);
			
			//5 случай
			var pointI = new Point(11.5,6.5);
			var pointJ = new Point(14,9);
			var line5 = new Line(pointI, pointJ);
			
			//6 случай
			var pointK = new Point(12,8);
			var pointL = new Point(15,8);
			var line6 = new Line(pointK, pointL);
			
			//Act. + Assert.
			Assert.Equal(0,line1.GetDistance(multiPolygon));
			Assert.Equal(0,line2.GetDistance(multiPolygon));
			Assert.Equal(0,line3.GetDistance(multiPolygon));
			Assert.Equal(1,line4.GetDistance(multiPolygon));
			Assert.Equal(0.5,line5.GetDistance(multiPolygon));
			Assert.Equal(1,line6.GetDistance(multiPolygon));
		}
	}
}
