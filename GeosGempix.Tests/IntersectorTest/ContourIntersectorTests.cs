using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Tests.IntersectorTest.TestData;

namespace GeosGempix.Tests.IntersectorTest;

public class ContourIntersectorTests
{
    // Проверка на пересечение между контуром и контуром
    [Theory]
    [MemberData(nameof(ContourIntersectorTestData.ContourAndContour), MemberType = typeof(ContourIntersectorTestData))]
    public void IsIntersectionContourAndContour(bool result, Contour contour1, Contour contour2)
    {
        //Act. + Assert.
        Assert.Equal(result,contour1.Intersects(contour2));
    }

    // Проверка на пересечение между контуром и мультиточкой
    [Theory]
    [MemberData(nameof(ContourIntersectorTestData.ContourAndMultiPoint), MemberType = typeof(ContourIntersectorTestData))]
    public void IsIntersectionContourAndMultiPoint(bool result, Contour contour, MultiPoint multiPoint)
    {
        //Act. + Assert.
        Assert.Equal(result,contour.Intersects(multiPoint));
    }

    // Проверка на пересечение между контуром и мультилинией
    [Theory]
    [MemberData(nameof(ContourIntersectorTestData.ContourAndMultiLine), MemberType = typeof(ContourIntersectorTestData))]
    public void IsIntersectionContourAndMultiLine(bool result, Contour contour, MultiLine multiLine)
    {
        //Act. + Assert.
        Assert.Equal(result,contour.Intersects(multiLine));
    }
    
    // Проверка на пересечение между контуром и полигоном
    [Theory]
    [MemberData(nameof(ContourIntersectorTestData.ContourAndPolygon), MemberType = typeof(ContourIntersectorTestData))]
    public void IsIntersectionContourAndPolygon(bool res, Contour contour, Polygon polygon)
    {
        //Act. + Assert.
        Assert.Equal(res,contour.Intersects(polygon));
    }
    
    // Проверка на пересечение между контуром и мультиполигоном
    
    
    [Theory]
    [MemberData(nameof(ContourIntersectorTestData.ContourAndMultipolygon), MemberType = typeof(ContourIntersectorTestData))]
    public void IsIntersectionContourAndMultiPolygon(bool res, Contour contour, MultiPolygon multiPolygon)
    {
        //Act. + Assert.
        Assert.Equal(res,contour.Intersects(multiPolygon));
    }
}