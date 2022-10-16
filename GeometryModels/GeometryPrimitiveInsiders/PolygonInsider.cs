using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System.Drawing;

namespace GeometryModels.GeometryPrimitiveInsiders
{
    public class PolygonInsider : IModelsIntersector
    {
        private bool _result;
        private Polygon _polygon;
        public static bool IsInside(Polygon polygon, Point point)
        {
            foreach (Line line in polygon.GetLines())
            {
                if (LineInsider.IsInside(line, point))
                    return true;
            }
            return false;
        }
        public static bool IsInside(Polygon polygon, Line line1)
        {
            foreach (Line line in polygon.GetLines())
            {
                if (LineInsider.IsInside(line, line1))
                    return true;
            }
            return false;
        }
        public static bool IsInside(Polygon polygon1, Polygon polygon2)
        {
            foreach (Line line in polygon1.GetLines())
            {
                if (IsInside(polygon2, line))
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
            _result = IsInside(_polygon, point);
        }

        public void Visit(Line line)
        {
            _result = IsInside(_polygon, line);
        }

        public void Visit(Polygon polygon)
        {
            _result = IsInside(_polygon, polygon);
        }

        public void Visit(MultiPoint multiPoint)
        {
            _result = MultiPointInsider.IsInside(multiPoint, _polygon);
        }

        public void Visit(MultiLine multiLine) 
        {
            _result = MultiLineInsider.IsInside(multiLine, _polygon);
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            _result = MultiPolygonInsider.IsInside(multiPolygon, _polygon);
        }

        public void Visit(Contour contour)
        {
            throw new NotImplementedException();
        }
    }
}
