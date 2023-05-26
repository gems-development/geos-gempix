using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class ContourDistanceInsideTestData
{
    public static IEnumerable<object[]> ContourAndPointInside =>
        new List<object[]>
        {     
            new object[] { 2, BaseTestData.ContourDistanceInsideTest, new Point(2,2) },
            new object[] { 0, BaseTestData.ContourDistanceInsideTest, new Point(6,2) }
        };
    
    public static IEnumerable<object[]> ContourAndLineInside =>
        new List<object[]>
        {     
            new object[] { 1, BaseTestData.ContourDistanceInsideTest, TestHelper.CreateLine(1,1,1,4) },
            new object[] { 0, BaseTestData.ContourDistanceInsideTest, TestHelper.CreateLine(1,6,5,6) }
        };
    
    public static IEnumerable<object[]> ContourAndContourInside =>
        new List<object[]>
        {     
            new object[]
            {
                1, BaseTestData.ContourDistanceInsideTest, 
                TestHelper.CreateContour(new Point(2,2), new Point(2,4), new Point(4,4),
                    new Point(4,2), new Point(2,2))
            },
            new object[]
            {
                0, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreateContour(new Point(7,2), new Point(7,4), new Point(9,4),
                    new Point(9,2), new Point(7,2))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiPointInside =>
        new List<object[]>
        {     
            new object[]
            {
                2, BaseTestData.ContourDistanceInsideTest, 
                TestHelper.CreateMultiPoint(new Point(2,2), new Point(3,2), new Point(3,3))
            },
            new object[]
            {
                0, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreateMultiPoint(new Point(6,2), new Point(8,3), new Point(8,4))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiLineInside =>
        new List<object[]>
        {     
            new object[]
            {
                1, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,1,3,2), TestHelper.CreateLine(1,2,3,3), TestHelper.CreateLine(1,3,3,4))
            },
            new object[]
            {
                0, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(6,2,8,3), TestHelper.CreateLine(7,1,9,1), TestHelper.CreateLine(9,2,9,4))
            }
        };
    
    public static IEnumerable<object[]> ContourAndPolygonInside =>
        new List<object[]>
        {     
            new object[]
            {
                1, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(2,2), new Point(2,3), new Point(3,3),
                            new Point(3,2), new Point(2,2))
                    },
                    new Point(1,1), new Point(1,4), new Point(4,4),
                    new Point(4,1), new Point(1,1))
            },
            new object[]
            {
                0, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(10,4), new Point(10,6), new Point(12,6),
                            new Point(12,4), new Point(10,4))
                    },
                    new Point(8,2), new Point(8,8), new Point(14,8),
                    new Point(14,2), new Point(8,2))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiPolygonInside =>
        new List<object[]>
        {     
            new object[]
            {
                1, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new Point(1,1), new Point(1,2), new Point(2,2),
                        new Point(2,1), new Point(1,1)),
		    
                    TestHelper.CreatePolygon(
                        new Point(1,3), new Point(1,4), new Point(2,4),
                        new Point(2,3), new Point(1,3)),
		    
                    TestHelper.CreatePolygon(
                        new Point(3,3), new Point(3,4), new Point(4,4),
                        new Point(4,3), new Point(3,3))
                )
            },
            new object[]
            {
                0, BaseTestData.ContourDistanceInsideTest,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new Point(7,1), new Point(7,2), new Point(8,2),
                        new Point(8,1), new Point(7,1)),
		    
                    TestHelper.CreatePolygon(
                        new Point(7,3), new Point(7,4), new Point(8,4),
                        new Point(8,3), new Point(7,3)),
		    
                    TestHelper.CreatePolygon(
                        new Point(9,3), new Point(9,4), new Point(10,4),
                        new Point(10,3), new Point(9,3))
                )
            }
        };
}