﻿using GeometryModels.Models;
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

    [Fact]
    public void CreatePolygonWithHole_Success()
    {
        //Arrage.
        Point point1 = new Point(0, 0);
        Point point2 = new Point(0, 3);
        Point point3 = new Point(3, 3);
        Point point4 = new Point(3, 0);
        Point point5 = new Point(1, 1);
        Point point6 = new Point(2, 2);
        Point point7 = new Point(2, 1);
        List<Point> list1 = new List<Point>();
        list1.Add(point1);
        list1.Add(point2);
        list1.Add(point3);
        list1.Add(point4);
        List<Point> list2 = new List<Point>();
        list2.Add(point5);
        list2.Add(point6);
        list2.Add(point7);
        Contour hole = new Contour(list2);
        List<Contour> list3 = new List<Contour>();
        list3.Add(hole);
        Polygon polygon = new Polygon(list1, list3);
        //Act. + Assert.
        Assert.Single(polygon.GetHoles());
    }
}
