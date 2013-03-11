using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ErpApi.Entities;
using ErpApi.Utility;
using Monday.DataAccess.Common;
using Monday.Environments;

namespace ErpApi.DAL
{
    /// <summary>
    /// <see cref="IRoleDao"/> 介面實作。
    /// </summary>
    public class RoleDao : IRoleDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleDao" /> class.
        /// </summary>
        public RoleDao()
        {
            this._connectionString = Setting.GetConnectionString("security");
        }

        /// <summary>
        /// 取得多筆角色資料。
        /// </summary>
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// 多筆角色資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">url</exception>
        IEnumerable<Role> IRoleDao.GetMany(int userId, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var commandText = @"
SELECT
	[roles_id],
	[roles_name],
	[roles_decimalprivs],
	[roles_select],
	[roles_insert],
	[roles_update],
	[roles_delete],
	[roles_particular],
	[roles_note],
	[roles_sysuser],
	[roles_sysdate],
	[roles_updateduser],
	[roles_updateddate],
	[roles_updated]
FROM
	dbo.middleur(NOLOCK)
	JOIN dbo.roles(NOLOCK) ON roles_id = middleur_rolesid
	JOIN dbo.privs(NOLOCK) ON privs_rolesid = roles_id
WHERE
	middleur_priuserid = @userId
	AND privs_url = @url
";
            var userIdParameter = new SqlParameter("@userId", userId);
            var urlParameter = new SqlParameter("@url", url);

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<Role>(dataRow),
                userIdParameter,
                urlParameter);

            return result;
        }
    }
}