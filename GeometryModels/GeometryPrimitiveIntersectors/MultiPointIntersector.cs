using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class MultiPointIntersector : IModelsIntersector
    {
        // поле результат

        // точка во множестве точек

        // линия включает в себя одну из точек

        // полигон содержит одну из точек

        public bool GetResult()
        {
            return true; // результат
        }
    }
}
