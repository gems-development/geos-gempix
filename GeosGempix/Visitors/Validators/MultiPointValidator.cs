using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class MultiPointValidator : IValidator
	{
        private bool _result;
        private readonly MultiPoint _multipoint;

        public MultiPointValidator(MultiPoint multipoint)
        {
            _multipoint = new MultiPoint(multipoint.GetPoints());
            _result = false;
        }

        public bool Validate()
        {
            if(_multipoint!=null)
                _result = true;
            return _result;
        }
    }
}
