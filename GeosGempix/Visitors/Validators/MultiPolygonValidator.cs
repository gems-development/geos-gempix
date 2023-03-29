using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class MultiPolygonValidator : IValidator
	{
        private bool _result;
        private readonly MultiPolygon _multipolygon;

        public MultiPolygonValidator(MultiPolygon multipolygon)
        {
            _multipolygon = new MultiPolygon(multipolygon.GetPolygons());
            _result = false;
        }

        public bool Validate()
        {
            if(_multipolygon!=null)
                _result = true;
            return _result;
        }
    }
}
