using GeosGempix.Interfaces.IVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Visitors.Validators
{
	public class MultiPolygonValidator : IValidator
	{
        private bool _result;
        private readonly MultiPolygon _multipolygon;

        public MultiPolygonValidator(MultiPolygon multipolygon)
        {
            _multipolygon = new MultiPolygon(multipolygon.GetPolygons());
            _result = false;
        }

        public bool Validate()
        {
            if(_multipolygon!=null)
                _result = true;
            return _result;
        }
    }
}
