using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest.TestData;

public class TestData
{
    public static Contour _contour = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 9), new Point(9, 9),
        new Point(9, 0), new Point(0, 0));
    
    public static Polygon _polygon = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(
                new Point(3, 3), new Point(3, 6), new Point(6, 6),
                new Point(6, 3), new Point(3, 3))
        },
        new Point(0, 0), new Point(0, 9), new Point(9, 9),
        new Point(9, 0), new Point(0, 0));
    
    public static MultiPolygon _multiPolygon = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(3, 3), new Point(3, 6), new Point(6, 6),
                    new Point(6, 3), new Point(3, 3))
            },
            new Point(0, 0), new Point(0, 9), new Point(9, 9),
            new Point(9, 0), new Point(0, 0)),
            
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(3, 14), new Point(3, 17), new Point(6, 17),
                    new Point(6, 14), new Point(3, 14))
            },
            new Point(0, 11), new Point(0, 20), new Point(9, 20),
            new Point(9, 11), new Point(0, 11)),
            
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(14,14), new Point(14,17), new Point(17,17),
                    new Point(17,14), new Point(14,14))
            },
            new Point(11,11), new Point(11,20), new Point(20,20),
            new Point(20,11), new Point(11,11))
    );
}