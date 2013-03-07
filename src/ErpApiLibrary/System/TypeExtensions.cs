using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Type 的擴充方法。
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// 判斷 t 是否為參考型別。
        /// </summary>
        /// <remarks>
        /// 因為 Nullable 型別仍會被判斷成值型別，此方法則是要將 Nullable 視為參考型別而設。
        /// </remarks>
        /// <param name="type">The t.</param>
        /// <returns>
        /// 如果是參考型別則為 <c>true</c>；否則為 <c>false</c>。
        /// </returns>
        public static bool IsRefType(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return true;
            }

            return !type.IsValueType;
        }
    }
}
