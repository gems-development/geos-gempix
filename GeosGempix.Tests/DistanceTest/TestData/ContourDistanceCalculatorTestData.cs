using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest.TestData;

public class ContourDistanceCalculatorTestData
{
    public static IEnumerable<object[]> ContourAndContour =>
    	    new List<object[]>
    	    {     
    		    new object[]
    		    {
    			    0, BaseTestData.ContourContourTest,
                    TestHelper.CreateContour(new Point(3,-3), new Point(3,2), new Point(8,2),
    				    new Point(8,-3), new Point(3,-3))
    		    },
    		    new object[]
    		    {
    			    0, BaseTestData.ContourContourTest,
                    TestHelper.CreateContour(new Point(5,5), new Point(5,10), new Point(10,10),
    				    new Point(10,5), new Point(5,5))
    		    },
    		    new object[]
    		    {
    			    0, BaseTestData.ContourContourTest, 
                    TestHelper.CreateContour(new Point(5,0), new Point(5,5), new Point(10,5),
    				    new Point(10,0), new Point(5,0))
    		    },
    		    new object[]
    		    {
    			    0, BaseTestData.ContourContourTest,
                    TestHelper.CreateContour(new Point(0,0), new Point(0,5), new Point(5,5),
    				    new Point(5,0), new Point(0,0))
    		    },
    		    new object[]
    		    {
    			    0, BaseTestData.ContourContourTest, 
                    TestHelper.CreateContour(new Point(2,2), new Point(2,3), new Point(3,3),
    				    new Point(3,2), new Point(2,2))
    		    },
    		    new object[]
    		    {
    			    0, BaseTestData.ContourContourTest, 
                    TestHelper.CreateContour(new Point(3,3), new Point(3,4), new Point(4,4),
    				    new Point(4,3), new Point(3,3))
    		    },
    		    new object[]
    		    {
    			    3, BaseTestData.ContourContourTest, 
                    TestHelper.CreateContour(new Point(8,-1), new Point(8,4), new Point(13,4),
    				    new Point(13,-1), new Point(8,-1))
    		    },
    		    new object[]
    		    {
    			    5, BaseTestData.ContourContourTest, 
                    TestHelper.CreateContour(new Point(9,8), new Point(9,13), new Point(14,13),
    				    new Point(14,8), new Point(9,8))
    		    },
    	    };
    
    public static IEnumerable<object[]> ContourAndMultiPoint =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest, TestHelper.CreateMultiPoint(new Point(2,2), new Point(3,5), new Point(4,2))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest, TestHelper.CreateMultiPoint(new Point(2,3), new Point(3,6), new Point(4,3))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest, TestHelper.CreateMultiPoint(new Point(2,1), new Point(3,4), new Point(4,1))
		    },
		    new object[]
		    {
			    1, BaseTestData.ContourContourTest, TestHelper.CreateMultiPoint(new Point(6,1), new Point(7,4), new Point(8,1))
		    },
		    new object[]
		    {
			    5, BaseTestData.ContourContourTest, TestHelper.CreateMultiPoint(new Point(9,8), new Point(9,10), new Point(12,9))
		    }
	    };
    
    public static IEnumerable<object[]> ContourAndMultiLine =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest,
			    TestHelper.CreateMultiLine(
				    TestHelper.CreateLine(4,1,4,4), TestHelper.CreateLine(6,4,8,4), TestHelper.CreateLine(9,1,9,3))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest,
			    TestHelper.CreateMultiLine(
				    TestHelper.CreateLine(5, 1, 5, 4), TestHelper.CreateLine(7,4,9,4), TestHelper.CreateLine(10,1,10,3))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest,
			    TestHelper.CreateMultiLine(
				    TestHelper.CreateLine(1, 1, 4, 1), TestHelper.CreateLine(1,2,1,4), TestHelper.CreateLine(3,3,4,3))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest,
			    TestHelper.CreateMultiLine(
				    TestHelper.CreateLine(5, 5, 5, 8), TestHelper.CreateLine(7,8,9,8), TestHelper.CreateLine(10,5,10,7))
		    },
		    new object[]
		    {
			    5, BaseTestData.ContourContourTest,
			    TestHelper.CreateMultiLine(
				    TestHelper.CreateLine(9, 8, 9, 11), TestHelper.CreateLine(11,11,11,13), TestHelper.CreateLine(14,8,14,10))
		    },
		    new object[]
		    {
			    3, BaseTestData.ContourContourTest,
			    TestHelper.CreateMultiLine(
				    TestHelper.CreateLine(8, 0, 8, 3), TestHelper.CreateLine(10,3,12,3), TestHelper.CreateLine(13, 0, 13, 2))
		    }
	    };
    
    public static IEnumerable<object[]> ContourAndPolygon =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest,
			    TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(new Point(2,2), new Point(2,3), new Point(3,3),
						    new Point(3,2), new Point(2,2))
				    },
				    new Point(0,0), new Point(0,5), new Point(5,5),
				    new Point(5,0), new Point(0,0))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest, 
			    TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(new Point(2,2), new Point(2,3), new Point(3,3),
						    new Point(3,2), new Point(2,2))
				    },
				    new Point(1,1), new Point(1,4), new Point(4,4),
				    new Point(4,1), new Point(1,1))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest, 
			    TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(new Point(6,6), new Point(6,7), new Point(7,7),
						    new Point(7,6), new Point(6,6))
				    },
				    new Point(5,5), new Point(5,8), new Point(8,8),
				    new Point(8,5), new Point(5,5))
		    },
		    new object[]
		    {
			    0, BaseTestData.ContourContourTest, 
			    TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(new Point(5,6), new Point(5,7), new Point(6,7),
						    new Point(6,6), new Point(5,6))
				    },
				    new Point(6,3), new Point(3,6), new Point(6,9),
				    new Point(9,6), new Point(6,3))
		    },
		    new object[]
		    {
			    5, BaseTestData.ContourContourTest,
			    TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(new Point(10,9), new Point(10,10), new Point(11,10),
						    new Point(11,9), new Point(10,9))
				    },
				    new Point(9,8), new Point(9,11), new Point(12,11),
				    new Point(12,8), new Point(9,8))
		    },
		    new object[]
		    {
			    3, BaseTestData.ContourContourTest, 
			    TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(new Point(9,2), new Point(9,3), new Point(10,3),
						    new Point(10,2), new Point(9,2))
				    },
				    new Point(8,1), new Point(8,4), new Point(11,4),
				    new Point(11,1), new Point(8,1))
		    },
	    };
    
    public static IEnumerable<object[]> ContourAndMultiPolygon =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(2,12), new Point(2,16), new Point(6,16),
				    new Point(6,12), new Point(2,12)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(0,0), new Point(0,8), new Point(8,8),
				    new Point(8,0), new Point(0,0)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(14,14), new Point(14,16), new Point(16,16),
				    new Point(16,14), new Point(14,14)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(18,8), new Point(18,10), new Point(20,10),
				    new Point(20,8), new Point(18,8)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(5,13), new Point(5,15), new Point(13,13),
				    new Point(13,15), new Point(5,13)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(5,3), new Point(5,5), new Point(9,5),
				    new Point(9,3), new Point(5,3)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(new Point(-2,-2), new Point(-2,19), new Point(20,19),
				    new Point(20,-2), new Point(-2,-2)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    1, TestHelper.CreateContour(new Point(3,14), new Point(3,15), new Point(4,15),
				    new Point(4,13), new Point(3,14)),
			    BaseTestData.MultiPolygonContourTest
		    },
		    new object[]
		    {
			    5, TestHelper.CreateContour(new Point(22,4), new Point(22,7), new Point(25,7),
				    new Point(25,4), new Point(22,4)),
			    BaseTestData.MultiPolygonContourTest
		    },
	    };
}