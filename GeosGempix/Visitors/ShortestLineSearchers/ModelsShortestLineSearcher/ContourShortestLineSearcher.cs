using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using GeosGempix.Extensions;

namespace GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher
{
	internal class ContourShortestLineSearcher : IModelShortestLineSearcher
	{
		private readonly Contour _contour;
		private Line _result;

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

		public Line GetResult() =>
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

        public void Visit(Contour contour) =>
            _result = GetShortestLine(_contour, contour);


        internal static Line? GetShortestLine(Contour contour, Point point)
        {
            Line shortLine = new Line(new Point(0, 0), new Point(double.MaxValue, double.MaxValue));
            Line curLine = null;
            // проверка если точка ВНУТРИ контура... то расстояние должно быть ноль О_О
            if (contour.Intersects(point))
                return null;
            List<Point> points = contour.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                lines.Add(new Line(points[i], points[i + 1]));
            }
            lines.Add(new Line(points[points.Count - 1], points[0]));
            foreach (Line line in lines)
            {
                curLine = LineShortestLineSearcher.GetShortestLine(line, point);
                if (curLine.GetLength() < shortLine.GetLength())
                {
                    shortLine = new Line(curLine);
                }
            }
            return shortLine;
        }

        internal static Line? GetShortestLine(Contour contour, Line line)
        {
            Line shortLine = new Line(new Point(0, 0), new Point(double.MaxValue, double.MaxValue));
            Line curLine = new Line(new Point(0, 0), new Point(0, 0));
            // проверка если отрезок ВНУТРИ контура... 
            if (contour.Intersects(line))
                return null;
            List<Point> points = contour.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                lines.Add(new Line(points[i], points[i + 1]));
            }
            lines.Add(new Line(points[points.Count - 1], points[0]));
            foreach (Line line1 in lines)
            {
                curLine = LineShortestLineSearcher.GetShortestLine(line1, line);
                if (curLine.GetLength() < shortLine.GetLength())
                {
                    shortLine = new Line(curLine);
                }
            }
            return shortLine;
        }

        internal static Line? GetShortestLine(Contour contour1, Contour contour2)
        {
             Line shortLine = new Line(new Point(0, 0), new Point(double.MaxValue, double.MaxValue));
            Line curLine = new Line(new Point(0, 0), new Point(0, 0));
            // проверка если контур ВНУТРИ контура... какой внутри какого?)))
            if (contour1.Intersects(contour2) || contour2.Intersects(contour1))
                return null;
            List<Point> points = contour2.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                lines.Add(new Line(points[i], points[i + 1]));
            }
            lines.Add(new Line(points[points.Count - 1], points[0]));

            foreach (Line line in lines)
            {
                curLine = GetShortestLine(contour1, line);
                if (curLine.GetLength() < shortLine.GetLength())
                {
                    shortLine = new Line(curLine);
                }
            }
            return shortLine;
        }
         
        internal static Line GetShortestLine(Contour contour, Polygon polygon) =>
			PolygonShortestLineSearcher.GetShortestLine(polygon, contour);

		internal static Line GetShortestLine(Contour contour, MultiLine multiLine) =>
			MultiLineShortestLineSearcher.GetShortestLine(multiLine, contour);

		internal static Line GetShortestLine(Contour contour, MultiPoint multiPoint) =>
			MultiPointShortestLineSearcher.GetShortestLine(multiPoint, contour);

		internal static Line GetShortestLine(Contour contour, MultiPolygon multiPolygon) =>
			MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, contour);

		
	}
}
