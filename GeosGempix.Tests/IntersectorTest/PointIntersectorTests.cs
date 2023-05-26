using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest;

public class PointIntersectorTests
{
    // Проверка на пересечение между точкой и точкой
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndPoint), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndPoint(bool result, Point point1, Point point2)
    {
        //Act. + Assert.
        Assert.Equal(result,point1.Intersects(point2));
    }
    
    // Проверка на пересечение между точкой и отрезком
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndLine), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndLine(bool result, Point point, Line line)
    {
        //Act. + Assert.
        Assert.Equal(result,point.Intersects(line));
    }
    
    // Проверка на пересечение между точкой и контуром
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndContour), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndContour(bool result, Point point, Contour contour)
    {
        //Act. + Assert.
        Assert.Equal(result,point.Intersects(contour));
    }
    
    // Проверка на пересечение между точкой и мультиточкой
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndMultiPoint), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndMultiPoint(bool result, Point point, MultiPoint multiPoint)
    {
        //Act. + Assert.
        Assert.Equal(result,point.Intersects(multiPoint));
    }
    
    // Проверка на пересечение между точкой и мультилинией
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndMultiLine), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndMultiLine(bool result, Point point, MultiLine multiLine)
    {
        //Act. + Assert.
        Assert.Equal(result,point.Intersects(multiLine));
    }
    
    // Проверка на пересечение между точкой и полигоном
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndPolygon), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndPolygon(bool result, Point point, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(result,point.Intersects(polygon));
    }
    
    // Проверка на пересечение между точкой и мультиполигоном
    [Theory]
    [MemberData(nameof(PointIntersectorTestData.PointAndMultiPolygon), MemberType = typeof(PointIntersectorTestData))]
    public void IsIntersectionPointAndMultiPolygon(bool result, Point point, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(result,point.Intersects(multiPolygon));
    }
}