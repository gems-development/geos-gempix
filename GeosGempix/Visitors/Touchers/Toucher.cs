using GeosGempix.GeometryPrimitiveTouchers;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Extensions
{
    internal class Toucher : IModelToucher
    {
        private readonly bool _result;

        private IModelToucher _toucher;

        public Toucher(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
        {
            primitive1.Accept(this);
            primitive2.Accept(_toucher!);
            _result = _toucher!.GetResult();
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _toucher = new PointToucher(point);

        public void Visit(Line line) =>
            _toucher = new LineToucher(line);

        public void Visit(Polygon polygon) =>
            _toucher = new PolygonToucher(polygon);

        public void Visit(MultiPoint multiPoint) =>
            _toucher = new MultiPointToucher(multiPoint);

        public void Visit(MultiLine multiLine) =>
            _toucher = new MultiLineToucher(multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _toucher = new MultiPolygonToucher(multiPolygon);

        public void Visit(Contour contour) =>
            _toucher = new ContourToucher(contour);
    }
}