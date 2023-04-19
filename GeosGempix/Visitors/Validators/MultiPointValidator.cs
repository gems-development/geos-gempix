using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class MultiPointValidator : IValidator
	{
        private readonly MultiPoint _multipoint;

        public MultiPointValidator(MultiPoint multipoint)
        {
            _multipoint = new MultiPoint(multipoint.GetPoints());
        }

        public bool Validate()
        {
            if(_multipoint == null || _multipoint.GetPoints().Count < 2)
                return false;
            return true;
        }
    }
}
