using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class PolygonDistanceCalculatorTestData
{
    public static IEnumerable<object[]> PolygonAndPolygon =>
        new List<object[]>
        {
            new object[]
            {
                0,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,7), new Point(7,7),
                            new Point(7,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,10), new Point(10,10),
                    new Point(10,0), new Point(0,0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(4,4), new Point(4,6), new Point(6,6),
                            new Point(6,4), new Point(4,4))
                    },
                    new Point(3,3), new Point(3,7), new Point(7,7),
                    new Point(7,3), new Point(3,3))
            },
            
            new object[]
            {
                0,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,7), new Point(7,7),
                            new Point(7,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,10), new Point(10,10),
                    new Point(10,0), new Point(0,0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(13,3), new Point(13,7), new Point(17,7),
                            new Point(17,3), new Point(13,3))
                    },
                    new Point(10,0), new Point(10,10), new Point(20,10),
                    new Point(20,0), new Point(10,0))
            },
            
            new object[]
            {
                0,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,7), new Point(7,7),
                            new Point(7,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,10), new Point(10,10),
                    new Point(10,0), new Point(0,0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,7), new Point(7,7),
                            new Point(7,3), new Point(3,3))
                    },
                    new Point(2,2), new Point(2,8), new Point(8,8),
                    new Point(8,2), new Point(2,2))
            },
            
            new object[]
            {
                0,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(5,3), new Point(5,8), new Point(10,8),
                            new Point(10,3), new Point(5,3))
                    },
                    new Point(0,0), new Point(0,10), new Point(10,10),
                    new Point(10,0), new Point(0,0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(9,5), new Point(9,6), new Point(10,6),
                            new Point(10,5), new Point(9,5))
                    },
                    new Point(8,4), new Point(8,7), new Point(11,7),
                    new Point(11,4), new Point(8,4))
            },
            
            new object[]
            {
                1,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(2,2), new Point(2,8), new Point(8,8),
                            new Point(8,2), new Point(2,2))
                    },
                    new Point(0,0), new Point(0,10), new Point(10,10),
                    new Point(10,0), new Point(0,0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(4,5), new Point(4,6), new Point(5,6),
                            new Point(5,5), new Point(4,5))
                    },
                    new Point(3,4), new Point(3,7), new Point(6,7),
                    new Point(6,4), new Point(3,4))
            },
            
            new object[]
            {
                5,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,7), new Point(7,7),
                            new Point(7,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,10), new Point(10,10),
                    new Point(10,0), new Point(0,0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(15,14), new Point(15,15), new Point(16,15),
                            new Point(16,14), new Point(15,14))
                    },
                    new Point(14,13), new Point(14,16), new Point(17,16),
                    new Point(17,13), new Point(14,13))
            },
        };

    public static IEnumerable<object[]> PolygonAndMultiPolygon =>
        new List<object[]>
        {
            new object[]
            {
                0, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(11,6), new Point(11,7), new Point(12,7),
                            new Point(12,6), new Point(11,6))
                    },
                    new Point(4,4), new Point(4,14), new Point(14,14),
                    new Point(14,4), new Point(4,4)),
                BaseTestData.MultiPolygonMultiPointTest2
            },
            
            new object[]
            {
                0, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(18,18), new Point(18,19), new Point(19,19),
                            new Point(19,18), new Point(18,18))
                    },
                    new Point(17,17), new Point(17,20), new Point(20,20),
                    new Point(20,17), new Point(17,17)),
                BaseTestData.MultiPolygonMultiPointTest2
            },
            
            new object[]
            {
                0, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(19,7), new Point(19,9), new Point(21,9),
                            new Point(21,7), new Point(19,7))
                    },
                    new Point(18,6), new Point(18,10), new Point(22,10),
                    new Point(22,6), new Point(18,6)),
                BaseTestData.MultiPolygonMultiPointTest2
            },
            
            new object[]
            {
                1, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3.5,13.5), new Point(3.5,14.5), new Point(4.5,14.5),
                            new Point(4.5,13.5), new Point(3.5,13.5))
                    },
                    new Point(3,13), new Point(3,15), new Point(5,15),
                    new Point(5,13), new Point(3,13)),
                BaseTestData.MultiPolygonMultiPointTest2
            },
            
            new object[]
            {
                2, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(11,3), new Point(11,5), new Point(13,5),
                            new Point(13,3), new Point(11,3))
                    },
                    new Point(10,2), new Point(10,6), new Point(14,6),
                    new Point(14,2), new Point(10,2)),
                BaseTestData.MultiPolygonMultiPointTest2
            },
            
            new object[]
            {
                5, TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(23,5), new Point(23,6), new Point(24,6),
                            new Point(24,5), new Point(23,5))
                    },
                    new Point(22,4), new Point(22,7), new Point(25,7),
                    new Point(25,4), new Point(22,4)),
                BaseTestData.MultiPolygonMultiPointTest2
            },
        };
}