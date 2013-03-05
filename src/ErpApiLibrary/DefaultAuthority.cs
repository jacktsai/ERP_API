using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Data;

namespace ErpApi
{
    /// <summary>
    /// 使用者細部權限。
    /// </summary>
    public class DefaultAuthority : IAuthority
    {
        private readonly bool canSelect;
        private readonly bool canInsert;
        private readonly bool canUpdate;
        private readonly bool canDelete;
        private readonly bool canParticular;

        public DefaultAuthority(IEnumerable<AuthorityData> datas)
        {
            this.canSelect = Judge(datas, d => d.CanSelect, d => d.DenySelect);
            this.canInsert = Judge(datas, d => d.CanInsert, d => d.DenyInsert);
            this.canUpdate = Judge(datas, d => d.CanUpdate, d => d.DenyUpdate);
            this.canDelete = Judge(datas, d => d.CanDelete, d => d.DenyDelete);
            this.canParticular = Judge(datas, d => d.CanParticular, d => d.DenyParticular);
        }

        bool IAuthority.CanSelect { get { return this.canSelect; } }

        bool IAuthority.CanInsert { get { return this.canInsert; } }

        bool IAuthority.CanUpdate { get { return this.canUpdate; } }

        bool IAuthority.CanDelete { get { return this.canDelete; } }

        bool IAuthority.CanParticular { get { return this.canParticular; } }

        private bool Judge(IEnumerable<AuthorityData> datas, Func<AuthorityData, bool?> canGetter, Func<AuthorityData, bool?> denyGetter)
        {
            // is denied ?
            if (datas.Any(o => denyGetter(o) == true))
            {
                return false;
            }

            // is granted ?
            if (datas.Any(o => canGetter(o) == true))
            {
                return true;
            }

            // default is false.
            return false;
        }
    }
}
