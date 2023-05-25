using GeosGempix.Extensions;
using GeosGempix.MultiModels;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class MultiLineToucherTests
{
    [Theory]
    [MemberData(nameof(MultiLineToucherTestData.MultiLineAndMultiLine), MemberType = typeof(MultiLineToucherTestData))]
    public static void IsMultiLineTouchingMultiLine(bool result, MultiLine multiLine1, MultiLine multiLine2)
    {
        //Act + Assert.
        Assert.Equal(result, multiLine1.IsTouching(multiLine2));
    }

    [Theory]
    [MemberData(nameof(MultiLineToucherTestData.MultiLineAndPolygon), MemberType = typeof(MultiLineToucherTestData))]
    public static void IsMultiLineTouchingPolygon(bool result, MultiLine multiLine, Polygon polygon)
    {
        //Act + Assert.
        Assert.Equal(result, multiLine.IsTouching(polygon));
    }
    
    [Theory]
    [MemberData(nameof(MultiLineToucherTestData.MultiLineAndMultiPolygon), MemberType = typeof(MultiLineToucherTestData))]
    public static void IsMultiLineTouchingMultiPolygon(bool result, MultiLine multiLine, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.Equal(result, multiLine.IsTouching(multiPolygon));
    }
}