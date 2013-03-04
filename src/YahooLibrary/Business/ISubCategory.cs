using System;

namespace Yahoo.Business
{
    /// <summary>
    /// 子站資料。
    /// </summary>
    public interface ISubCategory
    {
        /// <summary>
        /// 子站代碼。
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 子站名稱。
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// 區代碼。
        /// </summary>
        short ZoneId { get; }

        /// <summary>
        /// PM。
        /// </summary>
        IUser User { get; }

        /// <summary>
        /// PM 主管。
        /// </summary>
        IUser Manager { get; }

        /// <summary>
        /// 採購人。
        /// </summary>
        IUser Purchaser { get; }

        /// <summary>
        /// 採購主任。
        /// </summary>
        IUser Staff { get; }
    }
}
