using System;

namespace ErpApi
{
    /// <summary>
    /// 使用者角色。
    /// </summary>
    public interface IRole
    {
        string Name { get; }
        bool CanSelect { get; }
        bool CanInsert { get; }
        bool CanUpdate { get; }
        bool CanDelete { get; }
        bool CanParticular { get; }
    }
}
