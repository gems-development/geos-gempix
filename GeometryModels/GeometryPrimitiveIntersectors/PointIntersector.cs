using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class PointIntersector : IModelsIntersector
    {
        private bool _result;
        private Point _point;

        public PointIntersector(Point point)
        {
            _point?.Equal(point);
            _result = false;
        }

        // TODO проверить все, что связано с  Equals всех классов моделей
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

        double IGeometryPrimitiveVisitor.GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
