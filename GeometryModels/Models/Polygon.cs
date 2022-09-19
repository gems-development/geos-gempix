using GeometryModels;
using System;



public class Polygon : IGeometryPrimitive
{
	private List<Point> list;
	public Polygon(List<Point> points)
	{
		list = points;
	}
	public void AddPoint(Point point)
    {
		list.Add(point);
    }
	public List<Point> GetPoints()
    {
		return list;
    }
	public Point GetPoint(int i)
    {
		return list.ElementAt(i);
    }
	public int GetCountOfPoints()
    {
		return list.Count;
    }
	public void RemovePoint(int i)
    {
        list.RemoveAt(i);
    }
	// TODO: реализовать 
	// Метод 3
	// https://ru.wikihow.com/%D0%BD%D0%B0%D0%B9%D1%82%D0%B8-%D0%BF%D0%BB%D0%BE%D1%89%D0%B0%D0%B4%D1%8C-%D0%BC%D0%BD%D0%BE%D0%B3%D0%BE%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA%D0%B0
	public double GetSquare()
    {
		double square = 0;
		return square;
    }
	// TODO: реализовать с помощью функции вычисления расстояния между двумя точками
	public double GetPerimeter()
    {
		double perimeter = 0;
		for(int i = 0; i <= list.Count-2; i++)
        {
			perimeter += PointDistanceCalculator.GetDistance(list[i], list[i+1]);
        }
		perimeter = perimeter + PointDistanceCalculator.GetDistance(list[list.Count-1], list[0]);
		return perimeter;
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
		v.Visit(this);
    }
}
