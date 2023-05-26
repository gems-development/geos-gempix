using GeosGempix.Models;

namespace GeosGempix.Tests.ShortestLineSearcherTest.TestData;

public class PolygonShortestLineSearcherTestData
{
    public static IEnumerable<object[]> PolygonAndPoint =>
        new List<object[]>
        {
            new object[]
            {
                TestHelper.CreatePolygon(
                    new Point(8167573.6480276957,7359029.5101273526), 
                    new Point(8167611.8665418429,7359575.332281501), 
                    new Point(8168514.7789384574,7359548.9987604124),
                    new Point(8168490.8923671208,7358878.6908180518), 
                    new Point(8167573.6480276957,7359029.5101273526)),
                
                new Point(8166857.0508875223,7359398.1794956494),
            },
        };
}