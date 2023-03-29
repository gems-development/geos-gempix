using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest;

public class ContourIntersectorTests
{
    // Проверка на пересечение между контуром и контуром
    [Theory]
    [InlineData(true, new double[]{2,2,2,12,12,12,12,2})]
    [InlineData(true, new double[]{9,0,9,9,18,9,18,0})]
    [InlineData(true, new double[]{2,2,2,7,7,7,7,2})] //failed
    [InlineData(false, new double[]{11,0,11,9,20,9,20,0})]
    public void IsIntersectionContourAndContour(bool res, double[] a)
    {
        //Arrange.
        var contour1 = TestHelper.CreateContour(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]),
            new Point(a[6], a[7]),
            new Point(a[0], a[1]));
        
        var contour2 = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res,contour1.Intersects(contour2));
    }
    
    // Проверка на пересечение между контуром и мультиточкой
    [Theory]
    [InlineData(true, new double[]{5,5,6,7,7,6})] //failed
    [InlineData(true, new double[]{8,6,10,7,10,5})] //failed
    [InlineData(true, new double[]{9,0,10,2,11,1})]
    [InlineData(false, new double[]{11,4,12,7,14,5})]
    public void IsIntersectionContourAndMultiPoint(bool res, double[] b)
    {
        //Arrange.
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(b[0],b[1]),
            new Point(b[2],b[3]),
            new Point(b[4],b[5]));
        
        var contour = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res,contour.Intersects(multiPoint));
    }
    
    // Проверка на пересечение между контуром и мультилинией
    [Theory]
    [InlineData(true, new double[]{3,1,7,2,2,4,7,4,4,8,5,5})] //failed
    [InlineData(true, new double[]{10,2,13,3,9,4,12,4,11,8,12,5})]
    [InlineData(true, new double[]{7,4,8,7,10,6,13,5,11,4,12,3})] //failed
    [InlineData(false, new double[]{10,3,12,2,11,4,14,5,12,8,13,5})]
    public void IsIntersectionContourAndMultiLine(bool res, double[] a)
    {
        //Arrange.
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(a[0],a[1],a[2],a[3]),
            TestHelper.CreateLine(a[4],a[5],a[6],a[7]),
            TestHelper.CreateLine(a[8],a[9],a[10],a[11]));
        
        var contour = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));
        
        //Act. + Assert.
        Assert.Equal(res,contour.Intersects(multiLine));
    }
    
    // Проверка на пересечение между контуром и полигоном
    [Theory]
    [InlineData(true, new double[]{2,2,2,11,11,11,11,2})]
    [InlineData(true, new double[]{4,4,4,5,5,5,5,4})] //failed
    [InlineData(true, new double[]{9,0,9,9,18,9,18,0})]
    [InlineData(false, new double[]{11,0,11,9,20,9,20,0})]
    public void IsIntersectionContourAndPolygon(bool res, double[] a)
    {
        //Arrange.
        var contour0 = TestHelper.CreateContour(
            new Point(a[0], a[1]),
            new Point(a[2], a[3]),
            new Point(a[4], a[5]),
            new Point(a[6], a[7]),
            new Point(a[0], a[1]));
        
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
        Assert.Equal(res,contour0.Intersects(polygon));
    }
    
    // Проверка на пересечение между контуром и мультиполигоном
    [Theory]
    [InlineData(true, new double[]{8,13,8,18,12,18,12,13})]
    [InlineData(true, new double[]{20,9,20,11,23,11,23,9})]
    [InlineData(true, new double[]{4,4,4,5,5,5,5,4})] //failed
    [InlineData(false, new double[]{10,13,10,18,12,18,12,13})] //failed
    public void IsIntersectionContourAndMultiPolygon(bool res, double[] a)
    {
        //Arrange.
        var contour0 = TestHelper.CreateContour(
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
			
        //полигон 3
        var contour3 = TestHelper.CreateContour(
            new Point(14,14),
            new Point(14,17),
            new Point(17,17),
            new Point(17,14),
            new Point(14,14));
			
        var contours3 = new List<Contour>{ contour3 };
			
        var polygon3 = TestHelper.CreatePolygon(
            contours3,
            new Point(11,11),
            new Point(11,20),
            new Point(20,20),
            new Point(20,11),
            new Point(11,11));
			
        var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2, polygon3);
        
        //Act. + Assert.
        Assert.Equal(res,contour0.Intersects(multiPolygon));
    }
}