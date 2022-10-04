﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryModels.Interfaces.IVisitors
{
    internal interface IModelsIntersector : IGeometryPrimitiveVisitor
    {
        public bool GetResult();
    }
}