using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveTouchers
{
    public class MultiPolygonToucher : IModelToucher
    {

        private bool _result;
        private readonly MultiPolygon _multiPolygon;

        public MultiPolygonToucher(MultiPolygon multiPolygon)
        {
            _multiPolygon = multiPolygon;
        }

        internal static bool IsTouching(MultiPolygon multiPolygon, Point point)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                if (PolygonToucher.IsTouching(polygon, point))
                    return true;
            }
            return false;
        }

        internal static bool IsTouching(MultiPolygon multiPolygon, Line line)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                if (PolygonToucher.IsTouching(polygon, line))
                    return true;
            }
            return false;
        }

        internal static bool IsTouching(MultiPolygon multiPolygon, Polygon polygon1)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                if (PolygonToucher.IsTouching(polygon, polygon1))
                    return true;
            }
            return false;
        }

        internal static bool IsTouching(MultiPolygon multiPolygon, MultiPoint multiPoint)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                if (MultiPointToucher.IsTouching(multiPoint, polygon))
                    return true;
            }
            return false;
        }

        internal static bool IsTouching(MultiPolygon multiPolygon, MultiLine multiLine)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
            {
                if (MultiLineToucher.IsTouching(multiLine, polygon))
                    return true;
            }
            return false;
        }

        internal static bool IsTouching(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
        {
            foreach (Polygon polygon in multiPolygon2.GetPolygons())
            {
                if (IsTouching(multiPolygon1, polygon))
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
            _result = IsTouching(_multiPolygon, point);
        }

        public void Visit(Line line)
        {
            _result = IsTouching(_multiPolygon, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = IsTouching(_multiPolygon, polygon);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = IsTouching(_multiPolygon, multiPoint);
        }

        public void Visit(MultiLine multiLine)
        {
            _result = IsTouching(_multiPolygon, multiLine);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = IsTouching(_multiPolygon, multiPolygon);
        }

        public void Visit(Contour contour)
        {
            throw new NotImplementedException();
        }

        internal static bool IsTouching(MultiPolygon multiPolygon, Contour contour)
        {
            throw new NotImplementedException();
        }
    }
}
