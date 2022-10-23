using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using GeometryModels.GeometryPrimitiveIntersectors;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class LineInsider : IModelInsider
    {
        public LineInsider(Line line) { }

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
