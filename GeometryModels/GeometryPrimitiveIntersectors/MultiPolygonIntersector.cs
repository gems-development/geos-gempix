using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
	public class MultiPolygonIntersector : IModelsIntersector
	{

		private bool _result;
		private MultiPolygon _multiPolygon;

		public MultiPolygonIntersector(MultiPolygon multiPolygon)
		{
			_multiPolygon = multiPolygon;
		}

		public static bool Intersects(MultiPolygon multiPolygon, Point point)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (PolygonIntersector.Intersects(polygon, point))
					return true;
			}
			return false;
		}

		public static bool Intersects(MultiPolygon multiPolygon, Line line)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (PolygonIntersector.Intersects(polygon, line))
					return true;
			}
			return false;
		}

		public static bool Intersects(MultiPolygon multiPolygon, Polygon polygon1)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (PolygonIntersector.Intersects(polygon, polygon1))
					return true;
			}
			return false;
		}

		public static bool Intersects(MultiPolygon multiPolygon, MultiPoint multiPoint)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (MultiPointIntersector.Intersects(multiPoint, polygon))
					return true;
			}
			return false;
		}

		public static bool Intersects(MultiPolygon multiPolygon, MultiLine multiLine)
		{
			foreach (Polygon polygon in multiPolygon.GetPolygons())
			{
				if (MultiLineIntersector.Intersects(multiLine, polygon))
					return true;
			}
			return false;
		}

		public static bool Intersects(MultiPolygon multiPolygon1, MultiPolygon multiPolygon2)
		{
			foreach (Polygon polygon in multiPolygon2.GetPolygons())
			{
				if (Intersects(multiPolygon1, polygon))
					return true;
			}
			return false;
		}

		internal static bool Intersects(MultiPolygon multiPolygon, Contour contour)
		{
			throw new NotImplementedException();
		}

		public bool GetResult()
		{
			return _result;
		}

		public void Visit(Point point)
		{
			_result = Intersects(_multiPolygon, point);
		}

		public void Visit(Line line)
		{
			_result = Intersects(_multiPolygon, line);
		}

		public void Visit(Polygon polygon)
		{
			_result = Intersects(_multiPolygon, polygon);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = Intersects(_multiPolygon, multiPoint);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = Intersects(_multiPolygon, multiLine);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = Intersects(_multiPolygon, multiPolygon);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
