using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceCalculatorTests
{
	private Contour _contour;

	public ContourDistanceCalculatorTests()
	{
		_contour = TestHelper.CreateContour(
			new Point(0, 0), new Point(0, 5), new Point(5, 5),
			new Point(5, 0), new Point(0, 0));
	}

	//Проверка на расстояние между контуром и контуром
    public static IEnumerable<object[]> Data0 =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(3,-3), new Point(3,2), new Point(8,2),
				    new Point(8,-3), new Point(3,-3))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(5,5), new Point(5,10), new Point(10,10),
				    new Point(10,5), new Point(5,5))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(5,0), new Point(5,5), new Point(10,5),
				    new Point(10,0), new Point(5,0))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(0,0), new Point(0,5), new Point(5,5),
				    new Point(5,0), new Point(0,0))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(2,2), new Point(2,3), new Point(3,3),
				    new Point(3,2), new Point(2,2))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(3,3), new Point(3,4), new Point(4,4),
				    new Point(4,3), new Point(3,3))
		    },
		    new object[]
		    {
			    3, TestHelper.CreateContour(
				    new Point(8,-1), new Point(8,4), new Point(13,4),
				    new Point(13,-1), new Point(8,-1))
		    },
		    new object[]
		    {
			    5, TestHelper.CreateContour(
				    new Point(9,8), new Point(9,13), new Point(14,13),
				    new Point(14,8), new Point(9,8))
		    },
	    };
    
    [Theory]
    [MemberData(nameof(Data0))]
    public void GetDistanceBetweenContourAndContour(double res, Contour contour2)
    {
        //Arrange.
        var tests = new ContourDistanceCalculatorTests();
        //Act. + Assert.
        Assert.Equal(res,tests._contour.GetDistance(contour2));
    }
    
    //Проверка на расстояние между контуром и мультиточкой
    [Theory]
    [InlineData(new double[]{2, 2, 3, 5, 4, 2}, 0)]
    [InlineData(new double[]{2, 3, 3, 6, 4, 3}, 0)]
    [InlineData(new double[]{2, 1, 3, 4, 4, 1}, 0)]
    [InlineData(new double[]{6, 1, 7, 4, 8, 1}, 1)]
    [InlineData(new double[]{9, 8, 9, 10, 12, 9}, 5)]
    public void GetDistanceBetweenContourAndMultiPoint_Success(double[] a, double res)
    {
	    //Arrange.
	    var multiPoint = TestHelper.CreateMultiPoint(
		    new Point(a[0], a[1]),
		    new Point(a[2], a[3]),
		    new Point(a[4], a[5]));
	    
	    var tests = new ContourDistanceCalculatorTests();
	    //Act. + Assert.
	    Assert.Equal(res,tests._contour.GetDistance(multiPoint));
    }
    
    //Проверка на расстояние между контуром и мультилинией
    [Theory]
    [InlineData(new double[]{4, 1, 4, 4}, new double[]{6, 4, 8, 4}, new double[]{9, 1, 9, 3}, 0)] 
    [InlineData(new double[]{5, 1, 5, 4}, new double[]{7, 4, 9, 4}, new double[]{10, 1, 10, 3}, 0)]
    [InlineData(new double[]{1, 1, 4, 1}, new double[]{1, 2, 1, 4}, new double[]{3, 3, 4 ,3}, 0)] 
    [InlineData(new double[]{5, 5, 5, 8}, new double[]{7, 8, 9, 8}, new double[]{10, 5, 10, 7}, 0)]
    [InlineData(new double[]{9, 8, 9, 11}, new double[]{11, 11, 11, 13}, new double[]{14, 8, 14, 10}, 5)]
    [InlineData(new double[]{8, 0, 8, 3}, new double[]{10, 3, 12, 3}, new double[]{13, 0, 13, 2}, 3)]
    public void GetDistanceBetweenContourAndMultiLine_Success(double[] a, double[] b, double[] c, double res)
    {
	    //Arrange.
	    var multiLine = TestHelper.CreateMultiLine(
		    TestHelper.CreateLine(a[0], a[1], a[2], a[3]),
		    TestHelper.CreateLine(b[0], b[1], b[2], b[3]),
		    TestHelper.CreateLine(c[0], c[1], c[2], c[3]));

	    var tests = new ContourDistanceCalculatorTests();
	    //Act. + Assert.
	    Assert.Equal(res,tests._contour.GetDistance(multiLine));
    }
    
    //Проверка на расстояние между контуром и полигоном
    public static IEnumerable<object[]> Data1 =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(
						    new Point(2,2), new Point(2,3), new Point(3,3),
						    new Point(3,2), new Point(2,2))
				    },
				    new Point(0,0), new Point(0,5), new Point(5,5),
				    new Point(5,0), new Point(0,0))
		    },
		    new object[]
		    {
			    0, TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(
						    new Point(2,2), new Point(2,3), new Point(3,3),
						    new Point(3,2), new Point(2,2))
				    },
				    new Point(1,1), new Point(1,4), new Point(4,4),
				    new Point(4,1), new Point(1,1))
		    },
		    new object[]
		    {
			    0, TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(
						    new Point(6,6), new Point(6,7), new Point(7,7),
						    new Point(7,6), new Point(6,6))
				    },
				    new Point(5,5), new Point(5,8), new Point(8,8),
				    new Point(8,5), new Point(5,5))
		    },
		    new object[]
		    {
			    0, TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(
						    new Point(5,6), new Point(5,7), new Point(6,7),
						    new Point(6,6), new Point(5,6))
				    },
				    new Point(6,3), new Point(3,6), new Point(6,9),
				    new Point(9,6), new Point(6,3))
		    },
		    new object[]
		    {
			    5, TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(
						    new Point(10,9), new Point(10,10), new Point(11,10),
						    new Point(11,9), new Point(10,9))
				    },
				    new Point(9,8), new Point(9,11), new Point(12,11),
				    new Point(12,8), new Point(9,8))
		    },
		    new object[]
		    {
			    3, TestHelper.CreatePolygon(
				    new List<Contour>
				    {
					    TestHelper.CreateContour(
						    new Point(9,2), new Point(9,3), new Point(10,3),
						    new Point(10,2), new Point(9,2))
				    },
				    new Point(8,1), new Point(8,4), new Point(11,4),
				    new Point(11,1), new Point(8,1))
		    },
	    };
    
    [Theory]
    [MemberData(nameof(Data1))]
    public void GetDistanceBetweenContourAndPolygon_Success(double res, Polygon polygon)
    {
	    //Arrange.
	    var tests = new ContourDistanceCalculatorTests();
	    //Act. + Assert.
	    Assert.Equal(res,tests._contour.GetDistance(polygon));
    }

    public static IEnumerable<object[]> Data2 =>
	    new List<object[]>
	    {     
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(2,12), new Point(2,16), new Point(6,16),
				    new Point(6,12), new Point(2,12))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(0,0), new Point(0,8), new Point(8,8),
				    new Point(8,0), new Point(0,0))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(14,14), new Point(14,16), new Point(16,16),
				    new Point(16,14), new Point(14,14))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(18,8), new Point(18,10), new Point(20,10),
				    new Point(20,8), new Point(18,8))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(5,13), new Point(5,15), new Point(13,13),
				    new Point(13,15), new Point(5,13))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(5,3), new Point(5,5), new Point(9,5),
				    new Point(9,3), new Point(5,3))
		    },
		    new object[]
		    {
			    0, TestHelper.CreateContour(
				    new Point(-2,-2), new Point(-2,19), new Point(20,19),
				    new Point(20,-2), new Point(-2,-2))
		    },
		    new object[]
		    {
			    1, TestHelper.CreateContour(
				    new Point(3,14), new Point(3,15), new Point(4,15),
				    new Point(4,13), new Point(3,14))
		    },
		    new object[]
		    {
			    5, TestHelper.CreateContour(
				    new Point(22,4), new Point(22,7), new Point(25,7),
				    new Point(25,4), new Point(22,4))
		    },
	    };
    
    [Theory]
    [MemberData(nameof(Data2))]
    public void GetDistanceBetweenContourAndMultiPolygon_Success(double res, Contour contour)
    {
	    //Arrange.
	    var multiPolygon = TestHelper.CreateMultiPolygon(
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
	    
	    //Act. + Assert.
	    Assert.Equal(res,contour.GetDistance(multiPolygon));
    }
}