using GeometryModels.Models;
using Point = GeometryModels.Point;

public class Polygon : IGeometryPrimitive
{
    private List<Point> _points;
    private List<Contour> _holes;

    public Polygon(List<Point> points)
    {
        _points = points;
        _holes = new List<Contour>();
    }

    public Polygon(List<Point> points, List<Contour> holes)
    {
        _points = points;
        _holes = holes;
    }

    public Polygon(Polygon polygon)
    {
        _points = polygon.GetPoints();
        _holes = polygon.GetHoles();
    }
    public void AddPoint(Point point)
    {
        _points.Add(point);
    }
    public void Add(Contour hole)
    {
        _holes.Add(hole);
    }
    public List<Point> GetPoints()
    {
        return _points;
    }
    public List<Contour> GetHoles()
    {
        return _holes;
    }
    public Point GetPoint(int i)
    {
        return _points.ElementAt(i);
    }

    public Point GetNextPoint(Point point)
    {
        int index = _points.IndexOf(point);
        if (index < _points.Count - 1)
            return _points.ElementAt(index + 1);
        else
            return _points.ElementAt(0);
    }
    public int GetCountOfPoints()
    {
        return _points.Count;
    }
    public void RemovePoint(int i)
    {
        _points.RemoveAt(i);
    }

    public double GetSquare()
    {
        double square = 0;
        double sum1 = 0;
        double sum2 = 0;
        for (int i = 0; i < _points.Count - 1; i++)
        {
            sum1 = sum1 + _points[i].X * _points[i + 1].Y;
            sum2 = sum2 + _points[i].Y * _points[i + 1].X;
        }
        sum1 = sum1 + _points[_points.Count - 1].X * _points[0].Y;
        sum2 = sum2 + _points[_points.Count - 1].Y * _points[0].X;
        square = (sum2 - sum1) / 2;
        return square;
    }

    public double GetPerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i <= _points.Count - 2; i++)
        {
            perimeter += PointShortestLineSearcher.GetDistance(_points[i], _points[i + 1]);
        }
        perimeter = perimeter + PointShortestLineSearcher.GetDistance(_points[_points.Count - 1], _points[0]);
        return perimeter;
    }

    public List<Line> GetLines()
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



    public bool isClockwiseBypass()
    {
        double answer = 0;
        foreach (Line line in GetLines())
        {
            answer += (line.Point2.X - line.Point1.X) * (line.Point2.Y + line.Point1.Y);
        }
        return answer > 0;
    }


    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_points, _holes);
    }

    public override bool Equals(object? obj)
    {
        return obj is Polygon polygon &&
               EqualityComparer<List<Point>>.Default.Equals(_points, polygon._points) &&
               EqualityComparer<List<Contour>>.Default.Equals(_holes, polygon._holes);
    }
}
