namespace GeosGempix.Tests.ShortestLineSearcherTest.TestData;

public class LineShortestSearcherTestData
{
    public static IEnumerable<object[]> LineAndPoint =>
        new List<object[]>
        {
            new object[]
            {
                TestHelper.CreateLine(-3,-3,3,3),
                new Point(0, 2)
            },
        };
    
    public static IEnumerable<object[]> LineAndLine =>
        new List<object[]>
        {
            new object[]
            {
                TestHelper.CreateLine(0,0,0,3),
                TestHelper.CreateLine(3,0,3,3)
            },
        };
}