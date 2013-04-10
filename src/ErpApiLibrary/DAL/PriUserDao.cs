using System;
using System.Collections.Generic;
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
    /// <see cref="IPriUserDao"/> 介面實作。
    /// </summary>
    public class PriUserDao : IPriUserDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriUserDao" /> class.
        /// </summary>
        public PriUserDao()
        {
            this._connectionString = Setting.GetConnectionString("security");
        }

        /// <summary>
        /// 取得使用者資料。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <returns>
        /// 使用者資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">backyardId</exception>
        PriUser IPriUserDao.GetOne(string backyardId)
        {
            if (backyardId == null)
            {
                throw new ArgumentNullException("backyardId");
            }

            var commandText = @"
SELECT
	[priuser_id],
	[priuser_name],
	[priuser_fullname],
	[priuser_pwd],
	[priuser_company],
	[priuser_department],
	[priuser_degree],
	[priuser_notice],
	[priuser_email],
	[priuser_homepage],
	[priuser_extno],
	[priuser_status],
	[priuser_statusdate],
	[priuser_statusnote],
	[priuser_date],
	[priuser_note],
	[priuser_sysdate],
	[priuser_updated],
	[priuser_updateddate],
	[priuser_updateduser],
	[priuser_pwdexpired],
	[priuser_pwdchgdate],
	[priuser_supplierid],
	[priuser_otpenabled],
	[priuser_backyardid],
	[priuser_approvedeptcode],
	[priuser_approveagt],
	[priuser_approvestatus],
	[priuser_approveperiodstart],
	[priuser_approveperiodend]
FROM
    [dbo].[priuser](NOLOCK)
WHERE
    [priuser_backyardid] = @backyardId
";

            var backyardIdParameter = new SqlParameter("@backyardId", backyardId);

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<PriUser>(dataRow),
                backyardIdParameter);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// 取得多筆使用者資料。
        /// </summary>
        /// <param name="userNames">多個使用者帳號。</param>
        /// <returns>
        /// 多筆使用者資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">userNames</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">userNames</exception>
        IEnumerable<PriUser> IPriUserDao.GetMany(IEnumerable<string> userNames)
        {
            if (userNames == null)
            {
                throw new ArgumentNullException("userNames");
            }

            if (userNames.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("userNames");
            }

            var wrappedUserNames = userNames.Select(s => string.Format("'{0}'", s)); // 給每個值的前後加上單引號。
            var commandText = string.Format(
@"SELECT
	[priuser_id],
	[priuser_name],
	[priuser_fullname],
	[priuser_pwd],
	[priuser_company],
	[priuser_department],
	[priuser_degree],
	[priuser_notice],
	[priuser_email],
	[priuser_homepage],
	[priuser_extno],
	[priuser_status],
	[priuser_statusdate],
	[priuser_statusnote],
	[priuser_date],
	[priuser_note],
	[priuser_sysdate],
	[priuser_updated],
	[priuser_updateddate],
	[priuser_updateduser],
	[priuser_pwdexpired],
	[priuser_pwdchgdate],
	[priuser_supplierid],
	[priuser_otpenabled],
	[priuser_backyardid],
	[priuser_approvedeptcode],
	[priuser_approveagt],
	[priuser_approvestatus],
	[priuser_approveperiodstart],
	[priuser_approveperiodend]
FROM
	[dbo].[priuser](NOLOCK)
WHERE
    [priuser_name] IN ({0})
",
 string.Join(",", wrappedUserNames));

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<PriUser>(dataRow));

            return result;
        }
    }
}