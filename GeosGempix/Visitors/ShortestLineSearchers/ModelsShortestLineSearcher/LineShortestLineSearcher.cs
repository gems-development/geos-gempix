using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher
{
    public class LineShortestLineSearcher : IModelShortestLineSearcher
    {
        private readonly Line _line;
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

        public void Visit(Contour contour) =>
            _result = ContourShortestLineSearcher.GetShortestLine(contour, _line);

        internal static Line GetShortestLine(Line line, Point point)
        {
            Line shortLine = new Line(new Point(0, 0), new Point(0 ,0));

			var abc = line.GetEquationOfLine();

            var perpendicular = Line.GetEquationOfPerpendicularLine(abc, point);

            if (abc.a != 0)
            {

                double intersectX = ( (perpendicular.c / perpendicular.a) - (abc.c / abc.a)) /
                    ( (perpendicular.b / perpendicular.a) - (abc.b / abc.a));

                double intersectY = - ( abc.b * intersectX + abc.c) / abc.a;

                Point intersect = new Point(intersectX, intersectY);

                shortLine = new Line(point, intersect);

            }

			return shortLine;
        }

        public static Line GetShortestLine(Line line1, Line line2)
        {
			Line shortLine = new Line(new Point(0, 0), new Point(10000000, 0));
            Line shortLine1 = GetShortestLine(line1, line2.Point1);
			Line shortLine2 = GetShortestLine(line1, line2.Point2);
            if(shortLine1.GetLength() < shortLine.GetLength())
            {
                shortLine = new Line(shortLine1);
            }
            else
            {
                shortLine = new Line(shortLine2);
            }
			return shortLine;
        }

        internal static Line GetShortestLine(Line line, Contour contour) =>
            ContourShortestLineSearcher.GetShortestLine(contour, line);

        internal static Line GetShortestLine(Line line, Polygon polygon) =>
            PolygonShortestLineSearcher.GetShortestLine(polygon, line);

        internal static Line GetShortestLine(Line line, MultiLine multiLine) =>
            MultiLineShortestLineSearcher.GetShortestLine(multiLine, line);

        internal static Line GetShortestLine(Line line, MultiPoint multiPoint) =>
            MultiPointShortestLineSearcher.GetShortestLine(multiPoint, line);

        internal static Line GetShortestLine(Line line, MultiPolygon multiPolygon) =>
            MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, line);
    }
}