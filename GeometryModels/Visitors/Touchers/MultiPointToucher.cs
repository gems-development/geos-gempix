using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveTouchers
{
	public class MultiPointToucher : IModelToucher
    {
		private bool _result;
		private readonly MultiPoint _multiPoint;

		public MultiPointToucher(MultiPoint multiPoint)
		{
			_multiPoint = multiPoint;
		}

		internal static bool IsTouching(MultiPoint multiPoint, Point point1)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (PointToucher.IsTouching(point, point1))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiPoint multiPoint, Line line)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (LineToucher.IsTouching(line, point))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiPoint multiPoint, Polygon polygon)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				if (PolygonToucher.IsTouching(polygon, point))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiPoint multiPoint1, MultiPoint multiPoint2)
		{
			foreach (Point point in multiPoint2.GetPoints())
			{
				if (IsTouching(multiPoint1, point))
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
			_result = IsTouching(_multiPoint, point);
		}

		public void Visit(Line line)
		{
			_result = IsTouching(_multiPoint, line);
		}

		public void Visit(Polygon polygon)
		{
			_result = IsTouching(_multiPoint, polygon);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = IsTouching(_multiPoint, multiPoint);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineToucher.IsTouching(multiLine, _multiPoint);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonToucher.IsTouching(multiPolygon, _multiPoint);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
