public class PointTests
{
    [Fact]
    public void CreatePoint_Success()
    {
        //Arrage.
        public Point point1 = new Point(1, 3);
        //Act.
        double y = point1.GetY();
        //Assert.
        Assert.Equal(y, 3);
    }

    [Fact]
    public void AssignPoint_Success()
    {
        //Arrage.
        public Point point1 = new Point(1, 3);
        public Point point2 = point1;
        //Act.
        double y = point2.GetY();
        //Assert.
        Assert.Equal(y, 3);
    }
    

    [Fact]
    public void PointsDimensions_Succes()
    {
        //Arrage.
        public Point point1 = new Point(1, 3);
        //Act.
        double dimension = point1.GetDimension();
        //Assert.
        Assert.Equal(dimension, 2);
    }
}
