using GeosGempix.Extensions;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class MultiPolygonToucherTests
{
    [Theory]
    [MemberData(nameof(MultiPolygonToucherTestData.MultiPolygonAndMultiPolygon), MemberType = typeof(MultiPolygonToucherTestData))]
    public static void IsMultiPolygonTouchingMultiPolygon(bool result, MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
    {
        //Act + Assert.
        Assert.Equal(result,multiPolygon1.IsTouching(multiPolygon2));
    }
}