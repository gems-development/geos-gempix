namespace GeosGempix.Tests.IntersectorTest.TestData;

public class LineIntersectorTestData
{
    public static IEnumerable<object[]> LineAndLine =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(4,4,4,7), TestHelper.CreateLine(2,4,7,4)},
            new object[] {true, TestHelper.CreateLine(3,4,7,4), TestHelper.CreateLine(2,4,4,4)},
            new object[] {false, TestHelper.CreateLine(2,6,7,6), TestHelper.CreateLine(2,4,7,4)}
        };
    
    public static IEnumerable<object[]> LineAndContour =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(5,5,7,5), TestData._contour},
            new object[] {true, TestHelper.CreateLine(8,5,10,5), TestData._contour},
            new object[] {true, TestHelper.CreateLine(-1,5,10,5), TestData._contour},
            new object[] {true, TestHelper.CreateLine(0,5,9,5), TestData._contour},
            new object[] {false, TestHelper.CreateLine(10,3,10,7), TestData._contour}
        };
    
    public static IEnumerable<object[]> LineAndMultiPoint =>
        new List<object[]>
        {
            new object[] 
            {
                true, TestHelper.CreateLine(3,6,7,6), 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5))
            },
            new object[]
            {
                false, TestHelper.CreateLine(2,5,7,5), 
                TestHelper.CreateMultiPoint(new Point(3,3), new Point(5,6), new Point(6,4))
            },
            new object[]
            {
                false, TestHelper.CreateLine(2,2,7,2), 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5))
            }
        };
    
    public static IEnumerable<object[]> LineAndMultiLine =>
        new List<object[]>
        {
            new object[]
            {
                true, TestHelper.CreateLine(3,2,3,7), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            },
            new object[]
            {
                true, TestHelper.CreateLine(2,8,7,8), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            },
            new object[]
            {
                false, TestHelper.CreateLine(2,2,5,3), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            }
        };
    
    public static IEnumerable<object[]> LineAndPolygon =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(-1,4,4,4), TestData._polygon},
            new object[] {true, TestHelper.CreateLine(4,3,4,6), TestData._polygon},
            new object[] {true, TestHelper.CreateLine(4,4,5,4), TestData._polygon},
            new object[] {true, TestHelper.CreateLine(9,4,11,4), TestData._polygon},
            new object[] {false, TestHelper.CreateLine(10,3,10,6), TestData._polygon}
        };
    
    public static IEnumerable<object[]> LineAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateLine(4,15,5,15), TestData._multiPolygon},
            new object[] {true, TestHelper.CreateLine(15,18,15,21), TestData._multiPolygon},
            new object[] {true, TestHelper.CreateLine(0,4,0,6), TestData._multiPolygon},
            new object[] {false, TestHelper.CreateLine(10,15,10,16), TestData._multiPolygon}
        };
}