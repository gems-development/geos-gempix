using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest;

public class PointIntersectorTests
{
    // Проверка на пересечение между точкой и точкой
    [Theory]
    [InlineData(true, new double[]{4,5})]
    [InlineData(false, new double[]{6,6})]
    public void IsIntersectionPointAndPoint(bool res, double[] a)
    {
        //Arrange.
        var point1 = new Point(4,5);
        var point2 = new Point(a[0], a[1]);

        //Act. + Assert.
        Assert.Equal(res,point1.Intersects(point2));
    }
    
    // Проверка на пересечение между точкой и отрезком
    [Theory]
    [InlineData(true, new double[]{4,4})]
    [InlineData(false, new double[]{4,7})]
    public void IsIntersectionPointAndLine(bool res, double[] a)
    {
        //Arrange.
        var point = new Point(a[0], a[1]);
        var line = TestHelper.CreateLine(2,4,7,4);

        //Act. + Assert.
        Assert.Equal(res,point.Intersects(line));
    }
    
    // Проверка на пересечение между точкой и контуром
    [Theory]
    [InlineData(true, new double[]{0,5})]
    [InlineData(true, new double[]{3,5})] //failed
    [InlineData(false, new double[]{10,7})]
    public void IsIntersectionPointAndContour(bool res, double[] a)
    {
        //Arrange.
        var point = new Point(a[0], a[1]);
        
        var contour = TestHelper.CreateContour(
            new Point(0, 0),
            new Point(0, 9),
            new Point(9, 9),
            new Point(9, 0),
            new Point(0, 0));

        //Act. + Assert.
        Assert.Equal(res,point.Intersects(contour));
    }
    
    // Проверка на пересечение между точкой и мультиточкой
    [Theory]
    [InlineData(true, new double[]{4,4})]
    [InlineData(true, new double[]{5,6})]
    [InlineData(true, new double[]{6,5})]
    [InlineData(false, new double[]{7,7})]
    public void IsIntersectionPointAndMultiPoint(bool res, double[] a)
    {
        //Arrange.
        var point = new Point(a[0], a[1]);
        
        var multiPoint = TestHelper.CreateMultiPoint(
            new Point(4,4),
            new Point(5,6),
            new Point(6,5));

        //Act. + Assert.
        Assert.Equal(res,point.Intersects(multiPoint));
    }
    
    // Проверка на пересечение между точкой и мультилинией
    [Theory]
    [InlineData(true, new double[]{4,4})]
    [InlineData(false, new double[]{3,5})]
    public void IsIntersectionPointAndMultiLine(bool res, double[] a)
    {
        //Arrange.
        var point = new Point(a[0], a[1]);
        
        var multiLine = TestHelper.CreateMultiLine(
            TestHelper.CreateLine(3,1,7,2),
            TestHelper.CreateLine(2,4,7,4),
            TestHelper.CreateLine(4,8,5,5));

        //Act. + Assert.
        Assert.Equal(res,point.Intersects(multiLine));
    }
    
    // Проверка на пересечение между точкой и полигоном
    [Theory]
    [InlineData(true, new double[]{4,4})] //failed
    [InlineData(true, new double[]{0,5})]
    [InlineData(true, new double[]{4,6})]
    [InlineData(false, new double[]{10,5})]
    public void IsIntersectionPointAndPolygon(bool res, double[] a)
    {
        //Arrange.
        var point = new Point(a[0], a[1]);
        
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
        Assert.Equal(res,point.Intersects(polygon));
    }
    
    // Проверка на пересечение между точкой и мультиполигоном
    [Theory]
    [InlineData(true, new double[]{3,16})]
    [InlineData(true, new double[]{15,20})]
    [InlineData(true, new double[]{15,16})] //failed
    [InlineData(true, new double[]{3,6})]
    [InlineData(false, new double[]{10,16})]
    public void IsIntersectionPointAndMultiPolygon(bool res, double[] a)
    {
        //Arrange.
        var point = new Point(a[0], a[1]);
        
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
        Assert.Equal(res,point.Intersects(multiPolygon));
    }
}