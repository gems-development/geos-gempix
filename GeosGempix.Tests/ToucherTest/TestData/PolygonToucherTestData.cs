using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class PolygonToucherTestData
{
    public static IEnumerable<object[]> PolygonAndPolygon =>
        new List<object[]>
        {     
            new object[]
            {
                true, 
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(2,2), new Point(2,7), new Point(7,7), 
                            new Point(7,2), new Point(2,2))
                    },
                    new Point(0, 0), new Point(0, 9), new Point(9, 9),
                    new Point(9, 0), new Point(0, 0)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(4,4), new Point(4,5), new Point(5,5), 
                            new Point(5,4), new Point(4,4))
                    },
                    new Point(2,2), new Point(2,7), new Point(7,7), 
                    new Point(7,2), new Point(2,2))
            },
            
            new object[]
            {
                true, TestData._polygon,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(12,8), new Point(12,10), new Point(14,10), 
                            new Point(14,8), new Point(12,8))
                    },
                    new Point(9,5), new Point(9,13), new Point(17,13), 
                    new Point(17,5), new Point(9,5))
            },
            
            new object[]
            {
                false, TestData._polygon,
                TestHelper.CreatePolygon(
                    new Point(8,2), new Point(8,7), new Point(13,7), 
                    new Point(13,2), new Point(8,2))
            },
            
            new object[]
            {
                false, TestData._polygon,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(14,4), new Point(14,6), new Point(16,6), 
                            new Point(16,4), new Point(14,4))
                    },
                    new Point(12,2), new Point(12,8), new Point(18,8), 
                    new Point(18,2), new Point(12,2))
            }
        };
    
    public static IEnumerable<object[]> PolygonAndMultiPolygon =>
        new List<object[]>
        {     
            new object[]
            {
                true,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(13,13), new Point(13,15), new Point(15,15), 
                            new Point(15,13), new Point(13,13))
                    },
                    new Point(12,12), new Point(12,16), new Point(16,16),
                    new Point(16,12), new Point(12,12)),
                TestData._multiPolygon
            },
            
            new object[]
            {
                true,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(16,6), new Point(16,8), new Point(18,8), 
                            new Point(18,6), new Point(16,6))
                    },
                    new Point(14,5), new Point(14,10), new Point(20,10),
                    new Point(20,5), new Point(14,5)),
                TestData._multiPolygon
            },
            
            new object[]
            {
                false,
                TestHelper.CreatePolygon(
                    new Point(3,12), new Point(6,12), new Point(6,6),
                    new Point(3,6), new Point(3,12)),
                TestData._multiPolygon
            },
            
            new object[]
            {
                false,
                TestHelper.CreatePolygon(
                    new Point(11,2), new Point(11,7), new Point(16,7),
                    new Point(16,2), new Point(11,2)),
                TestData._multiPolygon
            }
        };
    
    public static IEnumerable<object[]> PolygonAndPolygonInside =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(6,6), new Point(6,8), new Point(8,8), 
                            new Point(8,6), new Point(6,6))
                    },
                    new Point(5, 5), new Point(5, 9), new Point(9, 9), 
                    new Point(9, 5), new Point(5, 5)),
                
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(3,7), new Point(7,3), new Point(11,7), 
                            new Point(7,11), new Point(3,7))
                    },
                    new Point(0,7), new Point(7,0), new Point(14,7), 
                    new Point(7,14), new Point(0,7))
            }
        };
    
    public static IEnumerable<object[]> PolygonAndMultiPolygonInside =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(6,6), new Point(6,8), new Point(8,8), 
                            new Point(8,6), new Point(6,6))
                    },
                    new Point(5, 5), new Point(5, 9), new Point(9, 9), 
                    new Point(9, 5), new Point(5, 5)),
                
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,7), new Point(7,3), new Point(11,7), 
                                new Point(7,11), new Point(3,7))
                        },
                        new Point(0,7), new Point(7,0), new Point(14,7), 
                        new Point(7,14), new Point(0,7)),
		    
                    TestHelper.CreatePolygon(
                        new Point(17,3), new Point(20,6), new Point(23,3),
                        new Point(20,0), new Point(17,3)),
		    
                    TestHelper.CreatePolygon(
                        new Point(17,12), new Point(20,15), new Point(23,12),
                        new Point(20,9), new Point(17,12))
                )
            }
        };
}