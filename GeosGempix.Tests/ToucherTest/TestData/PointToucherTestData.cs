using System.Collections;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.ToucherTest.TestData;

internal class PointToucherTestData
{
    private static Contour _contour = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 5), new Point(3, 3),
        new Point(5, 5), new Point(5, 0), new Point(0, 0));

    private static MultiPoint _multiPoint = TestHelper.CreateMultiPoint(
        new Point(0, 0), new Point(2, 2), new Point(5, 0));

    private static MultiLine _multiLine = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5));
    
    private static Polygon _polygon = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(
                new Point(3, 3), new Point(3, 6), new Point(6, 6),
                new Point(6, 3), new Point(3, 3))
        },
        new Point(0, 0), new Point(0, 9), new Point(9, 9),
        new Point(9, 0), new Point(0, 0));

    private static MultiPolygon _multiPolygon = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2, 6), new Point(6, 6),
                    new Point(6, 2), new Point(2,2))
            },
            new Point(0, 0), new Point(0, 8), new Point(8, 8),
            new Point(8, 0), new Point(0, 0)),

        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2,12), new Point(2,16), new Point(6,16),
                    new Point(6,12), new Point(2,12))
            },
            new Point(0, 10), new Point(0, 18), new Point(8, 18),
            new Point(8, 10), new Point(0, 10)),

        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(12,12), new Point(12,16), new Point(16,16),
                    new Point(16,12), new Point(12,12))
            },
            new Point(10,10), new Point(10,18), new Point(18,18),
            new Point(18,10), new Point(10,10)));
    
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
            new object[] {true, new Point(3, 3), _contour},
            new object[] {true, new Point(5, 1), _contour},
            new object[] {false, new Point(3, 5), _contour},
            new object[] {false, new Point(1, 2), _contour}
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
            new object[] {true, new Point(6,4), _polygon},
            new object[] {true, new Point(6,6), _polygon},
            new object[] {true, new Point(9, 4), _polygon},
            new object[] {true, new Point(9, 9), _polygon},
            new object[] {false, new Point(4, 5), _polygon},
            new object[] {false, new Point(7, 5), _polygon},
            new object[] {false, new Point(11, 5), _polygon}
        };
    
    public static IEnumerable<object[]> PointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(6,15), _multiPolygon},
            new object[] {true, new Point(8,10), _multiPolygon},
            new object[] {true, new Point(18,14), _multiPolygon},
            new object[] {true, new Point(6,6), _multiPolygon},
            new object[] {false, new Point(4,14), _multiPolygon},
            new object[] {false, new Point(4,9), _multiPolygon},
            new object[] {false, new Point(17, 14), _multiPolygon}
        };
}