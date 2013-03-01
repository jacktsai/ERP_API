﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahoo.Business
{
    /// <summary>
    /// 使用者功能權限集合。
    /// </summary>
    public interface IPrivilegeCollection : IEnumerable<IPrivilege>
    {
        void Add(string url);

        IPrivilege Find(string url);
    }
}