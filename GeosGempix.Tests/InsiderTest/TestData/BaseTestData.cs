using GeosGempix.Models;

namespace GeosGempix.Tests.InsiderTest.TestData;

public class BaseTestData
{
    public static Contour Contour = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 9), new Point(9, 9), 
        new Point(9, 0), new Point(0, 0));
    
    public static Contour ContourLineInternalTest = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 6), new Point(3, 3),
        new Point(6, 6), new Point(6, 0), new Point(0, 0));
}