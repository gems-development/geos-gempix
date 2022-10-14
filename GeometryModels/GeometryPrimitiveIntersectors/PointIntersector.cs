using GeometryModels.Interfaces.IVisitors;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    public class PointIntersector : IModelsIntersector
    {
        private bool _result;
        private Point _point;

        public PointIntersector(Point point)
        {
            _point?.Equal(point);
            _result = false;
        }

        public static bool Intersects(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }


        public bool GetResult()
        {
            return true;
        }

        public void Visit(Point point)
        {
            _result = Intersects(point, _point);
        }

        public void Visit(Line line)
        {
            _result = LineIntersector.Intersects(line, _point);
        }

        public void Visit(Polygon polygon)
        {
            _result = PolygonIntersector.Intersects(polygon, _point);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = MultiPointIntersector.Intersects(multiPoint, _point);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = MultiLineIntersector.Intersects(multiLine, _point);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _point);
        }
    }
}
