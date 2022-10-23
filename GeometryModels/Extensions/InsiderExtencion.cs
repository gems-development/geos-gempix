using GeometryModels.Visitors.Intersectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Extensions
{
    public class InsiderExtencion
    {
        public static bool IsInside(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Insider(primitive1, primitive2).GetResult();
    }
}
