namespace GeosGempix.Tests.IntersectorTest.TestData;

public class MultiPointIntersectorTestData
{
    public static IEnumerable<object[]> MultiPointAndMultiPoint =>
        new List<object[]>
        {
            new object[] 
            {
                true, 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5)), 
                TestHelper.CreateMultiPoint(new Point(6,5), new Point(6,6), new Point(7,5))
            },
            new object[]
            {
                false,
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5)), 
                TestHelper.CreateMultiPoint(new Point(5,5), new Point(7,6), new Point(6,3))
            }
        };
    
    public static IEnumerable<object[]> MultiPointAndMultiLine =>
        new List<object[]>
        {
            new object[]
            {
                true, 
                TestHelper.CreateMultiPoint(new Point(4,4), new Point(5,6), new Point(6,5)), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            },
            new object[]
            {
                false, 
                TestHelper.CreateMultiPoint(new Point(4,3), new Point(4,5), new Point(6,3)), 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5))
            }
        };
    
    public static IEnumerable<object[]> MultiPointAndPolygon =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateMultiPoint(new Point(4,4), new Point(4,11), new Point(10,4)), TestData._polygon},
            new object[] {true, TestHelper.CreateMultiPoint(new Point(0,0), new Point(4,8), new Point(7,5)), TestData._polygon},
            new object[] {false, TestHelper.CreateMultiPoint(new Point(-1,5), new Point(4,11), new Point(10,2)), TestData._polygon}
        };
    
    public static IEnumerable<object[]> MultiPointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true, TestHelper.CreateMultiPoint(new Point(4,15), new Point(10,16), new Point(10,15)), TestData._multiPolygon},
            new object[] {true, TestHelper.CreateMultiPoint(new Point(14,16), new Point(15,19), new Point(21,15)), TestData._multiPolygon},
            new object[] {false, TestHelper.CreateMultiPoint(new Point(4,10), new Point(10,15), new Point(21,16)), TestData._multiPolygon}
        };
}