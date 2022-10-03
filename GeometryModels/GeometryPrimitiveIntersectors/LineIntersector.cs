using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class LineIntersector : IModelsIntersector
    {
        // прив поле результат

        // точка наложилась на линию

        // линия с линией пересеклась
        public bool GetResult()
        {
            return true; // результат
        }
    }
}
