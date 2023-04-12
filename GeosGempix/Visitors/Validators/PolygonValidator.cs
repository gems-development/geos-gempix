using GeosGempix.Extensions;
using GeosGempix.GeometryPrimitiveInsiders;
using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.Validators.Helpers;

namespace GeosGempix.Visitors.Validators
{
    internal class PolygonValidator : IValidator
	{
        private readonly Polygon _polygon;

        public PolygonValidator(Polygon polygon) 
        {
            _polygon = new Polygon(polygon);
        }

        public bool Validate()
        {
            int lineCount = _polygon.GetLines().Count;
            
            if (_polygon == null || lineCount < 3)
                return false;

            var contours = _polygon.GetHoles();
            contours.Add(_polygon.OuterContour);

            if (CheckContoursSelfIntersection(contours))
                return false;

            if (CheckContoursIntersection(contours))
                return false;

            if(CheckAnyHoleIsOutsideOuterContour())
                return false;

            return true;
        }

        private bool CheckContoursSelfIntersection(IReadOnlyCollection<Contour> contours) 
        {
            foreach (var contour in contours)
            {
                if (GeometryPrimitiveValidationHelper.IsContourSelfIntersecting(contour.GetLines()))
                    return true;
            }
            return false;
        }

        private bool CheckContoursIntersection(IReadOnlyCollection<Contour> contours)
        {
            for (int i = 0; i < contours.Count; i++)
            {
                for (int j = i + 1; j < contours.Count; j++)
                {
                    if (ContourIntersector.Intersects(contours.ElementAt(i), contours.ElementAt(j)))
                        return true;
                }
            }
            return false;
        }

        private bool CheckAnyHoleIsOutsideOuterContour()
        {
            var holes = _polygon.GetHoles();
            if(holes.Count > 1)
            {
                var contour = _polygon.OuterContour;
                foreach (var hole in holes)
                {
                    if (!ContourInsider.IsInside(contour, hole))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
