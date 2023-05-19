using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class ContourToucherTests
{
    [Theory]
    [MemberData(nameof(ContourToucherTestData.ContourAndContour), MemberType = typeof(ContourToucherTestData))]
    public static void IsContourTouchingContour(bool result, Contour contour1, Contour contour2)
    {
        //Act + Assert.
        Assert.Equal(result, contour1.IsTouching(contour2));
    }
    
    [Theory]
    [MemberData(nameof(ContourToucherTestData.ContourAndMultiPoint), MemberType = typeof(ContourToucherTestData))]
    public static void IsContourTouchingMultiPoint(bool result, Contour contour, MultiPoint multiPoint)
    {
        //Act + Assert.
        Assert.Equal(result, contour.IsTouching(multiPoint));
    }
    
    [Theory]
    [MemberData(nameof(ContourToucherTestData.ContourAndMultiLine), MemberType = typeof(ContourToucherTestData))]
    public static void IsContourTouchingMultiLine(bool result, Contour contour, MultiLine multiLine)
    {
        //Act + Assert.
        Assert.Equal(result, contour.IsTouching(multiLine));
    }

    [Theory]
    [MemberData(nameof(ContourToucherTestData.ContourAndPolygonInside), MemberType = typeof(ContourToucherTestData))]
    public static void IsContourTouchingPolygon_Inside(Contour contour, Polygon polygon)
    {
        //Act + Assert.
        Assert.True(contour.IsTouching(polygon));
    }
    
    [Theory]
    [MemberData(nameof(ContourToucherTestData.ContourAndPolygon), MemberType = typeof(ContourToucherTestData))]
    public static void IsContourTouchingPolygon(bool result, Contour contour, Polygon polygon)
    {
        //Act + Assert.
        Assert.Equal(result, contour.IsTouching(polygon));
    }
    
    [Theory]
    [MemberData(nameof(ContourToucherTestData.ContourAndMultiPolygon), MemberType = typeof(ContourToucherTestData))]
    public static void IsContourTouchingMultiPolygon(bool result, Contour contour, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.Equal(result, contour.IsTouching(multiPolygon));
    }
}