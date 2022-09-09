public class LineStringTests
{
    [Fact]
    public void CreateLineString_Success()
    {
        //Arrage.
        public Point point1 = new Point(0, 0);
        public Point point2 = new Point(4, 3);
        public LineString lineString = new lineString(point1, point2);
        //Act.
        double length = lineString.Lenght;
        //Assert.
        Assert.Equal(length, 5);
    }

    [Fact]
    public void AssignLineString_Success()
    {
        //Arrage.
        public Point point1 = new Point(0, 0);
        public Point point2 = new Point(4, 3);
        public LineString lineString1 = new lineString(point1, point2);
        //Act.
        public LineString lineString2 = new lineString1;
        double length = lineString2.Length;
        //Assert.
        Assert.Equal(length, LineString1.Length);
    }
    

    [Fact]
    public void LineStringsDimensions_Succes()
    {
        //Arrage.
        public Point point1 = new Point(0, 0);
        public Point point2 = new Point(4, 3);
        public LineString lineString = new lineString(point1, point2);
        //Act.
        double dimension = lineString.GetDimension();
        //Assert.
        Assert.Equal(dimension, 2);
    }
}
