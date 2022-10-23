using GeometryModels;
using GeometryModels.Extensions;
using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Models;

public class LineTests
{
    [Fact]
    public void Createline_Success()
    {
        //Arrage.
        Point point1 = new Point(1, 3);
        Point point2 = new Point(2, 3);
        Line line = new Line(point1, point2);
        //Act. + Assert.
        Assert.Equal(1, line.Point1.X);
    }

    [Fact]
    public void CalculatelineLength_Success()
    {
        //Arrage.
        Point point1 = new Point(0, 0);
        Point point2 = new Point(3, 4);
        Line line = new Line(point1, point2);
        //Act.
        double length = line.GetLength();
        //Assert.
        Assert.Equal(5, length);
    }
    [Fact]
    public void ProofIsIntersection_Success()
    {
        //Arrage.
        Point point1 = new Point(0, 0);
        Point point2 = new Point(3, 3);
        Point point3 = new Point(3, 0);
        Point point4 = new Point(0, 3);
        Line line1 = new Line(point1, point2);
        Line line2 = new Line(point3, point4);
        //Act. + Assert.
        Assert.True(IntersectorExtencion.Intersects(line1, line2));
    }
}
