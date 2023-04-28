using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest;

public class MultiPointDistanceCalculatorTests
{
    //Проверка на расстояние между мультиточкой и мультиточкой
    [Theory]
    [InlineData(0, new double[] {0, 0, 2, 2, 4, 0}, new double[] {0, 0, 2, 2, 4, 0})]
    [InlineData(0, new double[] {0, 0, 2, 2, 4, 0}, new double[] {4, 0, 6, 2, 8, 0})]
    [InlineData(0, new double[] {0, 0, 2, 2, 4, 0}, new double[] {2, 2, 4, 0, 6, 2})]
    [InlineData(5, new double[] {0, 0, 2, 2, 4, 0}, new double[] {6, 5, 7, 5, 8, 5})]
    [InlineData(1, new double[] {0, 0, 6, 7, 14, 0}, new double[] {2, 2, 6, 6, 10, 0})]
    public void GetDistanceBetweenMultiPointAndMultiPoint(double res, double[] a, double[] b)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]));
        
        var multiPoint1 = TestHelper.CreateMultiPoint(
            new Point(b[0], b[1]),
            new Point(b[2], b[3]),
            new Point(b[4], b[5]));

        //Act. + Assert.
        Assert.Equal(res,multiPoint.GetDistance(multiPoint1));
    }
    
    //Проверка на расстояние между мультиточкой и мультилинией
    [Theory]
    [InlineData(0, new double[] {0, 3, 1, 0, 2, 3}, new double[] {2, 0, 2, 3, 3, 3, 5, 3, 6, 0, 6, 2})]
    [InlineData(0, new double[] {0, 3, 1, 0, 2, 3}, new double[] {2, 1, 2, 4, 3, 4, 5, 4, 6, 1, 6, 3})]
    [InlineData(1, new double[] {0, 3, 1, 0, 3, 3}, new double[] {2, 2, 2, 4, 5, 4, 7, 4, 8, 2, 8, 4})]
    [InlineData(5, new double[] {0, 2, 1, 0, 2, 2}, new double[] {6, 5, 6, 7, 7, 5, 9, 5, 10, 5, 10, 7})]
    [InlineData(1, new double[] {2, 0, 3, 3, 4, 0}, new double[] {0, 2, 0, 4, 1, 2, 4, 2, 5, 2, 5, 4})]
    public void GetDistanceBetweenMultiPointAndMultiLine(double res, double[] a, double[] b)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]));
        
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(b[0], b[1], b[2], b[3]),
            TestHelper.CreateLine(b[4], b[5], b[6], b[7]),
            TestHelper.CreateLine(b[8], b[9], b[10], b[11]));
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.GetDistance(multiLine));
    }
    
    // Проверка на растояние между мультиточкой и полигоном
    public static IEnumerable<object[]> Data0 =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 15), new Point(8, 14), new Point(9, 15)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,13), new Point(3,16), new Point(6,16),
                            new Point(6,13), new Point(3,13))
                    },
                    new Point(0,10), new Point(0,19), new Point(9,19),
                    new Point(9,10), new Point(0,10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4,6), new Point(4,7), new Point(5,7)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 14), new Point(8, 14), new Point(10, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(15, 15), new Point(17, 17), new Point(17, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4, 0), new Point(4, 3), new Point(4, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 8), new Point(7, 9), new Point(9, 15)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(13, 14), new Point(17, 14), new Point(20, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4, 4), new Point(6, 4), new Point(9, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(1, 14), new Point(3, 14), new Point(5, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(14, 14), new Point(17, 14), new Point(19, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4, 4), new Point(9, 4), new Point(10, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(6, 15), new Point(7, 14), new Point(9, 13)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(16, 15), new Point(17, 14), new Point(20, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 5), new Point(9, 4), new Point(10, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(16, 15), new Point(19, 14), new Point(20, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
        };
    
    [Theory]
    [MemberData(nameof(Data0))]
    public void GetDistanceBetweenMultiPointAndPolygon_LieOn(MultiPoint multiPoint, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(0,multiPoint.GetDistance(polygon));
    }
    
    // Проверка на растояние между мультиточкой и полигоном
    [Theory]
    [InlineData(1, new double[]{4, 4, 4, 5, 5, 5})] //failed
    [InlineData(5, new double[]{12, 11, 13, 12, 13, 11})]
    [InlineData(3, new double[]{11, 5, 12, 4, 13, 5})]
    [InlineData(1, new double[]{5, 9, 11, 6, 11, 0})]
    public void GetDistanceBetweenMultiPointAndPolygon_DontLieOn(double res, double[] a)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]));

        var polygon = TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2, 2), new Point(2, 6), new Point(6, 6),
                    new Point(6, 2), new Point(2, 2))
            },
            new Point(0, 0), new Point(0, 8), new Point(8, 8),
            new Point(8, 0), new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.GetDistance(polygon));
    }
    
    // Проверка на растояние между мультиточкой и мультиполигоном
    [Theory]
    [InlineData(0, new double[] {7, 15, 8, 14, 9, 15})] 
    [InlineData(0, new double[] {4, 8, 7, 14, 15, 12})]
    [InlineData(0, new double[] {4, 7, 4, 6, 5, 7})]
    [InlineData(0, new double[] {7, 14, 8, 14, 10, 14})]
    [InlineData(0, new double[] {15, 15, 17, 17, 17, 14})]
    [InlineData(0, new double[] {4, 0, 4, 3, 4, 4})]
    [InlineData(0, new double[] {7, 8, 7, 9, 9, 15})]
    [InlineData(0, new double[] {13, 14, 17, 14, 20, 14})]
    [InlineData(0, new double[] {1, 14, 3, 14, 5, 14})]
    [InlineData(0, new double[] {4, 4, 6, 4, 9, 4})]
    [InlineData(0, new double[] {14, 14, 17, 14, 19, 14})]
    [InlineData(0, new double[] {4, 4, 9, 4, 10, 4})]
    [InlineData(0, new double[] {6, 15, 7, 14, 9, 13})]
    [InlineData(0, new double[] {16, 15, 17, 14, 20, 14})]
    [InlineData(0, new double[] {7, 5, 9, 4, 10, 4})]
    [InlineData(0, new double[] {16, 15, 19, 14, 20, 14})]
    public void GetDistanceBetweenMultiPointAndMultiPolygon_LieOn(double res, double[] a)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]));

        var multiPolygon = TestHelper.CreateMultiPolygon(
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
                        new Point(3, 13), new Point(3, 16), new Point(6, 16),
                        new Point(6, 13), new Point(3, 13))
                },
                new Point(0, 10), new Point(0, 19), new Point(9, 19),
                new Point(9, 10), new Point(0, 10)),
            
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(13, 13), new Point(13, 16), new Point(16, 16),
                        new Point(16, 13), new Point(13, 13))
                },
                new Point(10, 10), new Point(10, 19), new Point(19, 19),
                new Point(19, 10), new Point(10, 10))
        );
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.GetDistance(multiPolygon));
    }

    // Проверка на растояние между мультиточкой и мультиполигоном
    [Theory]
    [InlineData(5, new double[] {21, 4, 21, 6, 22, 5})] 
    [InlineData(1, new double[] {4, 4, 3, 15, 14, 14})]
    [InlineData(1, new double[] {7, 9, 10, 5, 12, 7})] 
    [InlineData(1, new double[] {4, 4, 10, 5, 12, 9})] 
    public void GetDistanceBetweenMultiPointAndMultiPolygon_DontLieOn(double res, double[] a)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]));
        
        var multiPolygon = TestHelper.CreateMultiPolygon(
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(2, 2), new Point(2, 6), new Point(6, 6),
                        new Point(6, 2), new Point(2, 2))
                },
                new Point(0, 0), new Point(0, 8), new Point(8, 8),
                new Point(8, 0), new Point(0, 0)),
            
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(2, 12), new Point(2, 16), new Point(6, 16),
                        new Point(6, 12), new Point(2, 12))
                },
                new Point(0, 10), new Point(0, 18), new Point(8, 18),
                new Point(8, 10), new Point(0, 10)),
            
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(12, 12), new Point(12, 16), new Point(16, 16),
                        new Point(16, 12), new Point(12, 12))
                },
                new Point(10, 10), new Point(10, 18), new Point(18, 18),
                new Point(18, 10), new Point(10, 10))
        );
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.GetDistance(multiPolygon));
    }
}