using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest
{
	public class LineIntersectorTests
	{
		// Проверка на пересечение между отрезком и отрезком
		[Theory]
		[MemberData(nameof(LineIntersectorTestData.LineAndLine), MemberType = typeof(LineIntersectorTestData))]
		public void IsIntersectionLineAndLine(bool result, Line line1, Line line2)
		{
			//Act. + Assert.
			Assert.Equal(result,line1.Intersects(line2));
		}

		// Проверка на пересечение между отрезком и контуром
		[Theory]
		[MemberData(nameof(LineIntersectorTestData.LineAndContour), MemberType = typeof(LineIntersectorTestData))]
		public void IsIntersectionLineAndContour(bool res, Line line, Contour contour)
		{
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(contour));
		}
		
		// Проверка на пересечение между отрезком и мультиточкой
		[Theory]
		[MemberData(nameof(LineIntersectorTestData.LineAndMultiPoint), MemberType = typeof(LineIntersectorTestData))]
		public void IsIntersectionLineAndMultiPoint(bool res, Line line, MultiPoint multiPoint)
		{
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(multiPoint));
		}
		
		// Проверка на пересечение между отрезком и мультилинией
		[Theory]
		[MemberData(nameof(LineIntersectorTestData.LineAndMultiLine), MemberType = typeof(LineIntersectorTestData))]
		public void IsIntersectionLineAndMultiLine(bool res, Line line, MultiPoint multiLine)
		{
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(multiLine));
		}
		
		// Проверка на пересечение между отрезком и полигоном
		[Theory]
		[MemberData(nameof(LineIntersectorTestData.LineAndPolygon), MemberType = typeof(LineIntersectorTestData))]
		public void IsIntersectionLineAndPolygon(bool res, Line line, Polygon polygon)
		{
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(polygon));
		}
		
		// Проверка на пересечение между отрезком и мультиполигоном
		[Theory]
		[MemberData(nameof(LineIntersectorTestData.LineAndMultiPolygon), MemberType = typeof(LineIntersectorTestData))]
		public void IsIntersectionLineAndMultiPolygon(bool res, Line line, MultiPolygon multiPolygon)
		{
			//Act. + Assert.
			Assert.Equal(res,line.Intersects(multiPolygon));
		}
	}
}
