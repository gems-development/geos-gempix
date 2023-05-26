using GeosGempix.Models;

namespace GeosGempix.Tests.IntersectorTest.TestData;

public class MultiPolygonIntersectorTestData
{
    public static IEnumerable<object[]> MultiPolygonAndMultiPolygon =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(11,2), new Point(11,7), new Point(16,7),
                                new Point(16,2), new Point(11,2))
                        },
                        new Point(0,0), new Point(0,9), new Point(18,9),
                        new Point(18,0), new Point(0,0)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,14), new Point(3,17), new Point(6,17),
                                new Point(6,14), new Point(3,14))
                        },
                        new Point(0,11), new Point(0,20), new Point(9,20),
                        new Point(9,11), new Point(0,11))
                ),
                
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(13,4), new Point(13,5), new Point(14,5), 
                                new Point(14,4), new Point(13,4))
                        },
                        new Point(12,3), new Point(12,6), new Point(15,6),
                        new Point(15,3), new Point(12,3)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(12,14), new Point(12,15), new Point(14,15),
                                new Point(14,14), new Point(12,14))
                        },
                        new Point(11,13), new Point(11,16), new Point(15,16),
                        new Point(15,13), new Point(11,13))
                )
            },
            
            
            new object[]
            {
                true,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,3), new Point(3,6), new Point(6,6),
                                new Point(6,3), new Point(3,3))
                        },
                        new Point(0,0), new Point(0,9), new Point(9,9),
                        new Point(9,0), new Point(0,0)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,14), new Point(3,17), new Point(6,17),
                                new Point(6,14), new Point(3,14))
                        },
                        new Point(0,11), new Point(0,20), new Point(9,20),
                        new Point(9,11), new Point(0,11))
                ),
                
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(14,3), new Point(14,6), new Point(17,6), 
                                new Point(17,3), new Point(14,3))
                        },
                        new Point(11,0), new Point(11,9), new Point(20,9),
                        new Point(20,0), new Point(11,0)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(12,14), new Point(12,15), new Point(14,15),
                                new Point(14,14), new Point(12,14))
                        },
                        new Point(9,13), new Point(9,16), new Point(15,16),
                        new Point(15,13), new Point(9,13))
                )
            },
            
            new object[]
            {
                false,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,3), new Point(3,6), new Point(6,6),
                                new Point(6,3), new Point(3,3))
                        },
                        new Point(0,0), new Point(0,9), new Point(9,9),
                        new Point(9,0), new Point(0,0)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(25,3), new Point(25,6), new Point(28,6),
                                new Point(28,3), new Point(25,3))
                        },
                        new Point(22,0), new Point(22,9), new Point(31,9),
                        new Point(31,0), new Point(22,0))
                ),
                
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(14,3), new Point(14,6), new Point(17,6), 
                                new Point(17,3), new Point(14,3))
                        },
                        new Point(11,0), new Point(11,9), new Point(20,9),
                        new Point(20,0), new Point(11,0)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(36,3), new Point(36,6), new Point(39,6),
                                new Point(39,3), new Point(36,3))
                        },
                        new Point(33,0), new Point(33,9), new Point(42,9),
                        new Point(42,0), new Point(33,0))
                )
            }
        };
}