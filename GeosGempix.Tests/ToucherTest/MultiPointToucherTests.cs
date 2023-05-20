using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class MultiPointToucherTests
{
    [Theory]
    [MemberData(nameof(MultiPointToucherTestData.MultiPointAndMultiPoint), MemberType = typeof(MultiPointToucherTestData))]
    public static void IsMultiPointTouchingMultiPoint(bool result, MultiPoint multiPoint1, MultiPoint multiPoint2)
    {
        //Act + Assert.
        Assert.Equal(result, multiPoint1.IsTouching(multiPoint2));
    }
    
    [Theory]
    [MemberData(nameof(MultiPointToucherTestData.MultiPointAndMultiLine), MemberType = typeof(MultiPointToucherTestData))]
    public static void IsMultiPointTouchingMultiLine(bool result, MultiPoint multiPoint, MultiLine multiLine)
    {
        //Act + Assert.
        Assert.Equal(result, multiPoint.IsTouching(multiLine));
    }

    [Theory]
    [MemberData(nameof(MultiPointToucherTestData.MultiPointAndPolygon), MemberType = typeof(MultiPointToucherTestData))]
    public static void IsMultiPointTouchingPolygon(bool result, MultiPoint multiPoint, Polygon polygon)
    {
        //Act + Assert.
        Assert.Equal(result, multiPoint.IsTouching(polygon));
    }
    
    [Theory]
    [MemberData(nameof(MultiPointToucherTestData.MultiPointAndMultiPolygon), MemberType = typeof(MultiPointToucherTestData))]
    public static void IsMultiPointTouchingMultiPolygon(bool result, MultiPoint multiPoint, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.Equal(result, multiPoint.IsTouching(multiPolygon));
    }
}