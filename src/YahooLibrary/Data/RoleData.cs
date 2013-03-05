using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleData
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
        public bool? CanSelect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? CanInsert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? CanUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? CanDelete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? CanParticular { get; set; }
    }
}
