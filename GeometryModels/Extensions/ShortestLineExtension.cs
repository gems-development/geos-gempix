using GeometryModels.Models;
using GeometryModels.Visitors.ShortestLineSearchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Extensions
{
	public class ShortestLineExtension
	{
		public static Line GetShortestLine(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
			new ShortestLineSearcher(primitive1, primitive2).GetResult();
	}
}
