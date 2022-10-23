using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class MultiPolygonInsider : IModelInsider
    {

		private bool _result;
		private MultiPolygon _multiPolygon;

		public MultiPolygonInsider(MultiPolygon multiPolygon)
		{
			_multiPolygon = multiPolygon;
		}

		internal static bool IsInside(MultiPolygon multiPolygon, Point point)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (PolygonInsider.IsInside(polygon, point))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPolygon multiPolygon, Line line)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (PolygonInsider.IsInside(polygon, line))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPolygon multiPolygon, Polygon polygon1)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (PolygonInsider.IsInside(polygon, polygon1))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPolygon multiPolygon, MultiPoint multiPoint)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (MultiPointInsider.IsInside(multiPoint, polygon))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPolygon multiPolygon, MultiLine multiLine)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (MultiLineInsider.IsInside(multiLine, polygon))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
		{
			foreach (Polygon polygon in multiPolygon2.GetPolygons())
			{
				if (IsInside(multiPolygon1, polygon))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPolygon multiPolygon, Contour contour) =>
			throw new NotImplementedException();

		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(_multiPolygon, point);

		public void Visit(Line line) =>
			_result = IsInside(_multiPolygon, line);

		public void Visit(Polygon polygon) =>
			_result = IsInside(_multiPolygon, polygon);

		public void Visit(MultiPoint multiPoint) =>
			_result = IsInside(_multiPolygon, multiPoint);

		public void Visit(MultiLine multiLine) =>
			_result = IsInside(_multiPolygon, multiLine);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = IsInside(_multiPolygon, multiPolygon);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}
