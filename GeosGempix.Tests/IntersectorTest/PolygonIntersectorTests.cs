using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest;

public class PolygonIntersectorTests
{
    // Проверка на пересечение между полигоном и полигоном
    [Theory]
    [InlineData(true, new double[]{-4,-4,-4,13,13,13,13,-4}, new double[]{-1,-1,-1,10,10,10,10,-1})] //failed
    [InlineData(true, new double[]{7,3,7,6,15,6,15,3}, new double[]{10,4,10,5,14,5,14,4})]
    [InlineData(true, new double[]{9,3,9,6,14,6,14,3}, new double[]{9,3,9,6,11,6,11,3})]
    [InlineData(false, new double[]{11,0,11,9,20,9,20,0}, new double[]{14,3,14,6,17,6,17,3})]
    public void IsIntersectionPolygonAndPolygon(bool res, double[] a, double[] b)
    {
        //Arrange.
        var contour1 = TestHelper.CreateContour(
            new Point(b[0], b[1]),
            new Point(b[2], b[3]),
            new Point(b[4], b[5]),
            new Point(b[6], b[7]),
            new Point(b[0], b[1]));
			
        var contours1 = new List<Contour>{ contour1 };
			
        var polygon1 = TestHelper.CreatePolygon(
            contours1,
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]),
            new Point(a[6], a[7]),
            new Point(a[0], a[1]));
        
        var contour2 = TestHelper.CreateContour(
            new Point(3, 3),
            new Point(3, 6),
            new Point(6, 6),
            new Point(6, 3),
            new Point(3, 3));
			
        var contours2 = new List<Contour>{ contour2 };
			
        var polygon2 = TestHelper.CreatePolygon(
            contours2,
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res, polygon1.Intersects(polygon2));
    }
    
    // Проверка на пересечение между полигоном и мультиполигоном (True)
    [Theory]
    [InlineData(true, new double[]{8,13,8,16,15,16,15,13}, new double[]{12,14,12,15,14,15,14,14})]
    [InlineData(true, new double[]{12,3,12,6,15,6,15,3}, new double[]{13,4,13,5,14,5,14,4})] //failed
    public void IsIntersectionPolygonAndMultiPolygon_True(bool res, double[] a, double[] b)
    {
        //Arrange.
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
        
        //полигон 1
        var contour1 = TestHelper.CreateContour(
            new Point(11, 2),
            new Point(11,7),
            new Point(16,7),
            new Point(16,2),
            new Point(11,2));
			
        var contours1 = new List<Contour>{ contour1 };
			
        var polygon1 = TestHelper.CreatePolygon(
            contours1,
            new Point(0, 0),
            new Point(0, 9),
            new Point(18, 9),
            new Point(18, 0),
            new Point(0, 0));
			
        //полигон 2
        var contour2 = TestHelper.CreateContour(
            new Point(3, 14),
            new Point(3, 17),
            new Point(6, 17),
            new Point(6, 14),
            new Point(3, 14));
			
        var contours2 = new List<Contour>{ contour2 };
			
        var polygon2 = TestHelper.CreatePolygon(
            contours2,
            new Point(0, 11),
            new Point(0, 20),
            new Point(9, 20),
            new Point(9, 11),
            new Point(0, 11));

        var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2);
        
        //Act. + Assert.
        Assert.Equal(res, polygon.Intersects(multiPolygon));
    }
    
    // Проверка на пересечение между полигоном и мультиполигоном (False)
    [Theory]
    [InlineData(false, new double[]{11,0,11,9,20,9,20,0}, new double[]{14,3,14,6,17,6,17,3})]
    public void IsIntersectionPolygonAndMultiPolygon_False(bool res, double[] a, double[] b)
    {
        //Arrange.
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
        
        //полигон 1
        var contour1 = TestHelper.CreateContour(
            new Point(3, 3),
            new Point(3, 6),
            new Point(6, 6),
            new Point(6, 3),
            new Point(3, 3));
			
        var contours1 = new List<Contour>{ contour1 };
			
        var polygon1 = TestHelper.CreatePolygon(
            contours1,
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));
			
        //полигон 2
        var contour2 = TestHelper.CreateContour(
            new Point(25,3),
            new Point(25,6),
            new Point(28,6),
            new Point(28,3),
            new Point(25,3));
			
        var contours2 = new List<Contour>{ contour2 };
			
        var polygon2 = TestHelper.CreatePolygon(
            contours2,
            new Point(22,0),
            new Point(22,9),
            new Point(31,9),
            new Point(31,0),
            new Point(22,0));

        var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2);
        
        //Act. + Assert.
        Assert.Equal(res, polygon.Intersects(multiPolygon));
    }
}