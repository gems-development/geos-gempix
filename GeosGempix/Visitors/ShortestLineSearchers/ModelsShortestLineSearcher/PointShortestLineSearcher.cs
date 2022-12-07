using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher
{
    public class PointShortestLineSearcher : IModelShortestLineSearcher
    {
        private Point _point;
        private Line _result;
        public PointShortestLineSearcher(Point point) =>
            _point = point;

        public void Visit(Point point) =>
            _result = GetShortestLine(_point, point);

        public void Visit(Line line) =>
            _result = LineShortestLineSearcher.GetShortestLine(line, _point);

        public void Visit(Polygon polygon) =>
            _result = PolygonShortestLineSearcher.GetShortestLine(polygon, _point);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointShortestLineSearcher.GetShortestLine(multiPoint, _point);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineShortestLineSearcher.GetShortestLine(multiLine, _point);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, _point);

        public Line GetResult() =>
            _result;

        internal static Line GetShortestLine(Point point1, Point point2) =>
            new Line(point1, point2);
        internal static Line GetShortestLine(Point point, Line line) =>
            LineShortestLineSearcher.GetShortestLine(line, point);

        internal static Line GetShortestLine(Point point, Polygon polygon) =>
            PolygonShortestLineSearcher.GetShortestLine(polygon, point);

        internal static Line GetShortestLine(Point point, MultiLine multiLine) =>
            MultiLineShortestLineSearcher.GetShortestLine(multiLine, point);

        internal static Line GetShortestLine(Point point, MultiPoint multiPoint) =>
            MultiPointShortestLineSearcher.GetShortestLine(multiPoint, point);

        internal static Line GetShortestLine(Point point, MultiPolygon multiPolygon) =>
            MultiPolygonShortestLineSearcher.GetShortestLine(multiPolygon, point);

        public void Visit(Contour contour) =>
            throw new NotImplementedException();
    }
}