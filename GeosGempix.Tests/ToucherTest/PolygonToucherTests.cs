using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest;

public class PolygonToucherTests
{
    public static IEnumerable<object[]> PolygonAndPolygonToucherInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(6,6), new Point(6,8), new Point(8,8), 
                            new Point(8,6), new Point(6,6))
                    },
                    new Point(5, 5), new Point(5, 9), new Point(9, 9), 
                    new Point(9, 5), new Point(5, 5)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,7), new Point(7,3), new Point(11,7), 
                            new Point(7,11), new Point(3,7))
                    },
                    new Point(0,7), new Point(7,0), new Point(14,7), 
                    new Point(7,14), new Point(0,7))
            }
        };
    
    [Theory]
    [MemberData(nameof(PolygonAndPolygonToucherInsideTestData))]
    public static void IsPolygonTouchingPolygon_Inside(Polygon polygon1, Polygon polygon2)
    {
        //Act + Assert.
        Assert.True(polygon1.IsTouching(polygon2));
    }
    
    public static IEnumerable<object[]> PolygonAndMultiPolygonToucherInsideTestData =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(6,6), new Point(6,8), new Point(8,8), 
                            new Point(8,6), new Point(6,6))
                    },
                    new Point(5, 5), new Point(5, 9), new Point(9, 9), 
                    new Point(9, 5), new Point(5, 5)),
                
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,7), new Point(7,3), new Point(11,7), 
                                new Point(7,11), new Point(3,7))
                        },
                        new Point(0,7), new Point(7,0), new Point(14,7), 
                        new Point(7,14), new Point(0,7)),
		    
                    TestHelper.CreatePolygon(
                        new Point(17,3), new Point(20,6), new Point(23,3),
                        new Point(20,0), new Point(17,3)),
		    
                    TestHelper.CreatePolygon(
                        new Point(17,12), new Point(20,15), new Point(23,12),
                        new Point(20,9), new Point(17,12))
                )
            }
        };
    
    [Theory]
    [MemberData(nameof(PolygonAndMultiPolygonToucherInsideTestData))]
    public static void IsPolygonTouchingMultiPolygon_Inside(Polygon polygon, MultiPolygon multiPolygon)
    {
        //Act + Assert.
        Assert.True(polygon.IsTouching(multiPolygon));
    }
}