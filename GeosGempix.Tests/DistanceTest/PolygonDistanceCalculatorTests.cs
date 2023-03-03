using GeosGempix.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Tests.DistanceTest
{
    public class PolygonDistanceCalculatorTests
    {
		// Проверка на растояние между полигоном и точкой
		[Fact]
        public void GetDistanceBetweenPolygonAndPoint_Success()
        {
            //Arrange.
            var point1 = new Point(0, 0);
            var point2 = new Point(0, 3);
            var point3 = new Point(5, 4);
            var point4 = new Point(3, 2);
            var point5 = new Point(0, 0);
            var points = new List<Point>
            {
                point1,
                point2,
                point3,
                point4,
                point5
            };
            var polygon = new Polygon(points);
            
            var point = new Point(2, 2);
            
            //Act. + Assert.
            Assert.Equal(0, polygon.GetDistance(point));
        }
    }
}
