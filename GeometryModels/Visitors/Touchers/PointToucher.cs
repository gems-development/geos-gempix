using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveTouchers
{
	public class PointToucher : IModelsIntersector
	{
		private bool _result;
		private Point _point;

		public PointToucher(Point point)
		{
			_point = new Point(point);
			_result = false;
		}

		internal static bool IsTouching(Point point1, Point point2)
		{
			return point1.Equals(point2);
		}


		public bool GetResult()
		{
			return true;
		}

		public void Visit(Point point)
		{
			_result = IsTouching(point, _point);
		}

		public void Visit(Line line)
		{
			_result = LineToucher.IsTouching(line, _point);
		}

		public void Visit(Polygon polygon)
		{
			_result = PolygonToucher.IsTouching(polygon, _point);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = MultiPointToucher.IsTouching(multiPoint, _point);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineToucher.IsTouching(multiLine, _point);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonToucher.IsTouching(multiPolygon, _point);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
