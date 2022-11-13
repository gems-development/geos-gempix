using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
    public class MultiPolygonInsider : IModelInsider
    {

        private bool _result;
        private MultiPolygon _multiPolygon;

        public MultiPolygonInsider(MultiPolygon multiPolygon) =>
            _multiPolygon = multiPolygon;

        internal static bool IsInside(MultiPolygon multiPolygon, Point point)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonInsider.IsInside(polygon, point))
                    return true;
            return false;
        }

        internal static bool IsInside(MultiPolygon multiPolygon, Line line)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonInsider.IsInside(polygon, line))
                    return true;
            return false;
        }

        internal static bool IsInside(MultiPolygon multiPolygon, Polygon polygon1)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonInsider.IsInside(polygon, polygon1))
                    return true;
            return false;
        }

        internal static bool IsInside(MultiPolygon multiPolygon, MultiPoint multiPoint)
        {
            List<Point> points = multiPoint.GetPoints();
            List<Point> pointsForRemove = new List<Point>();
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                foreach (Point point in points)
                    if (PolygonInsider.IsInside(polygon, point))
                        pointsForRemove.Add(point);
                foreach (Point point in pointsForRemove)
                    points.Remove(point);
                pointsForRemove.Clear();
                if (points.Count == 0)
                    return true;
            }
            return false;
        }

        internal static bool IsInside(MultiPolygon multiPolygon, MultiLine multiLine)
        {
            List<Line> lines = multiLine.GetLines();
            List<Line> linesForRemove = new List<Line>();
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                foreach (Line line in lines)
                    if (PolygonInsider.IsInside(polygon, line))
                        linesForRemove.Add(line);
                foreach (Line line in linesForRemove)
                    lines.Remove(line);
                linesForRemove.Clear();
                if (lines.Count == 0)
                    return true;
            }
            return false;
        }

        internal static bool IsInside(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
        {
            List<Polygon> polygons = multiPolygon2.GetPolygons();
            List<Polygon> polygonsForRemove = new List<Polygon>();
            foreach (Polygon polygon1 in multiPolygon1.GetPolygons())
            {
                foreach (Polygon polygon in polygons)
                    if (PolygonInsider.IsInside(polygon, polygon))
                        polygonsForRemove.Add(polygon);
                foreach (Polygon polygon in polygonsForRemove)
                    polygons.Remove(polygon);
                polygonsForRemove.Clear();
                if (polygons.Count == 0)
                    return true;
            }
            return false;
        }

        internal static bool IsInside(MultiPolygon multiPolygon, Contour contour)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonInsider.IsInside(polygon, contour))
                    return true;
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = IsInside(_multiPolygon, point);

        public void Visit(Line line) =>
            _result = IsInside(_multiPolygon, line);

        public void Visit(Polygon polygon) =>
            _result = IsInside(_multiPolygon, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = IsInside(_multiPolygon, multiPoint);

        public void Visit(MultiLine multiLine) =>
            _result = IsInside(_multiPolygon, multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = IsInside(_multiPolygon, multiPolygon);

        public void Visit(Contour contour) =>
            _result = IsInside(_multiPolygon, contour);
    }
}
