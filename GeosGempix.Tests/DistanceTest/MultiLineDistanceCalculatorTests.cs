using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.DistanceTest.TestData;

namespace GeosGempix.Tests.DistanceTest;

public class MultiLineDistanceCalculatorTests
{
    //Проверка на расстояние между мультилинией и мультилинией
    [Theory]
    [MemberData(nameof(MultiLineDistanceCalculatorTestData.MultiLineAndMultiLine), MemberType = typeof(MultiLineDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiLineAndMultiLine(double result, MultiLine multiLine1, MultiLine multiLine2)
    {
        //Act. + Assert.
        Assert.Equal(result,multiLine1.GetDistance(multiLine2));
    }
    
    // Проверка на растояние между мультилинией и полигоном
    [Theory]
    [MemberData(nameof(MultiLineDistanceCalculatorTestData.MultiLineAndPolygon), MemberType = typeof(MultiLineDistanceCalculatorTestData))]
    public void GetDistanceBetweenMultiLineAndPolygon(double result, MultiLine multiLine, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(result,multiLine.GetDistance(polygon));
    }
}