using GeometryModels.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.GeometryPrimitiveIntersectors
{
    internal class MultiPolygonIntersector : IModelsIntersector
    {

        // поле результат

        // точка "пересекается" с одним из полигонов

        // линия пересекается с одним из полигонов

        // полигон пересекается с одним из полигонов

        // мультиточка - одна из точек "пересекается" с одним из полигонов

        // мультилиния - одна из линий пересекается с одним из полигонов

        // мультиполигон - один из полигонов пересекается с одним из полигонов
        public bool GetResult()
        {
            return true; // результат
        }
    }
}
