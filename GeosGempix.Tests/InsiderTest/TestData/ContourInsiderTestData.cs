using GeosGempix.Models;

namespace GeosGempix.Tests.InsiderTest.TestData;

public class ContourInsiderTestData
{
    public static IEnumerable<object[]> ContourAndPoint =>
        new List<object[]>
        {
            new object[] {true, BaseTestData.Contour, new Point(3, 3)},
            new object[] {false, BaseTestData.Contour, new Point(0, 3)},
            new object[] {false, BaseTestData.Contour, new Point(10, 3)}
        };
    
    public static IEnumerable<object[]> ContourAndLine =>
        new List<object[]>
        {
            new object[] {true, BaseTestData.Contour, TestHelper.CreateLine(1,1,8,8)},
            new object[] {false, BaseTestData.Contour, TestHelper.CreateLine(5,5,10,5)},
            new object[] {false, BaseTestData.Contour, TestHelper.CreateLine(3,0,6,0)},
            new object[] {false, BaseTestData.Contour, TestHelper.CreateLine(3,10,6,10)}
        };
    
    public static IEnumerable<object[]> ContourAndLineInternal =>
        new List<object[]>
        {
            new object[] {false, BaseTestData.ContourLineInternalTest, TestHelper.CreateLine(0,0,3,2)},
            new object[] {false, BaseTestData.ContourLineInternalTest, TestHelper.CreateLine(0,2,6,2)},
            new object[] {false, BaseTestData.ContourLineInternalTest, TestHelper.CreateLine(1,3,6,3)},
            new object[] {false, BaseTestData.ContourLineInternalTest, TestHelper.CreateLine(1,4,5,4)}
        };
    
    public static IEnumerable<object[]> ContourAndContour =>
        new List<object[]>
        {
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateContour(new Point(3, 3), new Point(3, 6), new Point(6, 6), 
                    new Point(6, 3), new Point(3, 3))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateContour(new Point(7, 3), new Point(7, 6), new Point(10, 6), 
                    new Point(10, 3), new Point(7, 3))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateContour(new Point(3, 10), new Point(3, 13), new Point(6, 10), 
                    new Point(6, 13), new Point(3, 10))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateContour(new Point(3, 9), new Point(3, 12), new Point(6, 9), 
                    new Point(6, 12), new Point(3, 9))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateContour(
                    new Point(3, 6), new Point(3, 9), new Point(6, 9), 
                    new Point(6, 6), new Point(3, 6))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiPoint =>
        new List<object[]>
        {
            new object[]
            {
                true, BaseTestData.Contour, TestHelper.CreateMultiPoint(new Point(3, 5), new Point(7, 5), new Point(5, 3))
            },
            new object[]
            {
                false, BaseTestData.Contour, TestHelper.CreateMultiPoint(new Point(8, 8), new Point(10, 8), new Point(10, 7))
            },
            new object[]
            {
                false, BaseTestData.Contour, TestHelper.CreateMultiPoint(new Point(8, 8), new Point(9, 7), new Point(8, 6))
            }
        };
    
    public static IEnumerable<object[]> ContourAndMultiLine =>
        new List<object[]>
        {
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,2,2,6), TestHelper.CreateLine(2,6,4,6), TestHelper.CreateLine(4,6,3,3))
            },
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiLine(TestHelper.CreateLine(2,6,4,6), TestHelper.CreateLine(4,4,4,1))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(8,2,8,6), TestHelper.CreateLine(8,6,10,6), TestHelper.CreateLine(10,6,9,3))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(10, 2, 10, 6), TestHelper.CreateLine(10, 6, 12, 6), TestHelper.CreateLine(12, 6, 11, 3))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(TestHelper.CreateLine(9,2,9,6), TestHelper.CreateLine(9,6,11,6), TestHelper.CreateLine(11,6,10,3))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(TestHelper.CreateLine(10,3,10,6), TestHelper.CreateLine(11,3,11,6))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(TestHelper.CreateLine(3,3,6,3), TestHelper.CreateLine(5,10,10,5))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(TestHelper.CreateLine(3,3,6,3), TestHelper.CreateLine(6,6,11,6))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiLine(TestHelper.CreateLine(0,6,9,6), TestHelper.CreateLine(4,9,4,0))
            }
        };

    public static IEnumerable<object[]> ContourAndPolygon =>
        new List<object[]>
        {
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreatePolygon(new Point(1, 1), new Point(1, 4), new Point(4, 4),
                    new Point(4, 1), new Point(1, 1))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreatePolygon(new Point(0,0), new Point(0,4), new Point(4,4), 
                    new Point(4,0), new Point(0,0))
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreatePolygon(new Point(7,7), new Point(7,12), new Point(12,12), 
                    new Point(12,7), new Point(7,7))
            }
        };

    public static IEnumerable<object[]> ContourAndMultiPolygon =>
        new List<object[]>
        {
            new object[]
            {
                true, BaseTestData.Contour,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(2, 2), new Point(2, 3), new Point(3, 3), new Point(3, 2), new Point(2, 2))
                        },
                        new Point(1, 1), new Point(1, 4), new Point(4, 4), new Point(4, 1), new Point(1, 1)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(6, 2), new Point(6, 3), new Point(7, 3), new Point(7, 2), new Point(6, 2))
                        },
                        new Point(5, 1), new Point(5, 4), new Point(8, 4), new Point(8, 1), new Point(5, 1)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(6, 6), new Point(6, 7), new Point(7, 7), new Point(7, 6), new Point(6, 6))
                        },
                        new Point(5, 5), new Point(5, 8), new Point(8, 8), new Point(8, 5), new Point(5, 5))
                )
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(6,2), new Point(6,3), new Point(7,3), new Point(7,2), new Point(6,2))
                        },
                        new Point(5,1), new Point(5,4), new Point(8,4), new Point(8,1), new Point(5,1)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(11,2), new Point(11,3), new Point(12,3), new Point(12,2), new Point(11,2))
                        },
                        new Point(10,1), new Point(10,4), new Point(13,4), new Point(13,1), new Point(10,1)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(11,6), new Point(11,7), new Point(12,7), new Point(12,6), new Point(11,6))
                        },
                        new Point(10,5), new Point(10,8), new Point(13,8), new Point(13,5), new Point(10,5))
                )
            },
            new object[]
            {
                false, BaseTestData.Contour,
                TestHelper.CreateMultiPolygon(
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(3,3), new Point(3,6), new Point(6,6), new Point(6,3), new Point(3,3))
                        },
                        new Point(0,0), new Point(0,9), new Point(9,9), new Point(9,0), new Point(0,0)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(11,2), new Point(11,3), new Point(12,3), new Point(12,2), new Point(11,2))
                        },
                        new Point(10,1), new Point(10,4), new Point(13,4), new Point(13,1), new Point(10,1)),
            
                    TestHelper.CreatePolygon(
                        new List<Contour>
                        {
                            TestHelper.CreateContour(
                                new Point(11,6), new Point(11,7), new Point(12,7), new Point(12,6), new Point(11,6))
                        },
                        new Point(10,5), new Point(10,8), new Point(13,8), new Point(13,5), new Point(10,5))
                )
            }
        };
}