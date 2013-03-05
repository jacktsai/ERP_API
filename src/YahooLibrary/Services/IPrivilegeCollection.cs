using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Services
{
    /// <summary>
    /// 使用者功能權限集合。
    /// </summary>
    public interface IPrivilegeCollection : IEnumerable<IPrivilege>
    {
        IPrivilege Find(string url);
    }
}
