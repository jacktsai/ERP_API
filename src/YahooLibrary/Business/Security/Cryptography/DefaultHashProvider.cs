using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business.Security.Cryptography
{
    /// <summary>
    /// 預設的 <see cref="IHashProvider"/> 實作。
    /// </summary>
    public class DefaultHashProvider : IHashProvider
    {
        byte[] IHashProvider.Compute(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
