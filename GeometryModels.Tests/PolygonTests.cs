using GeometryModels;
using System;
using System.Drawing;
using Point = GeometryModels.Point;

public class PolygonTests
{
    [Fact]
    public void CreatePolygon_Success()
    {
        //Arrage.
        List<Point> list = new List<Point>();
        list.Add(new Point(1, 1));
        list.Add(new Point(2, 2));
        list.Add(new Point(3, 3));
        Polygon polygon = new Polygon(list);
        //Act. + Assert.
        Assert.Equal(3, polygon.GetCountOfPoints());
    }

    [Fact]
    public void PerimeterOfPolygon_Triangle_Success()
    {
        //Arrage.
        List<Point> list = new List<Point>();
        list.Add(new Point(0, 0));
        list.Add(new Point(3, 4));
        list.Add(new Point(6, 0));
        Polygon polygon = new Polygon(list);
        //Act. + Assert.
        Assert.Equal(16, polygon.GetPerimeter());
    }
    [Fact]
    public void PerimeterOfPolygon_Square_Success()
    {
        //Arrage.
        List<Point> list = new List<Point>();
        list.Add(new Point(0, 0));
        list.Add(new Point(0, 3));
        list.Add(new Point(3, 3));
        list.Add(new Point(3, 0));
        Polygon polygon = new Polygon(list);
        //Act. + Assert.
        Assert.Equal(12, polygon.GetPerimeter());
    }

    [Fact]
    public void SquareOfPolygon_Square_Success()
    {
        //Arrage.
        List<Point> list = new List<Point>();
        list.Add(new Point(0, 0));
        list.Add(new Point(0, 3));
        list.Add(new Point(3, 3));
        list.Add(new Point(3, 0));
        Polygon polygon = new Polygon(list);
        //Act. + Assert.
        Assert.Equal(9, polygon.GetSquare());
    }
}
