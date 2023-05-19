using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.ShortestLineSearchers.ModelsShortestLineSearcher;
using GeosGempix.Visitors.ShortestLineSearchers.MultiModelsShortestLineSearcher;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.ShortestLineSearchers
{
    public class ShortestLineSearcher : IModelShortestLineSearcher
    {
        private readonly Line? _result;

        private IModelShortestLineSearcher _searcher;

        public ShortestLineSearcher(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
        {
            primitive1.Accept(this);
            primitive2.Accept(_searcher!);
            _result = _searcher!.GetResult();
        }

        public Line? GetResult() =>
            _result;

        public void Visit(Point point) =>
            _searcher = new PointShortestLineSearcher(point);

        public void Visit(Line line) =>
            _searcher = new LineShortestLineSearcher(line);

        public void Visit(Polygon polygon) =>
            _searcher = new PolygonShortestLineSearcher(polygon);

        public void Visit(MultiPoint multiPoint) =>
            _searcher = new MultiPointShortestLineSearcher(multiPoint);

        public void Visit(MultiLine multiLine) =>
            _searcher = new MultiLineShortestLineSearcher(multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _searcher = new MultiPolygonShortestLineSearcher(multiPolygon);

        public void Visit(Contour contour) =>
            _searcher = new ContourShortestLineSearcher(contour);
    }
}