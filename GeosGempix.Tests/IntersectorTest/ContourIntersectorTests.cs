using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.IntersectorTest;

public class ContourIntersectorTests
{
    private Contour _contour;
    private Polygon _polygon;
    private MultiPolygon _multiPolygon;
    
    public ContourIntersectorTests()
    {
        _contour = TestHelper.CreateContour(
            new Point(0, 0), new Point(0, 9), new Point(9, 9),
            new Point(9, 0), new Point(0, 0));
        
        _polygon = TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(3, 3), new Point(3, 6), new Point(6, 6),
                    new Point(6, 3), new Point(3, 3))
            },
            new Point(0, 0), new Point(0, 9), new Point(9, 9),
            new Point(9, 0), new Point(0, 0));

        _multiPolygon = TestHelper.CreateMultiPolygon(
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(3, 3), new Point(3, 6), new Point(6, 6),
                        new Point(6, 3), new Point(3, 3))
                },
                new Point(0, 0), new Point(0, 9), new Point(9, 9),
                new Point(9, 0), new Point(0, 0)),

            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(3, 14), new Point(3, 17), new Point(6, 17),
                        new Point(6, 14), new Point(3, 14))
                },
                new Point(0, 11), new Point(0, 20), new Point(9, 20),
                new Point(9, 11), new Point(0, 11)),

            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(14, 14), new Point(14, 17), new Point(17, 17),
                        new Point(17, 14), new Point(14, 14))
                },
                new Point(11, 11), new Point(11, 20), new Point(20, 20),
                new Point(20, 11), new Point(11, 11))
        );
    }
    
    // Проверка на пересечение между контуром и контуром
    public static IEnumerable<object[]> Data0 =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2,12), new Point(12,12),
                    new Point(12,2), new Point(2,2))
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(9,0), new Point(9,9), new Point(18,9),
                    new Point(18,0), new Point(9,0))
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2,7), new Point(7,7),
                    new Point(7,2), new Point(2,2))
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(11,0), new Point(11,9), new Point(20,9),
                    new Point(20,0), new Point(11,0))
            }
        };
    
    [Theory]
    [MemberData(nameof(Data0))]
    public void IsIntersectionContourAndContour(bool res, Contour contour)
    {
        //Arrange.
        var tests = new ContourIntersectorTests();
        //Act. + Assert.
        Assert.Equal(res,tests._contour.Intersects(contour));
    }

    // Проверка на пересечение между контуром и мультиточкой
    public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateMultiPoint(
                    new Point(5,5),
                    new Point(6,7),
                    new Point(7,6))
            },
            new object[]
            {
                true,
                TestHelper.CreateMultiPoint(
                    new Point(8,6),
                    new Point(10,7),
                    new Point(10,5))
            },
            new object[]
            {
                true,
                TestHelper.CreateMultiPoint(
                    new Point(9,0),
                    new Point(10,2),
                    new Point(11,1))
            },
            new object[]
            {
                false,
                TestHelper.CreateMultiPoint(
                    new Point(11,4),
                    new Point(12,7),
                    new Point(14,5))
            }
        };
    
    [Theory]
    [MemberData(nameof(Data1))]
    public void IsIntersectionContourAndMultiPoint(bool res, MultiPoint multiPoint)
    {
        //Arrange.
        var tests = new ContourIntersectorTests();
        //Act. + Assert.
        Assert.Equal(res,tests._contour.Intersects(multiPoint));
    }

    // Проверка на пересечение между контуром и мультилинией
    public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2),
                    TestHelper.CreateLine(2,4,7,4),
                    TestHelper.CreateLine(4,8,5,5))
            },
            new object[]
            {
                true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(10,2,13,3),
                    TestHelper.CreateLine(9,4,12,4),
                    TestHelper.CreateLine(11,8,12,5))
            },
            new object[]
            {
                true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(7,4,8,7),
                    TestHelper.CreateLine(10,6,13,5),
                    TestHelper.CreateLine(11,4,12,3))
            },
            new object[]
            {
                false,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(10,3,12,2),
                    TestHelper.CreateLine(11,4,14,5),
                    TestHelper.CreateLine(12,8,13,5))
            }
        };
    
    [Theory]
    [MemberData(nameof(Data2))]
    public void IsIntersectionContourAndMultiLine(bool res, MultiLine multiLine)
    {
        //Arrange.
        var tests = new ContourIntersectorTests();
        //Act. + Assert.
        Assert.Equal(res,tests._contour.Intersects(multiLine));
    }
    
    // Проверка на пересечение между контуром и полигоном
    public static IEnumerable<object[]> Data3 =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2,11), new Point(11,11),
                    new Point(11,2), new Point(2,2))
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(4,4), new Point(4,5), new Point(5,5),
                    new Point(5,4), new Point(4,4))
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(9,0), new Point(9,9), new Point(18,9),
                    new Point(18,0), new Point(9,0))
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(11,0), new Point(11,9), new Point(20,9),
                    new Point(20,0), new Point(11,0))
            }
        };
    
    [Theory]
    [MemberData(nameof(Data3))]
    public void IsIntersectionContourAndPolygon(bool res, Contour contour)
    {
        //Arrange.
        var tests = new ContourIntersectorTests();
        //Act. + Assert.
        Assert.Equal(res,contour.Intersects(tests._polygon));
    }
    
    // Проверка на пересечение между контуром и мультиполигоном
    public static IEnumerable<object[]> Data4 =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(8,13), new Point(8,18), new Point(12,18),
                    new Point(12,13), new Point(8,13))
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(20,9), new Point(20,11), new Point(23,11),
                    new Point(23,9), new Point(20,9))
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(4,4), new Point(4,5), new Point(5,5),
                    new Point(5,4), new Point(4,4))
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(10,13), new Point(10,18), new Point(12,18),
                    new Point(12,13), new Point(10,13))
            }
        };
    
    [Theory]
    [MemberData(nameof(Data4))]
    public void IsIntersectionContourAndMultiPolygon(bool res, Contour contour)
    {
        //Arrange.
        var tests = new ContourIntersectorTests();
        //Act. + Assert.
        Assert.Equal(res,contour.Intersects(tests._multiPolygon));
    }
}