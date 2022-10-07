using Point = GeometryModels.Point;

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
		double sum1 = 0;
		double sum2 = 0;
		for(int i = 0; i < list.Count-1; i++)
		{
			sum1 = sum1 + list[i].X * list[i+1].Y;
		    sum2 = sum2 + list[i].Y * list[i+1].X;
		}
		sum1 = sum1 + list[list.Count-1].X * list[0].Y;
		sum2 = sum2 + list[list.Count-1].Y * list[0].X;
		square = (sum2 - sum1) / 2;
		return square;
    }

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

    private List<Line> GetLines()
    {
        List<Point> points = GetPoints();
        List<Line> lines = new List<Line>();
        for (int i = 0; i < points.Count - 1; i++)
        {
            lines.Add(new Line(points[i], points[i + 1]));
        }
        lines.Add(new Line(points[points.Count - 1], points[0]));
        return lines; 
    }

    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Polygon p = (Polygon)obj;
            return list.Equals(p.GetPoints());
        }
    }


    public void Accept(IGeometryPrimitiveVisitor v)
    {
		v.Visit(this);
    }
}
