using System.Collections;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.ToucherTest.TestData;

internal class PointToucherTestData
{
    public static IEnumerable<object[]> PointAndPoint =>
        new List<object[]>
    {
        new object[] {true, new Point(0, 0), new Point(0,0)},
        new object[] {false, new Point(0, 0), new Point(3,0)}
    };

    public static IEnumerable<object[]> PointAndLine =>
        new List<object[]>
    {
        new object[] {true, new Point(0, 0), TestHelper.CreateLine(0,0,4,0)},
        new object[] {true, new Point(4, 0), TestHelper.CreateLine(0,0,4,0)},
        new object[] {false, new Point(5, 0), TestHelper.CreateLine(0,0,4,0)}
    };
    
    public static IEnumerable<object[]> PointAndContour =>
        new List<object[]>
        {
            new object[] {true, new Point(3, 3), BaseTestData.Contour},
            new object[] {true, new Point(5, 1), BaseTestData.Contour},
            new object[] {false, new Point(3, 5), BaseTestData.Contour},
            new object[] {false, new Point(1, 2), BaseTestData.Contour}
        };
    
    public static IEnumerable<object[]> PointAndMultiPoint =>
        new List<object[]>
        {
            new object[] {true, new Point(0, 0), BaseTestData.MultiPointPointTest},
            new object[] {false, new Point(2, 0), BaseTestData.MultiPointPointTest}
        };
    
    public static IEnumerable<object[]> PointAndMultiLine =>
        new List<object[]>
        {
            new object[] {true, new Point(4, 4), BaseTestData.MultiLinePointTest},
            new object[] {true, new Point(7, 2), BaseTestData.MultiLinePointTest},
            new object[] {false, new Point(3, 5), BaseTestData.MultiLinePointTest}
        };
    
    public static IEnumerable<object[]> PointAndPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(6,4), BaseTestData.Polygon},
            new object[] {true, new Point(6,6), BaseTestData.Polygon},
            new object[] {true, new Point(9, 4), BaseTestData.Polygon},
            new object[] {true, new Point(9, 9), BaseTestData.Polygon},
            new object[] {false, new Point(4, 5), BaseTestData.Polygon},
            new object[] {false, new Point(7, 5), BaseTestData.Polygon},
            new object[] {false, new Point(11, 5), BaseTestData.Polygon}
        };
    
    public static IEnumerable<object[]> PointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(6,15), BaseTestData.MultiPolygon},
            new object[] {true, new Point(8,10), BaseTestData.MultiPolygon},
            new object[] {true, new Point(18,14), BaseTestData.MultiPolygon},
            new object[] {true, new Point(6,6), BaseTestData.MultiPolygon},
            new object[] {false, new Point(4,14), BaseTestData.MultiPolygon},
            new object[] {false, new Point(4,9), BaseTestData.MultiPolygon},
            new object[] {false, new Point(17, 14), BaseTestData.MultiPolygon}
        };
}