namespace GeosGempix.Tests.IntersectorTest.TestData;

public class ContourIntersectorTestData
{
    public static IEnumerable<object[]> ContourAndContour =>
        new List<object[]>
        {     
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2,12), new Point(12,12),
                    new Point(12,2), new Point(2,2))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateContour(
                    new Point(9,0), new Point(9,9), new Point(18,9),
                    new Point(18,0), new Point(9,0))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2,7), new Point(7,7),
                    new Point(7,2), new Point(2,2))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateContour(
                    new Point(11,0), new Point(11,9), new Point(20,9),
                    new Point(20,0), new Point(11,0))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiPoint =>
        new List<object[]>
        {     
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiPoint(new Point(5,5), new Point(6,7), new Point(7,6))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiPoint(new Point(8,6), new Point(10,7), new Point(10,5))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiPoint(new Point(9,0), new Point(10,2), new Point(11,1))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiPoint(new Point(11,4), new Point(12,7), new Point(14,5))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiLine =>
        new List<object[]>
        {     
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,1,7,2),
                    TestHelper.CreateLine(2,4,7,4),
                    TestHelper.CreateLine(4,8,5,5))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(10,2,13,3),
                    TestHelper.CreateLine(9,4,12,4),
                    TestHelper.CreateLine(11,8,12,5))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(7,4,8,7),
                    TestHelper.CreateLine(10,6,13,5),
                    TestHelper.CreateLine(11,4,12,3))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(10,3,12,2),
                    TestHelper.CreateLine(11,4,14,5),
                    TestHelper.CreateLine(12,8,13,5))
            }
        };
    
    public static IEnumerable<object[]> ContourAndPolygon =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(2,2), new Point(2,11), new Point(11,11),
                    new Point(11,2), new Point(2,2)),
                BaseTestData.Polygon
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(4,4), new Point(4,5), new Point(5,5),
                    new Point(5,4), new Point(4,4)),
                BaseTestData.Polygon
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(9,0), new Point(9,9), new Point(18,9),
                    new Point(18,0), new Point(9,0)),
                BaseTestData.Polygon
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(11,0), new Point(11,9), new Point(20,9),
                    new Point(20,0), new Point(11,0)),
                BaseTestData.Polygon
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultipolygon =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(8,13), new Point(8,18), new Point(12,18),
                    new Point(12,13), new Point(8,13)),
                BaseTestData.MultiPolygon
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(20,9), new Point(20,11), new Point(23,11),
                    new Point(23,9), new Point(20,9)),
                BaseTestData.MultiPolygon
            },
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(4,4), new Point(4,5), new Point(5,5),
                    new Point(5,4), new Point(4,4)),
                BaseTestData.MultiPolygon
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(10,13), new Point(10,18), new Point(12,18),
                    new Point(12,13), new Point(10,13)),
                BaseTestData.MultiPolygon
            }
        };
}