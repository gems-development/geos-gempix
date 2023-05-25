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
            new object[] {0, TestHelper.CreateLine(1,0,3,0), BaseTestData.ContourLineTest},
            new object[] {0, TestHelper.CreateLine(2,2,6,2), BaseTestData.ContourLineTest},
            new object[] {0, TestHelper.CreateLine(4,3,7,3), BaseTestData.ContourLineTest},
            new object[] {0, TestHelper.CreateLine(1,1,1,2), BaseTestData.ContourLineTest},
            new object[] {1, TestHelper.CreateLine(5,1,7,4), BaseTestData.ContourLineTest},
            new object[] {5, TestHelper.CreateLine(8,7,9,6), BaseTestData.ContourLineTest}
        };
    
    public static IEnumerable<object[]> LineAndMultiPoint =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(0,3,3,3), BaseTestData.MultiPointLineTest},
            new object[] {1, TestHelper.CreateLine(0,2,3,2), BaseTestData.MultiPointLineTest},
            new object[] {5, TestHelper.CreateLine(5,6,6,6), BaseTestData.MultiPointLineTest}
        };
    
    public static IEnumerable<object[]> LineAndMultiLine =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(0,1,6,1), BaseTestData.MultiLineLineTest},
            new object[] {0, TestHelper.CreateLine(4,1,6,1), BaseTestData.MultiLineLineTest},
            new object[] {0, TestHelper.CreateLine(4,3,5,3), BaseTestData.MultiLineLineTest},
            new object[] {1, TestHelper.CreateLine(3,0,4,0), BaseTestData.MultiLineLineTest},
            new object[] {2, TestHelper.CreateLine(7,1,7,4), BaseTestData.MultiLineLineTest}
        };
    
    public static IEnumerable<object[]> LineAndPolygon =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(1,1,1,6), BaseTestData.PolygonLineTest},
            new object[] {0, TestHelper.CreateLine(-1,4,3,4), BaseTestData.PolygonLineTest},
            new object[] {0, TestHelper.CreateLine(1,4,6,4), BaseTestData.PolygonLineTest},
            new object[] {1, TestHelper.CreateLine(3,3,4,4), BaseTestData.PolygonLineTest},
            new object[] {2, TestHelper.CreateLine(9,5,11,3), BaseTestData.PolygonLineTest},
            new object[] {2, TestHelper.CreateLine(9,0,12,0), BaseTestData.PolygonLineTest},
            new object[] {5, TestHelper.CreateLine(11,10,11,12), BaseTestData.PolygonLineTest}
        };
    
    public static IEnumerable<object[]> LineAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {0, TestHelper.CreateLine(6,6,8,8), BaseTestData.MultiPolygonLineTest},
            new object[] {0, TestHelper.CreateLine(4,13,8,13), BaseTestData.MultiPolygonLineTest},
            new object[] {0, TestHelper.CreateLine(15,10,15,15), BaseTestData.MultiPolygonLineTest},
            new object[] {1, TestHelper.CreateLine(3,12,4,12), BaseTestData.MultiPolygonLineTest},
            new object[] {5, TestHelper.CreateLine(20,19,21,20), BaseTestData.MultiPolygonLineTest},
            new object[] {1, TestHelper.CreateLine(17,10,21,13), BaseTestData.MultiPolygonLineTest},
            new object[] {3, TestHelper.CreateLine(10,3,14,3), BaseTestData.MultiPolygonLineTest}
        };
}