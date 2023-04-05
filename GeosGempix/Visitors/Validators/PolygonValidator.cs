using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Visitors.Validators.Helpers;

namespace GeosGempix.Visitors.Validators
{
    internal class PolygonValidator : IValidator
	{
        private bool _result;
        private readonly Polygon _polygon;

        public PolygonValidator(Polygon polygon) 
        {
            _polygon = new Polygon(polygon);
            _result = false;
        }

        public bool Validate()
        {
            int lineCount = _polygon.GetLines().Count;
            if (_polygon == null || lineCount < 3)
            {
                return false;
            }
            if(GeometryPrimitiveValidationHelper.IsContourSelfIntersecting(_polygon.GetLines()))
            {
                return false; 
            }
            var holes = _polygon.GetHoles();
            foreach ( var hole in holes ) 
            {
                if(GeometryPrimitiveValidationHelper.IsContourSelfIntersecting(hole.GetLines()))
                    return false;
            }
            if (AreHolesIntersects())
                return false;
            return true;
        }

        private bool AreHolesIntersects()
        {
            var holes = _polygon.GetHoles();
            if(holes.Count > 0)
            {
                holes.Add(_polygon.OuterContour);
                for (int i = 0; i < holes.Count; i++)
                {
                    for (int j = i; j < holes.Count; j++)
                    {
                        if (ContourIntersector.Intersects(holes[i], holes[j]))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
