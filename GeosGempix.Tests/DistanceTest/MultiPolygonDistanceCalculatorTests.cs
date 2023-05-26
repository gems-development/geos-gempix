using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest;

public class MultiPolygonDistanceCalculatorTests
{
    // Проверка на растояние между мультиполигоном и мультиполигоном
    [Theory]
    [MemberData(nameof(MultiPolygonDistanceCalculatorTestData.MultiPolygonAndMultiPolygon), MemberType = typeof(MultiPolygonDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPolygonAndMultiPolygon(double result, MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPolygon1.GetDistance(multiPolygon2));
    }
}