using GeometryModels.GeometryPrimitiveInsiders;
using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Models;
using System.Diagnostics.CodeAnalysis;
using Point = GeometryModels.Point;

public class Polygon : IGeometryPrimitive
{
    private List<Point> _points;
    private List<Contour> _holes;

    public Polygon(List<Point> points)
    {
        if (points == null)
            throw new ArgumentNullException("points");
        if (points.Capacity == 0)
            throw new ArgumentException("points", "Длина списка points = 0");
        _points = new List<Point>();
        List<Line> lines = new List<Line>();
        foreach (Point point in points)
        {
            if (point == null)
                throw new ArgumentNullException("points", "Один из элементов списка points равен null");
            if (points.Contains(point))
                throw new ArgumentException("points", "Список точек содержит повторяющиеся элементы");
            if (points.Capacity > 1)
            {
                Point lastPoint = points.ElementAt(points.Capacity - 1);
                Line line1 = new Line(lastPoint, point);
                Point pointOfIntersection;
                foreach (Line line in lines)
                {
                    // должно быть line.Intersects(line1), но эти изменения еще не слиты
                    pointOfIntersection = 
                        LineIntersector.GetPointOfIntersection(
                            line.GetEquationOfLine(),
                            line1.GetEquationOfLine());
                    if (pointOfIntersection!= null && !lastPoint.Equals(pointOfIntersection))
                        throw new ArgumentException("points", 
                            "Порядок точек подразумевает самопересечения полигона, а это недопустимо");
                    lines.Add(line1);
                }
                
            }
            points.Add(point);
        }
        _holes = new List<Contour>();
    }

    public Polygon(List<Point> points, List<Contour> holes)
    {
        if (points == null)
            throw new ArgumentNullException("points");
        if (holes == null)
            throw new ArgumentNullException("holes");
        if (points.Capacity == 0)
            throw new ArgumentException("Длина списка points = 0");
        if (holes.Capacity == 0)
            throw new ArgumentException("Длина списка holes = 0");
        _points = new List<Point>();
        List<Line> lines = new List<Line>();
        foreach (Point point in points)
        {
            if (point == null)
                throw new ArgumentNullException("points", "Один из элементов списка points равен null");
            if (points.Contains(point))
                throw new ArgumentException("points", "Список точек содержит повторяющиеся элементы");
            if (points.Capacity > 1)
            {
                Point lastPoint = points.ElementAt(points.Capacity - 1);
                Line line1 = new Line(lastPoint, point);
                Point pointOfIntersection;
                foreach (Line line in lines)
                {
                    // должно быть line.Intersects(line1), но эти изменения еще не слиты
                    pointOfIntersection =
                        LineIntersector.GetPointOfIntersection(
                            line.GetEquationOfLine(),
                            line1.GetEquationOfLine());
                    if (pointOfIntersection != null && !lastPoint.Equals(pointOfIntersection))
                        throw new ArgumentException("points",
                            "Порядок точек подразумевает самопересечения полигона, а это недопустимо");
                    lines.Add(line1);
                }

            }
            points.Add(point);
        }
        _holes = new List<Contour>();
        foreach (Contour hole in holes)
        {
            if (hole == null)
                throw new ArgumentNullException("holes", "Один из элементов списка points равен null");
            if (_holes.Contains(hole))
                throw new ArgumentException("holes", "Список точек содержит повторяющиеся элементы");
            if (_holes.Capacity > 1)
            {
                foreach (Contour hole1 in _holes)
                {
                    if (ContourIntersector.Intersects(hole, hole1))
                        throw new ArgumentException("holes",
                            "Нельзя, чтобы пересекались внутренние контуры");
                    if (ContourInsider.IsInside(hole, hole1) || ContourInsider.IsInside(hole1, hole))
                        throw new ArgumentException("holes",
                            "Нельзя, чтобы один внутренний контур был внутри другого");
                }

            }
            _holes.Add(hole);
        }
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

    public List<Point> GetPoints() =>
        _points;
    public List<Contour> GetHoles() =>
        _holes;
    public Point GetPoint(int i) =>
        _points.ElementAt(i);
    public int GetCountOfPoints() =>
        _points.Count;
    public void RemovePoint(int i) =>
        _points.RemoveAt(i);

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
            perimeter += PointDistanceCalculator.GetDistance(_points[i], _points[i + 1]);
        }
        perimeter = perimeter + PointDistanceCalculator.GetDistance(_points[_points.Count - 1], _points[0]);
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
        if (v == null)
            throw new ArgumentNullException("v");
        v.Visit(this);
    }

    public override int GetHashCode() =>
        HashCode.Combine(_points, _holes);

    public override bool Equals(object? obj)
    {
        return obj is Polygon polygon &&
               EqualityComparer<List<Point>>.Default.Equals(_points, polygon._points) &&
               EqualityComparer<List<Contour>>.Default.Equals(_holes, polygon._holes);
    }
}
