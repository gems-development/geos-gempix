using GeosGempix.Interfaces.IVisitors;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.Validators
{
    internal class MultiLineValidator : IValidator
	{
        private readonly MultiLine _multiline;

        public MultiLineValidator(MultiLine multiline)
        {
            _multiline = new MultiLine(multiline.GetLines());
        }

        public bool Validate()
        {
            if (_multiline == null || _multiline.GetLines().Count < 2)
                return false;
            return true;
        }
    }
}
