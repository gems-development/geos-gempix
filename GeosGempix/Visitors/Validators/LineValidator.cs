using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators
{
    public class LineValidator : IValidator
	{
		private bool _result;
		private readonly Line _line;

		public LineValidator(Line line)
		{
			_line = new Line(line);
			_result = false;
		}

        public bool Validate()
        {
            if(_line.Point1!=null && _line.Point2!=null)
				_result = true;
			return _result;
        }
    }
}
