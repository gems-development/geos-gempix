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
            double distance = GeometryPrimitiveDistanceExtencion.GetDistance(point1, point2);
            //Assert.
            Assert.Equal(distance, 5);
        }

        [Fact]
        public void DistanceForTwoLine_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(4, 3);
            Point point3 = new Point(0, 1);
            Point point4 = new Point(4, 4);
            Line Line1 = new Line(point1, point2);
            Line Line2 = new Line(point3, point4);
            //Act.
            double distance = GeometryPrimitiveDistanceExtencion.GetDistance(Line1, Line2);
            //Assert.
            Assert.Equal(distance, Math.Sqrt(2));
        }

        [Fact]
        public void DistanceBetweenPointAndLine_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 1);
            Point point3 = new Point(5, 1);
            Line Line1 = new Line(point1, point2);
            //Act.
            double distance = GeometryPrimitiveDistanceExtencion.GetDistance(point3, Line1);
            //Assert.
            Assert.Equal(distance, 5);
        }
    }
}