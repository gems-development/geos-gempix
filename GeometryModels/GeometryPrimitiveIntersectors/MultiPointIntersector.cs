using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class MultiPointIntersector : IModelsIntersector
    {
        private bool _result;
        private MultiPoint _multiPoint;

        // TODO
        internal static bool Intersects(MultiPoint multiPoint, Point point)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPoint multiPoint, Line line)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPoint multiPoint, Polygon polygon)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPoint multiPoint1, MultiPoint multiPoint2)
        {
            return true;
        }

        public bool GetResult()
        {
            return _result;
        }

        public void Visit(Point point)
        {
            _result = Intersects(_multiPoint, point);
        }

        public void Visit(Line line)
        {
            _result = Intersects(_multiPoint, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = Intersects(_multiPoint, polygon);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = Intersects(_multiPoint, multiPoint);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = MultiLineIntersector.Intersects(multiLine, _multiPoint);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _multiPoint);
        }

        double IGeometryPrimitiveVisitor.GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
