using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.GeometryPrimitiveInsiders
{
    public class PolygonInsider : IModelInsider
    {
        private bool _result;
        private Polygon? _polygon;

        public PolygonInsider(Polygon? polygon) =>
            _polygon = polygon;


        internal static bool IsInside(Polygon polygon, Point point)
        {
            return IsStrictlyInside(polygon, point);
        }
        internal static bool IsInside(Polygon polygon, Line line)
        {
            return IsStrictlyInside(polygon, line);
        }

        internal static bool IsInside(Polygon polygon1, Polygon polygon2)
        {
            return IsStrictlyInside(polygon1, polygon2);
        }

        internal static bool IsInside(Polygon polygon, Contour contour)
        {
            return IsStrictlyInside(polygon, contour);
        }

        internal static bool IsInside(Polygon polygon, MultiPoint multiPoint)
        {
            return IsStrictlyInside(polygon, multiPoint);
        }

        internal static bool IsInside(Polygon polygon, MultiPolygon multiPolygon)
        {
            return IsStrictlyInside(polygon, multiPolygon);
        }

        internal static bool IsInside(Polygon polygon, MultiLine multiLine)
        {
            return IsStrictlyInside(polygon, multiLine);
        }

        internal static bool IsStrictlyInside(Polygon polygon, Point point, bool intersectBordersCheckRequired = true)
        {
            bool doesIntersectBorders = false;
            if (intersectBordersCheckRequired)
                doesIntersectBorders = PolygonIntersector.IntersectsBorders(polygon, point);
            foreach (Contour hole in polygon.GetHoles())
            {   // здесь есть дублирование проверок - как его избежать без дублирования кода?
                if (ContourInsider.IsStrictlyInside(hole, point))
                    return false;
            }
            var mainContour = new Contour(polygon.GetPoints());
            
            return !doesIntersectBorders && ContourInsider.IsStrictlyInside(mainContour, point);
        }
        internal static bool IsStrictlyInside(Polygon polygon, Line line, bool intersectBordersCheckRequired = true)
        {
            if (!intersectBordersCheckRequired && PolygonIntersector.IntersectsBorders(polygon, line))
                return false;
            foreach (Contour hole in polygon.GetHoles())
                if (ContourInsider.IsStrictlyInside(hole, line))
                    return false;
            if (IsInside(polygon, line.Point1))
                return true;
            return false;
        }

        internal static bool IsStrictlyInside(Polygon polygon1, Polygon polygon2, bool intersectBordersCheckRequired = true)
        {
            if (!intersectBordersCheckRequired && PolygonIntersector.IntersectsBorders(polygon1, polygon2))
                return false;
            foreach (Contour hole in polygon1.GetHoles())
                if (ContourInsider.IsStrictlyInside(hole, polygon2))
                    return false;
            if (IsInside(polygon1, polygon2.GetPoints()[0]))
                return true;
            return false;

        }

        internal static bool IsStrictlyInside(Polygon polygon, Contour contour, bool intersectBordersCheckRequired = true)
        {
            if (!intersectBordersCheckRequired && PolygonIntersector.IntersectsBorders(polygon, contour))
                return false;
            foreach (Contour hole in polygon.GetHoles())
                if (ContourInsider.IsStrictlyInside(hole, contour))
                    return false;
            var mainContour = new Contour(polygon.GetPoints());
            if (ContourInsider.IsStrictlyInside(mainContour, contour))
                return true;
            return false;
        }

        internal static bool IsStrictlyInside(Polygon polygon, MultiPoint multiPoint)
        {
            if (MultiPointIntersector.Intersects(multiPoint, polygon))
                return false;
            // если хоть одна точка попадает хоть в одну "дырку" - всё, значит не внутри полигона
            foreach (Contour hole in polygon.GetHoles())
                foreach (Point point in multiPoint.GetPoints())
                    if (ContourInsider.IsStrictlyInside(hole, point))
                        return false;
            var mainContour = new Contour(polygon.GetPoints());
            if (ContourInsider.IsStrictlyInside(mainContour, multiPoint))
                return true;
            return false;
        }

        internal static bool IsStrictlyInside(Polygon polygon, MultiPolygon multiPolygon)
        {
            // боже сколько дублирований проверок Intersects когда будем вызывать другие функции
            if (MultiPolygonIntersector.Intersects(multiPolygon, polygon))
                return false;
            // если хоть один полигон попадает хоть в одну "дырку" - всё, значит не внутри полигона
            foreach (Contour hole in polygon.GetHoles())
                foreach (Polygon polygon1 in multiPolygon.GetPolygons())
                    if (ContourInsider.IsStrictlyInside(hole, polygon1))
                        return false;
            var mainContour = new Contour(polygon.GetPoints());
            if (ContourInsider.IsStrictlyInside(mainContour, multiPolygon))
                return true;
            return false;
        }

        internal static bool IsStrictlyInside(Polygon polygon, MultiLine multiLine)
        {
            if (MultiLineIntersector.Intersects(multiLine, polygon))
                return false;
            // если хоть одна линия попадает хоть в одну "дырку" - всё, значит не внутри полигона
            foreach (Contour hole in polygon.GetHoles())
                foreach (Line line in multiLine.GetLines())
                    if (ContourInsider.IsStrictlyInside(hole, line))
                        return false;
            var mainContour = new Contour(polygon.GetPoints());
            if (ContourInsider.IsStrictlyInside(mainContour, multiLine))
                return true;
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = IsInside(_polygon!, point);

        public void Visit(Line line) =>
            _result = IsInside(_polygon!, line);

        public void Visit(Polygon polygon) =>
            _result = IsInside(_polygon!, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = IsInside(_polygon!, multiPoint);

        public void Visit(MultiLine multiLine) =>
            _result = IsInside(_polygon!, multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = IsInside(_polygon!, multiPolygon);

        public void Visit(Contour contour) =>
            _result = IsInside(_polygon!, contour);
    }
}
