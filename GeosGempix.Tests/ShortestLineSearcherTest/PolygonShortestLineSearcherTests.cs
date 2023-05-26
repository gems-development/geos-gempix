using GeosGempix.Extensions;
using GeosGempix.Tests.ShortestLineSearcherTest.TestData;

namespace GeosGempix.Tests.ShortestLineSearcherTest;

public class PolygonShortestLineSearcherTests
{
    [Theory]
    [MemberData(nameof(PolygonShortestLineSearcherTestData.PolygonAndPoint), MemberType = typeof(PolygonShortestLineSearcherTestData))]
    public void GetShortestLineBetweenPolygonAndPoint(Polygon polygon, Point point)
    {
        //Act.
        var shortestLine = PolygonShortestLineSearcher.GetShortestLine(polygon, point)!;
        //Assert.
        Assert.Equal(740.5981140416561,shortestLine.GetLength());
    }
}