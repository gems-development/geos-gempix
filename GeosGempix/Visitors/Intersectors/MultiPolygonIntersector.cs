using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.GeometryPrimitiveInsiders;

namespace GeosGempix.GeometryPrimitiveIntersectors
{
    public class MultiPolygonIntersector : IModelsIntersector
    {

        private bool _result;
        private MultiPolygon _multiPolygon;

        public MultiPolygonIntersector(MultiPolygon multiPolygon) =>
            _multiPolygon = multiPolygon;

        internal static bool Intersects(MultiPolygon multiPolygon, Point point)
        {
            if (IntersectsBorders(multiPolygon, point))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon, point))
                return true;
            return false;
        }

        internal static bool Intersects(MultiPolygon multiPolygon, Line line)
        {
            if (IntersectsBorders(multiPolygon, line))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon, line))
                return true;
            return false;
        }

        internal static bool Intersects(MultiPolygon multiPolygon, Polygon polygon1)
        {
            if (IntersectsBorders(multiPolygon, polygon1))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon, polygon1))
                return true;
            return false;
        }

        internal static bool Intersects(MultiPolygon multiPolygon, MultiPoint multiPoint)
        {
            if (IntersectsBorders(multiPolygon, multiPoint))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon, multiPoint))
                return true;
            return false;
        }

        internal static bool Intersects(MultiPolygon multiPolygon, MultiLine multiLine)
        {
            if (IntersectsBorders(multiPolygon, multiLine))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon, multiLine))
                return true;
            return false;
        }

        internal static bool Intersects(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
        {
            if (IntersectsBorders(multiPolygon1, multiPolygon2))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon1, multiPolygon2))
                return true;
            return false;
        }

        internal static bool Intersects(MultiPolygon multiPolygon, Contour contour)
        {
            if (IntersectsBorders(multiPolygon, contour))
                return true;
            if (MultiPolygonInsider.IsStrictlyInside(multiPolygon, contour))
                return true;
            return false;
        }
        internal static bool IntersectsBorders(MultiPolygon multiPolygon, Point point)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonIntersector.IntersectsBorders(polygon, point))
                    return true;
            return false;
        }
        internal static bool IntersectsBorders(MultiPolygon multiPolygon, Line line)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonIntersector.IntersectsBorders(polygon, line))
                    return true;
            return false;
        }

        internal static bool IntersectsBorders(MultiPolygon multiPolygon, Polygon polygon1)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonIntersector.IntersectsBorders(polygon, polygon1))
                    return true;
            return false;
        }

        internal static bool IntersectsBorders(MultiPolygon multiPolygon, MultiPoint multiPoint)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (MultiPointIntersector.Intersects(multiPoint, polygon))
                    return true;
            return false;
        }

        internal static bool IntersectsBorders(MultiPolygon multiPolygon, MultiLine multiLine)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (MultiLineIntersector.Intersects(multiLine, polygon))
                    return true;
            return false;
        }

        internal static bool IntersectsBorders(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
        {
            foreach (Polygon polygon in multiPolygon2.GetPolygons())
                if (IntersectsBorders(multiPolygon1, polygon))
                    return true;
            return false;
        }

        internal static bool IntersectsBorders(MultiPolygon multiPolygon, Contour contour)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (PolygonIntersector.IntersectsBorders(polygon, contour))
                    return true;
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = Intersects(_multiPolygon, point);

        public void Visit(Line line) =>
            _result = Intersects(_multiPolygon, line);

        public void Visit(Polygon polygon) =>
            _result = Intersects(_multiPolygon, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = Intersects(_multiPolygon, multiPoint);

        public void Visit(MultiLine multiLine) =>
            _result = Intersects(_multiPolygon, multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = Intersects(_multiPolygon, multiPolygon);

        public void Visit(Contour contour) =>
            _result = Intersects(_multiPolygon, contour);
    }
}
