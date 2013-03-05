using System;
namespace Yahoo
{
    /// <summary>
    /// 使用者功能權限。
    /// </summary>
    public interface IPrivilege
    {
        string Url { get; }

        string Name { get; }

        /// <summary>
        /// 取得細部權限。
        /// </summary>
        IAuthority Authority { get; }
    }
}
