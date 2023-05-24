using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class PointDistanceCalculatorTestData
{
    public static IEnumerable<object[]> PointAndPoint =>
        new List<object[]>
        {
            new object[] {0, new Point(1,1), new Point(1,1)},
            new object[] {5, new Point(1,1), new Point(5,4)}
        };
    
    public static IEnumerable<object[]> PointAndLine =>
        new List<object[]>
        {
            new object[] {0, new Point(1,1), TestHelper.CreateLine(1,1,5,1)},
            new object[] {2, new Point(1,3), TestHelper.CreateLine(1,1,5,1)},
            new object[] {2, new Point(3,3), TestHelper.CreateLine(1,1,5,1)},
            new object[] {5, new Point(0,3), TestHelper.CreateLine(4,0,8,0)}
        };
    
    public static IEnumerable<object[]> PointAndContour =>
        new List<object[]>
        {
            new object[] {0, new Point(3,0), _contour},
            new object[] {0, new Point(1,1), _contour},
            new object[] {2, new Point(5,1), _contour},
            new object[] {5, new Point(7,6), _contour}
        };
    
    public static IEnumerable<object[]> PointAndMultiPoint =>
        new List<object[]>
        {
            new object[] 
            {
                0, new Point(2,0), 
                TestHelper.CreateMultiPoint(new Point(0, 0), new Point(1, 2), new Point(2, 0))
            },
            new object[]
            {
                1, new Point(1,1), 
                TestHelper.CreateMultiPoint(new Point(0, 0), new Point(1, 2), new Point(2, 0))
            },
            new object[]
            {
                1, new Point(1,1), 
                TestHelper.CreateMultiPoint(new Point(0, 1), new Point(1, 2), new Point(1, 0))
            }
        };
    
    public static IEnumerable<object[]> PointAndMultiLine =>
        new List<object[]>
        {
            new object[] {0, new Point(6,1), _multiLine},
            new object[] {5, new Point(12,4), _multiLine}
        };
    
    public static IEnumerable<object[]> PointAndPolygon =>
        new List<object[]>
        {
            new object[] {0, new Point(3,4.5), _polygon},
            new object[] {0, new Point(5,2), _polygon},
            new object[] {2, new Point(2,2), _polygon},
            new object[] {5, new Point(9,8), _polygon},
            new object[] {3, new Point(8,1), _polygon}
        };
    
    public static IEnumerable<object[]> PointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {0, new Point(4.5, 8), _multiPolygon},
            new object[] {0, new Point(11, 9), _multiPolygon},
            new object[] {2, new Point(2, 9), _multiPolygon},
            new object[] {3, new Point(8, 2), _multiPolygon},
            new object[] {5, new Point(14, 2), _multiPolygon}
        };

    private static Contour _contour = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 3), new Point(3, 3),
        new Point(3, 0), new Point(0, 0));

    private static MultiLine _multiLine = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(0, 0, 3, 0), TestHelper.CreateLine(4, 0, 4, 2), TestHelper.CreateLine(5, 1, 8, 1));
    
    private static Polygon _polygon = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(
                new Point(1, 1), new Point(1, 4), new Point(4, 4),
                new Point(4, 1), new Point(1, 1))
        },
        new Point(0, 0), new Point(0, 5), new Point(5, 5),
        new Point(5, 0), new Point(0, 0));
    
    private static MultiPolygon _multiPolygon = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(1, 1), new Point(1, 4), new Point(4, 4),
                    new Point(4, 1), new Point(1, 1))
            },
            new Point(0, 0), new Point(0, 5), new Point(5, 5),
            new Point(5, 0), new Point(0, 0)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(1, 7), new Point(1, 10), new Point(4, 10),
                    new Point(4, 7), new Point(1, 7))
            },
            new Point(0, 6), new Point(0, 11), new Point(5, 11),
            new Point(5, 6), new Point(0, 6)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(7, 7), new Point(7, 10), new Point(10, 10),
                    new Point(10, 7), new Point(7, 7))
            },
            new Point(6, 6), new Point(6, 11), new Point(11, 11),
            new Point(11, 6), new Point(6, 6))
    );
}