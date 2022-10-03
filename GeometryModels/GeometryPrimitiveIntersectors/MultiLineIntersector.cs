using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class MultiLineIntersector : IModelsIntersector
    {
        // поле результат

        // точка лежит на одной из линий

        // линия пересекает одну из линий

        // полигон пересекается с одной из линий

        // мультиточка ээ... одна из точек мультиточки лежит на одной из линий
        public bool GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
