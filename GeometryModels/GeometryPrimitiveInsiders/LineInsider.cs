using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.GeometryPrimitiveIntersectors;

namespace GeometryModels.GeometryPrimitiveInsiders
{
    public class LineInsider : IModelsIntersector
    {
        private bool _result;
        private Line _line;

        public static bool IsInside(Line line, Point point)
        {
            return LineIntersector.Intersects(line, point);
        }

        public static bool IsInside(Line line1, Line line2)
        {
            return IsInside(line1, line2.Point1) && IsInside(line1, line2.Point2);
        }
        public bool GetResult()
        {
            return _result;
        }

        public void Visit(Point point)
        {
            _result = IsInside(_line, point);
        }

        public void Visit(Line line)
        {
            _result = IsInside(_line, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = PolygonInsider.IsInside(polygon, _line);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = MultiPointInsider.IsInside(multiPoint, _line);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = MultiLineInsider.IsInside(multiLine, _line);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonInsider.IsInside(multiPolygon, _line);
        }

        public void Visit(Contour contour)
        {
            throw new NotImplementedException();
        }
    }
}
