using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators
{
    public class PointValidator : IValidator
    {
		private bool _result;
		private readonly Point _point;

		public PointValidator(Point point)
		{
			_point = new Point(point);
			_result = false;
		}	

        public bool Validate()
        {
            if(_point!=null)
                _result = true;
            return _result;
        }
    }
}
