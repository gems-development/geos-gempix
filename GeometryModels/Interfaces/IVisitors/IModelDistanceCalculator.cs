using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Interfaces.IModels
{
    internal interface IModelDistanceCalculator: IGeometryPrimitiveVisitor
    {
        public double GetResult();
    }
}
