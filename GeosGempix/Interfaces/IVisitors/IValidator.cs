using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeosGempix.Interfaces.IVisitors
{
	public interface IValidator : IGeometryPrimitiveVisitor
	{
		public Boolean Validate();
	}
}
