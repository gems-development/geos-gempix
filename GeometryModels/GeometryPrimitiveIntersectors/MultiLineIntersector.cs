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

        public MultiLineIntersector(MultiLine multiLine)
        {
            _multiLine = multiLine;
        }

        internal static bool Intersects(MultiLine multiLine, Point point)
        {
            foreach (Line line in multiLine.GetLines())
            {
                if (LineIntersector.Intersects(line, point))
                    return true;
            }
            return false;
        }

        internal static bool Intersects(MultiLine multiLine, Line line1)
        {
            foreach (Line line in multiLine.GetLines())
            {
                if (LineIntersector.Intersects(line, line1))
                    return true;
            }
            return false;
        }

        internal static bool Intersects(MultiLine multiLine, Polygon polygon)
        {
            foreach (Line line in multiLine.GetLines())
            {
                if (PolygonIntersector.Intersects(polygon, line))
                    return true;
            }
            return false;
        }

        internal static bool Intersects(MultiLine multiLine, MultiPoint multiPoint)
        {
            foreach (Line line in multiLine.GetLines())
            {
                if (MultiPointIntersector.Intersects(multiPoint, line))
                    return true;
            }
            return false;
        }

        internal static bool Intersects(MultiLine multiLine1, MultiLine multiLine2)
        {
            foreach (Line line in multiLine1.GetLines())
            {
                if (Intersects(multiLine2, line))
                    return true;
            }
            return false;
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
