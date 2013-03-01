using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business
{
    public class UserNotFoundException : ApplicationException
    {
        public UserNotFoundException(string backyardId)
            : base(string.Format("Backyard ID '{0}' cannot be found in database.", backyardId))
        {
        }
    }
}
