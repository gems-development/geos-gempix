using GeometryModels.GeometryPrimitiveInsiders;
using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Visitors.Insiders
{
    public class Insider : IModelInsider
    {
        private bool _result;

        private IModelInsider _insider;

        public Insider(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
        {
            primitive1.Accept(this);
            primitive2.Accept(_insider);
            _result = _insider.GetResult();
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _insider = new PointInsider(point);

        public void Visit(Line line) =>
            _insider = new LineInsider(line);

        public void Visit(Polygon polygon) =>
            _insider = new PolygonInsider(polygon);

        public void Visit(MultiPoint multiPoint) =>
            _insider = new MultiPointInsider(multiPoint);

        public void Visit(MultiLine multiLine) =>
            _insider = new MultiLineInsider(multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _insider = new MultiPolygonInsider(multiPolygon);

        public void Visit(Contour contour) =>
            _insider = new ContourInsider(contour);
    }
}
