using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo
{
    public class SubCategoryNotFoundException : ApplicationException
    {
        public SubCategoryNotFoundException(int id)
            : base(string.Format("Sub category ID '{0}' cannot be found in database.", id))
        {
        }
    }
}
