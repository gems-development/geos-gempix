using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceCalculatorTests
{
    //Проверка на расстояние между контуром и контуром
    [Theory]
    [InlineData(new double[]{3, -3, 3, 2, 8, 2, 8, -3}, 0)]
    [InlineData(new double[]{5, 5, 5, 10, 10, 10, 10, 5}, 0)]
    [InlineData(new double[]{5, 0, 5, 5, 10, 5, 10, 0}, 0)]
    [InlineData(new double[]{0, 0, 0, 5, 5, 5, 5, 0}, 0)]
    [InlineData(new double[]{2, 2, 2, 3, 3, 3, 3, 2}, 2)] //failed
    [InlineData(new double[]{3, 3, 3, 4, 4, 4, 4, 3}, 1)] //failed
    [InlineData(new double[]{8, -1, 8, 4, 13, 4, 13, -1}, 3)]
    [InlineData(new double[]{9, 8, 9, 13, 14, 13, 14, 8}, 5)]
    public void GetDistanceBetweenContourAndContour(double[] a, double res)
    {
        //Arrange.
        var contour0 = TestHelper.CreateContour(
	        new Point(a[0], a[1]),
	        new Point(a[2], a[3]),
	        new Point(a[4], a[5]),
	        new Point(a[6], a[7]),
	        new Point(a[0], a[1]));
        
        var contour = TestHelper.CreateContour(
	        new Point(0, 0),
	        new Point(0, 5),
	        new Point(5, 5),
	        new Point(5, 0),
	        new Point(0, 0));

        //Act. + Assert.
        Assert.Equal(res,contour.GetDistance(contour0));
    }
    
    //Проверка на расстояние между контуром и мультиточкой
    [Theory]
    [InlineData(new double[]{2, 2, 3, 5, 4, 2}, 0)] //failed
    [InlineData(new double[]{2, 3, 3, 6, 4, 3}, 0)] //failed
    [InlineData(new double[]{2, 1, 3, 4, 4, 1}, 0)] //failed
    [InlineData(new double[]{6, 1, 7, 4, 8, 1}, 1)] //failed
    [InlineData(new double[]{9, 8, 9, 10, 12, 9}, 5)] //failed
    public void GetDistanceBetweenContourAndMultiPoint_Success(double[] a, double res)
    {
	    //Arrange.
	    var multiPoint = TestHelper.CreateMultiPoint(
		    new Point(a[0], a[1]),
		    new Point(a[2], a[3]),
		    new Point(a[4], a[5]));
	    
	    var contour = TestHelper.CreateContour(
		    new Point(0, 0),
		    new Point(0, 5),
		    new Point(5, 5),
		    new Point(5, 0),
		    new Point(0, 0));

	    //Act. + Assert.
	    Assert.Equal(res,contour.GetDistance(multiPoint));
    }
    
    //Проверка на расстояние между контуром и мультилинией
    [Theory]
    [InlineData(new double[]{4, 1, 4, 4}, new double[]{6, 4, 8, 4}, new double[]{9, 1, 9, 3}, 0)] 
    [InlineData(new double[]{5, 1, 5, 4}, new double[]{7, 4, 9, 4}, new double[]{10, 1, 10, 3}, 0)] //failed
    [InlineData(new double[]{1, 1, 4, 1}, new double[]{1, 2, 1, 4}, new double[]{3, 3, 4 ,3}, 0)] 
    [InlineData(new double[]{5, 5, 5, 8}, new double[]{7, 8, 9, 8}, new double[]{10, 5, 10, 7}, 0)]
    [InlineData(new double[]{9, 8, 9, 11}, new double[]{11, 11, 11, 13}, new double[]{14, 8, 14, 10}, 5)]
    [InlineData(new double[]{8, 0, 8, 3}, new double[]{10, 3, 12, 3}, new double[]{13, 0, 13, 2}, 3)]
    public void GetDistanceBetweenContourAndMultiLine_Success(double[] a, double[] b, double[] c, double res)
    {
	    //Arrange.
	    var multiLine = TestHelper.CreateMultiLine(
		    TestHelper.CreateLine(a[0], a[1], a[2], a[3]),
		    TestHelper.CreateLine(b[0], b[1], b[2], b[3]),
		    TestHelper.CreateLine(c[0], c[1], c[2], c[3]));
	    
	    var contour = TestHelper.CreateContour(
		    new Point(0, 0),
		    new Point(0, 5),
		    new Point(5, 5),
		    new Point(5, 0),
		    new Point(0, 0));

	    //Act. + Assert.
	    Assert.Equal(res,contour.GetDistance(multiLine));
    }
    
    //Проверка на расстояние между контуром и полигоном
    [Theory]
    [InlineData(0, new double[]{0, 0, 0, 5, 5, 5, 5, 0}, new double[]{2, 2, 2, 3, 3, 3, 3, 2})]
    [InlineData(0, new double[]{1, 1, 1, 4, 4, 4, 4, 1}, new double[]{2, 2, 2, 3, 3, 3, 3, 2})]
    [InlineData(0, new double[]{5, 5, 5, 8, 8, 8, 8, 5}, new double[]{6, 6, 6, 7, 7, 7, 7, 6})]
    [InlineData(0, new double[]{6, 3, 3, 6, 6, 9, 9, 6}, new double[]{5, 6, 5, 7, 6, 7, 6, 6})]
    [InlineData(5, new double[]{9, 8, 9, 11, 12, 11, 12, 8}, new double[]{10, 9, 10, 10, 11, 10, 11, 9})] //failed
    [InlineData(3, new double[]{8, 1, 8, 4, 11, 4, 11, 1}, new double[]{9, 2, 9, 3, 10, 3, 10, 2})] //failed
    public void GetDistanceBetweenContourAndPolygon_Success(double res, double[] a, double[] b)
    {
	    //Arrange.
	    var contour = TestHelper.CreateContour(
		    new Point(0, 0),
		    new Point(0, 5),
		    new Point(5, 5),
		    new Point(5, 0),
		    new Point(0, 0));
	    
	    var contour1 = TestHelper.CreateContour(
		    new Point(a[0], a[1]),
		    new Point(a[2], a[3]),
		    new Point(a[4], a[5]),
		    new Point(a[6], a[7]),
		    new Point(a[0], a[1]));
			
	    var contours1 = new List<Contour>{ contour1 };
			
	    var polygon1 = TestHelper.CreatePolygon(
		    contours1,
		    new Point(a[0], a[1]),
		    new Point(a[2], a[3]),
		    new Point(a[4], a[5]),
		    new Point(a[6], a[7]),
		    new Point(a[0], a[1]));

	    //Act. + Assert.
	    Assert.Equal(res,contour.GetDistance(polygon1));
    }

    [Theory]
    [InlineData(0, new double[]{2, 12, 2, 16, 6, 16, 6, 12})]
    [InlineData(0, new double[]{0, 0, 0, 8, 8, 8, 8, 0})]
    [InlineData(0, new double[]{14, 14, 14, 16, 16, 16, 16, 14})]
    [InlineData(0, new double[]{18, 8, 18, 10, 20, 10, 20, 8})]
    [InlineData(0, new double[]{5, 13, 5, 15, 13, 13, 13, 15})]
    [InlineData(0, new double[]{5, 3, 5, 5, 9, 5, 9, 3})]
    [InlineData(0, new double[]{-2, -2, -2, 19, 20, 19, 20, -2})]
    [InlineData(1, new double[]{3, 14, 3, 15, 4, 15, 4, 13})] //failed
    [InlineData(5, new double[]{22, 4, 22, 7, 25, 7, 25, 4})] //failed
    public void GetDistanceBetweenContourAndMultiPolygon_Success(double res, double[] a)
    {
	    //Arrange.
	    var contour = TestHelper.CreateContour(
		    new Point(a[0], a[1]),
		    new Point(a[2], a[3]),
		    new Point(a[4], a[5]),
		    new Point(a[6], a[7]),
		    new Point(a[0], a[1]));
	    
	    //полигон 1
	    var contour1 = TestHelper.CreateContour(
		    new Point(2, 2),
		    new Point(2, 6),
		    new Point(6, 6),
		    new Point(6, 2),
		    new Point(2, 2));
			
	    var contours1 = new List<Contour>{ contour1 };
			
	    var polygon1 = TestHelper.CreatePolygon(
		    contours1,
		    new Point(0, 0),
		    new Point(0, 8),
		    new Point(8, 8),
		    new Point(8, 0),
		    new Point(0, 0));
			
	    //полигон 2
	    var contour2 = TestHelper.CreateContour(
		    new Point(2, 12),
		    new Point(2, 16),
		    new Point(6, 16),
		    new Point(6, 12),
		    new Point(2, 12));
			
	    var contours2 = new List<Contour>{ contour2 };
			
	    var polygon2 = TestHelper.CreatePolygon(
		    contours2,
		    new Point(0, 10),
		    new Point(0, 18),
		    new Point(8, 18),
		    new Point(8, 10),
		    new Point(0, 10));
			
	    //полигон 3
	    var contour3 = TestHelper.CreateContour(
		    new Point(11, 11),
		    new Point(11, 14),
		    new Point(14, 14),
		    new Point(14, 11),
		    new Point(11, 11));
			
	    var contours3 = new List<Contour>{ contour3 };
			
	    var polygon3 = TestHelper.CreatePolygon(
		    contours3,
		    new Point(10, 10),
		    new Point(10, 18),
		    new Point(18, 18),
		    new Point(18, 10),
		    new Point(10, 10));
			
	    var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2, polygon3);
	    
	    //Act. + Assert.
	    Assert.Equal(res,contour.GetDistance(multiPolygon));
    }
}