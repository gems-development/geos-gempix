namespace GeosGempix.Tests.DistanceTest.TestData;

public class CountourDistanceCalculatorTriangleTestData
{
    public static IEnumerable<object[]> ContourAndContourTriangle1 =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateContour(
                    new Point(8167287.0091716265, 7359039.0859560855), 
                    new Point(8167396.8873997889, 7359472.3921513548), 
                    new Point(8167824.4570267573, 7359496.3317170413),
                    new Point(8167287.0091716265, 7359039.0859560855)),
                
                TestHelper.CreateContour(
                    new Point(8167779.0725412127, 7358665.6285971552), 
                    new Point(8167728.9107414037, 7359091.7530131396), 
                    new Point(8168261.5812822646, 7359086.9650989315),
                    new Point(8167779.0725412127, 7358665.6285971552))
            }
        };
    
    public static IEnumerable<object[]> ContourAndContourTriangle2 =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateContour(new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(0, 0)),
                TestHelper.CreateContour(new Point(2, 2), new Point(2, 3), new Point(3, 2), new Point(2, 2))
            }
        };
}