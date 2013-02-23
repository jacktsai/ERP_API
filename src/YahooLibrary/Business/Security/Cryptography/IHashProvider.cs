using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security.Cryptography
{
    /// <summary>
    /// 表示雜湊湊運算介面。
    /// </summary>
    public interface IHashProvider
    {
        /// <summary>
        /// 計算指定位元組陣列的雜湊值。
        /// </summary>
        /// <param name="buffer">要用來計算的值。</param>
        /// <returns>計算出來的雜湊值。</returns>
        byte[] Compute(byte[] buffer);
    }
}
