using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest;

public class MultiLineIntersectorTests
{
    // Проверка на пересечение между мультилинией и мультилинией
    [Theory]
    [MemberData(nameof(MultiLineIntersectorTestData.MultiLineAndMultiLine), MemberType = typeof(MultiLineIntersectorTestData))]
    public void IsIntersectionMultiLineAndMultiLine(bool result, MultiLine multiLine1, MultiLine multiLine2)
    {
        //Act. + Assert.
        Assert.Equal(result,multiLine1.Intersects(multiLine2));
    }
    
    // Проверка на пересечение между мультилинией и полигоном
    [Theory]
    [MemberData(nameof(MultiLineIntersectorTestData.MultiLineAndPolygon), MemberType = typeof(MultiLineIntersectorTestData))]
    public void IsIntersectionMultiLineAndPolygon(bool result, MultiLine multiLine, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(result,multiLine.Intersects(polygon));
    }
    
    // Проверка на пересечение между мультилинией и мультиполигоном
    [Theory]
    [MemberData(nameof(MultiLineIntersectorTestData.MultiLineAndMultiPolygon), MemberType = typeof(MultiLineIntersectorTestData))]
    public void IsIntersectionMultiLineAndMultiPolygon(bool result, MultiLine multiLine, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(result,multiLine.Intersects(multiPolygon));
    }
}