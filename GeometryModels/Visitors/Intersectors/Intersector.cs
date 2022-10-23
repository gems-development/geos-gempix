using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.Visitors.Intersectors
{
    public class Intersector : IModelsIntersector
    {
        private bool _result;

        private IModelsIntersector _intersector;

        public Intersector(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
        {
            primitive1.Accept(this);
            primitive2.Accept(_intersector!);
            _result = _intersector!.GetResult();
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _intersector = new PointIntersector(point);

        public void Visit(Line line) =>
            _intersector = new LineIntersector(line);

        public void Visit(Polygon polygon) =>
            _intersector = new PolygonIntersector(polygon);

        public void Visit(MultiPoint multiPoint) =>
            _intersector = new MultiPointIntersector(multiPoint);

        public void Visit(MultiLine multiLine) =>
            _intersector = new MultiLineIntersector(multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _intersector = new MultiPolygonIntersector(multiPolygon);

        public void Visit(Contour contour) =>
            _intersector = new ContourIntersector(contour);
    }
}
