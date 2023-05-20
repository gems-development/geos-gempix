using System.Collections;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.ToucherTest.TestData;

internal class PointToucherTestData
{
    private static MultiPoint _multiPoint = TestHelper.CreateMultiPoint(
        new Point(0, 0), new Point(2, 2), new Point(5, 0));

    private static MultiLine _multiLine = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5));

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
            new object[] {true, new Point(3, 3), TestData._contour},
            new object[] {true, new Point(5, 1), TestData._contour},
            new object[] {false, new Point(3, 5), TestData._contour},
            new object[] {false, new Point(1, 2), TestData._contour}
        };
    
    public static IEnumerable<object[]> PointAndMultiPoint =>
        new List<object[]>
        {
            new object[] {true, new Point(0, 0), _multiPoint},
            new object[] {false, new Point(2, 0), _multiPoint}
        };
    
    public static IEnumerable<object[]> PointAndMultiLine =>
        new List<object[]>
        {
            new object[] {true, new Point(4, 4), _multiLine},
            new object[] {true, new Point(7, 2), _multiLine},
            new object[] {false, new Point(3, 5), _multiLine}
        };
    
    public static IEnumerable<object[]> PointAndPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(6,4), TestData._polygon},
            new object[] {true, new Point(6,6), TestData._polygon},
            new object[] {true, new Point(9, 4), TestData._polygon},
            new object[] {true, new Point(9, 9), TestData._polygon},
            new object[] {false, new Point(4, 5), TestData._polygon},
            new object[] {false, new Point(7, 5), TestData._polygon},
            new object[] {false, new Point(11, 5), TestData._polygon}
        };
    
    public static IEnumerable<object[]> PointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(6,15), TestData._multiPolygon},
            new object[] {true, new Point(8,10), TestData._multiPolygon},
            new object[] {true, new Point(18,14), TestData._multiPolygon},
            new object[] {true, new Point(6,6), TestData._multiPolygon},
            new object[] {false, new Point(4,14), TestData._multiPolygon},
            new object[] {false, new Point(4,9), TestData._multiPolygon},
            new object[] {false, new Point(17, 14), TestData._multiPolygon}
        };
}