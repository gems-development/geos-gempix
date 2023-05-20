using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class ContourToucherTestData
{
    public static IEnumerable<object[]> ContourAndContour =>
        new List<object[]>
        {
            new object[]
            {
                true, TestData._contour,
                TestHelper.CreateContour(
                    new Point(0, 5), new Point(0, 10), new Point(3, 8), 
                    new Point(5, 10), new Point(5, 5), new Point(0, 5))
            },
            new object[]
            {
                true, TestData._contour,
                TestHelper.CreateContour(
                    new Point(5, 0), new Point(5, 5), new Point(8, 3), 
                    new Point(10, 5), new Point(10, 0), new Point(5, 0))
            },
            new object[]
            {
                true, TestData._contour,
                TestHelper.CreateContour(
                    new Point(5, 3), new Point(5, 8), new Point(8, 5), 
                    new Point(10, 8), new Point(10, 3), new Point(5, 3))
            },
            new object[]
            {
                false, TestData._contour,
                TestHelper.CreateContour(
                    new Point(0,3), new Point(0,8), new Point(5,8), 
                    new Point(5,3), new Point(0,3)),
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiPoint =>
        new List<object[]>
        {
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiPoint(new Point(3,4), new Point(5,1), new Point(8,2))
            },
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiPoint(new Point(1,4), new Point(5,1), new Point(8,2))
            },
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiPoint(new Point(1,4), new Point(5,1), new Point(5,3))
            },
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiPoint(new Point(5,1), new Point(6,2), new Point(8,4))
            },
            new object[]
            {
                false, TestData._contour, 
                TestHelper.CreateMultiPoint(new Point(2,1), new Point(5,1), new Point(8,1))
            },
            new object[]
            {
                false, TestData._contour, 
                TestHelper.CreateMultiPoint(new Point(1,2), new Point(2,1), new Point(5,1))
            },
        };
    
    public static IEnumerable<object[]> ContourAndMultiLine =>
        new List<object[]>
        {
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,5,4,5), TestHelper.CreateLine(5,1,5,3), TestHelper.CreateLine(7,0,7,4))
            },
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(-2,0,7,0), TestHelper.CreateLine(5,1,5,3), TestHelper.CreateLine(0,5,5,5))
            },
            new object[]
            {
                true, TestData._contour, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,5,5,5), TestHelper.CreateLine(5,1,5,3), TestHelper.CreateLine(6,1,8,3))
            },
            new object[]
            {
                false, TestData._contour, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,5,5), TestHelper.CreateLine(2,0,4,0), TestHelper.CreateLine(5,1,5,3))
            },
            new object[]
            {
                false, TestData._contour, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,0,3), TestHelper.CreateLine(0,5,3,3), TestHelper.CreateLine(2,-2,6,2))
            },
            new object[]
            {
                false, TestData._contour, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,1,3,1), TestHelper.CreateLine(1,-7,5,7), TestHelper.CreateLine(6,1,6,4))
            },
        };
    
    public static IEnumerable<object[]> ContourAndPolygonInside =>
        new List<object[]>
        {     
            new object[]
            {
                TestData._contour,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(0,0), new Point(0,5), new Point(5,5), 
                            new Point(5,0), new Point(0,0))
                    },
                    new Point(-2,-2), new Point(-2,7), new Point(7,7), 
                    new Point(7,-2), new Point(-2,-2))
            },
            
            new object[]
            {
                TestHelper.CreateContour(
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
    
    public static IEnumerable<object[]> ContourAndPolygon =>
        new List<object[]>
        {     
            new object[]
            {
                true, TestData._contour,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(7,2), new Point(7,3), new Point(8,3), 
                            new Point(8,2), new Point(7,2))
                    },
                    new Point(5,0), new Point(5,5), new Point(10,5), 
                    new Point(10,0), new Point(5,0))
            },
            
            new object[]
            {
                true, TestData._contour,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(1,1), new Point(1,2), new Point(2,2), 
                            new Point(2,1), new Point(1,1))
                    },
                    new Point(0,0), new Point(0,3), new Point(3,3), 
                    new Point(3,0), new Point(0,0))
            },
            
            new object[]
            {
                false, TestData._contour,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(7,2), new Point(7,3), new Point(8,3), 
                            new Point(8,2), new Point(7,2))
                    },
                    new Point(9,0), new Point(9,5), new Point(14,5), 
                    new Point(14,0), new Point(9,0))
            },
            
            new object[]
            {
                false, TestData._contour,
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(
                            new Point(7,2), new Point(7,3), new Point(8,3), 
                            new Point(8,2), new Point(7,2))
                    },
                    new Point(1,-1), new Point(1,6), new Point(9,6), 
                    new Point(9,-1), new Point(1,-1))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiPolygon =>
        new List<object[]>
        {
            new object[]
            {
                true,
                TestHelper.CreateContour(
                    new Point(2,12), new Point(2,16), new Point(6,16), 
                    new Point(6,12), new Point(2,12)),
                TestData._multiPolygon
            },
            new object[]
            {
                true, 
                TestHelper.CreateContour(
                    new Point(8,13), new Point(8,15), new Point(10,15), 
                    new Point(10,13), new Point(8,13)),
                TestData._multiPolygon
            },
            new object[]
            {
                true, 
                TestHelper.CreateContour(
                    new Point(8,2), new Point(8,6), new Point(12,6), 
                    new Point(12,2), new Point(8,2)),
                TestData._multiPolygon
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(3,13), new Point(3,15), new Point(5,15), 
                    new Point(5,13), new Point(3,13)),
                TestData._multiPolygon
            },
            new object[]
            {
                false,
                TestHelper.CreateContour(
                    new Point(11,2), new Point(11,6), new Point(15,6), 
                    new Point(15,2), new Point(11,2)),
                TestData._multiPolygon
            },
            new object[]
            {
                false, 
                TestHelper.CreateContour(
                    new Point(1,11), new Point(1,17), new Point(7,17), 
                    new Point(7,11), new Point(1,11)),
                TestData._multiPolygon
            },
        };
}