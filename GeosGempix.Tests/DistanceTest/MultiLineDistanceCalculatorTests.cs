using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest;

public class MultiLineDistanceCalculatorTests
{
    //Проверка на расстояние между мультилинией и мультилинией
    [Theory]
    [InlineData(0, new double[] {0, 3, 3, 3, 3, 3, 6, 3, 6, 3, 6, 0}, new double[] {1, 1, 4, 1, 4, 1, 7, 1, 7, 1, 7, 4})]
    [InlineData(0, new double[] {0, 0, 2, 0, 2, 0, 4, 0, 7, 0, 7, 2}, new double[] {0, 2, 2, 2, 2, 2, 4, 2, 6, 1, 8, 1})]
    [InlineData(0, new double[] {0, 0, 0, 2, 0, 0, 3, 0, 3, 0, 6, 0}, new double[] {0, 3, 3, 3, 3, 3, 6, 3, 6, 0, 6, 3})]
    [InlineData(3, new double[] {0, 3, 3, 3, 3, 3, 6, 3, 6, 3, 9, 3}, new double[] {2, 0, 5, 0, 5, 0, 8, 0, 8, 0, 11, 0})]
    [InlineData(5, new double[] {0, 3, 3, 3, 3, 0, 3, 3, 3, 3, 6, 3}, new double[] {10, 0, 13, 0, 13, 0, 13, 3, 13, 0, 16, 0})]
    [InlineData(2, new double[] {3, 0, 3, 3, 3, 3, 3, 6, 9, 1, 9, 4}, new double[] {0, 0, 0, 3, 0, 3, 0, 6, 7, 1, 7, 4})]
    public void GetDistanceBetweenMultiLineAndMultiLine(double res, double[] a, double[] b)
    {
        //Arrange.
        var multiLine1 = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(a[0], a[1], a[2], a[3]),
            TestHelper.CreateLine(a[4], a[5], a[6], a[7]),
            TestHelper.CreateLine(a[8], a[9], a[10], a[11]));
        
        var multiLine2 = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(b[0], b[1], b[2], b[3]),
            TestHelper.CreateLine(b[4], b[5], b[6], b[7]),
            TestHelper.CreateLine(b[8], b[9], b[10], b[11]));
        
        //Act. + Assert.
        Assert.Equal(res,multiLine1.GetDistance(multiLine2));
    }
    
    // Проверка на растояние между мультилинией и полигоном
    [Theory]
    [InlineData(0, new double[]{1, 3, 1, 5, 3, 7, 5, 7, 7, 3, 7, 5})]
    [InlineData(0, new double[]{5, 3, 5, 5, 7, 3, 7, 5, 9, 3, 9, 5})]
    [InlineData(0, new double[]{0, 3, 0, 5, 2, 3, 2, 5, 7, 3, 7, 5})]
    [InlineData(0, new double[]{3, 5, 3, 9, 4, 3, 4, 5, 10, 2, 10, 6})]
    [InlineData(0, new double[]{0, 0, 0, 8, 2, 2, 2, 6, 4, 3, 4, 5})]
    [InlineData(0, new double[]{0, 0, 0, 8, 2, 2, 2, 6, 6, 2, 6, 6})]
    [InlineData(0, new double[]{4, 3, 4, 5, 4, 6, 4, 8, 10, 3, 10, 6})]
    [InlineData(0, new double[]{-1, 4, 10, 4, 4, 3, 4, 5, 11, 2, 11, 6})]
    [InlineData(1, new double[]{3, 3, 3, 5, 4, 3, 4, 5, 5, 3, 5, 5})]
    [InlineData(5, new double[]{12, 11, 13, 11, 12, 11, 12, 12, 12, 12, 13, 12})]
    public void GetDistanceBetweenMultiLineAndPolygon(double res, double[] a)
    {
        //Arrange.
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(a[0], a[1], a[2], a[3]),
            TestHelper.CreateLine(a[4], a[5], a[6], a[7]),
            TestHelper.CreateLine(a[8], a[9], a[10], a[11]));
        
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
        Assert.Equal(res,multiLine.GetDistance(polygon));
    }
}