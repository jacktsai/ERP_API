using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Services
{
    /// <summary>
    /// 使用者角色集合。
    /// </summary>
    public interface IRoleCollection : IEnumerable<IRole>
    {
        bool HasSelect { get; }

        bool HasInsert { get; }

        bool HasUpdate { get; }

        bool HasDelete { get; }

        bool HasParticular { get; }
    }
}
