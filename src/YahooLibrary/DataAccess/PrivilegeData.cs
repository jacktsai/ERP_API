using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public class PrivilegeData
    {
        public int Id { get; set; }
        public int FunctionId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}
