using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class MultiLineInsider : IModelsIntersector
	{
		private bool _result;
		private MultiLine _multiLine;

		public MultiLineInsider(MultiLine multiLine) =>
			_multiLine = multiLine;

		public static bool IsInside(MultiLine multiLine, Point point)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (LineInsider.IsInside(line, point))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiLine multiLine, Line line1)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (LineInsider.IsInside(line, line1))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiLine multiLine, Polygon polygon)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (PolygonInsider.IsInside(polygon, line))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiLine multiLine, MultiPoint multiPoint)
		{
			foreach (Line line in multiLine.GetLines())
			{
				if (MultiPointInsider.IsInside(multiPoint, line))
					return true;
			}
			return false;
		}

		public static bool IsInside(MultiLine multiLine1, MultiLine multiLine2)
		{
			foreach (Line line in multiLine1.GetLines())
			{
				if (IsInside(multiLine2, line))
					return true;
			}
			return false;
		}

		internal static bool IsInside(MultiLine multiLine, Contour contour) =>
			throw new NotImplementedException();

		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(_multiLine, point);

		public void Visit(Line line) =>
			_result = IsInside(_multiLine, line);

		public void Visit(Polygon polygon) =>
			_result = IsInside(_multiLine, polygon);

		public void Visit(MultiPoint multiPoint) =>
			_result = IsInside(_multiLine, multiPoint);

		public void Visit(MultiLine multiLine) =>
			_result = IsInside(_multiLine, multiLine);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = MultiPolygonInsider.IsInside(multiPolygon, _multiLine);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}
