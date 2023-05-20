using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class MultiPointToucherTestData
{
    private static MultiPoint _multiPoint = TestHelper.CreateMultiPoint(
        new Point(0, 2), new Point(2, 0), new Point(4, 2));

    public static IEnumerable<object[]> MultiPointAndMultiPoint =>
        new List<object[]>
        {
            new object[] {true, _multiPoint,
                TestHelper.CreateMultiPoint(
                    new Point(0, 2), new Point(2, 0), new Point(4, 2))},
            new object[] {true, _multiPoint,
                TestHelper.CreateMultiPoint(
                    new Point(0,2), new Point(2,0), new Point(4,0))},
            new object[] {true, _multiPoint,
                TestHelper.CreateMultiPoint(
                    new Point(2,0), new Point(4,0), new Point(6,0))},
            new object[] {false, _multiPoint,
                TestHelper.CreateMultiPoint(
                    new Point(0,0), new Point(2,2), new Point(4,0))}
        };
    
    public static IEnumerable<object[]> MultiPointAndMultiLine =>
        new List<object[]>
        {
            new object[] {true, 
                TestHelper.CreateMultiPoint(
                    new Point(0,6), new Point(2,4), new Point(4,6)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,4,4,4), TestHelper.CreateLine(0,2,4,2), TestHelper.CreateLine(2,0,5,0))
            },
            new object[] {true, 
                TestHelper.CreateMultiPoint(
                    new Point(0,6), new Point(2,4), new Point(4,6)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(2,4,6,4), TestHelper.CreateLine(4,6,8,6), TestHelper.CreateLine(7,0,7,5))
            },
            new object[] {true, 
                TestHelper.CreateMultiPoint(
                    new Point(0,5), new Point(2,2), new Point(5,5)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,0,5), TestHelper.CreateLine(2,2,6,2), TestHelper.CreateLine(5,5,8,5))
            },
            new object[] {false, _multiPoint,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,0,5,0), TestHelper.CreateLine(5,4,9,4), TestHelper.CreateLine(7,0,7,2))
            },
            new object[] {false, _multiPoint,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(6,0,6,2), TestHelper.CreateLine(8,0,8,2), TestHelper.CreateLine(10,0,10,2))
            }
        };
    
    public static IEnumerable<object[]> MultiPointAndPolygon =>
        new List<object[]>
        {
            new object[] {true,
                TestHelper.CreateMultiPoint(
                    new Point(3,4), new Point(4,9), new Point(10,4)),
                TestData._polygon
            },
            new object[] {true,
                TestHelper.CreateMultiPoint(
                    new Point(6,4), new Point(9,9), new Point(9,4)),
                TestData._polygon
            },
            new object[] {true,
                TestHelper.CreateMultiPoint(
                    new Point(4,4), new Point(6,3), new Point(6,6)),
                TestData._polygon
            },
            new object[] {false,
                TestHelper.CreateMultiPoint(
                    new Point(5,4), new Point(7,4), new Point(10,4)),
                TestData._polygon
            },
            new object[] {false,
                TestHelper.CreateMultiPoint(
                    new Point(5,4), new Point(11,4), new Point(11,7)),
                TestData._polygon
            }
        };
    
    public static IEnumerable<object[]> MultiPointAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true,
                TestHelper.CreateMultiPoint(
                    new Point(6,12), new Point(8,4), new Point(10,10)),
                TestData._multiPolygon
            },
            new object[] {true,
                TestHelper.CreateMultiPoint(
                    new Point(0,12), new Point(9,13), new Point(14,13)),
                TestData._multiPolygon
            },
            new object[] {false,
                TestHelper.CreateMultiPoint(
                    new Point(1,14), new Point(9,14), new Point(14,14)),
                TestData._multiPolygon
            },
            new object[] {false,
                TestHelper.CreateMultiPoint(
                    new Point(4,4), new Point(11,5), new Point(4,14)),
                TestData._multiPolygon
            }
        };
}