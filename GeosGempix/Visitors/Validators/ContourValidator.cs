using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.Validators.Helpers;

namespace GeosGempix.Visitors.Validators
{
    internal class ContourValidator : IValidator
    {
        private readonly Contour _contour;

        public ContourValidator(Contour contour) 
        {
            _contour = new Contour(contour);
        }

        public bool Validate()
        {
            int lineCount = _contour.GetLines().Count;
            if (_contour == null || lineCount < 3)
            {
                return false;
            }
            return !GeometryPrimitiveValidationHelper.IsContourSelfIntersecting(_contour.GetLines());
        }
    }
}
