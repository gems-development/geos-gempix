using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class MultiLineIntersector : IModelsIntersector
    {
        private bool _result;
        private MultiLine _multiLine;

        // TODO
        internal static bool Intersects(MultiLine multiLine, Point point)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiLine multiLine, Line line)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiLine multiLine, Polygon polygon)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiLine multiLine, MultiPoint multiPoint)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(MultiLine multiLine1, MultiLine multiLine2)
        {
            return true;
        }

        public bool GetResult()
        {
            return _result;
        }

        public void Visit(Point point)
        {
            _result = Intersects(_multiLine, point);
        }

        public void Visit(Line line)
        {
            _result = Intersects(_multiLine, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = Intersects(_multiLine, polygon);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = Intersects(_multiLine, multiPoint);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = Intersects(_multiLine, multiLine);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _multiLine);
        }
    }
}
