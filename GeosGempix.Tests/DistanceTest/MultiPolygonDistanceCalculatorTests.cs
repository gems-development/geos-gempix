using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest;

public class MultiPolygonDistanceCalculatorTests
{
    // Проверка на растояние между мультиполигоном и мультиполигоном
    [Theory]
    [InlineData(0, 
        new double[]{18,3,18,6,21,6,21,3,19,4,19,5,20,5,20,4}, 
        new double[]{18,7,18,10,21,10,21,7,19,8,19,9,20,9,20,8}, 
        new double[]{22,7,22,10,25,10,25,7,23,8,23,9,24,9,24,8})]
    [InlineData(0, 
        new double[]{3,4,3,5,12,5,12,4,9,3.25,9,3.75,10,3.75,10,3.25}, 
        new double[]{3,13,3,15,5,15,5,13,3.5,13.5,3.5,14.5,4.5,14.5,4.5,13.5}, 
        new double[]{13,13,13,15,15,15,15,13,13.5,13.5,13.5,14.5,14.5,14.5,14.5,13.5})]
    [InlineData(2, 
        new double[]{10,3,10,6,13,6,13,3,11,4,11,5,12,5,12,4}, 
        new double[]{10,12,10,15,13,15,13,12,11,13,11,14,12,14,12,13}, 
        new double[]{14,3,14,6,17,6,17,3,15,4,15,5,16,5,16,4})]
    [InlineData(1, 
        new double[]{3,13,3,15,5,15,5,13,3.5,13.5,3.5,14.5,4.5,14.5,4.5,13.5}, 
        new double[]{10,1,10,4,13,4,13,1,11,2,11,3,12,3,12,2}, 
        new double[]{14,4,14,7,17,7,17,4,15,5,15,6,16,6,16,5})]
    public void GetDistanceBetweenMultiPolygonAndMultiPolygon_Success(double res, double[] a, double[] b, double[] c)
    {
        //Arrange.
        var multiPolygon1 = TestHelper.CreateMultiPolygon(
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(a[8], a[9]), new Point(a[10], a[11]), new Point(a[12], a[13]),
                        new Point(a[14], a[15]), new Point(a[8], a[9]))
                },
                new Point(a[0], a[1]), new Point(a[2], a[3]), new Point(a[4], a[5]),
                new Point(a[6], a[7]), new Point(a[0], a[1])),
            
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(b[8], b[9]), new Point(b[10], b[11]), new Point(b[12], b[13]),
                        new Point(b[14], b[15]), new Point(b[8], b[9]))
                },
                new Point(b[0], b[1]), new Point(b[2], b[3]), new Point(b[4], b[5]),
                new Point(b[6], b[7]), new Point(b[0], b[1])),
            
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(c[8], c[9]), new Point(c[10], c[11]), new Point(c[11], c[13]),
                        new Point(c[12], c[15]), new Point(c[8], c[9]))
                },
                new Point(c[0], c[1]), new Point(c[2], c[3]), new Point(c[4], c[5]),
                new Point(c[6], c[7]), new Point(c[0], c[1]))
        );

        var multiPolygon2 = TestHelper.CreateMultiPolygon(
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
        Assert.Equal(res,multiPolygon1.GetDistance(multiPolygon2));
    }
}