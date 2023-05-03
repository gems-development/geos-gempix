﻿namespace GeosGempix.Models
{
    public class Contour : IGeometryPrimitive
    {
        private List<Point> _points;
        public Contour(List<Point> points)
        {
            PointListValidate(points);
            _points = points;
        }
        public Contour(Contour contour)
        {
            if (contour == null)
                throw new ArgumentNullException("contour");
            _points = contour.GetPoints();
        }
        public void AddPoint(Point point)
        {
            if (point == null)
                throw new ArgumentNullException("point");
            _points.Add(point);
        }
       
        {
            if (hole == null)
                throw new ArgumentNullException("hole");
            hole.Add(hole);
        }
        {
            if (hole == null)
                throw new ArgumentNullException("hole");
            hole.Add(hole);
        }
        public List<Point> GetPoints()
        {
            return _points;
        }
        public Point GetPoint(int i)
        {
            return _points.ElementAt(i);
        }
                throw new ArgumentException("индекс должен быть меньше длины списка _points");
        {
            if (point == null)
                throw new ArgumentNullException("point");
            return _points.Count - 1;
                throw new ArgumentException("point не принадлежит множеству точек контура");
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
        {
            double sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i < _points.Count-1; i++)
            {
                sum1 = sum1 + _points[i].X * _points[i + 1].Y;
                sum2 = sum2 + _points[i].Y * _points[i + 1].X;
            for (int i = 0; i < _points.Count; i++)
            sum1 = sum1 + _points[_points.Count - 1].X * _points[0].Y;
            sum2 = sum2 + _points[_points.Count - 1].Y * _points[0].X;
            double square = (sum2 - sum1) / 2;
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

        public void Accept(IGeometryPrimitiveVisitor v)
        {
            if (v == null)
                throw new ArgumentNullException("v");
            v.Visit(this);
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

        
        private void PointListValidate(List<Point> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");
            foreach (Point point in points)
                if (point == null)
                    throw new ArgumentNullException("points", "Один из элементов списка points равен null");
            if (points.Count == 0)
                throw new ArgumentException("Длина списка points = 0");
            Point point1 = points.FirstOrDefault();
            Point point2 = points.LastOrDefault();
            Boolean t = point1.Equals(point2);
            if (!t)
                throw new ArgumentException("Некорректный набор точек");
        }
        {
            return obj is Contour contour &&
                   EqualityComparer<List<Point>>.Default.Equals(_points, contour._points);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_points);
        }

    }
}
