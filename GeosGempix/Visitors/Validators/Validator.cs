using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.Validators
{
    public class Validator : IValidator, IGeometryPrimitiveVisitor
	{
		private IValidator _validator;
		private bool _validationPassed;


		public Validator(IGeometryPrimitive primitive)
		{
			primitive.Accept(this);
			_validationPassed = _validator!.Validate();
		}

		public bool Validate()
		{
			return _validationPassed;
		}

		public void Visit(Point point) =>
			_validator = new PointValidator(point);

		public void Visit(Line line) =>
			_validator = new LineValidator(line);

		public void Visit(Polygon polygon) =>
			_validator = new PolygonValidator(polygon);

		public void Visit(MultiPoint multiPoint) =>
			_validator = new MultiPointValidator(multiPoint);

		public void Visit(MultiLine multiLine) =>
			_validator = new MultiLineValidator(multiLine);

		public void Visit(MultiPolygon multiPolygon) =>
			_validator = new MultiPolygonValidator(multiPolygon);

		public void Visit(Contour contour) =>
			_validator = new ContourValidator(contour);

	}
}
