using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public class AuthorityData
    {
        public int SystemId { get; set; }
        public string SystemName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

        public string Url { get; set; }
    }
}
