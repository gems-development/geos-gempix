using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class PointValidator : IValidator
    {
		private readonly Point _point;

		public PointValidator(Point point)
		{
			_point = new Point(point);
		}	

        public bool Validate()
        {
            if(_point == null)
                return false;
            return true;
        }
    }
}
