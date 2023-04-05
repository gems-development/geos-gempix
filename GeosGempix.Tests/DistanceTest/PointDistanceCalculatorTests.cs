using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest
{
	public class PointDistanceCalculatorTests
	{
		// Проверка на расстояние между точкой и точкой
		[Theory]
		[InlineData(0, new double[] {1, 1, 1, 1})]
		[InlineData(5, new double[] {1, 1, 5, 4})]
		public void GetDistanceBetweenPointAndPoint(double res, double[] a)
		{
			//Arrange.
			var point1 = new Point(a[0], a[1]);
			var point2 = new Point(a[2], a[3]);

			//Act. + Assert.
			Assert.Equal(res, point1.GetDistance(point2));
		}

		// Проверка на расстояние между точкой и прямой
		[Theory]
		[InlineData(new double[]{1, 1}, new double[]{1, 1, 5, 1}, 0)]
		[InlineData(new double[]{1, 3}, new double[]{1, 1, 5, 1}, 2)]
		[InlineData(new double[]{3, 3}, new double[]{1, 1, 5, 1}, 2)]
		[InlineData(new double[]{0, 3}, new double[]{4, 0, 8, 0}, 5)]
		public void GetDistanceBetweenPointAndLine(double[] a, double[] b, double res)
		{
			//Arrange.
			var point = new Point(a[0], a[1]);
			var line = TestHelper.CreateLine(b[0], b[1], b[2], b[3]);

			//Act. + Assert.
			Assert.Equal(res, line.GetDistance(point));
		}

		// Проверка на расстояние между точкой и контуром
		[Theory]
		[InlineData(new double[]{3, 0}, 0)]
		[InlineData(new double[]{1, 1}, 0)]
		[InlineData(new double[]{5, 1}, 2)]
		[InlineData(new double[]{7, 6}, 5)]
		public void GetDistanceBetweenPointAndContour(double[] a, double res)
		{
			//Arrange.
			var point = new Point(a[0], a[1]);
			
			var contour = TestHelper.CreateContour(
				new Point(0, 0),
				new Point(0, 3),
				new Point(3, 3),
				new Point(3, 0),
				new Point(0, 0));

			//Act. + Assert.
			Assert.Equal(res, contour.GetDistance(point));
		}

		// Проверка на расстояние между точкой и мультиточкой
		[Theory]
		[InlineData(new double[]{2, 0}, new double[]{0, 0, 1, 2, 2, 0}, 0)]
		[InlineData(new double[]{1, 1}, new double[]{0, 0, 1, 2, 2, 0}, 1)]
		[InlineData(new double[]{1, 1}, new double[]{0, 1, 1, 2, 1, 0}, 1)]
		public void GetDistanceBetweenMatchPointAndMultiPoint(double[] a, double[] b, double res)
		{
			//Arrange.
			var point = new Point(a[0], a[1]);

			var multiPoint = TestHelper.CreateMultiPoint(
				new Point(b[0], b[1]),
				new Point(b[2], b[3]),
				new Point(b[4], b[5]));

			//Act. + Assert.
			Assert.Equal(res, multiPoint.GetDistance(point));
		}

		// Проверка на расстояние между точкой и мультилинией
		[Theory]
		[InlineData(new double[]{6, 1}, 0)]
		[InlineData(new double[]{12, 4}, 5)]
		public void GetDistanceBetweenMatchPointAndMultiLine(double[] a, double res)
		{
			//Arrange.
			var point = new Point(a[0], a[1]);

			var multiLine = TestHelper.CreateMultiLine(
				TestHelper.CreateLine(0, 0, 3, 0),
				TestHelper.CreateLine(4, 0, 4, 2),
				TestHelper.CreateLine(5, 1, 8, 1));

			//Act. + Assert.
			Assert.Equal(res, multiLine.GetDistance(point));
		}

		// Проверка на расстояние между точкой и полигоном
		[Theory]
		[InlineData(new double[]{3, 4.5}, 0)]
		[InlineData(new double[]{5, 2}, 0)]
		[InlineData(new double[]{2, 2}, 2)]
		[InlineData(new double[]{9, 8}, 5)]
		[InlineData(new double[]{8, 1}, 3)]
		public void GetDistanceBetweenPointAndPolygon_Success(double[] a, double res)
		{
			//Arrange.
			var point = new Point(a[0], a[1]);
			
			var contour = TestHelper.CreateContour(
				new Point(1, 1),
				new Point(1, 4),
				new Point(4, 4),
				new Point(4, 1),
				new Point(1, 1));
			
			var contours = new List<Contour>{ contour };
			
			var polygon = TestHelper.CreatePolygon(
				contours,
				new Point(0, 0),
				new Point(0, 5),
				new Point(5, 5),
				new Point(5, 0),
				new Point(0, 0));
		
			//Act. + Assert.
			Assert.Equal(res, polygon.GetDistance(point));
		}
		
		// Проверка на расстояние между точкой и мультиполигоном
		[Theory]
		[InlineData(new double[]{4.5, 8}, 0)]
		[InlineData(new double[]{11, 9}, 0)]
		[InlineData(new double[]{2, 9}, 2)]
		[InlineData(new double[]{8, 2}, 3)]
		[InlineData(new double[]{14, 2}, 5)]
		public void GetDistanceBetweenPointAndMultiPolygon_Success(double[] a, double res)
		{
			//Arrange.
			var point = new Point(a[0], a[1]);
			
			//полигон 1
			var contour1 = TestHelper.CreateContour(
				new Point(1, 1),
				new Point(1, 4),
				new Point(4, 4),
				new Point(4, 1),
				new Point(1, 1));
			
			var contours1 = new List<Contour>{ contour1 };
			
			var polygon1 = TestHelper.CreatePolygon(
				contours1,
				new Point(0, 0),
				new Point(0, 5),
				new Point(5, 5),
				new Point(5, 0),
				new Point(0, 0));
			
			//полигон 2
			var contour2 = TestHelper.CreateContour(
				new Point(1, 7),
				new Point(1, 10),
				new Point(4, 10),
				new Point(4, 7),
				new Point(1, 7));
			
			var contours2 = new List<Contour>{ contour2 };
			
			var polygon2 = TestHelper.CreatePolygon(
				contours2,
				new Point(0, 6),
				new Point(0, 11),
				new Point(5, 11),
				new Point(5, 6),
				new Point(0, 6));
			
			//полигон 3
			var contour3 = TestHelper.CreateContour(
				new Point(7, 7),
				new Point(7, 10),
				new Point(10, 10),
				new Point(10, 7),
				new Point(7, 7));
			
			var contours3 = new List<Contour>{ contour3 };
			
			var polygon3 = TestHelper.CreatePolygon(
				contours3,
				new Point(6, 6),
				new Point(6, 11),
				new Point(11, 11),
				new Point(11, 6),
				new Point(6, 6));
			
			var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2, polygon3);

			//Act. + Assert.
			Assert.Equal(res, multiPolygon.GetDistance(point));
		}
	}
}
