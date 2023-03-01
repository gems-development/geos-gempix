using GeosGempix.Models;
using System.Diagnostics.CodeAnalysis;
using Point = GeosGempix.Point;

public class Polygon : IGeometryPrimitive
{
    private List<Point> _points;
    private List<Contour> _holes;

    public Polygon(List<Point> points)
    {
        PointListValidate(points);
        _points = points;
        _holes = new List<Contour>();
    }

    public Polygon(List<Point> points, List<Contour> holes)
    {
        PointListValidate(points);
        ContourListValidate(holes);
        _points = points;
        _holes = holes;
    }

    public Polygon(Polygon polygon)
    {
        if (polygon == null)
            throw new ArgumentNullException("polygon");
        _points = polygon.GetPoints();
        _holes = polygon.GetHoles();
    }
    public void AddPoint(Point point)
    {
        if (point == null)
            throw new ArgumentNullException("point");
        _points.Add(point);
    }

    public void Add(Contour hole)
    {
        if (hole == null)
            throw new ArgumentNullException("hole");
        _holes.Add(hole);
    }

    public List<Point> GetPoints() => _points;
    public List<Contour> GetHoles() => _holes;
    public Point GetPoint(int i) => _points.ElementAt(i);
    public int GetCountOfPoints() => _points.Count;
    public void RemovePoint(int i) => _points.RemoveAt(i);

    public double GetSquare()
    {
        double contourSquare = 0;
        
        var mainContour = new Contour(_points); 
        contourSquare = mainContour.GetSquare();

        for (int i = 0; i <= _holes.Count - 1; i++)
            contourSquare -= _holes[i].GetSquare();

        return contourSquare;
    }

    public double GetPerimeter()
    {
        double perimeter = 0;
        for (int i = 0; i <= _points.Count - 1; i++)
        {
            perimeter += PointDistanceCalculator.GetDistance(_points[i], _points[i + 1]);
        }
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
        if (v == null)
            throw new ArgumentNullException("v");
        v.Visit(this);
    }

    public override int GetHashCode() => HashCode.Combine(_points, _holes);

    public override bool Equals(object? obj)
    {
        return obj is Polygon polygon &&
               EqualityComparer<List<Point>>.Default.Equals(_points, polygon._points) &&
               EqualityComparer<List<Contour>>.Default.Equals(_holes, polygon._holes);
    }

    private void PointListValidate(List<Point> points)
    {
        if (points == null)
            throw new ArgumentNullException("points");
        foreach (Point point in points)
            if (point == null)
                throw new ArgumentNullException("points", "Один из элементов списка points равен null");
        if (points.Count == 0)
            throw new ArgumentException("Длина списка points = 0");
        if (!Equals(points.FirstOrDefault(), points.LastOrDefault()))
            throw new ArgumentException("Некорректный набор точек");
    }
    
    private void ContourListValidate(List<Contour> holes)
    {
        if (holes == null)
            throw new ArgumentNullException("holes");
        if (holes.Count == 0)
            throw new ArgumentException("Длина списка holes = 0");
        foreach (Contour hole in holes)
            if (hole == null)
                throw new ArgumentNullException("holes", "Один из элементов списка holes равен null");
    }
}
