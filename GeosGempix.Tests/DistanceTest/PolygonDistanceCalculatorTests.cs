using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest
{
	public class PolygonDistanceCalculatorTests
    {
        // Проверка на растояние между полигоном и полигоном
        [Theory]
        [MemberData(nameof(PolygonDistanceCalculatorTestData.PolygonAndPolygon), MemberType = typeof(PolygonDistanceCalculatorTestData))]
        public void GetDistanceBetweenPolygonAndPolygon_Success(double result, Polygon polygon1, Polygon polygon2)
        {
            //Act. + Assert.
            Assert.Equal(result,polygon1.GetDistance(polygon2));
        }
        
        // Проверка на растояние между полигоном и мультиполигоном
        [Theory]
        [MemberData(nameof(PolygonDistanceCalculatorTestData.PolygonAndMultiPolygon), MemberType = typeof(PolygonDistanceCalculatorTestData))]
        public void GetDistanceBetweenPolygonAndMultiPolygon_Success(double result, Polygon polygon, MultiPolygon multiPolygon)
        {
            //Act. + Assert.
            Assert.Equal(result,multiPolygon.GetDistance(polygon));
        }
    }
}
