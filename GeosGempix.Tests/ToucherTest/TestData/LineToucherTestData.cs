using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class LineToucherTestData
{
    public static IEnumerable<object[]> LineAndLine =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(0,2,5,2), TestHelper.CreateLine(5,2,8,0)},
            new object[] {true, TestHelper.CreateLine(0,0,3,0), TestHelper.CreateLine(2,0,6,0)},
            new object[] {true, TestHelper.CreateLine(0,2,5,2), TestHelper.CreateLine(2,0,2,2)},
            new object[] {false, TestHelper.CreateLine(0,2,4,2), TestHelper.CreateLine(0,0,4,0)},
            new object[] {false, TestHelper.CreateLine(0,3,4,1), TestHelper.CreateLine(0,0,4,4)}
        };
    
    public static IEnumerable<object[]> LineAndContour =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(0,0,5,0), BaseTestData.Contour},
            new object[] {true, TestHelper.CreateLine(0,5,5,5), BaseTestData.Contour},
            new object[] {true, TestHelper.CreateLine(5,1,5,3), BaseTestData.Contour},
            new object[] {false, TestHelper.CreateLine(0,0,5,5), BaseTestData.Contour}
        };
    
    public static IEnumerable<object[]> LineAndMultiPoint =>
        new List<object[]>
        {
            new object[]
            {
                true, TestHelper.CreateLine(0,2,5,2), 
                TestHelper.CreateMultiPoint(new Point(1,2), new Point(2, 2), new Point(3,2))
            },
            new object[]
            {
                true, TestHelper.CreateLine(0,2,5,2), 
                TestHelper.CreateMultiPoint(new Point(1,2), new Point(3,0), new Point(4,2))
            },
            new object[]
            {
                true, TestHelper.CreateLine(0,2,5,2), 
                TestHelper.CreateMultiPoint(new Point(1,0), new Point(1,2), new Point(3,0))
            },
            new object[]
            {
                false, TestHelper.CreateLine(0,2,5,2), 
                TestHelper.CreateMultiPoint(new Point(0,0), new Point(2,3), new Point(4,0))
            }
        };
    
    public static IEnumerable<object[]> LineAndPolygon =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(3,3,6,6), BaseTestData.Polygon},
            new object[] {true, TestHelper.CreateLine(9,2,9,8), BaseTestData.Polygon},
            new object[] {true, TestHelper.CreateLine(7,9,12,9), BaseTestData.Polygon},
            new object[] {true, TestHelper.CreateLine(6,4,6,5), BaseTestData.Polygon},
            new object[] {true, TestHelper.CreateLine(6,-2,11,2), BaseTestData.Polygon},
            new object[] {false, TestHelper.CreateLine(1,4,4,4), BaseTestData.Polygon},
            new object[] {false, TestHelper.CreateLine(4,4,5,5), BaseTestData.Polygon},
            new object[] {false, TestHelper.CreateLine(4,1,8,5), BaseTestData.Polygon},
            new object[] {false, TestHelper.CreateLine(5,5,11,5), BaseTestData.Polygon}
        };
    
    public static IEnumerable<object[]> LineAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(6,8,10,10), BaseTestData.MultiPolygon},
            new object[] {true, TestHelper.CreateLine(5,18,14,18), BaseTestData.MultiPolygon},
            new object[] {false, TestHelper.CreateLine(6,14,12,14), BaseTestData.MultiPolygon},
            new object[] {false, TestHelper.CreateLine(6,4,6,14), BaseTestData.MultiPolygon}
        };
}