using GeosGempix.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeosGempix.Models;

namespace GeosGempix.Tests.DistanceTest
{
    public class PolygonDistanceCalculatorTests
    {
        // Проверка на растояние между полигоном и полигоном
        [Theory]
        [InlineData(0, new double[]{0,0,0,10,10,10,10,0,3,3,3,7,7,7,7,3}, new double[]{3,3,3,7,7,7,7,3,4,4,4,6,6,6,6,4})] //failed
        [InlineData(0, new double[]{0,0,0,10,10,10,10,0,3,3,3,7,7,7,7,3}, new double[]{10,0,10,10,20,10,20,0,13,3,13,7,17,7,17,3})]
        [InlineData(0, new double[]{0,0,0,10,10,10,10,0,3,3,3,7,7,7,7,3}, new double[]{2,2,2,8,8,8,8,2,3,3,3,7,7,7,7,3})]
        [InlineData(0, new double[]{0,0,0,10,10,10,10,0,5,3,5,8,10,8,10,3}, new double[]{8,4,8,7,11,7,11,4,9,5,9,6,10,6,10,5})]
        [InlineData(1, new double[]{0,0,0,10,10,10,10,0,2,2,2,8,8,8,8,2}, new double[]{3,4,3,7,6,7,6,4,4,5,4,6,5,6,5,5})] //failed
        [InlineData(5, new double[]{0,0,0,10,10,10,10,0,3,3,3,7,7,7,7,3}, new double[]{14,13,14,16,17,16,17,13,15,14,15,15,16,15,16,14})]
        public void GetDistanceBetweenPolygonAndPolygon_Success(double res, double[] a, double[] b)
        {
            //Arrange.
            var contour1 = TestHelper.CreateContour(
                new Point(a[8], a[9]),
                new Point(a[10], a[11]),
                new Point(a[12], a[13]),
                new Point(a[14], a[15]),
                new Point(a[8], a[9]));
			
            var contours1 = new List<Contour>{ contour1 };
			
            var polygon1 = TestHelper.CreatePolygon(
                contours1,
                new Point(a[0], a[1]),
                new Point(a[2], a[3]),
                new Point(a[4], a[5]),
                new Point(a[6], a[7]),
                new Point(a[0], a[1]));
            
            var contour2 = TestHelper.CreateContour(
                new Point(b[8], b[9]),
                new Point(b[10], b[11]),
                new Point(b[12], b[13]),
                new Point(b[14], b[15]),
                new Point(b[8], b[9]));
			
            var contours2 = new List<Contour>{ contour2 };
			
            var polygon2 = TestHelper.CreatePolygon(
                contours2,
                new Point(b[0], b[1]),
                new Point(b[2], b[3]),
                new Point(b[4], b[5]),
                new Point(b[6], b[7]),
                new Point(b[0], b[1]));
            
            //Act. + Assert.
            Assert.Equal(res,polygon1.GetDistance(polygon2));
        }
        
        // Проверка на растояние между полигоном и мультиполигоном
        [Theory]
        [InlineData(0, new double[]{4,4,4,14,14,14,14,4}, new double[]{11,6,11,7,12,7,12,6})]
        [InlineData(0, new double[]{17,17,17,20,20,20,20,17}, new double[]{18,18,18,19,19,19,19,18})]
        [InlineData(0, new double[]{18,6,18,10,22,10,22,6}, new double[]{19,7,19,9,21,9,21,7})]
        [InlineData(1, new double[]{3,13,3,15,5,15,5,13}, new double[]{3.5,13.5,3.5,14.5,4.5,14.5,4.5,13.5})] //failed
        [InlineData(2, new double[]{10,2,10,6,14,6,14,2}, new double[]{11,3,11,5,13,5,13,3})] //failed
        [InlineData(5, new double[]{22,4,22,7,25,7,25,4}, new double[]{23,5,23,6,24,6,24,5})]
        public void GetDistanceBetweenPolygonAndMultiPolygon_Success(double res, double[] a, double[] b)
        {
            //Arrange.
            var contour = TestHelper.CreateContour(
                new Point(b[0], b[1]),
                new Point(b[2], b[3]),
                new Point(b[4], b[5]),
                new Point(b[6], b[7]),
                new Point(b[0], b[1]));
			
            var contours = new List<Contour>{ contour };
			
            var polygon = TestHelper.CreatePolygon(
                contours,
                new Point(a[0], a[1]),
                new Point(a[2], a[3]),
                new Point(a[4], a[5]),
                new Point(a[6], a[7]),
                new Point(a[0], a[1]));
            
            //полигон 1
            var contour1 = TestHelper.CreateContour(
                new Point(2, 2),
                new Point(2, 6),
                new Point(6, 6),
                new Point(6, 2),
                new Point(2, 2));
            	
            var contours1 = new List<Contour>{ contour1 };
            	
            var polygon1 = TestHelper.CreatePolygon(
                contours1,
                new Point(0, 0),
                new Point(0, 8),
                new Point(8, 8),
                new Point(8, 0),
                new Point(0, 0));
            	
            //полигон 2
            var contour2 = TestHelper.CreateContour(
                new Point(2, 12),
                new Point(2, 16),
                new Point(6, 16),
                new Point(6, 12),
                new Point(2, 12));
            	
            var contours2 = new List<Contour>{ contour2 };
            	
            var polygon2 = TestHelper.CreatePolygon(
                contours2,
                new Point(0, 10),
                new Point(0, 18),
                new Point(8, 18),
                new Point(8, 10),
                new Point(0, 10));
            	
            //полигон 3
            var contour3 = TestHelper.CreateContour(
                new Point(12, 12),
                new Point(12, 16),
                new Point(16, 16),
                new Point(16, 12),
                new Point(12, 12));
            	
            var contours3 = new List<Contour>{ contour3 };
            	
            var polygon3 = TestHelper.CreatePolygon(
                contours3,
                new Point(10, 10),
                new Point(10, 18),
                new Point(18, 18),
                new Point(18, 10),
                new Point(10, 10));
            	
            var multiPolygon = TestHelper.CreateMultiPolygon(polygon1, polygon2, polygon3);
            
            //Act. + Assert.
            Assert.Equal(res,multiPolygon.GetDistance(polygon));
        }
    }
}
