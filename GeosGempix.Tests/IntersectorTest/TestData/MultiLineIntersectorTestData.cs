namespace GeosGempix.Tests.IntersectorTest.TestData;

public class MultiLineIntersectorTestData
{
    public static IEnumerable<object[]> MultiLineAndMultiLine =>
        new List<object[]>
        {
            new object[]
            {
                true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,3,7,3), TestHelper.CreateLine(3,6,7,7), TestHelper.CreateLine(8,7,9,3))
            },
            new object[]
            {
                true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,1,4,3), TestHelper.CreateLine(2,5,2,7), TestHelper.CreateLine(4,4,5,4))
            },
            new object[]
            {
                false, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,3,7,3), TestHelper.CreateLine(2,5,2,7), TestHelper.CreateLine(8,7,9,3))
            }
        };
    
    public static IEnumerable<object[]> MultiLineAndPolygon =>
        new List<object[]>
        {
            new object[]
            {
                true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(-1,5,-1,8), TestHelper.CreateLine(4,5,5,4), TestHelper.CreateLine(10,2,10,5)), 
                TestData._polygon
            },
            new object[]
            {
                true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(-1,5,-1,8), TestHelper.CreateLine(8,5,10,5), TestHelper.CreateLine(10,1,11,4)), 
                TestData._polygon
            },
            new object[]
            {
                false, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(-1,5,-1,8), TestHelper.CreateLine(10,2,10,5), TestHelper.CreateLine(10,1,11,4)), 
                TestData._polygon
            }
        };
    
    public static IEnumerable<object[]> MultiLineAndMultiPolygon =>
        new List<object[]>
        {
            new object[]
            {
                true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(4,15,5,16), TestHelper.CreateLine(14,19,17,19), TestHelper.CreateLine(9,5,11,6)), 
                TestData._multiPolygon
            },
            new object[]
            {
                false, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(-1,9,-1,11), TestHelper.CreateLine(10,14,10,17), TestHelper.CreateLine(13,4,16,7)), 
                TestData._multiPolygon
            }
        };
}