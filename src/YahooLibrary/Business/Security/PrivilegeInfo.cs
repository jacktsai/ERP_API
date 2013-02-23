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

        /// <summary>
        /// 功能編號。
        /// </summary>
        public int FunctionId { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((PrivilegeInfo)obj).Id);
        }
    }
}
