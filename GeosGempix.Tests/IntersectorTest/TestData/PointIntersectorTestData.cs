namespace GeosGempix.Tests.IntersectorTest.TestData;

public class PointIntersectorTestData
{
    public static IEnumerable<object[]> PointAndPoint =>
        new List<object[]>
        {
            new object[] {true, new Point(4, 5), new Point(4,5)},
            new object[] {false, new Point(4, 5), new Point(6,6)}
        };
    
    public static IEnumerable<object[]> PointAndLine =>
        new List<object[]>
        {
            new object[] {true, new Point(4,4), TestHelper.CreateLine(2,4,7,4)},
            new object[] {false, new Point(4,7), TestHelper.CreateLine(2,4,7,4)}
        };
    
    public static IEnumerable<object[]> PointAndContour =>
        new List<object[]>
        {
            new object[] {true, new Point(0,5), TestData._contour},
            new object[] {true, new Point(3,5), TestData._contour},
            new object[] {false, new Point(10,7), TestData._contour}
        };
    
    public static IEnumerable<object[]> PointAndMultiPoint =>
        new List<object[]>
        {
            new object[] 
            {
                true, new Point(4,4), 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5))
            },
            new object[]
            {
                true, new Point(5, 6), 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5))
            },
            new object[]
            {
                true, new Point(6, 5), 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5))
            },
            new object[]
            {
                false, new Point(7, 7), 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5))
            }
        };
    
    public static IEnumerable<object[]> PointAndMultiLine =>
        new List<object[]>
        {
            new object[]
            {
                true, new Point(4, 4), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            },
            new object[]
            {
                false, new Point(3, 5), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            }
        };
    
    public static IEnumerable<object[]> PointAndPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(4,4), TestData._polygon},
            new object[] {true, new Point(0,5), TestData._polygon},
            new object[] {true, new Point(4,6), TestData._polygon},
            new object[] {false, new Point(10, 5), TestData._polygon},
        };
    
    public static IEnumerable<object[]> PointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, new Point(3,16), TestData._multiPolygon},
            new object[] {true, new Point(15,20), TestData._multiPolygon},
            new object[] {true, new Point(15,16), TestData._multiPolygon},
            new object[] {true, new Point(3,6), TestData._multiPolygon},
            new object[] {false, new Point(10,16), TestData._multiPolygon},
        };
}