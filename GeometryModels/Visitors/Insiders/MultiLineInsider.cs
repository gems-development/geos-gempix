using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.GeometryPrimitiveInsiders
{
	public class MultiLineInsider : IModelInsider
    {
        public MultiLineInsider(MultiLine multiLine) { }

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
