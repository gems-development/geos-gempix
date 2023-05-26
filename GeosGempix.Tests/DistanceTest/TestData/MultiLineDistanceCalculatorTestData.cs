using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class MultiLineDistanceCalculatorTestData
{
    public static IEnumerable<object[]> MultiLineAndMultiLine =>
        new List<object[]>
        {     
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,3,3,3), TestHelper.CreateLine(3,3,6,3), TestHelper.CreateLine(6,3,6,0)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,1,4,1), TestHelper.CreateLine(4,1,7,1), TestHelper.CreateLine(7,1,7,4))
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,2,0), TestHelper.CreateLine(2,0,4,0), TestHelper.CreateLine(7,0,7,2)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,2,2,2), TestHelper.CreateLine(2,2,4,2), TestHelper.CreateLine(6,1,8,1))
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,0,2), TestHelper.CreateLine(0,0,3,0), TestHelper.CreateLine(3,0,6,0)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,3,3,3), TestHelper.CreateLine(3,3,6,3), TestHelper.CreateLine(6,0,6,3))
            },
            new object[]
            {
                3, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,3,3,3), TestHelper.CreateLine(3,3,6,3), TestHelper.CreateLine(6,3,9,3)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,0,5,0), TestHelper.CreateLine(5,0,8,0), TestHelper.CreateLine(8,0,11,0))
            },
            new object[]
            {
                5, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,3,3,3), TestHelper.CreateLine(3,0,3,3), TestHelper.CreateLine(3,3,6,3)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(10,0,13,0), TestHelper.CreateLine(13,0,13,3), TestHelper.CreateLine(13,0,16,0))
            },
            new object[]
            {
                2, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,0,3,3), TestHelper.CreateLine(3,3,3,6), TestHelper.CreateLine(9,1,9,4)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,0,3), TestHelper.CreateLine(0,3,0,6), TestHelper.CreateLine(7,1,7,4))
            }
        };

    public static IEnumerable<object[]> MultiLineAndPolygon =>
        new List<object[]>
        {
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,3,1,5), TestHelper.CreateLine(3,7,5,7), TestHelper.CreateLine(7,3,7,5)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(5,3,5,5), TestHelper.CreateLine(7,3,7,5), TestHelper.CreateLine(9,3,9,5)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,3,0,5), TestHelper.CreateLine(2,3,2,5), TestHelper.CreateLine(7,3,7,5)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,5,3,9), TestHelper.CreateLine(4,3,4,5), TestHelper.CreateLine(10,2,10,6)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,0,8), TestHelper.CreateLine(2,2,2,6), TestHelper.CreateLine(4,3,4,5)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,0,8), TestHelper.CreateLine(2,2,2,6), TestHelper.CreateLine(6,2,6,6)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(4,3,4,5), TestHelper.CreateLine(4,6,4,8), TestHelper.CreateLine(10,3,10,6)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                0, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(-1,4,10,4), TestHelper.CreateLine(4,3,4,5), TestHelper.CreateLine(11,2,11,6)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                1, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,3,3,5), TestHelper.CreateLine(4,3,4,5), TestHelper.CreateLine(5,3,5,5)),
                BaseTestData.PolygonMultiPointTest
            },
            new object[]
            {
                5, TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(12,11,13,11), TestHelper.CreateLine(12,11,12,12), TestHelper.CreateLine(12,12,13,12)),
                BaseTestData.PolygonMultiPointTest
            },
        };
}