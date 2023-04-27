using GeosGempix.GeometryPrimitiveTouchers;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Extensions
{
    internal class ContourToucher : IModelToucher
    {
        private bool _result;
        private Contour _contour;

        public ContourToucher(Contour contour) =>
            _contour = contour;

        internal static bool IsTouching(Contour contour, Point point)
        {
            foreach (Line line in contour.GetLines())
                if (LineToucher.IsTouching(line, point))
                    return true;
            return false;
        }
        internal static bool IsTouching(Contour contour, Line line1)
        {
            foreach (Line line in contour.GetLines())
                if (LineToucher.IsTouching(line, line1))
                    return true;
            return false;
        }
        internal static bool IsTouching(Contour contour1, Contour contour2)
        {
            foreach (Line line in contour2.GetLines())
            {
                if (contour1.IsInside(PullLineEnds(line).Point1) && contour1.IsInside(PullLineEnds(line).Point2))
                    return false;
            }
            
            foreach (Line line in contour1.GetLines())
            {
                if (IsTouching(contour2, line))
                    return true;
            }
                
            return false;
        }

        private static (Point Point1, Point Point2) PullLineEnds(Line line)
        {
            const double step = 0.00000002;
            var vx = line.Point2.X - line.Point1.X;
            var vy = line.Point2.Y - line.Point1.Y;
            var denominator = Math.Sqrt(vx * vx + vy * vy);
            var x1 = line.Point1.X + step * vx / denominator;
            var y1 = line.Point1.Y + step * vy / denominator;
            var x2 = line.Point2.X - step * vx / denominator;
            var y2 = line.Point2.Y - step * vy / denominator;

            return (Point1: new Point(x1, y1), Point2: new Point(x2, y2));
        }

        internal static bool IsTouching(Contour contour1, Polygon polygon2)
        {
            foreach (Line line in contour1.GetLines())
                if (PolygonToucher.IsTouching(polygon2, line))
                    return true;
            var holes = polygon2.GetHoles();
            foreach (var hole in holes)
            {
                if (IsTouching(contour1, hole))
                    return true;
            }
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = IsTouching(_contour, point);

        public void Visit(Line line) =>
            _result = IsTouching(_contour, line);

        public void Visit(Polygon polygon) =>
            _result = IsTouching(_contour, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointToucher.IsTouching(multiPoint, _contour);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineToucher.IsTouching(multiLine, _contour);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonToucher.IsTouching(multiPolygon, _contour);

        public void Visit(Contour contour) =>
            _result = IsTouching(_contour, contour);
    }
}