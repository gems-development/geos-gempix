using GeosGempix.Extensions;
using GeosGempix.Models;

namespace GeosGempix.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void DistanceForTwoPoints_Success()
        {
            //Arrange.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(4, 3);
            //Act.
            double distance = DistanceExtension.GetDistance(point1, point2);
            //Assert.
            Assert.Equal(5, distance);
        }

        [Fact]
        public void DistanceBetweenPointAndLine_Success()
        {
            //Arrange.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 1);
            Point point3 = new Point(5, 1);
            Line line1 = new Line(point1, point2);
            //Act.
            double distance = DistanceExtension.GetDistance(point3, line1);
            //Assert.
            Assert.Equal(4, distance);
        }
    }
}