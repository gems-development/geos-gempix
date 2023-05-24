using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest;

public class MultiPointIntersectorTests
{
    // Проверка на пересечение между мультиточкой и мультиточкой
    [Theory]
    [MemberData(nameof(MultiPointIntersectorTestData.MultiPointAndMultiPoint), MemberType = typeof(MultiPointIntersectorTestData))]
    public void IsIntersectionMultiPointAndMultiPoint(bool result, MultiPoint multiPoint1, MultiPoint multiPoint2)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint1.Intersects(multiPoint2));
    }
    
    // Проверка на пересечение между мультиточкой и мультилинией
    [Theory]
    [MemberData(nameof(MultiPointIntersectorTestData.MultiPointAndMultiLine), MemberType = typeof(MultiPointIntersectorTestData))]
    public void IsIntersectionMultiPointAndMultiLine(bool result, MultiPoint multiPoint, MultiLine multiLine)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint.Intersects(multiLine));
    }
    
    // Проверка на пересечение между мультиточкой и полигоном
    [Theory]
    [MemberData(nameof(MultiPointIntersectorTestData.MultiPointAndPolygon), MemberType = typeof(MultiPointIntersectorTestData))]
    public void IsIntersectionMultiPointAndPolygon(bool result, MultiPoint multiPoint, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint.Intersects(polygon));
    }
    
    // Проверка на пересечение между мультиточкой и мультиполигоном
    [Theory]
    [MemberData(nameof(MultiPointIntersectorTestData.MultiPointAndMultiPolygon), MemberType = typeof(MultiPointIntersectorTestData))]
    public void IsIntersectionMultiPointAndMultiPolygon(bool result, MultiPoint multiPoint, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(result,multiPoint.Intersects(multiPolygon));
    }
}