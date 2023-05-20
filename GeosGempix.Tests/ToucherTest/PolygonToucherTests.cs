using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class PolygonToucherTests
{
    [Theory]
    [MemberData(nameof(PolygonToucherTestData.PolygonAndPolygon), MemberType = typeof(PolygonToucherTestData))]
    public static void IsPolygonTouchingPolygon(bool result, Polygon polygon1, Polygon polygon2)
    {
        //Act + Assert.
        Assert.Equal(result, polygon1.IsTouching(polygon2));
    }

    [Theory]
    [MemberData(nameof(PolygonToucherTestData.PolygonAndMultiPolygon), MemberType = typeof(PolygonToucherTestData))]
    public static void IsPolygonTouchingMultiPolygon(bool result, Polygon polygon, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.Equal(result, polygon.IsTouching(multiPolygon));
    }
    
    [Theory]
    [MemberData(nameof(PolygonToucherTestData.PolygonAndPolygonInside), MemberType = typeof(PolygonToucherTestData))]
    public static void IsPolygonTouchingPolygon_Inside(Polygon polygon1, Polygon polygon2)
    {
        //Act + Assert.
        Assert.True(polygon1.IsTouching(polygon2));
    }

    [Theory]
    [MemberData(nameof(PolygonToucherTestData.PolygonAndMultiPolygonInside), MemberType = typeof(PolygonToucherTestData))]
    public static void IsPolygonTouchingMultiPolygon_Inside(Polygon polygon, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.True(polygon.IsTouching(multiPolygon));
    }
}