public class PointTests
{
    [Fact]
    public void CreatePoint_Success()
    {
        //Arrange.
        public Point point1 = new Point(1, 3);
    //Act.
        double x = point1.X;
        double y = point1.Y;
        //Assert.
        Assert.Equal(x, 1);
        Assert.Equal(y, 3);
    }

    [Fact]
    public void AssignPoint_Success()
    {
        //Arrange.
        public Point point1 = new Point(1, 3);
        public Point point2 = point1;
        //Act.
        double x = point2.X;
        double y = point2.Y;
        //Assert.
        Assert.Equal(x, 1);
        Assert.Equal(y, 3);
    }
    

    // Что делает тест?
    [Fact]
    public void PointsDimensions_Succes()
    {
        //Arrange.
        public Point point1 = new Point(1, 3);
        //Act.
        double dimension = point1.GetDimension();
        //Assert.
        Assert.Equal(dimension, 2);
    }
}
