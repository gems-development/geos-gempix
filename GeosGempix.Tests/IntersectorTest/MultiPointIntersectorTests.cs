using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest;

public class MultiPointIntersectorTests
{
    // Проверка на пересечение между мультиточкой и мультиточкой
    [Theory]
    [InlineData(true, new double[]{6,5,6,6,7,5})]
    [InlineData(false, new double[]{5,5,7,6,6,3})]
    public void IsIntersectionMultiPointAndMultiPoint(bool res, double[] b)
    {
        //Arrange.
        var multiPoint1 = TestHelper.CreateMultiPoint(
            new Point(b[0],b[1]),
            new Point(b[2],b[3]),
            new Point(b[4],b[5]));
        
        var multiPoint2 = TestHelper.CreateMultiPoint(
            new Point(4,4),
            new Point(5,6),
            new Point(6,5));
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint1.Intersects(multiPoint2));
    }
    
    // Проверка на пересечение между мультиточкой и мультилинией
    [Theory]
    [InlineData(true, new double[]{4,4,5,6,6,5})]
    [InlineData(false, new double[]{4,3,4,5,6,3})]
    public void IsIntersectionMultiPointAndMultiLine(bool res, double[] b)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(b[0],b[1]),
            new Point(b[2],b[3]),
            new Point(b[4],b[5]));
        
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(3,1,7,2),
            TestHelper.CreateLine(2,4,7,4),
            TestHelper.CreateLine(4,8,5,5));
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.Intersects(multiLine));
    }
    
    // Проверка на пересечение между мультиточкой и полигоном
    [Theory]
    [InlineData(true, new double[]{4,4,4,11,10,4})] //failed
    [InlineData(true, new double[]{0,0,4,8,7,5})]
    [InlineData(false, new double[]{-1,5,4,11,10,2})]
    public void IsIntersectionMultiPointAndPolygon(bool res, double[] b)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(b[0],b[1]),
            new Point(b[2],b[3]),
            new Point(b[4],b[5]));
        
        var contour = TestHelper.CreateContour(
            new Point(3, 3),
            new Point(3, 6),
            new Point(6, 6),
            new Point(6, 3),
            new Point(3, 3));
			
        var contours = new List<Contour>{ contour };
			
        var polygon = TestHelper.CreatePolygon(
            contours,
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.Intersects(polygon));
    }
    
    // Проверка на пересечение между мультиточкой и мультиполигоном
    [Theory]
    [InlineData(true, new double[]{4,15,10,16,10,15})] //failed
    [InlineData(true, new double[]{14,16,15,19,21,15})]
    [InlineData(false, new double[]{4,10,10,15,21,16})]
    public void IsIntersectionMultiPointAndMultiPolygon(bool res, double[] b)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(b[0],b[1]),
            new Point(b[2],b[3]),
            new Point(b[4],b[5]));

        //полигон 1
        var contour1 = TestHelper.CreateContour(
            new Point(3, 14),
            new Point(3, 17),
            new Point(6, 17),
            new Point(6, 14),
            new Point(3, 14));
			
        var contours1 = new List<Contour>{ contour1 };
			
        var polygon1 = TestHelper.CreatePolygon(
            contours1,
            new Point(0, 11),
            new Point(0, 20),
            new Point(9, 20),
            new Point(9, 11),
            new Point(0, 11));
			
        //полигон 2
        var contour2 = TestHelper.CreateContour(
            new Point(14,14),
            new Point(14,17),
            new Point(17,17),
            new Point(17,14),
            new Point(14,14));
			
        var contours2 = new List<Contour>{ contour2 };
			
        var polygon2 = TestHelper.CreatePolygon(
            contours2,
            new Point(11,11),
            new Point(11,20),
            new Point(20,20),
            new Point(20,11),
            new Point(11,11));
			
        var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2);
        
        //Act. + Assert.
        Assert.Equal(res,multiPoint.Intersects(multiPolygon));
    }
}