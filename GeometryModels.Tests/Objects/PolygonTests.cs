public class PolygonTests
{
    [Fact]
    public void CreatePolygon_Success()
    {
        //Arrage.
        public Point point1 = new Point(1, 3);
        public Point point2 = new Point(2, 5);
        public Point point3 = new Point(3, 6);
        public Polygon polygon1 = new Polygon(point1, point2, point3);
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
        public Point point2 = new Point(2, 5);
        public Point point3 = new Point(3, 6);
        public Polygon polygon1 = new Polygon();
        public Polygon polygon2 = polygon1;
        //Act.
        double square = polygon2.GetSquare();
        //Assert.
        Assert.Equal(square, polygon1.GetSquare());
    }
    

    [Fact]
    public void PointsDimensions_Succes()
    {
        //Arrage.
        public Polygon polygon = new Polygon();
        //Act.
        double dimension = polygon.GetDimension();
        //Assert.
        Assert.Equal(dimension, 2);
    }

}
