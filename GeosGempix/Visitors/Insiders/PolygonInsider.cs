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
            if (PolygonIntersector.Intersects(polygon, point))
                return false;
            foreach (Contour contour1 in polygon.GetHoles())
            {   // здесь есть дублирование проверок - как его избежать без дублирования кода?
                if (ContourInsider.IsInside(contour1, point))
                    return false;
            }
            Contour contour = new Contour(polygon.GetPoints());
            // а не хранить ли контур вместо списка точек?
            if (ContourInsider.IsInside(contour, point))
                return true;
            return false;
        }
        internal static bool IsInside(Polygon polygon, Line line1)
        {
            if (PolygonIntersector.Intersects(polygon, line1))
                return false;
            foreach (Contour contour in polygon.GetHoles())
                if (ContourInsider.IsInside(contour, line1))
                    return false;
            if (IsInside(polygon, line1.Point1))
                return true;
            return false;
        }

        internal static bool IsInside(Polygon polygon1, Polygon polygon2)
        {
            if (PolygonIntersector.Intersects(polygon1, polygon2))
                return false;
            foreach (Contour contour in polygon1.GetHoles())
                if (ContourInsider.IsInside(contour, polygon2))
                    return false;
            if (IsInside(polygon1, polygon2.GetPoints()[0]))
                return true;
            return false;

        }

        internal static bool IsInside(Polygon polygon, Contour contour)
        {
            if (PolygonIntersector.Intersects(polygon, contour))
                return false;
            foreach (Contour contour1 in polygon.GetHoles())
                if (ContourInsider.IsInside(contour1, contour))
                    return false;
            Contour contour2 = new Contour(polygon.GetPoints());
            if (ContourInsider.IsInside(contour2, contour))
                return true;
            return false;
        }

        internal static bool IsInside(Polygon polygon, MultiPoint multiPoint)
        {
            if (MultiPointIntersector.Intersects(multiPoint, polygon))
                return false;
            // если хоть одна точка попадает хоть в одну "дырку" - всё, значит не внутри полигона
            foreach (Contour contour in polygon.GetHoles())
                foreach (Point point in multiPoint.GetPoints())
                    if (ContourInsider.IsInside(contour, point))
                        return false;
            Contour contour1 = new Contour(polygon.GetPoints());
            if (ContourInsider.IsInside(contour1, multiPoint))
                return true;
            return false;
        }

        internal static bool IsInside(Polygon polygon, MultiPolygon multiPolygon)
        {
            // боже сколько дублирований проверок Intersects когда будем вызывать другие функции
            if (MultiPolygonIntersector.Intersects(multiPolygon, polygon))
                return false;
            // если хоть один полигон попадает хоть в одну "дырку" - всё, значит не внутри полигона
            foreach (Contour contour in polygon.GetHoles())
                foreach (Polygon polygon1 in multiPolygon.GetPolygons())
                    if (ContourInsider.IsInside(contour, polygon1))
                        return false;
            Contour contour1 = new Contour(polygon.GetPoints());
            if (ContourInsider.IsInside(contour1, multiPolygon))
                return true;
            return false;
        }

        internal static bool IsInside(Polygon polygon, MultiLine multiLine)
        {
            if (MultiLineIntersector.Intersects(multiLine, polygon))
                return false;
            // если хоть одна линия попадает хоть в одну "дырку" - всё, значит не внутри полигона
            foreach (Contour contour in polygon.GetHoles())
                foreach (Line line in multiLine.GetLines())
                    if (ContourInsider.IsInside(contour, line))
                        return false;
            Contour contour1 = new Contour(polygon.GetPoints());
            if (ContourInsider.IsInside(contour1, multiLine))
                return true;
            return false;
        }

        internal static bool IsStrictlyInside(Polygon polygon, Point point)
        {
            throw new NotImplementedException();
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
