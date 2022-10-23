using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    public class PointIntersector : IModelsIntersector
	{
		private bool _result;
		private Point _point;

		public PointIntersector(Point point) =>
			_point = new Point(point);

		internal static bool Intersects(Point point1, Point point2) =>
			point1.Equals(point2);


		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
            _result = Intersects(point, _point);

		public void Visit(Line line) =>
            _result = LineIntersector.Intersects(line, _point);

		public void Visit(Polygon polygon) =>
            _result = PolygonIntersector.Intersects(polygon, _point);

		public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointIntersector.Intersects(multiPoint, _point);

		public void Visit(MultiLine multiLine) =>
            _result = MultiLineIntersector.Intersects(multiLine, _point);

		public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _point);

		public void Visit(Contour contour) =>
            _result = ContourIntersector.Intersects(contour, _point);
    }
}
