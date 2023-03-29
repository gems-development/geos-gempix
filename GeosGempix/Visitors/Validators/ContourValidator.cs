using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators
{
    internal class ContourValidator : IValidator
    {
        private readonly Contour _contour;

        public ContourValidator(Contour contour) 
        {
            _contour = new Contour(contour);
        }

        public bool Validate()
        {
            int lineCount = _contour.GetLines().Count;
            if (_contour == null || lineCount < 3)
            {
                return false;
            }
            List<Line> lines = _contour.GetLines();
            for (int i = 0; i < lineCount; i++)
            {
                for (int j = 0; j < lineCount; j++)
                {
                    if (!lines[i].Point1.Equals(lines[j].Point2) && !lines[i].Point2.Equals(lines[j].Point1))
                    {
                        if (LineIntersector.Intersects(lines[i], lines[j]))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
