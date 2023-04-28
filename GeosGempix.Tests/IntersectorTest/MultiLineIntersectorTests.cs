using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest;

public class MultiLineIntersectorTests
{
    // Проверка на пересечение между мультилинией и мультилинией
    [Theory]
    [InlineData(true, new double[]{3,3,7,3,3,6,7,7,8,7,9,3})]
    [InlineData(true, new double[]{2,1,4,3,2,5,2,7,4,4,5,4})] //failed
    [InlineData(false, new double[]{3,3,7,3,2,5,2,7,8,7,9,3})]
    public void IsIntersectionMultiLineAndMultiLine(bool res, double[] a)
    {
        //Arrange.
        var multiLine1 = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(3,1,7,2),
            TestHelper.CreateLine(2,4,7,4),
            TestHelper.CreateLine(4,8,5,5));
        
        var multiLine2 = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(a[0],a[1],a[2],a[3]),
            TestHelper.CreateLine(a[4],a[5],a[6],a[7]),
            TestHelper.CreateLine(a[8],a[9],a[10],a[11]));
        
        //Act. + Assert.
        Assert.Equal(res,multiLine1.Intersects(multiLine2));
    }
    
    // Проверка на пересечение между мультилинией и полигоном
    [Theory]
    [InlineData(true, new double[]{-1,5,-1,8,4,5,5,4,10,2,10,5})] //failed
    [InlineData(true, new double[]{-1,5,-1,8,8,5,10,5,10,1,11,4})]
    [InlineData(false, new double[]{-1,5,-1,8,10,2,10,5,10,1,11,4})]
    public void IsIntersectionMultiLineAndPolygon(bool res, double[] a)
    {
        //Arrange.
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(a[0],a[1],a[2],a[3]),
            TestHelper.CreateLine(a[4],a[5],a[6],a[7]),
            TestHelper.CreateLine(a[8],a[9],a[10],a[11]));

        var polygon = TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(3, 3), new Point(3, 6), new Point(6, 6),
                    new Point(6, 3), new Point(3, 3))
            },
            new Point(0, 0), new Point(0, 9), new Point(9, 9),
            new Point(9, 0), new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res,multiLine.Intersects(polygon));
    }
    
    // Проверка на пересечение между мультилинией и мультиполигоном
    [Theory]
    [InlineData(true, new double[]{4,15,5,16,14,19,17,19,9,5,11,6})]
    [InlineData(false, new double[]{-1,9,-1,11,10,14,10,17,13,4,16,7})]
    public void IsIntersectionMultiLineAndMultiPolygon(bool res, double[] a)
    {
        //Arrange.
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(a[0],a[1],a[2],a[3]),
            TestHelper.CreateLine(a[4],a[5],a[6],a[7]),
            TestHelper.CreateLine(a[8],a[9],a[10],a[11]));

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
                        new Point(3, 14), new Point(3, 17), new Point(6, 17),
                        new Point(6, 14), new Point(3, 14))
                },
                new Point(0, 11), new Point(0, 20), new Point(9, 20),
                new Point(9, 11), new Point(0, 11)),
            
            TestHelper.CreatePolygon(
                new List<Contour>
                {
                    TestHelper.CreateContour(
                        new Point(14,14), new Point(14,17), new Point(17,17),
                        new Point(17,14), new Point(14,14))
                },
                new Point(11,11), new Point(11,20), new Point(20,20),
                new Point(20,11), new Point(11,11))
        );
        
        //Act. + Assert.
        Assert.Equal(res,multiLine.Intersects(multiPolygon));
    }
}