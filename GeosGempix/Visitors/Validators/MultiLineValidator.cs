﻿using GeosGempix.Interfaces.IVisitors;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.Validators
{
    internal class MultiLineValidator : IValidator
	{
        private bool _result;
        private readonly MultiLine _multiline;

        public MultiLineValidator(MultiLine multiline)
        {
            _multiline = new MultiLine(multiline.GetLines());
            _result = false;
        }

        public bool Validate()
        {
            if(_multiline!=null && _multiline.GetLines().Count > 1)
                _result = true;
            return _result;
        }
    }
}
