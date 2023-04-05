using GeosGempix.Extensions;
using GeosGempix.GeometryPrimitiveInsiders;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.GeometryPrimitiveIntersectors
{
    public class PolygonIntersector : IModelsIntersector
    {
        private bool _result;
        private Polygon _polygon;

        public PolygonIntersector(Polygon polygon) =>
            _polygon = polygon;

        // пример верно написанного метода ниже
        internal static bool Intersects(Polygon polygon, Point point)
        {
            if (IntersectsBorders(polygon, point))
                return true;
            if (PolygonInsider.IsStrictlyInside(polygon, point))
                return true;
            return false;
        }
        internal static bool Intersects(Polygon polygon, Line line)
        {
            if (IntersectsBorders(polygon, line))
                return true;
            if (PolygonInsider.IsStrictlyInside(polygon, line, false))
                return true;
            return false;
        }
        internal static bool Intersects(Polygon polygon1, Polygon polygon2)
        {
            if (IntersectsBorders(polygon1, polygon2))
                return true;
            if (PolygonInsider.IsStrictlyInside(polygon1, polygon2, false))
                return true;
            return false;
        }

        internal static bool Intersects(Polygon polygon, Contour contour)
        {
            if (IntersectsBorders(polygon, contour))
                return true;
            if (PolygonInsider.IsStrictlyInside(polygon, contour, false))
                return true;
            return false;
        }
        // тот метод, что ниже - написан верно
        internal static bool IntersectsBorders(Polygon polygon, Point point)
        {
            foreach (Contour hole in polygon.GetHoles())
                if (ContourIntersector.IntersectsBorders(hole, point))
                    return true;
            foreach (Line line in polygon.GetLines())
                if (LineIntersector.Intersects(line, point))
                    return true;
            return false;
        }

        internal static bool IntersectsBorders(Polygon polygon, Line line1)
        {
            foreach (Contour hole in polygon.GetHoles())
                if (ContourIntersector.IntersectsBorders(hole, line1))
                    return true;
            foreach (Line line in polygon.GetLines())
                if (LineIntersector.Intersects(line, line1))
                    return true;
            return false;
        }
        internal static bool IntersectsBorders(Polygon polygon1, Polygon polygon2)
        {
            foreach (Contour hole in polygon1.GetHoles())
                if (PolygonIntersector.IntersectsBorders(polygon2, hole))
                    return true;
            foreach (Line line in polygon1.GetLines())
                if (IntersectsBorders(polygon2, line))
                    return true;
            return false;
        }
        internal static bool IntersectsBorders(Polygon polygon, Contour contour)
        {
            foreach (Line line in contour.GetLines())
                if (IntersectsBorders(polygon, line))
                    return true;
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = Intersects(_polygon, point);

        public void Visit(Line line) =>
            _result = Intersects(_polygon, line);

        public void Visit(Polygon polygon) =>
            _result = Intersects(_polygon, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointIntersector.Intersects(multiPoint, _polygon);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineIntersector.Intersects(multiLine, _polygon);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _polygon);

        public void Visit(Contour contour) =>
            _result = Intersects(_polygon, contour);
    }
}
