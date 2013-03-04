using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yahoo.DataAccess;

namespace Yahoo.Business.Defaults
{
    /// <summary>
    /// 使用者細部權限。
    /// </summary>
    public class DefaultAuthority : IAuthority
    {
        public DefaultAuthority(IEnumerable<AuthorityData> datas)
        {
            if (!datas.Any(o => o.DenySelect.HasValue && o.DenySelect.Value))
            {
                CanSelect = datas.Any(o => o.CanSelect != null && o.CanSelect.Value);
            }

            if (!datas.Any(o => o.DenyInsert.HasValue && o.DenyInsert.Value))
            {
                CanInsert = datas.Any(o => o.CanInsert != null && o.CanInsert.Value);
            }

            if (!datas.Any(o => o.DenyUpdate.HasValue && o.DenyUpdate.Value))
            {
                CanUpdate = datas.Any(o => o.CanUpdate != null && o.CanUpdate.Value);
            }

            if (!datas.Any(o => o.DenyDelete.HasValue && o.DenyDelete.Value))
            {
                CanDelete = datas.Any(o => o.CanDelete != null && o.CanDelete.Value);
            }

            if (!datas.Any(o => o.DenyParticular.HasValue && o.DenyParticular.Value))
            {
                CanParticular = datas.Any(o => o.CanParticular != null && o.CanParticular.Value);
            }
        }

        public bool CanSelect { get; private set; }

        public bool CanInsert { get; private set; }

        public bool CanUpdate { get; private set; }

        public bool CanDelete { get; private set; }

        public bool CanParticular { get; private set; }
    }
}
