using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpApi.Entities;
using Monday.Environments;
using Monday.DataAccess.Common;
using System.Data;
using ErpApi.Utility;

namespace ErpApi.DAL
{
    /// <summary>
    /// <see cref="ICatZoneDao"/> 介面實作。
    /// </summary>
    public sealed class CatZoneDao : ICatZoneDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatSubDao" /> class.
        /// </summary>
        public CatZoneDao()
        {
            this._connectionString = Setting.GetConnectionString("sale");
        }

        /// <summary>
        /// 以多筆 catzone_id 取得多筆 CatZone。
        /// </summary>
        /// <param name="ids">多筆 catzone_id</param>
        /// <returns>
        /// 多筆 CatZone
        /// </returns>
        IEnumerable<CatZone> ICatZoneDao.GetMany(IEnumerable<short> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids");
            }

            if (!ids.Any())
            {
                throw new ArgumentOutOfRangeException("ids");
            }

            var commandText = string.Format(
@"SELECT
	[catzone_id],
	[catzone_name],
	[catzone_sort],
	[catzone_pmdep],
	[catzone_user],
	[catzone_sysdate],
	[catzone_updated],
	[catzone_updateddate],
	[catzone_updateduser],
	[catzone_type],
	[catzone_typename] = ISNULL(lkup_desc, '')
FROM
	sale.dbo.catzone WITH (NOLOCK)
	JOIN sale.dbo.lkup WITH (NOLOCK) ON [lkup_owner] = 'catzone' AND [lkup_type] = 'catzone_type' AND [lkup_code] = [catzone_type]
WHERE
	[catzone_id] IN ({0})",
 string.Join(",", ids));

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<CatZone>(dataRow));

            return result;
        }
    }
}
