using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    public class LineIntersector : IModelsIntersector
    {
        private bool _result;
        private Line _line;

        public static bool Intersects(Line line, Point point)
        {
            return PointDistanceCalculator.GetDistance(point, line.Point1) +
                PointDistanceCalculator.GetDistance(point, line.Point2) == line.GetLength();
        }

        public static bool Intersects(Line line1, Line line2)
        {
            if (line1.Point1.X == line1.Point2.X && line2.Point1.X != line2.Point2.X)
            {
                return true;
            }
            if (line1.Point1.X == line1.Point2.X && line2.Point1.X == line2.Point2.X)
            {
                return false;
            }

            double k1 = (line1.Point2.Y - line1.Point1.Y) / (line1.Point2.X - line1.Point1.X);
            double k2 = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);

            return k2 - k1 > 0;
        }
        public bool GetResult()
        {
            return _result;
        }

        public void Visit(Point point)
        {
            _result = Intersects(_line, point);
        }

        public void Visit(Line line)
        {
            _result = Intersects(_line, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = PolygonIntersector.Intersects(polygon, _line);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = MultiPointIntersector.Intersects(multiPoint, _line);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = MultiLineIntersector.Intersects(multiLine, _line);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _line);
        }

        public void Visit(Contour contour)
        {
            throw new NotImplementedException();
        }
    }
}
