using GeosGempix.Extensions;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceCalculatorTests
{
    //Проверка на расстояние между контуром и контуром
    [Theory]
    [InlineData(3, -3, 3, 2, 8, 2, 8, -3, 3, -3, 0)]
    [InlineData(5, 5, 5, 10, 10, 10, 10, 5, 5, 5, 0)]
    [InlineData(5, 0, 5, 5, 10, 5, 10, 0, 5, 0, 0)]
    [InlineData(0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0)]
    [InlineData(2, 2, 2, 3, 3, 3, 3, 2, 2, 2, 2)] //failed
    [InlineData(3, 3, 3, 4, 4, 4, 4, 3, 3, 3, 1)] //failed
    [InlineData(8, -1, 8, 4, 13, 4, 13, -1, 8, -1, 3)]
    [InlineData(9, 8, 9, 13, 14, 13, 14, 8, 9, 8, 5)]
    public void GetDistanceBetweenContourAndContour(double x1, double y1, double x2, double y2,  
	    double x3, double y3, double x4, double y4, double x5, double y5, double res)
    {
        //Arrange.
        var contour0 = TestHelper.CreateContour(
	        new Point(x1, y1),
	        new Point(x2, y2),
	        new Point(x3, y3),
	        new Point(x4, y4),
	        new Point(x5, y5));
        
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
    [InlineData(2, 2, 3, 5, 4, 2, 0)] //failed
    [InlineData(2, 3, 3, 6, 4, 3, 0)] //failed
    [InlineData(2, 1, 3, 4, 4, 1, 0)] //failed
    [InlineData(6, 1, 7, 4, 8, 1, 1)] //failed
    [InlineData(9, 8, 9, 10, 12, 9, 5)] //failed
    public void GetDistanceBetweenContourAndMultiPoint_Success(double x1, double y1, double x2, double y2,  
	    double x3, double y3, double res)
    {
	    //Arrange.
	    var multiPoint = TestHelper.CreateMultiPoint(
		    new Point(x1, y1),
		    new Point(x2, y2),
		    new Point(x3, y3));
	    
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
    [InlineData(4, 1, 4, 4, 6, 4, 8, 4, 9, 1, 9, 3, 0)] 
    [InlineData(5, 1, 5, 4, 7, 4, 9, 4, 10, 1, 10, 3, 0)] //failed
    [InlineData(1, 1, 4, 1, 1, 2, 1, 4, 3, 3, 4 ,3, 0)] 
    [InlineData(5, 5, 5, 8, 7, 8, 9, 8, 10, 5, 10, 7, 0)]
    [InlineData(9, 8, 9, 11, 11, 11, 11, 13, 14, 8, 14, 10, 5)]
    [InlineData(8, 0, 8, 3, 10, 3, 12, 3, 13, 0, 13, 2, 3)]
    public void GetDistanceBetweenContourAndMultiLine_Success(double x1, double y1, double x2, double y2,  
	    double x3, double y3, double x4, double y4, double x5, double y5, double x6, double y6, double res)
    {
	    //Arrange.
	    var multiLine = TestHelper.CreateMultiLine(
		    TestHelper.CreateLine(x1, y1, x2, y2),
		    TestHelper.CreateLine(x3, y3, x4, y4),
		    TestHelper.CreateLine(x5, y5, x6, y6));
	    
	    var contour = TestHelper.CreateContour(
		    new Point(0, 0),
		    new Point(0, 5),
		    new Point(5, 5),
		    new Point(5, 0),
		    new Point(0, 0));

	    //Act. + Assert.
	    Assert.Equal(res,contour.GetDistance(multiLine));
    }
}