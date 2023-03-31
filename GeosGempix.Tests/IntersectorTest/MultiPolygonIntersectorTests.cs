using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest;

public class MultiPolygonIntersectorTests
{
    // Проверка на пересечение между мультиполигоном и мультиполигоном
    [Theory]
    [InlineData(true, //failed
        new double[]{0,0,0,9,18,9,18,0,11,2,11,7,16,7,16,2}, 
        new double[]{0,11,0,20,9,20,9,11,3,14,3,17,6,17,6,14},
        new double[]{12,3,12,6,15,6,15,3,13,4,13,5,14,5,14,4},
        new double[]{11,13,11,16,15,16,15,13,12,14,12,15,14,15,14,14})]
    [InlineData(true,
        new double[]{0,0,0,9,9,9,9,0,3,3,3,6,6,6,6,3}, 
        new double[]{0,11,0,20,9,20,9,11,3,14,3,17,6,17,6,14},
        new double[]{11,0,11,9,20,9,20,0,14,3,14,6,17,6,17,3},
        new double[]{9,13,9,16,15,16,15,13,12,14,12,15,14,15,14,14})]
    [InlineData(false,
        new double[]{0,0,0,9,9,9,9,0,3,3,3,6,6,6,6,3}, 
        new double[]{22,0,22,9,31,9,31,0,25,3,25,6,28,6,28,3},
        new double[]{11,0,11,9,20,9,20,0,14,3,14,6,17,6,17,3},
        new double[]{33,0,33,9,42,9,42,0,36,3,36,6,39,6,39,3})]
    public void IsIntersectionMultiPolygonAndMultiPolygon(bool res, double[] a, double[] b, double[] c, double[] d)
    {
        /* Мультиполигон 1 */
        //полигон 1
        var contour1 = TestHelper.CreateContour(
            new Point(a[8], a[9]),
            new Point(a[10], a[11]),
            new Point(a[12], a[13]),
            new Point(a[14], a[15]),
            new Point(a[8], a[9]));
            
        var contours1 = new List<Contour>{ contour1 };
            
        var polygon1 = TestHelper.CreatePolygon(
            contours1,
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]),
            new Point(a[6], a[7]),
            new Point(a[0], a[1]));
            
        //полигон 2
        var contour2 = TestHelper.CreateContour(
            new Point(b[8], b[9]),
            new Point(b[10], b[11]),
            new Point(b[12], b[13]),
            new Point(b[14], b[15]),
            new Point(b[8], b[9]));
            
        var contours2 = new List<Contour>{ contour2 };
            
        var polygon2 = TestHelper.CreatePolygon(
            contours2,
            new Point(b[0], b[1]),
            new Point(b[2], b[3]),
            new Point(b[4], b[5]),
            new Point(b[6], b[7]),
            new Point(b[0], b[1]));
        
        var multiPolygon1 = TestHelper.CreateMultiPolygon(polygon1, polygon2);
        
        /* Мультиполигон 2 */
        //полигон 1
        var contour3 = TestHelper.CreateContour(
            new Point(c[8], c[9]),
            new Point(c[10], c[11]),
            new Point(c[12], c[13]),
            new Point(c[14], c[15]),
            new Point(c[8], c[9]));
            
        var contours3 = new List<Contour>{ contour3 };
            
        var polygon3 = TestHelper.CreatePolygon(
            contours3,
            new Point(c[0], c[1]),
            new Point(c[2], c[3]),
            new Point(c[4], c[5]),
            new Point(c[6], c[7]),
            new Point(c[0], c[1]));
            
        //полигон 2
        var contour4 = TestHelper.CreateContour(
            new Point(d[8], d[9]),
            new Point(d[10], d[11]),
            new Point(d[12], d[13]),
            new Point(d[14], d[15]),
            new Point(d[8], d[9]));
            
        var contours4 = new List<Contour>{ contour4 };
            
        var polygon4 = TestHelper.CreatePolygon(
            contours4,
            new Point(d[0], d[1]),
            new Point(d[2], d[3]),
            new Point(d[4], d[5]),
            new Point(d[6], d[7]),
            new Point(d[0], d[1]));
        
        var multiPolygon2 = TestHelper.CreateMultiPolygon(polygon3, polygon4);
        
        //Act. + Assert.
        Assert.Equal(res, multiPolygon1.Intersects(multiPolygon2));
    }
}