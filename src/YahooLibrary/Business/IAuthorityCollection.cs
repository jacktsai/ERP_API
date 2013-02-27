using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business
{
    /// <summary>
    /// 使用者權限集合。
    /// </summary>
    public interface IAuthorityCollection : IEnumerable<Authority>
    {
        Authority Find(string url);
    }
}
