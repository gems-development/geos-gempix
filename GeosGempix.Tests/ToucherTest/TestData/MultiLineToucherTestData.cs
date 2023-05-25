using GeosGempix.Models;

namespace GeosGempix.Tests.ToucherTest.TestData;

public class MultiLineToucherTestData
{
    public static IEnumerable<object[]> MultiLineAndMultiLine =>
        new List<object[]>
        {
            new object[] {true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,9,3,9), TestHelper.CreateLine(3,6,6,6), TestHelper.CreateLine(6,3,9,3)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,6,3,9), TestHelper.CreateLine(6,3,6,6), TestHelper.CreateLine(9,0,9,3))
            },
            new object[] {true, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,4,4,4), TestHelper.CreateLine(2,2,5,2), TestHelper.CreateLine(3,0,6,0)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(6,0,6,9), TestHelper.CreateLine(7,2,10,2), TestHelper.CreateLine(8,4,11,4))
            },
            new object[] {false, 
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,4,4,0), TestHelper.CreateLine(0,2,4,2), TestHelper.CreateLine(0,0,4,0)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,4,4,0), TestHelper.CreateLine(4,2,8,2), TestHelper.CreateLine(6,0,10,0))
            },
            new object[] {false,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(0,4,4,4), TestHelper.CreateLine(0,2,4,2), TestHelper.CreateLine(0,0,4,0)),
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(7,0,11,0), TestHelper.CreateLine(7,2,11,2), TestHelper.CreateLine(7,4,11,4))
            }
        };
    
    public static IEnumerable<object[]> MultiLineAndPolygon =>
        new List<object[]>
        {
            new object[] {true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(3,5,6,5), TestHelper.CreateLine(9,3,9,7), TestHelper.CreateLine(11,1,11,6)),
                TestData._polygon
            },
            new object[] {true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(4,4,5,5), TestHelper.CreateLine(9,4,14,4), TestHelper.CreateLine(11,6,15,6)),
                TestData._polygon
            },
            new object[] {false,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(5,5,11,5), TestHelper.CreateLine(9,7,13,7), TestHelper.CreateLine(12,0,12,3)),
                TestData._polygon
            },
            new object[] {false,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(1,2,1,7), TestHelper.CreateLine(2,9,6,9), TestHelper.CreateLine(11,2,11,6)),
                TestData._polygon
            }
        };
    
    public static IEnumerable<object[]> MultiLineAndMultiPolygon =>
        new List<object[]>
        {
            new object[] {true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(8,2,8,5), TestHelper.CreateLine(8,14,10,14), TestHelper.CreateLine(12,12,16,16)),
                TestData._multiPolygon
            },
            new object[] {true,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(4,12,4,14), TestHelper.CreateLine(8,8,10,10), TestHelper.CreateLine(13,14,15,14)),
                TestData._multiPolygon
            },
            new object[] {false,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(4,6,4,12), TestHelper.CreateLine(7,14,11,14), TestHelper.CreateLine(13,7,13,10)),
                TestData._multiPolygon
            },
            new object[] {false,
                TestHelper.CreateMultiLine(
                    TestHelper.CreateLine(9,13,9,16), TestHelper.CreateLine(11,3,11,7), TestHelper.CreateLine(14,3,14,7)),
                TestData._multiPolygon
            }
        };
}