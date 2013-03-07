using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErpApi.Services
{
    /// <summary>
    /// 操作者相關資訊。
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// 取得操作者個人資料。
        /// </summary>
        public User User { get; internal set; }

        /// <summary>
        /// 取得操作者擁有的子站代碼。
        /// </summary>
        public IEnumerable<int> SubCatIds { get; internal set; }
    }
}
