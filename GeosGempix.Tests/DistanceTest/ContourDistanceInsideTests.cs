using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.DistanceTest.TestData;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceInsideTests
{
    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndPointInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndPoint(double result, Contour contour, Point point)
    {
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour, point));
    }
    
    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndLineInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndLine(double result, Contour contour, Line line)
    {
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour, line));
    }
    
    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndContourInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndContour(double result, Contour contour1, Contour contour2)
    {
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour1, contour2));
    }

    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndMultiPointInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndMultiPoint(double result, Contour contour, MultiPoint multiPoint)
    {
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour, multiPoint));
    }

    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndMultiLineInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndMultiLine(double result, Contour contour, MultiLine multiLine)
    {
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour, multiLine));
    }

    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndPolygonInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndPolygon(double result, Contour contour, Polygon polygon)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour, polygon));
    }
    
    [Theory]
    [MemberData(nameof(ContourDistanceInsideTestData.ContourAndMultiPolygonInside), MemberType = typeof(ContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndMultiPolygon(double result, Contour contour, MultiPolygon multiPolygon)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(result, ContourDistanceCalculator.GetDistanceInside(contour, multiPolygon));
    }
}