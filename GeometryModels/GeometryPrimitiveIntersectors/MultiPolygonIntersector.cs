using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class MultiPolygonIntersector : IModelsIntersector
    {

        private bool _result;
        private MultiPolygon _multiPolygon;

        // TODO
        internal static bool Intersects(MultiPolygon multiPolygon, Point point)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPolygon multiPolygon, Line line)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPolygon multiPolygon, Polygon polygon)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPolygon multiPolygon, MultiPoint multiPoint)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPolygon multiPolygon, MultiLine multiLine)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
        {
            return true;
        }

        public bool GetResult()
        {
            return _result;
        }

        public void Visit(Point point)
        {
            _result = Intersects(_multiPolygon, point);
        }

        public void Visit(Line line)
        {
            _result = Intersects(_multiPolygon, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = Intersects(_multiPolygon, polygon);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = Intersects(_multiPolygon, multiPoint);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = Intersects(_multiPolygon, multiLine);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = Intersects(_multiPolygon, multiPolygon);
        }

        double IGeometryPrimitiveVisitor.GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
