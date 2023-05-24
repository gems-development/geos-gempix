using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class LineDistanceCalculatorTestData
{
    public static IEnumerable<object[]> LineAndLine =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(0,0,4,0), TestHelper.CreateLine(0,0,4,0)},
            new object[] {0, TestHelper.CreateLine(2,2,7,2), TestHelper.CreateLine(6,0,6,4)},
            new object[] {0, TestHelper.CreateLine(0,0,2,0), TestHelper.CreateLine(2,0,2,1)},
            new object[] {2, TestHelper.CreateLine(0,0,4,0), TestHelper.CreateLine(0,2,4,2)},
            new object[] {5, TestHelper.CreateLine(0,0,1,0), TestHelper.CreateLine(5,3,5,4)}
        };
    
    public static IEnumerable<object[]> LineAndContour =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(1,0,3,0), _contour},
            new object[] {0, TestHelper.CreateLine(2,2,6,2), _contour},
            new object[] {0, TestHelper.CreateLine(4,3,7,3), _contour},
            new object[] {0, TestHelper.CreateLine(1,1,1,2), _contour},
            new object[] {1, TestHelper.CreateLine(5,1,7,4), _contour},
            new object[] {5, TestHelper.CreateLine(8,7,9,6), _contour}
        };
    
    public static IEnumerable<object[]> LineAndMultiPoint =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(0,3,3,3), _multiPoint},
            new object[] {1, TestHelper.CreateLine(0,2,3,2), _multiPoint},
            new object[] {5, TestHelper.CreateLine(5,6,6,6), _multiPoint}
        };
    
    public static IEnumerable<object[]> LineAndMultiLine =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(0,1,6,1), _multiLine},
            new object[] {0, TestHelper.CreateLine(4,1,6,1), _multiLine},
            new object[] {0, TestHelper.CreateLine(4,3,5,3), _multiLine},
            new object[] {1, TestHelper.CreateLine(3,0,4,0), _multiLine},
            new object[] {2, TestHelper.CreateLine(7,1,7,4), _multiLine}
        };
    
    public static IEnumerable<object[]> LineAndPolygon =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(1,1,1,6), _polygon},
            new object[] {0, TestHelper.CreateLine(-1,4,3,4), _polygon},
            new object[] {0, TestHelper.CreateLine(1,4,6,4), _polygon},
            new object[] {1, TestHelper.CreateLine(3,3,4,4), _polygon},
            new object[] {2, TestHelper.CreateLine(9,5,11,3), _polygon},
            new object[] {2, TestHelper.CreateLine(9,0,12,0), _polygon},
            new object[] {5, TestHelper.CreateLine(11,10,11,12), _polygon}
        };
    
    public static IEnumerable<object[]> LineAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(6,6,8,8), _multiPolygon},
            new object[] {0, TestHelper.CreateLine(4,13,8,13), _multiPolygon},
            new object[] {0, TestHelper.CreateLine(15,10,15,15), _multiPolygon},
            new object[] {1, TestHelper.CreateLine(3,12,4,12), _multiPolygon},
            new object[] {5, TestHelper.CreateLine(20,19,21,20), _multiPolygon},
            new object[] {1, TestHelper.CreateLine(17,10,21,13), _multiPolygon},
            new object[] {3, TestHelper.CreateLine(10,3,14,3), _multiPolygon}
        };

    private static MultiPoint _multiPoint =
        TestHelper.CreateMultiPoint(new Point(0, 0), new Point(1, 3), new Point(2, 0));
    
    private static MultiLine _multiLine = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(1, 0, 1, 3), TestHelper.CreateLine(2, 3, 4, 3), TestHelper.CreateLine(5, 0, 5, 2));
    
    private static Contour _contour = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 4), new Point(4, 4),
        new Point(4, 0), new Point(0, 0));
    
    private static Polygon _polygon = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(
                new Point(2, 2), new Point(2, 5), new Point(5, 5),
                new Point(5, 2), new Point(2, 2))
        },
        new Point(0, 0), new Point(0, 7), new Point(7, 7),
        new Point(7, 0), new Point(0, 0));
    
    private static MultiPolygon _multiPolygon = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2, 2), new Point(2, 5), new Point(5, 5),
                    new Point(5, 2), new Point(2, 2))
            },
            new Point(0, 0), new Point(0, 7), new Point(7, 7),
            new Point(7, 0), new Point(0, 0)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2, 11), new Point(2, 14), new Point(5, 14),
                    new Point(5, 11), new Point(2, 11))
            },
            new Point(0, 9), new Point(0, 16), new Point(7, 16),
            new Point(7, 9), new Point(0, 9)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(11, 11), new Point(11, 14), new Point(14, 14),
                    new Point(14, 11), new Point(11, 11))
            },
            new Point(9, 9), new Point(9, 16), new Point(16, 16),
            new Point(16, 9), new Point(9, 9))
    );
}