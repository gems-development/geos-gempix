using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceCalculatorTests
{
	//Проверка на расстояние между контуром и контуром
	[Theory]
	[MemberData(nameof(ContourDistanceCalculatorTestData.ContourAndContour), MemberType = typeof(ContourDistanceCalculatorTestData))]
    public void GetDistanceBetweenContourAndContour(double result, Contour contour1, Contour contour2)
    {
	    //Act. + Assert.
        Assert.Equal(result,contour1.GetDistance(contour2));
    }
    
    //Проверка на расстояние между контуром и мультиточкой
    [Theory]
    [MemberData(nameof(ContourDistanceCalculatorTestData.ContourAndMultiPoint), MemberType = typeof(ContourDistanceCalculatorTestData))]
    public void GetDistanceBetweenContourAndMultiPoint_Success(double result, Contour contour, MultiPoint multiPoint)
    {
	    //Act. + Assert.
	    Assert.Equal(result,contour.GetDistance(multiPoint));
    }
    
    //Проверка на расстояние между контуром и мультилинией
    [Theory]
    [MemberData(nameof(ContourDistanceCalculatorTestData.ContourAndMultiLine), MemberType = typeof(ContourDistanceCalculatorTestData))]
    public void GetDistanceBetweenContourAndMultiLine_Success(double result, Contour contour, MultiLine multiLine)
    {
	    //Act. + Assert.
	    Assert.Equal(result,contour.GetDistance(multiLine));
    }
    
    //Проверка на расстояние между контуром и полигоном
    [Theory]
    [MemberData(nameof(ContourDistanceCalculatorTestData.ContourAndPolygon), MemberType = typeof(ContourDistanceCalculatorTestData))]
    public void GetDistanceBetweenContourAndPolygon_Success(double result, Contour contour, Polygon polygon)
    {
	    //Arrange.
	    var tests = new ContourDistanceCalculatorTests();
	    //Act. + Assert.
	    Assert.Equal(result,contour.GetDistance(polygon));
    }
    
    [Theory]
    [MemberData(nameof(ContourDistanceCalculatorTestData.ContourAndMultiPolygon), MemberType = typeof(ContourDistanceCalculatorTestData))]
    public void GetDistanceBetweenContourAndMultiPolygon_Success(double result, Contour contour, MultiPolygon multiPolygon)
    {
	    //Act. + Assert.
	    Assert.Equal(result,contour.GetDistance(multiPolygon));
    }
}