using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ErpApi.Entities;
using ErpApi.Utility;
using Monday.DataAccess.Common;
using Monday.Environments;

namespace ErpApi.DAL
{
    /// <summary>
    /// 以 System.Data.Common 為基礎所建立的 <see cref="IDenyPrivilegeDao"/> 介面實作。
    /// </summary>
    public class DenyPrivilegeDao : IDenyPrivilegeDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DenyPrivilegeDao" /> class.
        /// </summary>
        public DenyPrivilegeDao()
        {
            this._connectionString = Setting.GetConnectionString("security");
        }

        /// <summary>
        /// 取得Deny Privilege Data。
        /// </summary>
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// Deny Privilege Data。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        DenyPrivilege IDenyPrivilegeDao.GetOne(int userId, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var commandText = @"
SELECT
	[denyprivs_id],
	[denyprivs_url],
	[denyprivs_priuserid],
	[denyprivs_select],
	[denyprivs_insert],
	[denyprivs_update],
	[denyprivs_delete],
	[denyprivs_particular],
	[denyprivs_sysuser],
	[denyprivs_sysdate],
	[denyprivs_updateduser],
	[denyprivs_updateddate],
	[denyprivs_updated]
FROM
	dbo.denyprivs(NOLOCK)
WHERE
	denyprivs_priuserid = @userId
	AND denyprivs_url = @url
";
            var userIdParameter = new SqlParameter("@userId", userId);
            var urlParameter = new SqlParameter("@url", url);

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<DenyPrivilege>(dataRow),
                userIdParameter,
                urlParameter);

            return result.FirstOrDefault();
        }
    }
}