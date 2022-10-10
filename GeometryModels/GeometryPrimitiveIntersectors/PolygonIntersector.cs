using GeometryModels.Interfaces.IVisitors;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    public class PolygonIntersector : IModelsIntersector
    {
        private bool _result;
        private Polygon _polygon;

        // TODO
        public static bool Intersects(Polygon polygon, Point point)
        {
            return true;
        }

        // TODO
        public static bool Intersects(Polygon polygon, Line line)
        {
            return true;
        }

        // TODO
        public static bool Intersects(Polygon polygon1, Polygon polygon2)
        {
            return true;
        }

        public bool GetResult()
        {
            return _result;
        }

        public void Visit(Point point)
        {
            _result = Intersects(_polygon, point);
        }

        public void Visit(Line line)
        {
            _result = Intersects(_polygon, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = Intersects(_polygon, polygon);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = MultiPointIntersector.Intersects(multiPoint, _polygon);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = MultiLineIntersector.Intersects(multiLine, _polygon);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _polygon);
        }
    }
}
