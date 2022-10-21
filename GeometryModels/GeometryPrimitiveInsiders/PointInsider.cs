using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class PointInsider : IModelsIntersector
	{
		private bool _result;
		private Point _point;

		public PointInsider(Point point)
		{
			_point = new Point(point);
			_result = false;
		}

		public static bool IsInside(Point point1, Point point2) =>
			point1.Equals(point2);


		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(point, _point);

		public void Visit(Line line) =>
			_result = false;

		public void Visit(Polygon polygon) =>
			_result = false;

		public void Visit(MultiPoint multiPoint)
		{
			if (multiPoint.GetPoints().Count == 1)
				_result = multiPoint.GetPoints()[0].Equals(_point);
			else
				_result = false;
		}

		public void Visit(MultiLine multiLine) =>
			_result = false;

		public void Visit(MultiPolygon multiPolygon) =>
			_result = false;

		public void Visit(Contour contour) =>
			_result = false;
	}
}
