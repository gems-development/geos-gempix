namespace GeometryModels.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void DistanceForTwoPoints_Success()
        {
            //Arrage.
            public Point point1 = new Point(0, 0);
            public Point point2 = new Point(4, 3);
            //Act.
            double distance = DistanceBetweenObjects.GetDistanceBetweenPoints(point1, point2);
            //Assert.
            Assert.Equal(distance, 5);
        }

        [Fact]
        public void DistanceForTwoLineStrings_Success()
        {
            //Arrage.
            public Point point1 = new Point(0, 0);
            public Point point2 = new Point(4, 3);
            public Point point3 = new Point(0, 1);
            public Point point4 = new Point(4, 4);
            public LineStrings linestring1 = new LineStrings(point1, point2);
            public LineStrings lineString2 = new lineStrings(point3, point4);
            //Act.
            double distance = DistanceBetweenObjects.GetDistanceBetweenLineStrings(linestrings1, linestrings2);
            //Assert.
            Assert.Equal(distance, Math.Sqrt(2));
        }

        [Fact]
        public void DistanceBetweenPointAndLineString_Success()
        {
            //Arrage.
            public Point point1 = new Point(0, 0);
            public Point point2 = new Point(1, 1);
            public Point point3 = new Point(5, 1);
            public LineStrings linestring1 = new LineStrings(point1, point2);
            //Act.
            double distance = DistanceBetweenObjects.GetDistanceBetweenPointAndLineString(point3, linestrings1);
            //Assert.
            Assert.Equal(distance, 5);
        }
    }
}