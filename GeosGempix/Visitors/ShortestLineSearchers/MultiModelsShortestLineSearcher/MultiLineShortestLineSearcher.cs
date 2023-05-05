using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher
{
    public class MultiLineShortestLineSearcher : IModelShortestLineSearcher
    {
        private MultiLine _multiLine;
        private Line? _result;

        public MultiLineShortestLineSearcher(MultiLine multiLine) =>
            _multiLine = multiLine;

        public Line? GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = GetShortestLine(_multiLine, point);

        public void Visit(Line line) =>
            _result = GetShortestLine(_multiLine, line);

        public void Visit(Polygon polygon) =>
            _result = GetShortestLine(_multiLine, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = GetShortestLine(_multiLine, multiPoint);

        public void Visit(MultiLine multiLine) =>
            _result = GetShortestLine(_multiLine, multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, _multiLine);

        public void Visit(Contour contour) =>
            _result = GetShortestLine(_multiLine, contour);

        internal static Line? GetShortestLine(MultiLine multiLine, Polygon polygon) =>
             GetShortestLine(
                 multiLine,
                 polygon,
                 (line, primitive) => LineShortestLineSearcher.GetShortestLine(line, (Polygon)primitive));

        internal static Line? GetShortestLine(MultiLine multiLine, Line line1) =>
             GetShortestLine(
                 multiLine,
                 line1,
                 (line, primitive) => LineShortestLineSearcher.GetShortestLine(line, (Line)primitive));

        internal static Line? GetShortestLine(MultiLine multiLine, Point point) =>
             GetShortestLine(
                 multiLine,
                 point,
                 (line, primitive) => LineShortestLineSearcher.GetShortestLine(line, (Point)primitive));

        internal static Line? GetShortestLine(MultiLine multiLine1, MultiLine multiLine2) =>
             GetShortestLine(
                 multiLine1,
                 multiLine2,
                 (line, primitive) => LineShortestLineSearcher.GetShortestLine(line, (MultiLine)primitive));

        internal static Line? GetShortestLine(MultiLine multiLine, MultiPoint multiPoint) =>
             GetShortestLine(
                 multiLine,
                 multiPoint,
                 (line, primitive) => LineShortestLineSearcher.GetShortestLine(line, (MultiPoint)primitive));

        internal static Line? GetShortestLine(MultiLine multiLine, Contour contour) =>
             GetShortestLine(
                 multiLine,
                 contour,
                 (line, primitive) => LineShortestLineSearcher.GetShortestLine(line, (Contour)primitive));

        internal static Line? GetShortestLine(
            MultiLine multiLine,
            IGeometryPrimitive primitive,
            Func<Line, IGeometryPrimitive, Line> getShortestLine)
        {
            Line shortLine = new Line(new Point(0, 0), new Point(double.MaxValue, double.MaxValue));
            Line curLine = new Line(new Point(0, 0), new Point(0, 0));
            List<Line> lines = multiLine.GetLines();
            foreach (Line? line in lines)
            {
				curLine = getShortestLine(line, primitive);
                if (curLine.GetLength() < shortLine.GetLength())
                {
					shortLine = new Line(curLine);
                }
            }
            return shortLine;
        }
    }
}