using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasSelect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasInsert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasDelete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? HasParticular { get; set; }
    }
}
