using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest;

public class ContourToucherTests
{
    public static IEnumerable<object[]> Data0 =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateContour(
                    new Point(0, 5), new Point(0, 10),
                    new Point(3, 8), new Point(5, 10),
                    new Point(5, 5), new Point(0, 5))
            },
            
            new object[]
            {
                TestHelper.CreateContour(
                    new Point(5, 0), new Point(5, 5),
                    new Point(8, 3), new Point(10, 5),
                    new Point(10, 0), new Point(5, 0))
            },
            
            new object[]
            {
                TestHelper.CreateContour(
                    new Point(5, 3), new Point(5, 8),
                    new Point(8, 5), new Point(10, 8),
                    new Point(10, 3), new Point(5, 3))
            }
        };

    [Theory]
    [MemberData(nameof(Data0))]
    public static void IsContourTouchingContour_Success(Contour contour2)
    {
        //Arrange
        var contour1 = TestHelper.CreateContour(
            new Point(0, 0), new Point(0, 5),
            new Point(3, 3), new Point(5, 5),
            new Point(5, 0), new Point(0, 0));
        //Act + Assert.
        Assert.True(contour2.IsTouching(contour1));
    }

    public static IEnumerable<object[]> Data1 =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateContour(
                    new Point(0,3), new Point(0,8), new Point(5,8), 
                    new Point(5,3), new Point(0,3)),
                
                TestHelper.CreateContour(
                    new Point(0, 0), new Point(0, 5),
                    new Point(3, 3), new Point(5, 5),
                    new Point(5, 0), new Point(0, 0))
            }
        };
    
    [Theory]
    [MemberData(nameof(Data1))]
    public static void IsContourTouchingContour_Failed(Contour contour1, Contour contour2)
    {
        //Act + Assert.
        Assert.False(contour2.IsTouching(contour1));
    }
    
    public static IEnumerable<object[]> Data2 =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateContour(
                    new Point(0, 0), new Point(0, 5),
                    new Point(3, 3), new Point(5, 5),
                    new Point(5, 0), new Point(0, 0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(0,0), new Point(0,5), new Point(5,5), 
                            new Point(5,0), new Point(0,0))
                    },
                    new Point(-2,-2), new Point(-2,7), new Point(7,7), 
                    new Point(7,-2), new Point(-2,-2))
            },
            
            new object[]
            {
                TestHelper.CreateContour(
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
    [MemberData(nameof(Data2))]
    public static void IsContourTouchingPolygon(Contour contour, Polygon polygon)
    {
        //Act + Assert.
        Assert.True(contour.IsTouching(polygon));
    }
}