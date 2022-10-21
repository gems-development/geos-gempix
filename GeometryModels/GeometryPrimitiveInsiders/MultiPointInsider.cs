using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class MultiPointInsider : IModelsIntersector
	{
		private bool _result;
		private MultiPoint _multiPoint;

		public MultiPointInsider(MultiPoint multiPoint)
		{
			_multiPoint = multiPoint;
		}

		public static bool IsInside(MultiPoint multiPoint, Point point1)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (PointInsider.IsInside(point, point1))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiPoint multiPoint, Line line)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (LineInsider.IsInside(line, point))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiPoint multiPoint, Polygon polygon)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (PolygonInsider.IsInside(polygon, point))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiPoint multiPoint1, MultiPoint multiPoint2)
		{
			foreach (Point point in multiPoint2.GetPoints())
			{
				if (IsInside(multiPoint1, point))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiPoint multiPoint, Contour contour)
		{
			throw new NotImplementedException();
		}

		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(_multiPoint, point);

		public void Visit(Line line) =>
			_result = IsInside(_multiPoint, line);

		public void Visit(Polygon polygon) =>
			_result = IsInside(_multiPoint, polygon);

		public void Visit(MultiPoint multiPoint) =>
			_result = IsInside(_multiPoint, multiPoint);

		public void Visit(MultiLine multiLine) =>
			_result = MultiLineInsider.IsInside(multiLine, _multiPoint);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = MultiPolygonInsider.IsInside(multiPolygon, _multiPoint);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}
