using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class LineIntersector : IModelsIntersector
    {
        private bool _result;
        private Line _line;

        // TODO
        internal static bool Intersects(Line line, Point point)
        {
            return true;
        }

        // TODO
        internal static bool Intersects(Line line1, Line line2)
        {
            return true;
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
    }
}
