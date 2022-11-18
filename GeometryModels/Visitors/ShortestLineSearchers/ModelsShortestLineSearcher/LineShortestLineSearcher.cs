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

        internal static Line GetShortestLine(Line line, Point point)
        {
            double[] ABC = line.GetEquationOfLine();

            double[] perpendicular = Line.GetEquationOfPerpendicularLine(ABC, point);

            double intersectX = (( ABC[2] * perpendicular[0] / ABC[0] ) - perpendicular[2]) /
                ( perpendicular[1] - (ABC[1] * perpendicular[0]) / ABC[0] );

            double intersectY = -(ABC[1] * intersectX + ABC[2]) / ABC[0];

			Point intersect = new Point(intersectX, intersectY);

			Line shortline = new Line(point, intersect);

			return shortline;
        }

        internal static Line GetShortestLine(Line line1, Line line2)
        {
			Line shortline = new Line(new Point(0, 0), new Point(0, 0));
            if (!LineIntersector.Intersects(line1, line2))
            {
				
            }
			return shortline;
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