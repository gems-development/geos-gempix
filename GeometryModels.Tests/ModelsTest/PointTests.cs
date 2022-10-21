namespace GeometryModels.Tests.ModelsTest
{
    public class PointTests
    {
        [Fact]
        public void CreatePoint_Success()
        {
            //Arrage.
            Point point = new Point(1, 3);
            //Act. + Assert.
            Assert.Equal(1, point.X);
        }
        [Fact]
        public void EqualsPoints_Success()
        {
            //Arrage.
            Point point1 = new Point(0, 0);
            Point point2 = new Point(1, 1);
            //Act.
            point2 = new Point(point1);
            //Assert.
            Assert.Equal(0, point2.X);
        }
        [Fact]
        public void EqualPoints_Success()
        {
            //Arrage.
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 1);
            //Act. + Assert.
            Assert.True(point2.Equals(point1));
        }
    }
}