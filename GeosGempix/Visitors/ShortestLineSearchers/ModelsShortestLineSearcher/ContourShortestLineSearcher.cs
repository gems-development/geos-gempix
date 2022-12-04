/*using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher
{
	internal class ContourShortestLineSearcher : IModelShortestLineSearcher
	{
		private readonly Contour _contour;
		private Contour _result;

		public ContourShortestLineSearcher(List<Point> points)
			{
				if (points == null)
					throw new ArgumentNullException("points");
				if (points.Capacity == 0)
					throw new ArgumentException("Длина списка points = 0");
				_contour = new Contour(points); 
			}

		public ContourShortestLineSearcher(Contour contour)
		{
			if (contour == null)
				throw new ArgumentNullException("contour");
			_contour = new Contour(contour);
		}

		public Contour GetResult() =>
			_result;

		public void Visit(Point point) =>
			_result = GetShortestLine(_contour, point);

		public void Visit(Line line) =>
			_result = GetShortestLine(_contour, line);

		public void Visit(Polygon polygon) =>
			_result = PolygonShortestLineSearcher.GetShortestLine(polygon, _contour);

		public void Visit(MultiPoint multiPoint) =>
			_result = MultiPointShortestLineSearcher.GetShortestLine(multiPoint, _contour);

		public void Visit(MultiLine multiLine) =>
			_result = MultiLineShortestLineSearcher.GetShortestLine(multiLine, _contour);

		public void Visit(MultiPolygon multiPolygon) =>
			_result = MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, _contour);

		internal static Line GetShortestLine(Contour _contour, Polygon polygon) =>
			PolygonShortestLineSearcher.GetShortestLine(polygon, _contour);

		internal static Line GetShortestLine(Contour _contour, MultiLine multiLine) =>
			MultiLineShortestLineSearcher.GetShortestLine(multiLine, _contour);

		internal static Line GetShortestLine(Contour _contour, MultiPoint multiPoint) =>
			MultiPointShortestLineSearcher.GetShortestLine(multiPoint, _contour);

		internal static Line GetShortestLine(Contour _contour, MultiPolygon multiPolygon) =>
			MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, _contour);

		public void Visit(Contour contour) =>
			throw new NotImplementedException();
	}
}
*/