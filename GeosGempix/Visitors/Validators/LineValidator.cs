using GeosGempix.Extensions;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Visitors.Validators
{
	public class LineValidator
	{
		private bool _result;
		private readonly Line _line;

		public LineValidator(Line line)
		{
			_line = new Line(line);
			_result = false;
		}

		internal static bool IsValidate(Point point, Line line1)
		{
			return line1.Intersects(point);
		}
		internal static bool IsValidate(Line line1, Line line2)
		{
			return line1.Equals(line2);
		}

		public bool GetResult()
		{
			return _result;
		}

		public void Visit(Point point)
		{
			_result = PointValidator.IsValidate(point, _line);
		}

		public void Visit(Line line)
		{
			_result = LineValidator.IsValidate(line, _line);
		}

		public void Visit(Polygon polygon)
		{
			_result = PolygonValidator.IsValidate(polygon, _line);
		}

		public void Visit(MultiPoint multipoint)
		{
			_result = MultiLineValidator.IsValidate(multipoint, _line);
		}

		public void Visit(MultiLine multiLine)
		{
			_result = MultiLineValidator.IsValidate(multiLine, _line);
		}

		public void Visit(MultiPolygon multiPolygon)
		{
			_result = MultiPolygonValidator.IsValidate(multiPolygon, _line);
		}

		public void Visit(Contour contour)
		{
			_result = ContourValidator.IsValidate(contour, _line);
		}
	}
}
