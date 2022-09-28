using GeometryModels;
public class LineStringTests
{
    [Fact]
    public void CreateLineString_Success()
    {
        //Arrage.
        Point point1 = new Point(1, 3);
        Point point2 = new Point(2, 3);
        LineString lineString = new LineString(point1, point2);
        //Act. + Assert.
        Assert.Equal(1, lineString.Point1.X);
    }

    [Fact]
    public void CalculateLineStringLength_Success()
    {
        //Arrage.
        Point point1 = new Point(0, 0);
        Point point2 = new Point(3, 4);
        LineString lineString = new LineString(point1, point2);
        //Act.
        double length = lineString.GetLength();
        //Assert.
        Assert.Equal(5, length);
    }
    ///*
    [Fact]
    public void ProofIsIntersection_Success()
    {
        //Arrage.
        Point point1 = new Point(0, 0);
        Point point2 = new Point(3, 3);
        Point point3 = new Point(3, 0);
        Point point4 = new Point(0, 3);
        LineString lineString1 = new LineString(point1, point2);
        LineString lineString2 = new LineString(point3, point4);
        //Act. + Assert.
        Assert.True(LineString.IsIntersection(lineString1, lineString2));
    }
    //*/
}
