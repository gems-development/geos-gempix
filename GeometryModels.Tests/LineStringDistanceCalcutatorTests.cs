using GeometryModels;
using System;

public class LineStringDistanceCalcutator
{
    [Fact]
    public void DistanceBetweenPointAndLineString_Success()
    {
        //Arrage.
        Point point1 = new Point(2,3);
        Point point2 = new Point(7,3);
        Point point3 = new Point(5,0);
        //Act.
        LineString lineString = new LineString(point1, point2);
        //Assert.
        Assert.Equal(3, LineStringDistanceCalculator.GetDistance(point3, lineString));
    }
}
