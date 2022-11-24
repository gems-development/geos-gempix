using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;

namespace GeometryModels.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher
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

        public static Line GetShortestLine(Line line, Point point)
        {
            Line shortLine = new Line(new Point(0, 0), new Point(0 ,0));

			var abc = line.GetEquationOfLine();

            var perpendicular = Line.GetEquationOfPerpendicularLine(abc, point);

            if (abc.a != 0)
            {

                double intersectX = ((abc.c * perpendicular.a / abc.a) - perpendicular.c) /
                    (perpendicular.b - (abc.b * perpendicular.a) / abc.a);

                double intersectY = -(abc.b * intersectX + abc.c) / abc.a;

                Point intersect = new Point(intersectX, intersectY);

                shortLine = new Line(point, intersect);

            }

			return shortLine;
        }

        internal static Line GetShortestLine(Line line1, Line line2)
        {
			double[] distances = new double[6];
			Line shortLine = new Line(new Point(0, 0), new Point(10000000, 0));
            if (!LineIntersector.Intersects(line1, line2))
            {
				distances[0] = PointDistanceCalculator.GetDistance(line1.Point1, line2.Point1);
                if (PointDistanceCalculator.GetDistance(line1.Point1, line2.Point1) <
				   shortLine.GetLength()) shortLine = new Line(line1.Point1, line2.Point1);

				distances[1] = PointDistanceCalculator.GetDistance(line1.Point1, line2.Point2);
				if (PointDistanceCalculator.GetDistance(line1.Point1, line2.Point2) <
				   shortLine.GetLength()) shortLine = new Line(line1.Point1, line2.Point2);

				distances[2] = PointDistanceCalculator.GetDistance(line1.Point2, line2.Point1);
				if (PointDistanceCalculator.GetDistance(line1.Point2, line2.Point1) <
				   shortLine.GetLength()) shortLine = new Line(line1.Point2, line2.Point1);

				distances[3] = PointDistanceCalculator.GetDistance(line1.Point2, line2.Point2);
				if (PointDistanceCalculator.GetDistance(line1.Point2, line2.Point2) <
				   shortLine.GetLength()) shortLine = new Line(line1.Point2, line2.Point2);

				double k = (line2.Point2.Y - line2.Point1.Y) / (line2.Point2.X - line2.Point1.X);
				double b = line2.Point1.Y - k * line2.Point1.X;
				double xz1 = (line1.Point1.X * line2.Point2.X - line1.Point1.X * line2.Point1.X +
					line1.Point1.Y * line2.Point2.Y - line1.Point1.Y - line2.Point1.Y +
					line2.Point1.Y * b - line2.Point2.Y * b) /
					(k * line2.Point2.Y - k * line2.Point1.Y + line2.Point2.X - line2.Point1.X);
				Point point1 = new Point(xz1, k * xz1 + b);
				distances[4] = PointDistanceCalculator.GetDistance(line1.Point1, point1);
				if (PointDistanceCalculator.GetDistance(line1.Point1, point1) <
				   shortLine.GetLength()) shortLine = new Line(line1.Point1, point1);
				double xz2 = (line1.Point2.X * line2.Point2.X - line1.Point2.X * line2.Point1.X +
					line1.Point2.Y * line2.Point2.Y - line1.Point2.Y - line2.Point1.Y +
					line2.Point1.Y * b - line2.Point2.Y * b) / (k * line2.Point2.Y - k * line2.Point1.Y +
					line2.Point2.X - line2.Point1.X);
				Point point2 = new Point(xz2, k * xz2 + b);
				distances[5] = PointDistanceCalculator.GetDistance(line1.Point1, point2);
				if (PointDistanceCalculator.GetDistance(line1.Point1, point2) <
				   shortLine.GetLength()) shortLine = new Line(line1.Point1, point2);
			}
			return shortLine;
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