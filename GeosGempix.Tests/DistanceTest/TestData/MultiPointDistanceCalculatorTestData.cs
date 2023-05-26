using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class MultiPointDistanceCalculatorTestData
{
    public static IEnumerable<object[]> MultiPointAndMultiPoint =>
        new List<object[]>
        {     
            new object[]
            {
                0, TestHelper.CreateMultiPoint(new Point(0,0), new Point(2,2), new Point(4,0)),
                TestHelper.CreateMultiPoint(new Point(0,0), new Point(2,2), new Point(4,0))
            },
            new object[]
            {
                0, TestHelper.CreateMultiPoint(new Point(0,0), new Point(2,2), new Point(4,0)),
                TestHelper.CreateMultiPoint(new Point(4,0), new Point(6,2), new Point(8,0))
            },
            new object[]
            {
                0, TestHelper.CreateMultiPoint(new Point(0,0), new Point(2,2), new Point(4,0)),
                TestHelper.CreateMultiPoint(new Point(2,2), new Point(4,0), new Point(6,2))
            },
            new object[]
            {
                5, TestHelper.CreateMultiPoint(new Point(0,0), new Point(2,2), new Point(4,0)),
                TestHelper.CreateMultiPoint(new Point(6,5), new Point(7,5), new Point(8,5))
            },
            new object[]
            {
                1, TestHelper.CreateMultiPoint(new Point(0,0), new Point(6,7), new Point(14,0)),
                TestHelper.CreateMultiPoint(new Point(2,2), new Point(6,6), new Point(10,0))
            }
        };
    
    public static IEnumerable<object[]> MultiPointAndMultiLine =>
        new List<object[]>
        {     
            new object[]
            {
                0, TestHelper.CreateMultiPoint(new Point(0,3), new Point(1,0), new Point(2,3)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,0,2,3), TestHelper.CreateLine(3,3,5,3), TestHelper.CreateLine(6,0,6,2))
            },
            new object[]
            {
                0, TestHelper.CreateMultiPoint(new Point(0,3), new Point(1,0), new Point(2,3)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,1,2,4), TestHelper.CreateLine(3,4,5,4), TestHelper.CreateLine(6,1,6,3))
            },
            new object[]
            {
                1, TestHelper.CreateMultiPoint(new Point(0,3), new Point(1,0), new Point(3,3)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,2,2,4), TestHelper.CreateLine(5,4,7,4), TestHelper.CreateLine(8,2,8,4))
            },
            new object[]
            {
                5, TestHelper.CreateMultiPoint(new Point(0,2), new Point(1,0), new Point(2,2)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(6,5,6,7), TestHelper.CreateLine(7,5,9,5), TestHelper.CreateLine(10,5,10,7))
            },
            new object[]
            {
                1, TestHelper.CreateMultiPoint(new Point(2,0), new Point(3,3), new Point(4,0)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,2,0,4), TestHelper.CreateLine(1,2,4,2), TestHelper.CreateLine(5,2,5,4))
            }
        };
    
    public static IEnumerable<object[]> MultiPointAndPolygonLieOn =>
        new List<object[]>
        {     
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 15), new Point(8, 14), new Point(9, 15)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,13), new Point(3,16), new Point(6,16),
                            new Point(6,13), new Point(3,13))
                    },
                    new Point(0,10), new Point(0,19), new Point(9,19),
                    new Point(9,10), new Point(0,10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4,6), new Point(4,7), new Point(5,7)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 14), new Point(8, 14), new Point(10, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(15, 15), new Point(17, 17), new Point(17, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4, 0), new Point(4, 3), new Point(4, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 8), new Point(7, 9), new Point(9, 15)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(13, 14), new Point(17, 14), new Point(20, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4, 4), new Point(6, 4), new Point(9, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(1, 14), new Point(3, 14), new Point(5, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(14, 14), new Point(17, 14), new Point(19, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(4, 4), new Point(9, 4), new Point(10, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(6, 15), new Point(7, 14), new Point(9, 13)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3, 13), new Point(3, 16), new Point(6, 16),
                            new Point(6, 13), new Point(3, 13))
                    },
                    new Point(0, 10), new Point(0, 19), new Point(9, 19),
                    new Point(9, 10), new Point(0, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(16, 15), new Point(17, 14), new Point(20, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(7, 5), new Point(9, 4), new Point(10, 4)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(3,3), new Point(3,6), new Point(6,6),
                            new Point(6,3), new Point(3,3))
                    },
                    new Point(0,0), new Point(0,9), new Point(9,9),
                    new Point(9,0), new Point(0,0))
            },
            new object[]
            {
                TestHelper.CreateMultiPoint(new Point(16, 15), new Point(19, 14), new Point(20, 14)),
                TestHelper.CreatePolygon(
                    new List<Contour>
                    {
                        TestHelper.CreateContour(new Point(13, 13), new Point(13, 16), new Point(16, 16),
                            new Point( 16, 13), new Point(13, 13))
                    },
                    new Point(10, 10), new Point(10, 19), new Point(19, 19),
                    new Point(19, 10), new Point(10, 10))
            },
        };

    public static IEnumerable<object[]> MultiPointAndPolygonDontLieOn =>
        new List<object[]>
        {
            new object[] {1, TestHelper.CreateMultiPoint(new Point(4,4), new Point(4,5), new Point(5,5)), BaseTestData.PolygonMultiPointTest},
            new object[] {5, TestHelper.CreateMultiPoint(new Point(12,11), new Point(13,12), new Point(13,11)), BaseTestData.PolygonMultiPointTest},
            new object[] {3, TestHelper.CreateMultiPoint(new Point(11,5), new Point(12,4), new Point(13,5)), BaseTestData.PolygonMultiPointTest},
            new object[] {1, TestHelper.CreateMultiPoint(new Point(5,9), new Point(11,6), new Point(11,0)), BaseTestData.PolygonMultiPointTest}
        };
    
    public static IEnumerable<object[]> MultiPointAndMultiPolygonLieOn =>
        new List<object[]>
        {
            new object[] {TestHelper.CreateMultiPoint(new Point(7,15), new Point(8,14), new Point(9,15)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(4,8), new Point(7,14), new Point(15,12)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(4,7), new Point(4,6), new Point(5,7)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(7,14), new Point(8,14), new Point(10,14)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(15,15), new Point(17,17), new Point(17,14)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(4,0), new Point(4,3), new Point(4,4)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(7,8), new Point(7,9), new Point(9,15)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(13,14), new Point(17,14), new Point(20,14)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(1,14), new Point(3,14), new Point(5,14)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(4,4), new Point(6,4), new Point(9,4)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(14,14), new Point(17,14), new Point(19,14)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(4,4), new Point(9,4), new Point(10,4)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(6,15), new Point(7,14), new Point(9,13)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(16,15), new Point(17,14), new Point(20,14)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(7,5), new Point(9,4), new Point(10,4)), BaseTestData.MultiPolygonMultiPointTest1},
            new object[] {TestHelper.CreateMultiPoint(new Point(16,15), new Point(19,14), new Point(20,14)), BaseTestData.MultiPolygonMultiPointTest1},
        };

    public static IEnumerable<object[]> MultiPointAndMultiPolygonDontLieOn =>
        new List<object[]>
        {
            new object[] {5, TestHelper.CreateMultiPoint(new Point(21,4), new Point(21,6), new Point(22,5)), BaseTestData.MultiPolygonMultiPointTest2},
            new object[] {1, TestHelper.CreateMultiPoint(new Point(4,4), new Point(3,15), new Point(14,14)), BaseTestData.MultiPolygonMultiPointTest2},
            new object[] {1, TestHelper.CreateMultiPoint(new Point(7,9), new Point(10,5), new Point(12,7)), BaseTestData.MultiPolygonMultiPointTest2},
            new object[] {1, TestHelper.CreateMultiPoint(new Point(4,4), new Point(10,5), new Point(12,9)), BaseTestData.MultiPolygonMultiPointTest2}
        };
}