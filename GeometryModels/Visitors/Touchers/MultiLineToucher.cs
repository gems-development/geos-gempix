using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveTouchers
{
	public class MultiLineToucher : IModelToucher
    {
		private bool _result;
		private MultiLine _multiLine;

		public MultiLineToucher(MultiLine multiLine)
		{
			_multiLine = multiLine;
		}

		internal static bool IsTouching(MultiLine multiLine, Point point)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (LineToucher.IsTouching(line, point))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiLine multiLine, Line line1)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (LineToucher.IsTouching(line, line1))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiLine multiLine, Polygon polygon)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (PolygonToucher.IsTouching(polygon, line))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiLine multiLine, MultiPoint multiPoint)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (MultiPointToucher.IsTouching(multiPoint, line))
					return true;
			}
			return false;
		}

		internal static bool IsTouching(MultiLine multiLine1, MultiLine multiLine2)
		{
			foreach (Line line in multiLine1.GetLines())
			{
				if (IsTouching(multiLine2, line))
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
			_result = IsTouching(_multiLine, point);
		}

		public void Visit(Line line)
		{
			_result = IsTouching(_multiLine, line);
		}

		public void Visit(Polygon polygon)
		{
			_result = IsTouching(_multiLine, polygon);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = IsTouching(_multiLine, multiPoint);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = IsTouching(_multiLine, multiLine);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonToucher.IsTouching(multiPolygon, _multiLine);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
