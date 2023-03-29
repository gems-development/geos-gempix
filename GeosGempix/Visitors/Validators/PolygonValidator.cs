using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class PolygonValidator : IValidator
	{
        private bool _result;
        private readonly Polygon _polygon;

        public PolygonValidator(Polygon polygon) 
        {
            _polygon = new Polygon(polygon);
            _result = false;
        }

        public bool Validate()
        {
            if(_polygon!=null)
                _result = true;
            return _result;
        }
    }
}
