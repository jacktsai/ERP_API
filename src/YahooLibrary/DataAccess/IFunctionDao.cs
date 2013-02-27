using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public interface IFunctionDao
    {
        IEnumerable<Function> GetMany(IEnumerable<int> functionIds);
    }
}
