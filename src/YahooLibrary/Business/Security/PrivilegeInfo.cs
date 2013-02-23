using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security
{
    /// <summary>
    /// 權限資訊。
    /// </summary>
    public class PrivilegeInfo
    {
        /// <summary>
        /// 權限編號。
        /// </summary>
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return Id.Equals(((PrivilegeInfo)obj).Id);
        }
    }
}
