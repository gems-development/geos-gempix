using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.GeometryPrimitiveIntersectors;

namespace GeometryModels.GeometryPrimitiveTouchers
{
	public class LineToucher : IModelToucher
    {
		private bool _result;
		private Line? _line;

		public LineToucher(Line line)
		{
			_line = line;
		}

		internal static bool IsTouching(Line line, Point point)
		{
			return LineIntersector.Intersects(line, point);
		}

		internal static bool IsTouching(Line line1, Line line2)
		{
			return IsTouching(line1, line2.Point1) && IsTouching(line1, line2.Point2);
		}
		public bool GetResult()
		{
			return _result;
		}

		public void Visit(Point point)
		{
			_result = IsTouching(_line, point);
		}

		public void Visit(Line line)
		{
			_result = IsTouching(_line, line);
		}

		public void Visit(Polygon polygon)
		{
			_result = PolygonToucher.IsTouching(polygon, _line);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = MultiPointToucher.IsTouching(multiPoint, _line);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineToucher.IsTouching(multiLine, _line);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonToucher.IsTouching(multiPolygon, _line);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
