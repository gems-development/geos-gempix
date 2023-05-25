using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class MultiPolygonToucherTestData
{
    public static IEnumerable<object[]> MultiPolygonAndMultiPolygon =>
        new List<object[]>
        {
            new object[]
            {
                true,
                BaseTestData.MultiPolygon,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(13,13), new Point(13,15), new Point(15,15), 
                                new Point(15,13), new Point(13,13))
                        },
                        new Point(12,12), new Point(12,16), new Point(16,16),
                        new Point(16,12), new Point(12,12)),
                    
                    TestHelper.CreatePolygon(
                        new Point(11,2), new Point(11,7), new Point(16,7),
                        new Point(16,2), new Point(11,2))
                )
            }
        };
}