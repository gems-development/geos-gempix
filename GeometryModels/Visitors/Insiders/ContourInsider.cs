﻿using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class ContourInsider : IModelInsider
	{
		private bool _result;
		private Contour _contour;

		public ContourInsider(Contour contour)
		{
			_contour = contour;
		}

		internal static bool IsInside(Contour contour, Point point)
		{
			Line closestLine = null;
			double distance = double.MaxValue;
			double curDistance;
			// нашли самую близкую сторону
			foreach (Line line in contour.GetLines())
			{
				curDistance = LineDistanceCalculator.GetDistance(line, point);
				if (distance > curDistance)
				{
					distance = curDistance;
					closestLine = line;
				}
			}
			Point vertex1 = closestLine!.Point1;
			Point vertex2 = closestLine.Point2;
			Point vertex3 = contour.GetNextPoint(vertex2);
			// уравнения этой стороны и соседней
			double[] equation1 = closestLine.GetEquationOfLine();
			double[] equation2 = new Line(vertex2, vertex3).GetEquationOfLine();
			// уравнение биссектрисы
			double[] bis = GetEquationOfBisector(equation1, equation2, vertex1, vertex3);
			Point pointFromBis1;
			Point pointFromBis2;
			double a = bis[0];
			double b = bis[1];
			double c = bis[2];
			double x, y;
			// надо понять, какой кусочек биссектрисы будет внешним для многоугольника
			if (b != 0)
			{
				x = vertex2.X + 1;
				y = (-c - a * x) / b;
				pointFromBis1 = new Point(x, y);
				x = x - 2;
				y = (-c - a * x) / b;
				pointFromBis2 = new Point(x, y);
			}
			else if (a != 0)
			{
				x = -c / a;
				y = vertex2.Y + 1;
				pointFromBis1 = new Point(x, y);
				y = y - 2;
				pointFromBis2 = new Point(x, y);
			}
			else
				throw new ArithmeticException("Line doesn't exist, coefs A and B are 0");
			// нашли две точки, принадлежащие биссектрисе, одна внешняя, другая внутренняя.
			// определим внешнюю с помощью обходов "по часовой" и "против часовой"
			// рассмотрим треугольники, состоящие из следующих точек:
			// vertex2, pointFromBis1, vertex3
			// vertex2, pointFromBis2, vertex3
			// у одного треугольника будет обход по часовой, у другого против
			// у исходного многоугольника тоже был свой обход
			// Нам нужен тот треугольник, обход которого совпадает с исходным
			// в нем находится нужная нам ВНЕШНЯЯ точка из биссектрисы
			bool bypass = contour.isClockwiseBypass();
			bool bypass1 = new Contour(new List<Point>() { vertex2, pointFromBis1, vertex3 }).isClockwiseBypass();
			Point pointFromBis;
			if (bypass == bypass1)
				pointFromBis = pointFromBis1;
			else
				pointFromBis = pointFromBis2;
			// будем смотреть на угол между нормалью, проходящей через point,
			// и биссектрисой (вектором внешнего ее продолжения)
			Point p = LineIntersector.GetPointOfIntersection(
				equation1,
				Line.GetEquationOfPerpendicularLine(equation1, point));
			// координаты вектора внешней части биссектрисы
			double x1 = pointFromBis.X - vertex2.X;
			double y1 = pointFromBis.Y - vertex2.Y;
			// координаты вектора нормали (неизвестно, внутренняя она или внешняя, в этом и смысл)
			double x2 = point.X - p.X;
			double y2 = point.Y - p.Y;
			// скалярное произведение разделить на произведение длин векторов
			double cos = (x1 * x2 + y1 * y2) / (Math.Sqrt(x1 * x1 + y1 * y1) + Math.Sqrt(x2 * x2 + y2 * y2));
			// если косинус больше нуля, то угол от 0 до 90 градусов, а значит, точка снаружи
			// иначе - внутри
			// косинус не может быть 0
			return cos < 0;
		}

		public static double[] GetEquationOfBisector(double[] line1, double[] line2, Point first, Point last)
		{
			double a1 = line1[0];
			double a2 = line2[0];
			double b1 = line1[1];
			double b2 = line2[1];
			double c1 = line1[2];
			double c2 = line2[2];
			double denum1 = Math.Sqrt(a1 * a1 + b1 * b1);
			double denum2 = Math.Sqrt(a2 * a2 + b2 * b2);
			// одна биссектриса для внешнего угла, другая для внутреннего
			double[] bis1 = {
				a1 * denum2 - a2 * denum1,
				b1 * denum2 - b2 * denum1,
				c1 * denum2 - c2 * denum1 };
			double[] bis2 = {
				a1 * denum2 + a2 * denum1,
				b1 * denum2 + b2 * denum1,
				c1 * denum2 + c2 * denum1 };
			// если подставить координаты точек в уравнения,
			// то если результаты одного знака, то это бис-са внешнего угла, иначе - внутреннего
			double res1 = bis1[0] * first.X + bis1[1] * first.Y + bis1[2];
			double res2 = bis1[0] * last.X + bis1[1] * last.Y + bis1[2];
			if (res1 > 0 && res2 > 0 || res1 < 0 && res2 < 0)
				return bis2;
			return bis1;
		}
		internal static bool IsInside(Contour contour, Line line1)
		{
			if (IsInside(contour, line1.Point1) && !ContourIntersector.Intersects(contour, line1))
				return true;
			return false;
		}
		// надо еще подумать над Intersects, потому что есть дырки в полигоне
		internal static bool IsInside(Contour contour, Polygon polygon)
		{
			if (IsInside(contour, polygon.GetPoints()[0]) && !PolygonIntersector.Intersects(polygon, contour))
				return true;
			return false;
		}

		public bool GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = IsInside(_contour, point);

		public void Visit(Line line) =>
			_result = IsInside(_contour, line);

		public void Visit(Polygon polygon) =>
			_result = false;

		public void Visit(MultiPoint multiPoint) =>
			_result = MultiPointInsider.IsInside(multiPoint, _contour);

		public void Visit(MultiLine multiLine) =>
			_result = MultiLineInsider.IsInside(multiLine, _contour);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = MultiPolygonInsider.IsInside(multiPolygon, _contour);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}