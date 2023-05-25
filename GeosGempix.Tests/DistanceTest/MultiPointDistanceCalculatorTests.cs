using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest;

public class MultiPointDistanceCalculatorTests
{
    //Проверка на расстояние между мультиточкой и мультиточкой
    [Theory]
    [MemberData(nameof(MultiPointDistanceCalculatorTestData.MultiPointAndMultiPoint), MemberType = typeof(MultiPointDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPointAndMultiPoint(double result, MultiPoint multiPoint1, MultiPoint multiPoint2)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint1.GetDistance(multiPoint2));
    }
    
    //Проверка на расстояние между мультиточкой и мультилинией
    [Theory]
    [MemberData(nameof(MultiPointDistanceCalculatorTestData.MultiPointAndMultiLine), MemberType = typeof(MultiPointDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPointAndMultiLine(double result, MultiPoint multiPoint, MultiLine multiLine)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint.GetDistance(multiLine));
    }
    
    // Проверка на растояние между мультиточкой и полигоном
    [Theory]
    [MemberData(nameof(MultiPointDistanceCalculatorTestData.MultiPointAndPolygonLieOn), MemberType = typeof(MultiPointDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPointAndPolygon_LieOn(MultiPoint multiPoint, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(0,multiPoint.GetDistance(polygon));
    }
    
    // Проверка на растояние между мультиточкой и полигоном
    [Theory]
    [MemberData(nameof(MultiPointDistanceCalculatorTestData.MultiPointAndPolygonDontLieOn), MemberType = typeof(MultiPointDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPointAndPolygon_DontLieOn(double result, MultiPoint multiPoint, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint.GetDistance(polygon));
    }
    
    // Проверка на растояние между мультиточкой и мультиполигоном
    [Theory]
    [MemberData(nameof(MultiPointDistanceCalculatorTestData.MultiPointAndMultiPolygonLieOn), MemberType = typeof(MultiPointDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPointAndMultiPolygon_LieOn(MultiPoint multiPoint, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(0,multiPoint.GetDistance(multiPolygon));
    }

    // Проверка на растояние между мультиточкой и мультиполигоном
    [Theory]
    [MemberData(nameof(MultiPointDistanceCalculatorTestData.MultiPointAndMultiPolygonDontLieOn), MemberType = typeof(MultiPointDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiPointAndMultiPolygon_DontLieOn(double result, MultiPoint multiPoint, MultiPolygon multiPolygon)
    {
       //Act. + Assert.
        Assert.Equal(result,multiPoint.GetDistance(multiPolygon));
    }
}