using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class BaseTestData
{
    public static Contour ContourPointTest = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 3), new Point(3, 3),
        new Point(3, 0), new Point(0, 0));
    
    public static Contour ContourLineTest = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 4), new Point(4, 4),
        new Point(4, 0), new Point(0, 0));
    
    public static Contour ContourContourTest = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 5), new Point(5, 5),
        new Point(5, 0), new Point(0, 0));
    
    public static Contour ContourDistanceInsideTest = TestHelper.CreateContour(
        new Point(0, 0), new Point(0, 5), new Point(5, 5),
        new Point(5, 0), new Point(0, 0));
    
    public static MultiPoint MultiPointLineTest =
        TestHelper.CreateMultiPoint(new Point(0, 0), new Point(1, 3), new Point(2, 0));

    public static MultiLine MultiLinePointTest = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(0, 0, 3, 0), TestHelper.CreateLine(4, 0, 4, 2), TestHelper.CreateLine(5, 1, 8, 1));
    
    public static MultiLine MultiLineLineTest = TestHelper.CreateMultiLine(
        TestHelper.CreateLine(1, 0, 1, 3), TestHelper.CreateLine(2, 3, 4, 3), TestHelper.CreateLine(5, 0, 5, 2));
    
    public static Polygon PolygonPointTest = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(new Point(1, 1), new Point(1, 4), new Point(4, 4),
                new Point(4, 1), new Point(1, 1))
        },
        new Point(0, 0), new Point(0, 5), new Point(5, 5),
        new Point(5, 0), new Point(0, 0));
    
    public static Polygon PolygonLineTest = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(new Point(2, 2), new Point(2, 5), new Point(5, 5),
                new Point(5, 2), new Point(2, 2))
        },
        new Point(0, 0), new Point(0, 7), new Point(7, 7),
        new Point(7, 0), new Point(0, 0));
    
    public static Polygon PolygonMultiPointTest = TestHelper.CreatePolygon(
        new List<Contour>
        {
            TestHelper.CreateContour(new Point(2, 2), new Point(2, 6), new Point(6, 6),
                new Point(6, 2), new Point(2, 2))
        },
        new Point(0, 0), new Point(0, 8), new Point(8, 8),
        new Point(8, 0), new Point(0, 0));
    
    public static MultiPolygon MultiPolygonPointTest = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(1, 1), new Point(1, 4), new Point(4, 4),
                    new Point(4, 1), new Point(1, 1))
            },
            new Point(0, 0), new Point(0, 5), new Point(5, 5),
            new Point(5, 0), new Point(0, 0)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(1, 7), new Point(1, 10), new Point(4, 10),
                    new Point(4, 7), new Point(1, 7))
            },
            new Point(0, 6), new Point(0, 11), new Point(5, 11),
            new Point(5, 6), new Point(0, 6)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(7, 7), new Point(7, 10), new Point(10, 10),
                    new Point(10, 7), new Point(7, 7))
            },
            new Point(6, 6), new Point(6, 11), new Point(11, 11),
            new Point(11, 6), new Point(6, 6))
    );
    
    public static MultiPolygon MultiPolygonLineTest = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(2, 2), new Point(2, 5), new Point(5, 5),
                    new Point(5, 2), new Point(2, 2))
            },
            new Point(0, 0), new Point(0, 7), new Point(7, 7),
            new Point(7, 0), new Point(0, 0)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(2, 11), new Point(2, 14), new Point(5, 14),
                    new Point(5, 11), new Point(2, 11))
            },
            new Point(0, 9), new Point(0, 16), new Point(7, 16),
            new Point(7, 9), new Point(0, 9)),
				
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(11, 11), new Point(11, 14), new Point(14, 14),
                    new Point(14, 11), new Point(11, 11))
            },
            new Point(9, 9), new Point(9, 16), new Point(16, 16),
            new Point(16, 9), new Point(9, 9))
    );
    
    public static MultiPolygon MultiPolygonContourTest = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2, 2), new Point(2, 6), new Point(6, 6),
                    new Point(6, 2), new Point(2, 2))
            },
            new Point(0, 0), new Point(0, 8), new Point(8, 8),
            new Point(8, 0), new Point(0, 0)),
		    
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(2, 12), new Point(2, 16), new Point(6, 16),
                    new Point(6, 12), new Point(2, 12))
            },
            new Point(0, 10), new Point(0, 18), new Point(8, 18),
            new Point(8, 10), new Point(0, 10)),
		    
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(
                    new Point(11, 11), new Point(11, 14), new Point(14, 14),
                    new Point(14, 11), new Point(11, 11))
            },
            new Point(10, 10), new Point(10, 18), new Point(18, 18),
            new Point(18, 10), new Point(10, 10))
    );
    
    public static MultiPolygon MultiPolygonMultiPointTest1 = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(3, 3), new Point(3, 6), new Point(6, 6),
                    new Point(6, 3), new Point(3, 3))
            },
            new Point(0, 0), new Point(0, 9), new Point(9, 9),
            new Point(9, 0), new Point(0, 0)),
            
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(3, 13), new Point(3, 16), new Point(6, 16),
                    new Point(6, 13), new Point(3, 13))
            },
            new Point(0, 10), new Point(0, 19), new Point(9, 19),
            new Point(9, 10), new Point(0, 10)),
            
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(13, 13), new Point(13, 16), new Point(16, 16),
                    new Point(16, 13), new Point(13, 13))
            },
            new Point(10, 10), new Point(10, 19), new Point(19, 19),
            new Point(19, 10), new Point(10, 10))
    );
    
    public static MultiPolygon MultiPolygonMultiPointTest2 = TestHelper.CreateMultiPolygon(
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(2, 2), new Point(2, 6), new Point(6, 6),
                    new Point(6, 2), new Point(2, 2))
            },
            new Point(0, 0), new Point(0, 8), new Point(8, 8),
            new Point(8, 0), new Point(0, 0)),
            
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(2, 12), new Point(2, 16), new Point(6, 16),
                    new Point(6, 12), new Point(2, 12))
            },
            new Point(0, 10), new Point(0, 18), new Point(8, 18),
            new Point(8, 10), new Point(0, 10)),
            
        TestHelper.CreatePolygon(
            new List<Contour>
            {
                TestHelper.CreateContour(new Point(12, 12), new Point(12, 16), new Point(16, 16),
                    new Point(16, 12), new Point(12, 12))
            },
            new Point(10, 10), new Point(10, 18), new Point(18, 18),
            new Point(18, 10), new Point(10, 10))
    );
}