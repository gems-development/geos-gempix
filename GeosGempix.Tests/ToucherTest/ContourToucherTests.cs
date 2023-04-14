using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest;

public class ContourToucherTests
{
    [Theory]
    [InlineData(true, new double[] {5,0,5,5,8,3,10,5,10,0})]
    [InlineData(true, new double[] {0,5,0,10,3,8,5,10,5,5})]
    [InlineData(true, new double[] {5,3,5,8,8,5,10,8,10,3})]
    public static void IsContourTouchingContour_Success(bool res, double[] a)
    {
        //Arrange.
        var contour1 = TestHelper.CreateContour(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]),
            new Point(a[6], a[7]),
            new Point(a[8], a[9]),
            new Point(a[0], a[1]));
        
        var contour2 = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 5),
            new Point(3, 3),
            new Point(5, 5),
            new Point(5, 0),
            new Point(0, 0));
        
        //Act + Assert.
        Assert.Equal(res, contour1.IsTouching(contour2));
    }

    [Fact]
    public static void IsContourTouchingContour_Failed()
    {
        //Arrange.
        var contour1 = TestHelper.CreateContour(
            new Point(0,3),
            new Point(0,8),
            new Point(5,8),
            new Point(5,3),
            new Point(0,3));
        
        var contour2 = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 5),
            new Point(3, 3),
            new Point(5, 5),
            new Point(5, 0),
            new Point(0, 0));
        
        var contour3 = TestHelper.CreateContour(
            new Point(0,0),
            new Point(0,8),
            new Point(8,8),
            new Point(8,0),
            new Point(0,0));
        
        var contour4 = TestHelper.CreateContour(
            new Point(0,2),
            new Point(0,5),
            new Point(5,5),
            new Point(5,2),
            new Point(0,2));
        
        //Act + Assert.
        Assert.False(contour2.IsTouching(contour1));
        Assert.False(contour3.IsTouching(contour4));
    }

    [Theory]
    [InlineData(true, new double[]{-2,-2,-2,7,7,7,7,-2}, new double[]{0,0,0,5,5,5,5,0})]
    public static void IsContourTouchingPolygon1(bool res, double[] a, double[] b)
    {
        //Arrange.
        var contour0 = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 5),
            new Point(3, 3),
            new Point(5, 5),
            new Point(5, 0),
            new Point(0, 0));
        
        var contour = TestHelper.CreateContour(
            new Point(b[0], b[1]),
            new Point(b[2], b[3]),
            new Point(b[4], b[5]),
            new Point(b[6], b[7]),
            new Point(b[0], b[1]));
			
        var contours = new List<Contour>{ contour };
			
        var polygon = TestHelper.CreatePolygon(
            contours,
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]),
            new Point(a[6], a[7]),
            new Point(a[0], a[1]));
        
        //Act + Assert.
        Assert.Equal(res, contour0.IsTouching(polygon));
    }

    [Fact]
    public static void IsContourTouchingPolygon2()
    {
        //Arrange.
        var contour0 = TestHelper.CreateContour(
            new Point(5, 5),
            new Point(5, 9),
            new Point(9, 9),
            new Point(9, 5),
            new Point(5, 5));
        
        var contour = TestHelper.CreateContour(
            new Point(3,7),
            new Point(7,3),
            new Point(11,7),
            new Point(7,11),
            new Point(3,7));
			
        var contours = new List<Contour>{ contour };
			
        var polygon = TestHelper.CreatePolygon(
            contours,
            new Point(0,7),
            new Point(7,0),
            new Point(14,7),
            new Point(7,14),
            new Point(0,7));
        
        //Act + Assert.
        Assert.True(contour0.IsTouching(polygon));
    }
}