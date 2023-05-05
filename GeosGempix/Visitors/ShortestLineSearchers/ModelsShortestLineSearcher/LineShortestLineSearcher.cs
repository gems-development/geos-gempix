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
            double[] distances = new double[3];
            distances[2] = double.MaxValue;
            distances[0] = PointDistanceCalculator.GetDistance(line.Point1, point);
            distances[1] = PointDistanceCalculator.GetDistance(line.Point2, point);
            var eq1 = line.GetEquationOfLine();
            var eq2 = Line.GetEquationOfPerpendicularLine(eq1, point);
            Point? point1 = LineIntersector.GetPointOfIntersection(eq1, eq2);
            if (LineIntersector.Intersects(line, point1))
                distances[2] = PointDistanceCalculator.GetDistance(point1, point);
            double minDistance = distances.Min();
            if (distances[0].Equals(minDistance))
                return new Line(line.Point1, point);
            if (distances[1].Equals(minDistance))
                return new Line(line.Point2, point);
            return new Line(point1, point);
        }

        public static Line GetShortestLine(Line line1, Line line2)
        {
            Line shortLine1 = GetShortestLine(line1, line2.Point1);
			Line shortLine2 = GetShortestLine(line1, line2.Point2);
            Line shortLine3 = GetShortestLine(line2, line1.Point1);
            Line shortLine4 = GetShortestLine(line2, line1.Point2);
            Line shortLine = new Line(shortLine1);
            if (shortLine2.GetLength() < shortLine.GetLength())
                shortLine = new Line(shortLine2);
            if (shortLine3.GetLength() < shortLine.GetLength())
                shortLine = new Line(shortLine3);
            if (shortLine4.GetLength() < shortLine.GetLength())
                shortLine = new Line(shortLine4);
            return shortLine;
        }

        internal static Line? GetShortestLine(Line line, Contour contour) =>
            ContourShortestLineSearcher.GetShortestLine(contour, line);

        internal static Line? GetShortestLine(Line line, Polygon polygon) =>
            PolygonShortestLineSearcher.GetShortestLine(polygon, line);

        internal static Line GetShortestLine(Line line, MultiLine multiLine) =>
            MultiLineShortestLineSearcher.GetShortestLine(multiLine, line);

        internal static Line GetShortestLine(Line line, MultiPoint multiPoint) =>
            MultiPointShortestLineSearcher.GetShortestLine(multiPoint, line);

        internal static Line GetShortestLine(Line line, MultiPolygon multiPolygon) =>
            MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, line);
    }
}