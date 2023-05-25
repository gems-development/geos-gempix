using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class BaseTestData
{
    public static MultiPoint MultiPointPointTest = TestHelper.CreateMultiPoint(
        new Point(0, 0), new Point(2, 2), new Point(5, 0));
    
    public static MultiPoint MultiPointMultiPointTest = TestHelper.CreateMultiPoint(
        new Point(0, 2), new Point(2, 0), new Point(4, 2));

    public static MultiLine MultiLinePointTest = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(3,1,7,2), TestHelper.CreateLine(2,4,7,4), TestHelper.CreateLine(4,8,5,5));
    
    public static Contour Contour = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 5), new Point(3, 3),
        new Point(5, 5), new Point(5, 0), new Point(0, 0));
    
    public static Polygon Polygon = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(
                new Point(3, 3), new Point(3, 6), new Point(6, 6),
                new Point(6, 3), new Point(3, 3))
        },
        new Point(0, 0), new Point(0, 9), new Point(9, 9),
        new Point(9, 0), new Point(0, 0));

    public static MultiPolygon MultiPolygon = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2, 6), new Point(6, 6),
                    new Point(6, 2), new Point(2,2))
            },
            new Point(0, 0), new Point(0, 8), new Point(8, 8),
            new Point(8, 0), new Point(0, 0)),

        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2,12), new Point(2,16), new Point(6,16),
                    new Point(6,12), new Point(2,12))
            },
            new Point(0, 10), new Point(0, 18), new Point(8, 18),
            new Point(8, 10), new Point(0, 10)),

        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(12,12), new Point(12,16), new Point(16,16),
                    new Point(16,12), new Point(12,12))
            },
            new Point(10,10), new Point(10,18), new Point(18,18),
            new Point(18,10), new Point(10,10)));
}