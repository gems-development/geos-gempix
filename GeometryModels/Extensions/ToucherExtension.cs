using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Extensions
{
    public class ToucherExtension
    {
        public static bool IsTouching(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2) =>
            new Toucher(primitive1, primitive2).GetResult();
    }
}
