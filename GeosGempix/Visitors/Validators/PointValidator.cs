using GeosGempix.GeometryPrimitiveTouchers;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Visitors.Validators
{
	public class PointValidator
	{
		private bool _result;
		private readonly Point _point;

		public PointValidator(Point point)
		{
			_point = new Point(point);
			_result = false;
		}

		internal static bool IsValidate(Point point1, Point point2)
		{
			return point1.Equals(point2);
		}

		public bool GetResult()
		{
			return _result;
		}

		public void Visit(Point point)
		{
			_result = IsValidate(point, _point);
		}

		public void Visit(Line line)
		{
			_result = LineValidator.IsValidate(line, _point);
		}

		public void Visit(Polygon polygon)
		{
			_result = PolygonValidator.IsValidate(polygon, _point);
		}

		public void Visit(MultiPoint multiPoint)
		{
			_result = MultiPointValidator.IsValidate(multiPoint, _point);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineValidator.IsValidate(multiLine, _point);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonValidator.IsValidate(multiPolygon, _point);
		}

		public void Visit(Contour contour)
		{
			_result = ContourValidator.IsValidate(contour, _point);
		}
	}
}
