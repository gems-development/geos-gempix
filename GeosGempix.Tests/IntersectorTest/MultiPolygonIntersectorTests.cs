using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest;

public class MultiPolygonIntersectorTests
{
    // Проверка на пересечение между мультиполигоном и мультиполигоном
    [Theory]
    [MemberData(nameof(MultiPolygonIntersectorTestData.MultiPolygonAndMultiPolygon), MemberType = typeof(MultiPolygonIntersectorTestData))]
    public void IsIntersectionMultiPolygonAndMultiPolygon(bool result, MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
    {
        //Act. + Assert.
        Assert.Equal(result, multiPolygon1.Intersects(multiPolygon2));
    }
}