using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    /// <summary>
    /// 子站權限。
    /// </summary>
    public class CatPrivilege
    {
        private readonly CatPrivilegeData data;

        public CatPrivilege()
        {
            this.data = new CatPrivilegeData();
        }

        internal CatPrivilege(CatPrivilegeData data)
        {
            this.data = data;
        }

        public short ZoneId { get { return this.data.ZoneId; } }

        public string ZoneName { get { return this.data.ZoneName; } }

        public int SubId { get { return this.data.SubId; } }

        public string SubName { get { return this.data.SubName; } }
    }
}
