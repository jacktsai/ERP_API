using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.DataAccess
{
    public class CatPrivilegeData
    {
        /// <summary>
        /// 區編號。
        /// </summary>
        public short ZoneId { get; set; }

        /// <summary>
        /// 區名稱。
        /// </summary>
        public string ZoneName { get; set; }

        /// <summary>
        /// 子站編號。
        /// </summary>
        public int SubId { get; set; }

        /// <summary>
        /// 子站名稱。
        /// </summary>
        public string SubName { get; set; }
    }
}
