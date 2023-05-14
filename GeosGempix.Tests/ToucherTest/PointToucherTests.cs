using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.ToucherTest.TestData;

namespace GeosGempix.Tests.ToucherTest;

public class PointToucherTests
{
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndPoint), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingPoint(bool result, Point point1, Point point2)
    {
        //Assert
        Assert.Equal(result, point1.IsTouching(point2));
    }
    
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndLine), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingLine(bool result, Point point, Line line)
    {
        //Assert
        Assert.Equal(result, point.IsTouching(line));
    }
    
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndContour), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingContour(bool result, Point point, Contour contour)
    {
        //Assert
        Assert.Equal(result, contour.IsTouching(point));
    }
    
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndMultiPoint), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingMultiPoint(bool result, Point point, MultiPoint multiPoint)
    {
        //Assert
        Assert.Equal(result, point.IsTouching(multiPoint));
    }
    
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndMultiLine), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingMultiLine(bool result, Point point, MultiLine multiLine)
    {
        //Assert
        Assert.Equal(result, point.IsTouching(multiLine));
    }
    
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndPolygon), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingPolygon(bool result, Point point, Polygon polygon)
    {
        //Assert
        Assert.Equal(result, point.IsTouching(polygon));
    }
    
    [Theory]
    [MemberData(nameof(PointToucherTestData.PointAndMultiPolygon), MemberType = typeof(PointToucherTestData))]
    public static void IsPointTouchingMultiPolygon(bool result, Point point, MultiPolygon multiPolygon)
    {
        //Assert
        Assert.Equal(result, point.IsTouching(multiPolygon));
    }
}