using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class LineToucherTests
{
    [Theory]
    [MemberData(nameof(LineToucherTestData.LineAndLine), MemberType = typeof(LineToucherTestData))]
    public static void IsLineTouchingLine(bool result, Line line1, Line line2)
    {
        //Act + Assert.
        Assert.Equal(result, line1.IsTouching(line2));
    }
    
    [Theory]
    [MemberData(nameof(LineToucherTestData.LineAndContour), MemberType = typeof(LineToucherTestData))]
    public static void IsLineTouchingContour(bool result, Line line, Contour contour)
    {
        //Act + Assert.
        Assert.Equal(result, contour.IsTouching(line));
    }
    
    [Theory]
    [MemberData(nameof(LineToucherTestData.LineAndMultiPoint), MemberType = typeof(LineToucherTestData))]
    public static void IsLineTouchingMultiPoint(bool result, Line line, MultiPoint multiPoint)
    {
        //Act + Assert.
        Assert.Equal(result, line.IsTouching(multiPoint));
    }

    [Theory]
    [MemberData(nameof(LineToucherTestData.LineAndPolygon), MemberType = typeof(LineToucherTestData))]
    public static void IsLineTouchingPolygon(bool result, Line line, Polygon polygon)
    {
        //Act + Assert.
        Assert.Equal(result, line.IsTouching(polygon));
    }
    
    [Theory]
    [MemberData(nameof(LineToucherTestData.LineAndMultiPolygon), MemberType = typeof(LineToucherTestData))]
    public static void IsLineTouchingMultiPolygon(bool result, Line line, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.Equal(result, line.IsTouching(multiPolygon));
    }
}