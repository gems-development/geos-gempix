using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
	public class MultiPointIntersector : IModelsIntersector
	{
		private bool _result;
		private MultiPoint _multiPoint;

		public MultiPointIntersector(MultiPoint multiPoint)
		{
			_multiPoint = multiPoint;
		}

		internal static bool Intersects(MultiPoint multiPoint, Point point1)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (PointIntersector.Intersects(point, point1))
					return true;
			}
			return false;
		}

		internal static bool Intersects(MultiPoint multiPoint, Line line)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (LineIntersector.Intersects(line, point))
					return true;
			}
			return false;
		}

		internal static bool Intersects(MultiPoint multiPoint, Polygon polygon)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (PolygonIntersector.Intersects(polygon, point))
					return true;
			}
			return false;
		}

		internal static bool Intersects(MultiPoint multiPoint1, MultiPoint multiPoint2)
		{
			foreach (Point point in multiPoint2.GetPoints())
			{
				if (Intersects(multiPoint1, point))
					return true;
			}
			return false;
		}

		internal static bool Intersects(MultiPoint multiPoint, Contour contour)
		{
			throw new NotImplementedException();
		}

		public bool GetResult()
		{
			return _result;
		}

		public void Visit(Point point)
		{
			_result = Intersects(_multiPoint, point);
		}

		public void Visit(Line line)
		{
			_result = Intersects(_multiPoint, line);
		}

		public void Visit(Polygon polygon)
		{
			_result = Intersects(_multiPoint, polygon);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = Intersects(_multiPoint, multiPoint);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineIntersector.Intersects(multiLine, _multiPoint);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonIntersector.Intersects(multiPolygon, _multiPoint);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
