using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public class AuthorityData
    {
        public bool? CanSelect { get; set; }

        public bool? CanInsert { get; set; }

        public bool? CanUpdate { get; set; }

        public bool? CanDelete { get; set; }

        public bool? CanParticular { get; set; }

        public bool? DenySelect { get; set; }

        public bool? DenyInsert { get; set; }

        public bool? DenyUpdate { get; set; }

        public bool? DenyDelete { get; set; }

        public bool? DenyParticular { get; set; }
    }
}
