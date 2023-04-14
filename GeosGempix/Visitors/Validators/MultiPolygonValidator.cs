using GeosGempix.Extensions;
using GeosGempix.Interfaces.IVisitors;

namespace GeosGempix.Visitors.Validators
{
    internal class MultiPolygonValidator : IValidator
	{
        private readonly MultiPolygon _multipolygon;

        public MultiPolygonValidator(MultiPolygon multipolygon)
        {
            _multipolygon = new MultiPolygon(multipolygon.GetPolygons());
        }

        public bool Validate()
        {
            var polygons = _multipolygon.GetPolygons();
            if(_multipolygon == null || polygons.Count < 2)
                return false;

            if(IsPolygonsIntersects(polygons))
                return false;

			if (IsPolygonsInside(polygons))
				return false;

			if (IsNotPolygonsValidates(polygons))
                return false;

            return true;
        }


        private bool IsPolygonsIntersects(List<Polygon> polygons)
        {
            for (int i = 0; i < polygons.Count - 1; i++)
            {
                for (int j = i + 1; j < polygons.Count; j++)
                {
                    if (polygons[i].Intersects(polygons[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

		private bool IsPolygonsInside(List<Polygon> polygons)
		{
			for (int i = 0; i < polygons.Count - 1; i++)
			{
				for (int j = i + 1; j < polygons.Count; j++)
				{
					if (polygons[i].IsInside(polygons[j]))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsNotPolygonsValidates(List<Polygon> polygons)
		{
			foreach (Polygon polygon in polygons)
            {
                var polygonvalidator = new PolygonValidator(polygon);
                if(!polygonvalidator.Validate())
                    return true;
            }
			return false;
		}

	}
}
