using GeometryModels.GeometryPrimitiveTouchers;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.Extensions
{
    internal class ContourToucher : IModelToucher
    {
        private bool _result;
        private Contour _contour;

        public ContourToucher(Contour contour) =>
            _contour = contour;

        internal static bool IsTouching(Contour contour, Point point)
        {
            foreach (Line line in contour.GetLines())
                if (LineToucher.IsTouching(line, point))
                    return true;
            return false;
        }
        internal static bool IsTouching(Contour contour, Line line1)
        {
            foreach (Line line in contour.GetLines())
                if (LineToucher.IsTouching(line, line1))
                    return true;
            return false;
        }
        internal static bool IsTouching(Contour contour1, Contour contour2)
        {
            foreach (Line line in contour1.GetLines())
                if (IsTouching(contour2, line))
                    return true;
            return false;
        }

        internal static bool IsTouching(Contour contour1, Polygon polygon2)
        {
            foreach (Line line in contour1.GetLines())
                if (PolygonToucher.IsTouching(polygon2, line))
                    return true;
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = IsTouching(_contour, point);

        public void Visit(Line line) =>
            _result = IsTouching(_contour, line);

        public void Visit(Polygon polygon) =>
            _result = IsTouching(_contour, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointToucher.IsTouching(multiPoint, _contour);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineToucher.IsTouching(multiLine, _contour);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonToucher.IsTouching(multiPolygon, _contour);

        public void Visit(Contour contour) =>
            _result = IsTouching(_contour, contour);
    }
}