using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.DistanceTest
{
	public class LineDistanceCalculatorTests
	{
		// Проверка на расстояние между отрезком и отрезком
		[Theory]
		[InlineData(0, 0, 4, 0, 0, 0, 4, 0, 0)]
		[InlineData(2, 2, 7, 2, 6, 0, 6, 4, 0)]
		[InlineData(0, 0, 2, 0, 2, 0, 2, 1, 0)]
		[InlineData(0, 0, 4, 0, 0, 2, 4, 2, 2)]
		[InlineData(0, 0, 1, 0, 5, 3, 5, 4, 5)]
		public void GetDistanceBetweenLineAndLine(double x1, double y1, double x2, double y2,  
			double x3, double y3, double x4, double y4, double res)
		{
			//Arrange.
			var line1 = TestHelper.CreateLine(x1, y1, x2, y2);
			var line2 = TestHelper.CreateLine(x3, y3, x4, y4);

			//Act. + Assert.
			Assert.Equal(res,line1.GetDistance(line2));
		}

		//Проверка на расстояние между отрезком и контуром
		[Theory]
		[InlineData(1, 0, 3, 0, 0)]
		[InlineData(2, 2, 6, 2, 0)]
		[InlineData(4, 3, 7, 3, 0)]
		[InlineData(1, 1, 1, 2, 1)] //failed
		[InlineData(5, 1, 7, 4, 1)] //failed
		[InlineData(8, 7, 9, 6, 5)] //failed
		public void GetDistanceBetweenLineAndContour(double x1, double y1, double x2, double y2, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(x1, y1, x2, y2);
			
			var contour = TestHelper.CreateContour(
				new Point(0, 0),
				new Point(0, 4),
				new Point(4, 4),
				new Point(4, 0),
				new Point(0, 0));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(contour));
		}
		
		// Проверка на расстояние между отрезком и мультиточкой
		[Theory]
		[InlineData(0, 3, 3, 3, 0)]
		[InlineData(0, 2, 3, 2, 1)]
		[InlineData(5, 6, 6, 6, 5)]
		public void GetDistanceBetweenLineAndMultiPoint_Success(double x1, double y1, double x2, double y2, double res)
		{
			var line = TestHelper.CreateLine(x1, y1, x2, y2);
			
			var multiPoint = TestHelper.CreateMultiPoint(
				new Point(0, 0),
				new Point(1, 3),
				new Point(2, 0));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(multiPoint));
		}
		
		// Проверка на расстояние между отрезком и мультилинией
		[Theory]
		[InlineData(0, 1, 6, 1, 0)]
		[InlineData(4, 1, 6, 1, 0)]
		[InlineData(4, 3, 5, 3, 0)]
		[InlineData(3, 0, 4, 0, 1)]
		[InlineData(7, 1, 7, 4, 2)]
		public void GetDistanceBetweenLineAndMultiLine_Success(double x1, double y1, double x2, double y2, double res)
		{
			var line = TestHelper.CreateLine(x1, y1, x2, y2);
			
			var multiLine = TestHelper.CreateMultiLine(
				TestHelper.CreateLine(1, 0, 1, 3),
				TestHelper.CreateLine(2, 3, 4, 3),
				TestHelper.CreateLine(5, 0, 5, 2));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(multiLine));
		}
		
		//Проверка на расстояние между отрезком и полигоном
		[Theory]
		[InlineData(1, 1, 1, 6, 0)]
		[InlineData(-1, 4, 3, 4, 0)]
		[InlineData(1, 4, 6, 4, 0)] //failed
		[InlineData(3, 3, 4, 4, 1)] //failed
		[InlineData(9, 5, 11, 3, 2)] //failed
		[InlineData(9, 0, 12, 0, 2)]
		[InlineData(11, 10, 11, 12, 2)] //failed
		public void GetDistanceBetweenLineAndPolygon_Success(double x1, double y1, double x2, double y2, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(x1, y1, x2, y2);
			
			var contour = TestHelper.CreateContour(
				new Point(2, 2),
				new Point(2, 5),
				new Point(5, 5),
				new Point(5, 2),
				new Point(2, 2));
			
			var contours = new List<Contour>{ contour };
			
			var polygon = TestHelper.CreatePolygon(
				contours,
				new Point(0, 0),
				new Point(0, 7),
				new Point(7, 7),
				new Point(7, 0),
				new Point(0, 0));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(polygon));
		}
		
		//Проверка на расстояние между отрезком и мультиполигоном
		[Theory]
		[InlineData(6, 6, 8, 8, 0)]
		[InlineData(4, 13, 8, 13, 0)]
		[InlineData(15, 10, 15, 15, 0)] 
		[InlineData(3, 12, 4, 12, 1)] //failed
		[InlineData(20, 19, 21, 20, 5)] //failed
		[InlineData(17, 10, 21, 13, 1)] //failed
		[InlineData(10, 3, 14, 3, 3)] //failed
		public void GetDistanceBetweenLineAndMultiPolygon_Success(double x1, double y1, double x2, double y2, double res)
		{
			var line = TestHelper.CreateLine(x1, y1, x2, y2);
			
			//полигон 1
			var contour1 = TestHelper.CreateContour(
				new Point(2, 2),
				new Point(2, 5),
				new Point(5, 5),
				new Point(5, 2),
				new Point(2, 2));
			
			var contours1 = new List<Contour>{ contour1 };
			
			var polygon1 = TestHelper.CreatePolygon(
				contours1,
				new Point(0, 0),
				new Point(0, 7),
				new Point(7, 7),
				new Point(7, 0),
				new Point(0, 0));
			
			//полигон 2
			var contour2 = TestHelper.CreateContour(
				new Point(2, 11),
				new Point(2, 14),
				new Point(5, 14),
				new Point(5, 11),
				new Point(2, 11));
			
			var contours2 = new List<Contour>{ contour2 };
			
			var polygon2 = TestHelper.CreatePolygon(
				contours2,
				new Point(0, 9),
				new Point(0, 16),
				new Point(7, 16),
				new Point(7, 9),
				new Point(0, 9));
			
			//полигон 3
			var contour3 = TestHelper.CreateContour(
				new Point(11, 11),
				new Point(11, 14),
				new Point(14, 14),
				new Point(14, 11),
				new Point(11, 11));
			
			var contours3 = new List<Contour>{ contour3 };
			
			var polygon3 = TestHelper.CreatePolygon(
				contours3,
				new Point(9, 9),
				new Point(9, 16),
				new Point(16, 16),
				new Point(16, 9),
				new Point(9, 9));
			
			var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2, polygon3);

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(multiPolygon));
		}
	}
}
