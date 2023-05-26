using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest
{
	public class LineDistanceCalculatorTests
	{
		// Проверка на расстояние между отрезком и отрезком
		[Theory]
		[MemberData(nameof(LineDistanceCalculatorTestData.LineAndLine), MemberType = typeof(LineDistanceCalculatorTestData))]
		public void GetDistanceBetweenLineAndLine(double result, Line line1, Line line2)
		{
			//Act. + Assert.
			Assert.Equal(result,line1.GetDistance(line2));
		}

		//Проверка на расстояние между отрезком и контуром
		[Theory]
		[MemberData(nameof(LineDistanceCalculatorTestData.LineAndContour), MemberType = typeof(LineDistanceCalculatorTestData))]
		public void GetDistanceBetweenLineAndContour(double result, Line line, Contour contour)
		{
			//Act. + Assert.
			Assert.Equal(result, line.GetDistance(contour));
		}
		
		// Проверка на расстояние между отрезком и мультиточкой
		[Theory]
		[MemberData(nameof(LineDistanceCalculatorTestData.LineAndMultiPoint), MemberType = typeof(LineDistanceCalculatorTestData))]
		public void GetDistanceBetweenLineAndMultiPoint(double result, Line line, MultiPoint multiPoint)
		{
			//Act. + Assert.
			Assert.Equal(result,line.GetDistance(multiPoint));
		}
		
		// Проверка на расстояние между отрезком и мультилинией
		[Theory]
		[MemberData(nameof(LineDistanceCalculatorTestData.LineAndMultiLine), MemberType = typeof(LineDistanceCalculatorTestData))]
		public void GetDistanceBetweenLineAndMultiLine_Success(double result, Line line, MultiLine multiLine)
		{
			//Act. + Assert.
			Assert.Equal(result,line.GetDistance(multiLine));
		}
		
		//Проверка на расстояние между отрезком и полигоном
		[Theory]
		[MemberData(nameof(LineDistanceCalculatorTestData.LineAndPolygon), MemberType = typeof(LineDistanceCalculatorTestData))]
		public void GetDistanceBetweenLineAndPolygon_Success(double result, Line line, Polygon polygon)
		{
			//Act. + Assert.
			Assert.Equal(result,line.GetDistance(polygon));
		}
		
		//Проверка на расстояние между отрезком и мультиполигоном
		[Theory]
		[MemberData(nameof(LineDistanceCalculatorTestData.LineAndMultiPolygon), MemberType = typeof(LineDistanceCalculatorTestData))]
		public void GetDistanceBetweenLineAndMultiPolygon_Success(double result, Line line, MultiPolygon multiPolygon)
		{
			//Act. + Assert.
			Assert.Equal(result,line.GetDistance(multiPolygon));
		}
	}
}
