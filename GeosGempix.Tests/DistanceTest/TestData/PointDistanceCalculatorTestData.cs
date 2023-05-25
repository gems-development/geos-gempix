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
            new object[] {0, new Point(3,0), BaseTestData.ContourPointTest},
            new object[] {0, new Point(1,1), BaseTestData.ContourPointTest},
            new object[] {2, new Point(5,1), BaseTestData.ContourPointTest},
            new object[] {5, new Point(7,6), BaseTestData.ContourPointTest}
        };
    
    public static IEnumerable<object[]> PointAndMultiPoint =>
        new List<object[]>
        {
            new object[] 
            {
                0, new Point(2,0), TestHelper.CreateMultiPoint(new Point(0, 0), new Point(1, 2), new Point(2, 0))
            },
            new object[]
            {
                1, new Point(1,1), TestHelper.CreateMultiPoint(new Point(0, 0), new Point(1, 2), new Point(2, 0))
            },
            new object[]
            {
                1, new Point(1,1), TestHelper.CreateMultiPoint(new Point(0, 1), new Point(1, 2), new Point(1, 0))
            }
        };
    
    public static IEnumerable<object[]> PointAndMultiLine =>
        new List<object[]>
        {
            new object[] {0, new Point(6,1), BaseTestData.MultiLinePointTest},
            new object[] {5, new Point(12,4), BaseTestData.MultiLinePointTest}
        };
    
    public static IEnumerable<object[]> PointAndPolygon =>
        new List<object[]>
        {
            new object[] {0, new Point(3,4.5), BaseTestData.PolygonPointTest},
            new object[] {0, new Point(5,2), BaseTestData.PolygonPointTest},
            new object[] {2, new Point(2,2), BaseTestData.PolygonPointTest},
            new object[] {5, new Point(9,8), BaseTestData.PolygonPointTest},
            new object[] {3, new Point(8,1), BaseTestData.PolygonPointTest}
        };
    
    public static IEnumerable<object[]> PointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {0, new Point(4.5, 8), BaseTestData.MultiPolygonPointTest},
            new object[] {0, new Point(11, 9), BaseTestData.MultiPolygonPointTest},
            new object[] {2, new Point(2, 9), BaseTestData.MultiPolygonPointTest},
            new object[] {3, new Point(8, 2), BaseTestData.MultiPolygonPointTest},
            new object[] {5, new Point(14, 2), BaseTestData.MultiPolygonPointTest}
        };
}