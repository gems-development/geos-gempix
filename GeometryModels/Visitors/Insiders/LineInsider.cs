using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.GeometryPrimitiveIntersectors;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class LineInsider : IModelsIntersector
	{
		private bool _result;
		private Line _line;
		public LineInsider(Line line)
		{
			_line = line;
			_result = false;
		}

		public static bool IsInside(Line line, Point point) =>
			LineIntersector.Intersects(line, point);

		public static bool IsInside(Line line1, Line line2) =>
			IsInside(line1, line2.Point1) && IsInside(line1, line2.Point2);

		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(_line, point);

		public void Visit(Line line) =>
			_result = IsInside(_line, line);

		public void Visit(Polygon polygon) =>
			_result = false;

		public void Visit(MultiPoint multiPoint)
		{
			foreach (Point point in multiPoint.GetPoints())
			{
				_result = IsInside(_line, point);
				if (!_result)
					break;
			}
		}

		public void Visit(MultiLine multiLine)
		{
			foreach (Line line in multiLine.GetLines())
			{
				_result = IsInside(_line, line);
				if (!_result)
					break;
			}
		}

		public void Visit(MultiPolygon multiPolygon) =>
			_result = false;

		public void Visit(Contour contour) =>
			_result = false;
	}
}
