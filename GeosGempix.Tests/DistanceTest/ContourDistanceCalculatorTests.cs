using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.DistanceTest;

public class ContourDistanceCalculatorTests
{
    //Проверка на расстояние между контуром и контуром
    [Fact]
    public void GetDistanceBetweenContourAndContour_Success()
    {
        //Arrange.
        var point1 = new Point(0, 0);
        var point2 = new Point(0, 5);
        var point3 = new Point(5, 5);
        var point4 = new Point(5, 0);
        
        var point11 = new Point(3, -3);
        var point21 = new Point(3, 2);
        var point31 = new Point(8, 2);
        var point41 = new Point(8, -3);
        
        var point12 = new Point(5, 5);
        var point22 = new Point(5, 10);
        var point32 = new Point(10, 10);
        var point42 = new Point(10, 5);
        
        var point13 = new Point(5, 0);
        var point23 = new Point(5, 5);
        var point33 = new Point(10, 5);
        var point43 = new Point(10, 0);
        
        var point14 = new Point(2, 2);
        var point24 = new Point(2, 3);
        var point34 = new Point(3, 3);
        var point44 = new Point(3, 2);
        
        var point15 = new Point(3, 3);
        var point25 = new Point(3, 4);
        var point35 = new Point(4, 4);
        var point45 = new Point(4, 3);
        
        var point16 = new Point(8, -1);
        var point26 = new Point(8, 4);
        var point36 = new Point(13, 4);
        var point46 = new Point(13, -1);
        
        var point17 = new Point(9, 8);
        var point27 = new Point(9, 13);
        var point37 = new Point(14, 13);
        var point47 = new Point(14, 8);

        var points1 = new List<Point>
        {
	        point1,
	        point2,
	        point3,
	        point4,
	        point1
        };
        var contour1 = new Contour(points1);
        
        //1 случай
        var points2 = new List<Point>
        {
         	point11,
         	point21,
         	point31,
         	point41,
         	point11
        };
        var contour2 = new Contour(points2);
        
        //2 случай
        var points3 = new List<Point>
        {
	        point12,
	        point22,
	        point32,
	        point42,
	        point12
        };
        var contour3 = new Contour(points3);
        
        //3 случай
        var points4 = new List<Point>
        {
	        point13,
	        point23,
	        point33,
	        point43,
	        point13
        };
        var contour4 = new Contour(points4);
        
        //4 случай
        var points5 = new List<Point>
        {
	        point14,
	        point24,
	        point34,
	        point44,
	        point14
        };
        var contour5 = new Contour(points5);
        
        //5 случай
        var points6 = new List<Point>
        {
	        point15,
	        point25,
	        point35,
	        point45,
	        point15
        };
        var contour6 = new Contour(points6);
        
        //6 случай
        var points7 = new List<Point>
        {
	        point16,
	        point26,
	        point36,
	        point46,
	        point16
        };
        var contour7 = new Contour(points7);
        
        //6 случай
        var points8 = new List<Point>
        {
	        point17,
	        point27,
	        point37,
	        point47,
	        point17
        };
        var contour8 = new Contour(points8);
        
        //Act. + Assert.
        Assert.Equal(0,contour1.GetDistance(contour2));
        Assert.Equal(0,contour1.GetDistance(contour3));
        Assert.Equal(0,contour1.GetDistance(contour4));
        Assert.Equal(0,contour1.GetDistance(contour1));
        Assert.Equal(2,contour1.GetDistance(contour5));
        Assert.Equal(1,contour1.GetDistance(contour6));
        Assert.Equal(3,contour1.GetDistance(contour7));
        Assert.Equal(5,contour1.GetDistance(contour8));
    }
    
    //Проверка на расстояние между контуром и мультиточкой
    [Fact]
    public void GetDistanceBetweenContourAndMultiPoint_Success()
    {
	    //Arrange.
	    var point1 = new Point(0, 0);
	    var point2 = new Point(0, 5);
	    var point3 = new Point(5, 5);
	    var point4 = new Point(5, 0);
	    
	    var points = new List<Point>
	    {
		    point1,
		    point2,
		    point3,
		    point4,
		    point1
	    };
	    var contour = new Contour(points);
	    
	    //1 случай
	    var point11 = new Point(2, 2);
	    var point21 = new Point(3, 5);
	    var point31 = new Point(4, 2);
	    var points1 = new List<Point>
	    {
		    point11,
		    point21,
		    point31
	    };
	    var multiPoint1 = new MultiPoint(points1);
	    
	    //2 случай
	    var point12 = new Point(2, 3);
	    var point22 = new Point(3, 6);
	    var point32 = new Point(4, 3);
	    var points2 = new List<Point>
	    {
		    point12,
		    point22,
		    point32
	    };
	    var multiPoint2 = new MultiPoint(points2);
	    
	    //3 случай
	    var point13 = new Point(2, 1);
	    var point23 = new Point(3, 4);
	    var point33 = new Point(4, 1);
	    var points3 = new List<Point>
	    {
		    point13,
		    point23,
		    point33
	    };
	    var multiPoint3 = new MultiPoint(points3);
	    
	    //4 случай
	    var point14 = new Point(6, 1);
	    var point24 = new Point(7, 4);
	    var point34 = new Point(8, 1);
	    var points4 = new List<Point>
	    {
		    point14,
		    point24,
		    point34
	    };
	    var multiPoint4 = new MultiPoint(points4);
	    
	    //5 случай
	    var point15 = new Point(9, 8);
	    var point25 = new Point(9, 10);
	    var point35 = new Point(12, 9);
	    var points5 = new List<Point>
	    {
		    point15,
		    point25,
		    point35
	    };
	    var multiPoint5 = new MultiPoint(points5);
	    
	    //Act. + Assert.
	    Assert.Equal(0,contour.GetDistance(multiPoint1));
	    Assert.Equal(0,contour.GetDistance(multiPoint2));
	    Assert.Equal(0,contour.GetDistance(multiPoint3));
	    Assert.Equal(1,contour.GetDistance(multiPoint4));
	    Assert.Equal(5,contour.GetDistance(multiPoint5));
    }
    
    //Проверка на расстояние между контуром и мультилинией
    [Fact]
    public void GetDistanceBetweenContourAndMultiLine_Success()
    {
	    //Arrange.
	    var point1 = new Point(0, 0);
	    var point2 = new Point(0, 5);
	    var point3 = new Point(5, 5);
	    var point4 = new Point(5, 0);
	    
	    var points = new List<Point>
	    {
		    point1,
		    point2,
		    point3,
		    point4,
		    point1
	    };
	    var contour1 = new Contour(points);
	    
	    //1 случай
	    var point11 = new Point(4, 1);
	    var point21 = new Point(4, 4);
	    var point31 = new Point(6, 4);
	    var point41 = new Point(8, 4);
	    var point51 = new Point(9, 1);
	    var point61 = new Point(9, 3);
	    
	    var lineA = new Line(point11, point21);
	    var lineB = new Line(point31, point41);
	    var lineC = new Line(point51, point61);
	    
	    //2 случай
	    var point12 = new Point(5, 1);
	    var point22 = new Point(5, 4);
	    var point32 = new Point(7, 4);
	    var point42 = new Point(9, 4);
	    var point52 = new Point(10, 1);
	    var point62 = new Point(10, 3);
	    
	    var lineD = new Line(point12, point22);
	    var lineE = new Line(point32, point42);
	    var lineF = new Line(point52, point62);
	    
	    //3 случай
	    var point13 = new Point(1, 1);
	    var point23 = new Point(4, 1);
	    var point33 = new Point(1, 2);
	    var point43 = new Point(1, 4);
	    var point53 = new Point(3, 3);
	    var point63 = new Point(4, 3);
	    
	    var lineG = new Line(point13, point23);
	    var lineH = new Line(point33, point43);
	    var lineI = new Line(point53, point63);
	    
	    //4 случай
	    var point14 = new Point(5, 5);
	    var point24 = new Point(5, 8);
	    var point34 = new Point(7, 8);
	    var point44 = new Point(9, 8);
	    var point54 = new Point(10, 5);
	    var point64 = new Point(10, 7);
	    
	    var lineJ = new Line(point14, point24);
	    var lineK = new Line(point34, point44);
	    var lineL = new Line(point54, point64);
	    
	    //5 случай
	    var point15 = new Point(9, 8);
	    var point25 = new Point(9, 11);
	    var point35 = new Point(11, 11);
	    var point45 = new Point(11, 13);
	    var point55 = new Point(14, 8);
	    var point65 = new Point(14, 10);
	    
	    var lineM = new Line(point15, point25);
	    var lineN = new Line(point35, point45);
	    var lineO = new Line(point55, point65);
	    
	    //6 случай
	    var point16 = new Point(8, 0);
	    var point26 = new Point(8, 3);
	    var point36 = new Point(10, 3);
	    var point46 = new Point(12, 3);
	    var point56 = new Point(13, 0);
	    var point66 = new Point(13, 2);
	    
	    var lineP = new Line(point16, point26);
	    var lineQ = new Line(point36, point46);
	    var lineR = new Line(point56, point66);
	    
	    //7 случай
	    var point17 = new Point(8, 0);
	    var point27 = new Point(8, 3);
	    var point37 = new Point(10, 3);
	    var point47 = new Point(12, 3);
	    var point57 = new Point(13, 0);
	    var point67 = new Point(13, 2);
	    
	    var lineS = new Line(point17, point27);
	    var lineT = new Line(point37, point47);
	    var lineU = new Line(point57, point67);
			
	    var lines1 = new List<Line>{ lineA, lineB, lineC };
	    var multiLine1 = new MultiLine(lines1);
	    
	    var lines2 = new List<Line>{ lineD, lineE, lineF };
	    var multiLine2 = new MultiLine(lines2);
	    
	    var lines3 = new List<Line>{ lineG, lineH, lineI };
	    var multiLine3 = new MultiLine(lines3);
	    
	    var lines4 = new List<Line>{ lineJ, lineK, lineL };
	    var multiLine4 = new MultiLine(lines4);
	    
	    var lines5 = new List<Line>{ lineM, lineN, lineO };
	    var multiLine5 = new MultiLine(lines5);
	    
	    var lines6 = new List<Line>{ lineP, lineQ, lineR };
	    var multiLine6 = new MultiLine(lines6);
	    
	    var lines7 = new List<Line>{ lineS, lineT, lineU };
	    var multiLine7 = new MultiLine(lines7);
	    
	    //Act. + Assert.
	    Assert.Equal(0,contour1.GetDistance(multiLine1));
	    Assert.Equal(0,contour1.GetDistance(multiLine2));
	    Assert.Equal(0,contour1.GetDistance(multiLine3));
	    Assert.Equal(0,contour1.GetDistance(multiLine4));
	    Assert.Equal(5,contour1.GetDistance(multiLine5));
	    Assert.Equal(3,contour1.GetDistance(multiLine6));
	    Assert.Equal(2,contour1.GetDistance(multiLine7));
    }
    
    //Проверка на расстояние между контуром и полигоном
    [Fact]
    public void GetDistanceBetweenContourAndPolygon_Success()
    {
	    //Arrange.
	    var point1 = new Point(0, 0);
	    var point2 = new Point(0, 5);
	    var point3 = new Point(5, 5);
	    var point4 = new Point(5, 0);
	    
	    var points = new List<Point>
	    {
		    point1,
		    point2,
		    point3,
		    point4,
		    point1
	    };
	    var contour = new Contour(points);
	    
	    //1 случай
	    var point11 = new Point(0, 0);
	    var point21 = new Point(0, 5);
	    var point31 = new Point(5, 5);
	    var point41 = new Point(5, 0);
	    var points1 = new List<Point>
	    {
		    point11,
		    point21,
		    point31,
		    point41,
		    point11
	    };
			
	    var point61 = new Point(2, 2);
	    var point71 = new Point(2, 3);
	    var point81 = new Point(3, 3);
	    var point91 = new Point(3, 2);
	    var points2 = new List<Point>
	    {
		    point61,
		    point71,
		    point81,
		    point91,
		    point61
	    };
		
	    var contour1 = new Contour(points2);
	    var contours1 = new List<Contour>
	    {
		    contour1
	    };
	    var polygon1 = new Polygon(points1, contours1);
	    
	    //2 случай
	    var point12 = new Point(1, 1);
	    var point22 = new Point(1, 4);
	    var point32 = new Point(4, 4);
	    var point42 = new Point(4, 1);
	    var points3 = new List<Point>
	    {
		    point12,
		    point22,
		    point32,
		    point42,
		    point12
	    };
	    var polygon2 = new Polygon(points3, contours1);
	    
	    //3 случай
	    var point13 = new Point(5, 5);
	    var point23 = new Point(5, 8);
	    var point33 = new Point(8, 8);
	    var point43 = new Point(8, 5);
	    var points4 = new List<Point>
	    {
		    point13,
		    point23,
		    point33,
		    point43,
		    point13
	    };
			
	    var point63 = new Point(6, 6);
	    var point73 = new Point(6, 7);
	    var point83 = new Point(7, 7);
	    var point93 = new Point(7, 6);
	    var points5 = new List<Point>
	    {
		    point63,
		    point73,
		    point83,
		    point93,
		    point63
	    };
		
	    var contour3 = new Contour(points5);
	    var contours3 = new List<Contour>
	    {
		    contour3
	    };
	    var polygon3 = new Polygon(points4, contours3);
	    
	    //Act. + Assert.
	    Assert.Equal(0,contour.GetDistance(polygon1));
	    Assert.Equal(0,contour.GetDistance(polygon2));
	    Assert.Equal(0,contour.GetDistance(polygon3));
    }
}