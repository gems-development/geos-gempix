using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.GeometryPrimitiveInsiders
{
    public class MultiPointInsider : IModelInsider
    {
        public MultiPointInsider(MultiPoint multiPoint) { }

        public bool GetResult() =>
            false;

        public void Visit(Point point) { }

        public void Visit(Line line) { }

        public void Visit(Polygon polygon) { }

        public void Visit(MultiPoint multiPoint) { }

        public void Visit(MultiLine multiLine) { }

        public void Visit(MultiPolygon multiPolygon) { }

        public void Visit(Contour contour) { }
    }
}
