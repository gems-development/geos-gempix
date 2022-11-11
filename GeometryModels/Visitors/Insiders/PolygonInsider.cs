using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System.Drawing;

namespace GeometryModels.GeometryPrimitiveInsiders
{
    public class PolygonInsider : IModelInsider
    {
        private bool _result;
        private Polygon? _polygon;

        public PolygonInsider(Polygon? polygon) =>
            _polygon = polygon;

        public static bool IsInside(Polygon polygon, Point point)
        {
            foreach (Contour contour1 in polygon.GetHoles())
            {
                if (ContourInsider.IsInside(contour1, point))
                    return false;
                if (ContourIntersector.Intersects(contour1, point))
                    return false;
            }
            Contour contour = new Contour(polygon.GetPoints());
            if (ContourInsider.IsInside(contour, point))
                return true;
            return false;
        }
        public static bool IsInside(Polygon polygon, Line line1)
        {
            foreach (Contour contour in polygon.GetHoles())
                if (ContourInsider.IsInside(contour, line1))
                    return false;
            if (IsInside(polygon, line1.Point1) && !PolygonIntersector.Intersects(polygon, line1))
                return true;
            return false;
        }
        // надо еще подумать над Intersects, потому что есть дырки в полигоне
        public static bool IsInside(Polygon polygon1, Polygon polygon2)
        {
            if (IsInside(polygon1, polygon2.GetPoints()[0]) && !PolygonIntersector.Intersects(polygon1, polygon2))
                return true;
            return false;
        }

        internal static bool IsInside(Polygon polygon, Contour contour)
        {
            foreach (Contour contour1 in polygon.GetHoles())
                if (ContourInsider.IsInside(contour1, contour))
                    return false;
            Contour contour2 = new Contour(polygon.GetPoints());
            if (ContourInsider.IsInside(contour2, contour))
                return true;
            return false;
        }

        private bool IsInside(MultiPoint multiPoint, Polygon? polygon)
        {
            throw new NotImplementedException();
        }

        private bool IsInside(MultiPolygon multiPolygon, Polygon? polygon)
        {
            throw new NotImplementedException();
        }

        private bool IsInside(MultiLine multiLine, Polygon? polygon)
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
            _result = IsInside(multiPoint, _polygon);

        public void Visit(MultiLine multiLine) =>
            _result = IsInside(multiLine, _polygon);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = IsInside(multiPolygon, _polygon);

        public void Visit(Contour contour) =>
            throw new NotImplementedException();
    }
}
