using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class PointIntersector : IModelsIntersector

    {
        //поле результат
        
        // метод - точка наложилась на точку
        public bool GetResult()
        {
            return true;
        }
    }
}
