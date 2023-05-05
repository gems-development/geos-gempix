using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceInsideTests
{
    private Contour _contour;

    public ContourDistanceInsideTests()
    {
        _contour = TestHelper.CreateContour(
            new Point(0, 0), new Point(0, 5), new Point(5, 5),
            new Point(5, 0), new Point(0, 0));
    }
    
    public static IEnumerable<object[]> ContourAndPointDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[] { 2, new Point(2,2) },
            new object[] { 0, new Point(6,2) }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndPointDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndPoint(double res, Point point)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, point));
    }
    
    public static IEnumerable<object[]> ContourAndLineDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[] { 1, TestHelper.CreateLine(1,1,1,4) },
            new object[] { 0, TestHelper.CreateLine(1,6,5,6) }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndLineDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndLine(double res, Line line)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, line));
    }
    
    public static IEnumerable<object[]> ContourAndContourDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                1, TestHelper.CreateContour(
                    new Point(2,2), new Point(2,4), new Point(4,4),
                    new Point(4,2), new Point(2,2))
            },
            new object[]
            {
                0, TestHelper.CreateContour(
                    new Point(7,2), new Point(7,4), new Point(9,4),
                    new Point(9,2), new Point(7,2))
            }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndContourDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndContour(double res, Contour contour)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, contour));
    }
    
    public static IEnumerable<object[]> ContourAndMultiPointDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                2, TestHelper.CreateMultiPoint(
                    new Point(2,2), new Point(3,2), new Point(3,3))
            },
            new object[]
            {
                0, TestHelper.CreateMultiPoint(
                    new Point(6,2), new Point(8,3), new Point(8,4))
            }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndMultiPointDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndMultiPoint(double res, MultiPoint multiPoint)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, multiPoint));
    }
    
    public static IEnumerable<object[]> ContourAndMultiLineDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                1, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,1,3,2),
                    TestHelper.CreateLine(1,2,3,3),
                    TestHelper.CreateLine(1,3,3,4))
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(6,2,8,3),
                    TestHelper.CreateLine(7,1,9,1),
                    TestHelper.CreateLine(9,2,9,4))
            }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndMultiLineDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndMultiLine(double res, MultiLine multiLine)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, multiLine));
    }
    
    public static IEnumerable<object[]> ContourAndPolygonDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                1, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(2,2), new Point(2,3), new Point(3,3),
                            new Point(3,2), new Point(2,2))
                    },
                    new Point(1,1), new Point(1,4), new Point(4,4),
                    new Point(4,1), new Point(1,1))
            },
            new object[]
            {
                0, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(10,4), new Point(10,6), new Point(12,6),
                            new Point(12,4), new Point(10,4))
                    },
                    new Point(8,2), new Point(8,8), new Point(14,8),
                    new Point(14,2), new Point(8,2))
            }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndPolygonDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndPolygon(double res, Polygon polygon)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, polygon));
    }
    
    public static IEnumerable<object[]> ContourAndMultiPolygonDistanceInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                1, TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new Point(1,1), new Point(1,2), new Point(2,2),
                        new Point(2,1), new Point(1,1)),
		    
                    TestHelper.CreatePolygon(
                        new Point(1,3), new Point(1,4), new Point(2,4),
                        new Point(2,3), new Point(1,3)),
		    
                    TestHelper.CreatePolygon(
                        new Point(3,3), new Point(3,4), new Point(4,4),
                        new Point(4,3), new Point(3,3))
                )
            },
            new object[]
            {
                0, TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new Point(7,1), new Point(7,2), new Point(8,2),
                        new Point(8,1), new Point(7,1)),
		    
                    TestHelper.CreatePolygon(
                        new Point(7,3), new Point(7,4), new Point(8,4),
                        new Point(8,3), new Point(7,3)),
		    
                    TestHelper.CreatePolygon(
                        new Point(9,3), new Point(9,4), new Point(10,4),
                        new Point(10,3), new Point(9,3))
                    )
            }
        };
    
    [Theory]
    [MemberData(nameof(ContourAndMultiPolygonDistanceInsideTestData))]
    public static void GetDistanceInsideBetweenContourAndMultiPolygon(double res, MultiPolygon multiPolygon)
    {
        //Arrange
        var tests = new ContourDistanceInsideTests();
        //Act + Assert.
        Assert.Equal(res, ContourDistanceCalculator.GetDistanceInside(tests._contour, multiPolygon));
    }
}