using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators
{
    public class ContourValidator : IValidator
    {
        private bool _result;
        private readonly Contour _contour;

        public ContourValidator(Contour contour) 
        {
            _contour = new Contour(contour);
            _result = false;
        }

        public bool Validate()
        {
            if(_contour!=null)
                _result = true;
            return _result;
        }
    }
}
