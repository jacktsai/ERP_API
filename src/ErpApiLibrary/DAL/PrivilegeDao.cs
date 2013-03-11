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
    /// <see cref="IPrivilegeDao"/> 介面實作。
    /// </summary>
    public class PrivilegeDao : IPrivilegeDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivilegeDao" /> class.
        /// </summary>
        public PrivilegeDao()
        {
            this._connectionString = Setting.GetConnectionString("security");
        }

        /// <summary>
        /// 取得 Privilege Data。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>
        /// Privilege Data。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId</exception>
        /// <exception cref="System.ArgumentNullException">url</exception>
        Privilege IPrivilegeDao.GetOne(string backyardId, string url)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var commandText = @"
SELECT
	[privilege_id],
	[privilege_prifuncid],
	[privilege_priuserid],
	[privilege_date],
	[privilege_note],
	[privilege_sysdate],
	[privilege_updated],
	[privilege_updateddate],
	[privilege_updateduser],
	[privilege_prigroupid]
FROM
	dbo.priuser(NOLOCK)
	JOIN dbo.privilege(NOLOCK) ON privilege_priuserid = priuser_id
	JOIN dbo.prifunc(NOLOCK) ON prifunc_id = privilege_prifuncid
WHERE
	priuser_backyardid = @backyardId
	AND prifunc_url = @url
";
            var backyardIdParameter = new SqlParameter("@backyardId", backyardId);
            var urlParameter = new SqlParameter("@url", url);

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<Privilege>(dataRow),
                backyardIdParameter,
                urlParameter);

            return result.FirstOrDefault();
        }
    }
}