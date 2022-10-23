using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System.Drawing;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class PolygonInsider : IModelsIntersector
	{
		private bool _result;
		private Polygon? _polygon;
		public static bool IsInside(Polygon polygon, Point point)
		{
			throw new NotImplementedException();
		}
		public static bool IsInside(Polygon polygon, Line line1)
		{
			foreach (Contour contour in polygon.GetHoles())
			{
				if (ContourInsider.IsInside(contour, line1))
				{
					return false;
				}
			}
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

		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(_polygon, point);

		public void Visit(Line line) =>
			_result = IsInside(_polygon, line);

		public void Visit(Polygon polygon) =>
			_result = IsInside(_polygon, polygon);

		public void Visit(MultiPoint multiPoint) =>
			_result = MultiPointInsider.IsInside(multiPoint, _polygon);

		public void Visit(MultiLine multiLine) =>
			_result = MultiLineInsider.IsInside(multiLine, _polygon);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = MultiPolygonInsider.IsInside(multiPolygon, _polygon);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}
