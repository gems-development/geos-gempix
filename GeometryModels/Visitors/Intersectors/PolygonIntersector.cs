using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System.Drawing;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
	public class PolygonIntersector : IModelsIntersector
	{
		private bool _result;
		private Polygon _polygon;

		public PolygonIntersector(Polygon polygon) =>
			_polygon = polygon;

		internal static bool Intersects(Polygon polygon, Point point)
		{
			foreach (Line line in polygon.GetLines())
				if (LineIntersector.Intersects(line, point))
					return true;
			return false;
		}
		internal static bool Intersects(Polygon polygon, Line line1)
		{
			foreach (Line line in polygon.GetLines())
				if (LineIntersector.Intersects(line, line1))
					return true;
			return false;
		}
		internal static bool Intersects(Polygon polygon1, Polygon polygon2)
		{
			foreach (Line line in polygon1.GetLines())
				if (Intersects(polygon2, line))
					return true;
			return false;
		}

		internal static bool Intersects(Polygon polygon, Contour contour)
		{
            foreach (Line line in contour.GetLines())
                if (Intersects(polygon, line))
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
}
