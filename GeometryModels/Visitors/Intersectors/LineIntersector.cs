using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    public class LineIntersector : IModelsIntersector
    {
        private bool _result;
        private readonly Line _line;

        public LineIntersector(Line line) =>
            _line = line;

        public static bool Intersects(Line line, Point point) =>
            Math.Abs(PointDistanceCalculator.GetDistance(point, line.Point1) +
                PointDistanceCalculator.GetDistance(point, line.Point2) - line.GetLength()) < 0.00000001;

        internal static bool IntersectsStraightLines(Line line1, Line line2)
        {
            if (GetPointOfIntersection(line1.GetEquationOfLine(), line2.GetEquationOfLine()) != null)
                return true;
            return false;
        }

        internal static bool Intersects(Line line1, Line line2)
        {
            Point? point = GetPointOfIntersection(line1.GetEquationOfLine(), line2.GetEquationOfLine());
            if (point == null)
                return false;
            if (Intersects(line1, point))
                return true;
            return false;
        }

        internal static Point? GetPointOfIntersection((double a1, double b1, double c1) lineEq1,
            (double a2, double b2, double c2) lineEq2)
        {
            double a1 = lineEq1.a1, b1 = lineEq1.b1, c1 = lineEq1.c1,
               a2 = lineEq2.a2, b2 = lineEq2.b2, c2 = lineEq2.c2;
            double x, y;
            if (a1 == 0)
            {
                if (a2 == 0)
                    return null;
                y = -c1 / b1;
                x = (-c2 - b2 * y) / a2;
                return new Point(x, y);
            }
            if (a2 == 0)
            {
                y = -c2 / b2;
                x = (-c1 - b1 * y) / a1;
                return new Point(x, y);
            }
            if (b1 == 0 && b2 == 0)
                return null;
            y = (-c2 + c1 * a2 / a1) / (b2 - b1 * a2 / a1);
            x = (-c1 - b1 * y) / a1;
            return new Point(x, y);
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = Intersects(_line, point);

        public void Visit(Line line) =>
            _result = Intersects(_line, line);

        public void Visit(Polygon polygon) =>
            _result = PolygonIntersector.Intersects(polygon, _line);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointIntersector.Intersects(multiPoint, _line);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineIntersector.Intersects(multiLine, _line);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _line);

        public void Visit(Contour contour) =>
            _result = ContourIntersector.Intersects(contour, _line);

    }
}
