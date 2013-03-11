using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Entities
{
    /// <summary>
    /// 使用者相關資訊。
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 使用者資訊。
        /// </summary>
        public User User { get; internal set; }

        /// <summary>
        /// 子站代碼。
        /// </summary>
        public IEnumerable<int> SubCatIds { get; internal set; }
    }
}
