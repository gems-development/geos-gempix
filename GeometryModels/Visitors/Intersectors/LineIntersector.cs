using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System.Drawing;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
	public class LineIntersector : IModelsIntersector
	{
		private bool _result;
		private Line _line;

		public LineIntersector(Line line)=>
			_line = line;

		public static bool Intersects(Line line, Point point)=>
			Math.Abs(PointShortestLineSearcher.GetDistance(point, line.Point1) +
				PointShortestLineSearcher.GetDistance(point, line.Point2) - line.GetLength()) < 0.00000001;

		// это для прямых, а не для отрезков, и надо учесть случай совпадения прямых
		// метод пересечения отрезков будет включать в себя метод GetPointOfIntersection 
		// его нужно прописать отдельно
		public static bool Intersects(Line line1, Line line2)
		{
			if (line1.Point1.X == line1.Point2.X && line2.Point1.X != line2.Point2.X)
				return true;
			if (line1.Point1.X == line1.Point2.X && line2.Point1.X == line2.Point2.X)
				return false;

			double k1 = (line1.Point2.Y - line1.Point1.Y) / (line1.Point2.X - line1.Point1.X);
			double k2 = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);

			return k2 - k1 > 0;
		}

		// подразумевается, что прямые не параллельны друг другу
		internal static Point GetPointOfIntersection(double[] lineEq1, double[] lineEq2)
		{
			if (lineEq1[0] / lineEq2[0] == lineEq1[1] / lineEq2[1] && lineEq1[1] / lineEq2[1] == lineEq1[2] / lineEq2[2])
				throw new ArithmeticException("Отрезки не должны быть параллельны друг другу");
			double A1 = lineEq1[0], B1 = lineEq1[1], C1 = lineEq1[2],
				A2 = lineEq2[0], B2 = lineEq2[1], C2 = lineEq2[2];
			// решение системы из двух уравнений прямых
			double x = (-C2 + B2*C1/B1)/ (A2 - B2 * A1 / B1);
			double y = (-C1-A1*x)/ B1;
			return new Point(x, y);
		}
		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
            _result = Intersects(_line, point);

		public void Visit(Line line) =>
            _result = Intersects(_line, line);

		public void Visit(Polygon polygon) =>
            _result = PolygonIntersector.Intersects(polygon, _line);
		
		public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointIntersector.Intersects(multiPoint, _line);
		
		public void Visit(MultiLine multiLine) =>
            _result = MultiLineIntersector.Intersects(multiLine, _line);
		
		public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _line);

		public void Visit(Contour contour) =>
			_result = ContourIntersector.Intersects(contour, _line);

    }
}
