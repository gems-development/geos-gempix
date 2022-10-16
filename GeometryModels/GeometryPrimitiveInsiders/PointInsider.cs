using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
    public class PointInsider : IModelsIntersector
    {
        private bool _result;
        private Point _point;

        public PointInsider(Point point)
        {
            _point?.Equal(point);
            _result = false;
        }

        public static bool IsInside(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }


        public bool GetResult()
        {
            return true;
        }

        public void Visit(Point point)
        {
            _result = IsInside(point, _point);
        }

        public void Visit(Line line)
        {
            _result = LineInsider.IsInside(line, _point);
        }

        public void Visit(Polygon polygon)
        {
            _result = PolygonInsider.IsInside(polygon, _point);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = MultiPointInsider.IsInside(multiPoint, _point);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = MultiLineInsider.IsInside(multiLine, _point);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonInsider.IsInside(multiPolygon, _point);
        }

        public void Visit(Contour contour)
        {
            throw new NotImplementedException();
        }
    }
}
