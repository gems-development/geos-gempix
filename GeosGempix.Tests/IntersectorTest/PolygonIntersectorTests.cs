using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest;

public class PolygonIntersectorTests
{
    // Проверка на пересечение между полигоном и полигоном
    [Theory]
    [MemberData(nameof(PolygonIntersectorTestData.PolygonAndPolygon), MemberType = typeof(PolygonIntersectorTestData))]
    public void IsIntersectionPolygonAndPolygon(bool result, Polygon polygon1, Polygon polygon2)
    {
        //Act. + Assert.
        Assert.Equal(result, polygon1.Intersects(polygon2));
    }
    
    // Проверка на пересечение между полигоном и мультиполигоном (Success)
    [Theory]
    [MemberData(nameof(PolygonIntersectorTestData.PolygonAndMultiPolygonSuccess), MemberType = typeof(PolygonIntersectorTestData))]
    public void IsIntersectionPolygonAndMultiPolygon_Success(bool res, Polygon polygon, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(res, polygon.Intersects(multiPolygon));
    }
    
    // Проверка на пересечение между полигоном и мультиполигоном (Failed)
    [Theory]
    [MemberData(nameof(PolygonIntersectorTestData.PolygonAndMultiPolygonFailed), MemberType = typeof(PolygonIntersectorTestData))]
    public void IsIntersectionPolygonAndMultiPolygon_Failed(bool res, Polygon polygon, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(res, polygon.Intersects(multiPolygon));
    }
}