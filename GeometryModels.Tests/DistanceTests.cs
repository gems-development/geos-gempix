using GeometryModels.Extensions;
using GeometryModels.Models;

namespace GeometryModels.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void DistanceForTwoPoints_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(4, 3);
            //Act.
            double distance = DistanceExtencion.GetDistance(point1, point2);
            //Assert.
            Assert.Equal(5, distance);
        }

        /*
        [Fact]
        public void DistanceForTwoLine_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(4, 3);
            Point point3 = new Point(0, 1);
            Point point4 = new Point(4, 4);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point3, point4);
            //Act.
            double distance = LineDistanceCalculator.GetDistance(line1, line2);
            //Assert.
            Assert.Equal(Math.Sqrt(2), distance);
        }
        */


        [Fact]
        public void DistanceBetweenPointAndLine_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 1);
            Point point3 = new Point(5, 1);
            Line line1 = new Line(point1, point2);
            //Act.
            double distance = DistanceExtencion.GetDistance(point3, line1);
            //Assert.
            Assert.Equal(4, distance);
        }
    }
}