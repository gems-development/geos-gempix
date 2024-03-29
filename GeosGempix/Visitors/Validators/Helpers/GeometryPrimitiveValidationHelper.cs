﻿using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Models;

namespace GeosGempix.Visitors.Validators.Helpers
{
	internal static class GeometryPrimitiveValidationHelper
    {
        public static bool IsContourSelfIntersecting(IReadOnlyCollection<Line> lines)
        {
            int lineCount = lines.Count;
            for (int i = 0; i < lineCount; i++)
            {
                for (int j = i + 1; j < lineCount; j++)
                {
                    if (!lines.ElementAt(i).Point1.Equals(lines.ElementAt(j).Point2) && 
                        !lines.ElementAt(i).Point2.Equals(lines.ElementAt(j).Point1))
                    {
                        if (LineIntersector.Intersects(lines.ElementAt(i), lines.ElementAt(j)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
