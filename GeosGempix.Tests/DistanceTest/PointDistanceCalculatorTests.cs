using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest
{
	public class PointDistanceCalculatorTests
	{
		// Проверка на расстояние между точкой и точкой
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndPoint), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenPointAndPoint(double result, Point point1, Point point2)
		{
			//Act. + Assert.
			Assert.Equal(result, point1.GetDistance(point2));
		}

		// Проверка на расстояние между точкой и отрезком
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndLine), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenPointAndLine(double result, Point point, Line line)
		{
			//Act. + Assert.
			Assert.Equal(result, point.GetDistance(line));
		}

		// Проверка на расстояние между точкой и контуром
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndContour), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenPointAndContour(double result, Point point, Contour contour)
		{
			//Act. + Assert.
			Assert.Equal(result, point.GetDistance(contour));
		}

		// Проверка на расстояние между точкой и мультиточкой
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndMultiPoint), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenMatchPointAndMultiPoint(double result, Point point, MultiPoint multiPoint)
		{
			//Act. + Assert.
			Assert.Equal(result, point.GetDistance(multiPoint));
		}

		// Проверка на расстояние между точкой и мультилинией
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndMultiLine), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenMatchPointAndMultiLine(double result, Point point, MultiLine multiLine)
		{
			//Act. + Assert.
			Assert.Equal(result, point.GetDistance(multiLine));
		}

		// Проверка на расстояние между точкой и полигоном
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndPolygon), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenPointAndPolygon_Success(double result, Point point, Polygon polygon)
		{
			//Act. + Assert.
			Assert.Equal(result, point.GetDistance(polygon));
		}
		
		// Проверка на расстояние между точкой и мультиполигоном
		[Theory]
		[MemberData(nameof(PointDistanceCalculatorTestData.PointAndMultiPolygon), MemberType = typeof(PointDistanceCalculatorTestData))]
		public void GetDistanceBetweenPointAndMultiPolygon_Success(double result, Point point, MultiPolygon multiPolygon)
		{
			//Act. + Assert.
			Assert.Equal(result, point.GetDistance(multiPolygon));
		}
	}
}
