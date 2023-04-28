using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest
{
	public class LineDistanceCalculatorTests
	{
		// Проверка на расстояние между отрезком и отрезком
		[Theory]
		[InlineData(new double[]{0, 0, 4, 0}, new double[]{0, 0, 4, 0}, 0)]
		[InlineData(new double[]{2, 2, 7, 2}, new double[]{6, 0, 6, 4}, 0)]
		[InlineData(new double[]{0, 0, 2, 0}, new double[]{2, 0, 2, 1}, 0)]
		[InlineData(new double[]{0, 0, 4, 0}, new double[]{0, 2, 4, 2}, 2)]
		[InlineData(new double[]{0, 0, 1, 0}, new double[]{5, 3, 5, 4}, 5)]
		public void GetDistanceBetweenLineAndLine(double[] a, double[] b, double res)
		{
			//Arrange.
			var line1 = TestHelper.CreateLine(a[0], a[1], a[2], a[3]);
			var line2 = TestHelper.CreateLine(b[0], b[1], b[2], b[3]);

			//Act. + Assert.
			Assert.Equal(res,line1.GetDistance(line2));
		}

		//Проверка на расстояние между отрезком и контуром
		[Theory]
		[InlineData(new double[]{1, 0, 3, 0}, 0)]
		[InlineData(new double[]{2, 2, 6, 2}, 0)]
		[InlineData(new double[]{4, 3, 7, 3}, 0)]
		[InlineData(new double[]{1, 1, 1, 2}, 1)] //failed
		[InlineData(new double[]{5, 1, 7, 4}, 1)] //failed
		[InlineData(new double[]{8, 7, 9, 6}, 5)] //failed
		public void GetDistanceBetweenLineAndContour(double[] a, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0], a[1], a[2], a[3]);
			
			var contour = TestHelper.CreateContour(
				new Point(0, 0), new Point(0, 4), new Point(4, 4),
				new Point(4, 0), new Point(0, 0));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(contour));
		}
		
		// Проверка на расстояние между отрезком и мультиточкой
		[Theory]
		[InlineData(new double[]{0, 3, 3, 3}, 0)]
		[InlineData(new double[]{0, 2, 3, 2}, 1)]
		[InlineData(new double[]{5, 6, 6, 6}, 5)]
		public void GetDistanceBetweenLineAndMultiPoint_Success(double[] a, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0], a[1], a[2], a[3]);
			
			var multiPoint = TestHelper.CreateMultiPoint(
				new Point(0, 0),
				new Point(1, 3),
				new Point(2, 0));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(multiPoint));
		}
		
		// Проверка на расстояние между отрезком и мультилинией
		[Theory]
		[InlineData(new double[]{0, 1, 6, 1}, 0)]
		[InlineData(new double[]{4, 1, 6, 1}, 0)]
		[InlineData(new double[]{4, 3, 5, 3}, 0)]
		[InlineData(new double[]{3, 0, 4, 0}, 1)]
		[InlineData(new double[]{7, 1, 7, 4}, 2)]
		public void GetDistanceBetweenLineAndMultiLine_Success(double[] a, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0], a[1], a[2], a[3]);
			
			var multiLine = TestHelper.CreateMultiLine(
				TestHelper.CreateLine(1, 0, 1, 3),
				TestHelper.CreateLine(2, 3, 4, 3),
				TestHelper.CreateLine(5, 0, 5, 2));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(multiLine));
		}
		
		//Проверка на расстояние между отрезком и полигоном
		[Theory]
		[InlineData(new double[]{1, 1, 1, 6}, 0)]
		[InlineData(new double[]{-1, 4, 3, 4}, 0)]
		[InlineData(new double[]{1, 4, 6, 4}, 0)] //failed
		[InlineData(new double[]{3, 3, 4, 4}, 1)] //failed
		[InlineData(new double[]{9, 5, 11, 3}, 2)] //failed
		[InlineData(new double[]{9, 0, 12, 0}, 2)]
		[InlineData(new double[]{11, 10, 11, 12}, 2)] //failed
		public void GetDistanceBetweenLineAndPolygon_Success(double[] a, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0], a[1], a[2], a[3]);
			
			var polygon = TestHelper.CreatePolygon(
				new List<Contour>
				{
					TestHelper.CreateContour(
						new Point(2, 2), new Point(2, 5), new Point(5, 5),
						new Point(5, 2), new Point(2, 2))
				},
				new Point(0, 0), new Point(0, 7), new Point(7, 7),
				new Point(7, 0), new Point(0, 0));

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(polygon));
		}
		
		//Проверка на расстояние между отрезком и мультиполигоном
		[Theory]
		[InlineData(new double[]{6, 6, 8, 8}, 0)]
		[InlineData(new double[]{4, 13, 8, 13}, 0)]
		[InlineData(new double[]{15, 10, 15, 15}, 0)] 
		[InlineData(new double[]{3, 12, 4, 12}, 1)] //failed
		[InlineData(new double[]{20, 19, 21, 20}, 5)] //failed
		[InlineData(new double[]{17, 10, 21, 13}, 1)] //failed
		[InlineData(new double[]{10, 3, 14, 3}, 3)] //failed
		public void GetDistanceBetweenLineAndMultiPolygon_Success(double[] a, double res)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0], a[1], a[2], a[3]);

			var multiPolygon = TestHelper.CreateMultiPolygon(
				TestHelper.CreatePolygon(
					new List<Contour>
					{
						TestHelper.CreateContour(
							new Point(2, 2), new Point(2, 5), new Point(5, 5),
							new Point(5, 2), new Point(2, 2))
					},
					new Point(0, 0), new Point(0, 7), new Point(7, 7),
					new Point(7, 0), new Point(0, 0)),
				
				TestHelper.CreatePolygon(
					new List<Contour>
					{
						TestHelper.CreateContour(
							new Point(2, 11), new Point(2, 14), new Point(5, 14),
							new Point(5, 11), new Point(2, 11))
					},
					new Point(0, 9), new Point(0, 16), new Point(7, 16),
					new Point(7, 9), new Point(0, 9)),
				
				TestHelper.CreatePolygon(
					new List<Contour>
					{
						TestHelper.CreateContour(
							new Point(11, 11), new Point(11, 14), new Point(14, 14),
							new Point(14, 11), new Point(11, 11))
					},
					new Point(9, 9), new Point(9, 16), new Point(16, 16),
					new Point(16, 9), new Point(9, 9))
			);

			//Act. + Assert.
			Assert.Equal(res,line.GetDistance(multiPolygon));
		}
	}
}
