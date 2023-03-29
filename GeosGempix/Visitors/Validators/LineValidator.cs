using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators
{
    internal class LineValidator : IValidator
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
            if(Math.Abs(_line.Point1.X - _line.Point2.X) > Double.Epsilon && Math.Abs(_line.Point1.Y - _line.Point2.Y) > Double.Epsilon)
				_result = true;
			return _result;
        }
    }
}
