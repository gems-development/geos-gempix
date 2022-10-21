using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System.Drawing;

namespace GeometryModels.GeometryPrimitiveTouchers
{
	public class PolygonToucher : IModelsIntersector
	{
		private bool _result;
		private Polygon _polygon;
		public static bool IsTouching(Polygon polygon, Point point)
		{
			foreach (Line line in polygon.GetLines())
			{
				if (LineToucher.IsTouching(line, point))
					return true;
			}
			return false;
		}
		public static bool IsTouching(Polygon polygon, Line line1)
		{
			foreach (Line line in polygon.GetLines())
			{
				if (LineToucher.IsTouching(line, line1))
					return true;
			}
			return false;
		}
		public static bool IsTouching(Polygon polygon1, Polygon polygon2)
		{
			foreach (Line line in polygon1.GetLines())
			{
				if (IsTouching(polygon2, line))
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
			_result = IsTouching(_polygon, point);
		}

		public void Visit(Line line)
		{
			_result = IsTouching(_polygon, line);
		}

		public void Visit(Polygon polygon)
		{
			_result = IsTouching(_polygon, polygon);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = MultiPointToucher.IsTouching(multiPoint, _polygon);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineToucher.IsTouching(multiLine, _polygon);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonToucher.IsTouching(multiPolygon, _polygon);
		}

		public void Visit(Contour contour)
		{
			throw new NotImplementedException();
		}
	}
}
