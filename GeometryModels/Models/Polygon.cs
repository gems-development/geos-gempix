using System;



ublic class Polygon : IGeometryPrimitive
{
	public List<Point> list;
	public Polygon(params Point points)
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
	public List<Point> GetPoint(int i)
    {
		return list[i];
    }
	public bool RemovePoint(int i)
    {
		return list.Remove(i);
    }
	public double GetSquare()
    {
		double square = 0;
		return 0;
    }
	public double GetPerimeter()
    {
		double perimeter = 0;
		return perimeter;
    }
}
