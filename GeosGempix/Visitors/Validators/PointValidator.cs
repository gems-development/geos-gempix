using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class PointValidator : IValidator
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
