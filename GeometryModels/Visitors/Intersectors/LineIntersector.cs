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

        internal static Point? GetPointOfIntersection(double[] lineEq1, double[] lineEq2)
        {
            double A1 = lineEq1[0], B1 = lineEq1[1], C1 = lineEq1[2],
               A2 = lineEq2[0], B2 = lineEq2[1], C2 = lineEq2[2];
            double x, y;
            if (A1 == 0)
            {
                if (A2 == 0)
                    return null;
                y = -C1 / B1;
                x = (-C2 - B2 * y) / A2;
                return new Point(x, y);
            }
            if (A2 == 0)
            {
                y = -C2 / B2;
                x = (-C1 - B1 * y) / A1;
                return new Point(x, y);
            }
            if (B1 == 0 && B2 == 0)
                return null;
            y = (-C2 + C1 * A2 / A1) / (B2 - B1 * A2 / A1);
            x = (-C1 - B1 * y) / A1;
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
