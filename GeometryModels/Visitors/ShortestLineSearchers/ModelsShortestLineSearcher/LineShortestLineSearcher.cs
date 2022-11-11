using GeometryModels;
using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IModels;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher
{
	public class LineShortestLineSearcher : IModelShortestLineSearcher
	{
		private Line _line;
		private Line _result;

		public LineShortestLineSearcher(Point point1, Point point2) =>
			_line = new Line(point1, point2);

		public LineShortestLineSearcher(Line line) =>
			_line = line;

		public Line GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = GetShortestLine(_line, point);

		public void Visit(Line line) =>
			_result = GetShortestLine(_line, line);

		public void Visit(Polygon polygon) =>
			_result = PolygonShortestLineSearcher.GetShortestLine(polygon, _line);

		public void Visit(MultiPoint multiPoint) =>
			_result = MultiPointShortestLineSearcher.GetShortestLine(multiPoint, _line);

		public void Visit(MultiLine multiLine) =>
			_result = MultiLineShortestLineSearcher.GetShortestLine(multiLine, _line);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, _line);

		internal static Line GetShortestLine(Line line, Point point)
		{
			Line res;
			double a = PointShortestLineSearcher.GetShortestLine(point, line.Point1);
			double b = PointShortestLineSearcher.GetShortestLine(point, line.Point2);
			double c = PointShortestLineSearcher.GetShortestLine(line.Point1, line.Point2);
			if (a * a > b * b + c * c || b * b > a * a + c * c)
			{
				res = Math.Min(a, b);
			}
			else
			{
				double P = line.Point2.Y - line.Point1.Y;
				double Q = line.Point1.X - line.Point2.X;
				double R = -line.Point1.X * P + line.Point1.Y * (line.Point2.X - line.Point1.X);
				res = Math.Abs(P * point.X + Q * point.Y + R) / Math.Sqrt(P * P + Q * Q);
			}
			return res;
		}

		internal static Line GetShortestLine(Line line1, Line line2)
		{
			double[] distances = new double[6];
			if (!LineIntersector.Intersects(line1, line2))
			{
				distances[0] = PointShortestLineSearcher.GetShortestLine(line1.Point1, line2.Point1);
				distances[1] = PointShortestLineSearcher.GetShortestLine(line1.Point1, line2.Point2);
				distances[2] = PointShortestLineSearcher.GetShortestLine(line1.Point2, line2.Point1);
				distances[3] = PointShortestLineSearcher.GetShortestLine(line1.Point2, line2.Point2);
				double k = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);
				double b = line2.Point1.Y - k * line2.Point1.X;
				double xz1 = (line1.Point1.X * line2.Point2.X - line1.Point1.X * line2.Point1.X +
					line1.Point1.Y * line2.Point2.Y - line1.Point1.Y - line2.Point1.Y +
					line2.Point1.Y * b - line2.Point2.Y * b) /
					(k * line2.Point2.Y - k * line2.Point1.Y + line2.Point2.X - line2.Point1.X);
				Point point1 = new Point(xz1, k * xz1 + b);
				distances[4] = PointShortestLineSearcher.GetShortestLine(line1.Point1, point1);
				double xz2 = (line1.Point2.X * line2.Point2.X - line1.Point2.X * line2.Point1.X +
					line1.Point2.Y * line2.Point2.Y - line1.Point2.Y - line2.Point1.Y +
					line2.Point1.Y * b - line2.Point2.Y * b) / (k * line2.Point2.Y - k * line2.Point1.Y +
					line2.Point2.X - line2.Point1.X);
				Point point2 = new Point(xz2, k * xz2 + b);
				distances[5] = PointShortestLineSearcher.GetShortestLine(line1.Point1, point2);
			}
			return distances.Min();
		}

		internal static Line GetShortestLine(Line line, Polygon polygon) =>
			PolygonShortestLineSearcher.GetShortestLine(polygon, line);

		internal static Line GetShortestLine(Line line, MultiLine multiLine) =>
			MultiLineShortestLineSearcher.GetShortestLine(multiLine, line);

		internal static Line GetShortestLine(Line line, MultiPoint multiPoint) =>
			MultiPointShortestLineSearcher.GetShortestLine(multiPoint, line);

		internal static Line GetShortestLine(Line line, MultiPolygon multiPolygon) =>
			MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, line);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}