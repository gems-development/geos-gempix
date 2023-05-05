using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators
{
    internal class LineValidator : IValidator
	{
		private readonly Line _line;

		public LineValidator(Line line)
		{
			_line = new Line(line);
		}

        public bool Validate()
        {
            if(Math.Abs(_line.Point1.X - _line.Point2.X) < Double.Epsilon && Math.Abs(_line.Point1.Y - _line.Point2.Y) < Double.Epsilon)
				return false;
			return true;
        }
    }
}
