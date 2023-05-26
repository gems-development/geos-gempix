using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class MultiPolygonDistanceCalculatorTestData
{
    public static IEnumerable<object[]> MultiPolygonAndMultiPolygon =>
        new List<object[]>
        {
            new object[]
            {
                0, BaseTestData.MultiPolygonMultiPointTest2,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(19,4), new Point(19,5), new Point(20,5),
                                new Point(20,4), new Point(19,4))
                        },
                        new Point(18,3), new Point(18,6), new Point(21,6),
                        new Point(21,3), new Point(18,3)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(19,8), new Point(19,9), new Point(20,9),
                                new Point(20,8), new Point(19,8))
                        },
                        new Point(18,7), new Point(18,10), new Point(21,10),
                        new Point(21,7), new Point(18,7)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(23,8), new Point(23,9), new Point(24,9),
                                new Point(24,8), new Point(23,8))
                        },
                        new Point(22,7), new Point(22,10), new Point(25,10),
                        new Point(25,7), new Point(22,7))
                )
            },
            
            new object[]
            {
                0, BaseTestData.MultiPolygonMultiPointTest2,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(9,3.25), new Point(9,3.75), new Point(10,3.75),
                                new Point(10,3.25), new Point(9,3.25))
                        },
                        new Point(3,4), new Point(3,5), new Point(12,5),
                        new Point(12,4), new Point(3,4)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(3.5,13.5), new Point(3.5,14.5), new Point(4.5,14.5),
                                new Point(4.5,13.5), new Point(3.5,13.5))
                        },
                        new Point(3,13), new Point(3,15), new Point(5,15),
                        new Point(5,13), new Point(3,13)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(13.5,13.5), new Point(13.5,14.5), new Point(14.5,14.5),
                                new Point(14.5,13.5), new Point(13.5,13.5))
                        },
                        new Point(13,13), new Point(13,15), new Point(15,15),
                        new Point(15,13), new Point(13,13))
                )
            },
            
            new object[]
            {
                2, BaseTestData.MultiPolygonMultiPointTest2,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(11,4), new Point(11,5), new Point(12,5),
                                new Point(12,4), new Point(11,4))
                        },
                        new Point(10,3), new Point(10,6), new Point(13,6),
                        new Point(13,3), new Point(10,3)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(11,13), new Point(11,14), new Point(12,14),
                                new Point(12,13), new Point(11,13))
                        },
                        new Point(10,12), new Point(10,15), new Point(13,15),
                        new Point(13,12), new Point(10,12)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(15,4), new Point(15,5), new Point(16,5),
                                new Point(16,4), new Point(15,4))
                        },
                        new Point(14,3), new Point(14,6), new Point(17,6),
                        new Point(17,3), new Point(14,3))
                )
            },
            
            new object[]
            {
                1, BaseTestData.MultiPolygonMultiPointTest2,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(3.5,13.5), new Point(3.5,14.5), new Point(4.5,14.5),
                                new Point(4.5,13.5), new Point(3.5,13.5))
                        },
                        new Point(3,13), new Point(3,15), new Point(5,15),
                        new Point(5,13), new Point(3,13)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(11,2), new Point(11,3), new Point(12,3),
                                new Point(12,2), new Point(11,2))
                        },
                        new Point(10,1), new Point(10,4), new Point(13,4),
                        new Point(13,1), new Point(10,1)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(new Point(15,5), new Point(15,6), new Point(16,6),
                                new Point(16,5), new Point(15,5))
                        },
                        new Point(14,4), new Point(14,7), new Point(17,7),
                        new Point(17,4), new Point(14,4))
                )
            },
        };
}