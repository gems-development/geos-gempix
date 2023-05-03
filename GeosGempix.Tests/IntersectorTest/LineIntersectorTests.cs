using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest
{
	public class LineIntersectorTests
	{
		// Проверка на пересечение между отрезком и отрезком
		[Theory]
		[InlineData(true, new double[]{2,4,7,4}, new double[]{4,4,4,7})]
		[InlineData(true, new double[]{2,4,4,4}, new double[]{3,4,7,4})] //failed
		[InlineData(false, new double[]{2,4,7,4}, new double[]{2,6,7,6})]
		public void IsIntersectionLineAndLine(bool res, double[] a, double[] b)
		{
			//Arrange.
			var line1 = TestHelper.CreateLine(a[0],a[1],a[2],a[3]);
			var line2 = TestHelper.CreateLine(b[0],b[1],b[2],b[3]);
			//Act. + Assert.
			Assert.Equal(res,line1.Intersects(line2));
		}

		// Проверка на пересечение между отрезком и контуром
		[Theory]
		[InlineData(true, new double[]{5,5,7,5})] //failed
		[InlineData(true, new double[]{8,5,10,5})]
		[InlineData(true, new double[]{-1,5,10,5})]
		[InlineData(true, new double[]{0,5,9,5})]
		[InlineData(false, new double[]{10,3,10,7})]
		public void IsIntersectionLineAndContour(bool res, double[] a)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0],a[1],a[2],a[3]);
			
			var contour = TestHelper.CreateContour(
				new Point(0, 0),
				new Point(0, 9),
				new Point(9, 9),
				new Point(9, 0),
				new Point(0, 0));
			
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(contour));
		}
		
		// Проверка на пересечение между отрезком и мультиточкой
		[Theory]
		[InlineData(true, new double[]{3,6,7,6}, new double[]{4,4,5,6,6,5})]
		[InlineData(false, new double[]{2,5,7,5}, new double[]{3,3,5,6,6,4})]
		[InlineData(false, new double[]{2,2,7,2}, new double[]{4,4,5,6,6,5})]
		public void IsIntersectionLineAndMultiPoint(bool res, double[] a, double[] b)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0],a[1],a[2],a[3]);
			
			var multiPoint = TestHelper.CreateMultiPoint(
				new Point(b[0],b[1]),
				new Point(b[2],b[3]),
				new Point(b[4],b[5]));
			
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(multiPoint));
		}
		
		// Проверка на пересечение между отрезком и мультилинией
		[Theory]
		[InlineData(true, new double[]{3,2,3,7})]
		[InlineData(true, new double[]{2,8,7,8})]
		[InlineData(false, new double[]{2,2,5,3})]
		public void IsIntersectionLineAndMultiLine(bool res, double[] a)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0],a[1],a[2],a[3]);
			
			var multiLine = TestHelper.CreateMultiLine(
				TestHelper.CreateLine(3,1,7,2),
				TestHelper.CreateLine(2,4,7,4),
				TestHelper.CreateLine(4,8,5,5));
			
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(multiLine));
		}
		
		// Проверка на пересечение между отрезком и полигоном
		[Theory]
		[InlineData(true, new double[]{-1,4,4,4})]
		[InlineData(true, new double[]{4,3,4,6})]
		[InlineData(true, new double[]{4,4,5,4})] //failed
		[InlineData(true, new double[]{9,4,11,4})]
		[InlineData(false, new double[]{10,3,10,6})]
		public void IsIntersectionLineAndPolygon(bool res, double[] a)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0],a[1],a[2],a[3]);
			
			var contour = TestHelper.CreateContour(
				new Point(3, 3),
				new Point(3, 6),
				new Point(6, 6),
				new Point(6, 3),
				new Point(3, 3));
			
			var contours = new List<Contour>{ contour };
			
			var polygon = TestHelper.CreatePolygon(
				contours,
				new Point(0, 0),
				new Point(0, 9),
				new Point(9, 9),
				new Point(9, 0),
				new Point(0, 0));
			
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(polygon));
		}
		
		// Проверка на пересечение между отрезком и мультиполигоном
		[Theory]
		[InlineData(true, new double[]{4,15,5,15})] //failed
		[InlineData(true, new double[]{15,18,15,21})]
		[InlineData(true, new double[]{0,4,0,6})] //failed
		[InlineData(false, new double[]{10,15,10,16})]
		public void IsIntersectionLineAndMultiPolygon(bool res, double[] a)
		{
			//Arrange.
			var line = TestHelper.CreateLine(a[0],a[1],a[2],a[3]);
			
			//полигон 1
			var contour1 = TestHelper.CreateContour(
				new Point(3, 3),
				new Point(3, 6),
				new Point(6, 6),
				new Point(6, 3),
				new Point(3, 3));
			
			var contours1 = new List<Contour>{ contour1 };
			
			var polygon1 = TestHelper.CreatePolygon(
				contours1,
				new Point(0, 0),
				new Point(0, 9),
				new Point(9, 9),
				new Point(9, 0),
				new Point(0, 0));
			
			//полигон 2
			var contour2 = TestHelper.CreateContour(
				new Point(3, 14),
				new Point(3, 17),
				new Point(6, 17),
				new Point(6, 14),
				new Point(3, 14));
			
			var contours2 = new List<Contour>{ contour2 };
			
			var polygon2 = TestHelper.CreatePolygon(
				contours2,
				new Point(0, 11),
				new Point(0, 20),
				new Point(9, 20),
				new Point(9, 11),
				new Point(0, 11));
			
			//полигон 3
			var contour3 = TestHelper.CreateContour(
				new Point(14,14),
				new Point(14,17),
				new Point(17,17),
				new Point(17,14),
				new Point(14,14));
			
			var contours3 = new List<Contour>{ contour3 };
			
			var polygon3 = TestHelper.CreatePolygon(
				contours3,
				new Point(11,11),
				new Point(11,20),
				new Point(20,20),
				new Point(20,11),
				new Point(11,11));
			
			var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2, polygon3);
			
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(multiPolygon));
		}
	}
}
