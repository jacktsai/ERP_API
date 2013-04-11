using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Entities;

namespace ErpApi.DAL
{
    /// <summary>
    /// CatZone 存取介面
    /// </summary>
    public interface ICatZoneDao
    {
        /// <summary>
        /// 以多筆 catzone_id 取得多筆 CatZone。
        /// </summary>
        /// <param name="ids">多筆 catzone_id</param>
        /// <returns>多筆 CatZone</returns>
        IEnumerable<CatZone> GetMany(IEnumerable<short> ids);
    }
}
