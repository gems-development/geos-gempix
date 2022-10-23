using GeometryModels.Interfaces.IVisitors;
using GeometryModels.Models;

namespace GeometryModels.Extensions
{
    internal class ContourToucher : IModelToucher
    {
        private Contour _contour;

        public ContourToucher(Contour contour)
        {
            _contour = contour;
        }

        public bool GetResult()
        {
            throw new NotImplementedException();
        }

        public void Visit(Point point)
        {
            throw new NotImplementedException();
        }

        public void Visit(Line line)
        {
            throw new NotImplementedException();
        }

        public void Visit(Polygon polygon)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultiPoint multiPoint)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultiLine multiLine)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultiPolygon multiPolygon)
        {
            throw new NotImplementedException();
        }

        public void Visit(Contour contour)
        {
            throw new NotImplementedException();
        }
    }
}