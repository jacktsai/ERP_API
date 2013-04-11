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
    /// <see cref="ICatSubDao"/> 介面實作。
    /// </summary>
    public class CatSubDao : ICatSubDao
    {
        /// <summary>
        /// The database connection string.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatSubDao" /> class.
        /// </summary>
        public CatSubDao()
        {
            this._connectionString = Setting.GetConnectionString("sale");
        }

        /// <summary>
        /// 以 user ID 搜尋子站資料。
        /// </summary>
        /// <param name="userId">user ID。</param>
        /// <returns>
        /// 多筆子站資料。
        /// </returns>
        IEnumerable<CatSub> ICatSubDao.GetMany(int userId)
        {
            var commandText = @"
SELECT
	[catsub_id],
	[catsub_catzoneid],
	[catsub_catlinid],
	[catsub_name],
	[catsub_mdypurher],
	[catsub_mdystaff],
	[catsub_casrcdqty],
	[catsub_stkfileqty],
	[catsub_sysdate],
	[catsub_updated],
	[catsub_updateddate],
	[catsub_updateduser],
	[catsub_mdypm],
	[catsub_grossmargin],
	[catsub_ltgrossmargin],
	[catsub_funcs],
	[catsub_gdlmtrate],
	[catsub_purhfullname],
	[catsub_stafffullname],
	[catsub_pmfullname],
	[catsub_blnggroup],
	[catsub_blngteam],
	[catsub_blngline],
	[catsub_ecupnrate],
	[catsub_blnggrpid],
	[catsub_type],
	[catsub_spsgstgrossmargin]
FROM
	dbo.catprivilege(NOLOCK)
	JOIN dbo.catsub(NOLOCK) ON catsub_id = catprivilege_catsubid
WHERE
	catprivilege_priuserid = @userId
";

            var userIdParameter = new SqlParameter("@userId", userId);

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow => ColumnMappingHelper.MappingEntity<CatSub>(dataRow),
                userIdParameter);

            return result;
        }

        /// <summary>
        /// 以子站代碼搜尋子站資料。
        /// </summary>
        /// <param name="ids">多重子站代碼。</param>
        /// <returns>
        /// 多筆子站資料。
        /// </returns>
        /// <exception cref="System.ArgumentNullException">ids</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ids</exception>
        IEnumerable<CatSub> ICatSubDao.GetMany(IEnumerable<int> ids)
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
	[catsub_id],
	[catsub_catzoneid],
	[catsub_catlinid],
	[catsub_name],
	[catsub_mdypurher],
	[catsub_mdystaff],
	[catsub_casrcdqty],
	[catsub_stkfileqty],
	[catsub_sysdate],
	[catsub_updated],
	[catsub_updateddate],
	[catsub_updateduser],
	[catsub_mdypm],
	[catsub_grossmargin],
	[catsub_ltgrossmargin],
	[catsub_funcs],
	[catsub_gdlmtrate],
	[catsub_purhfullname],
	[catsub_stafffullname],
	[catsub_pmfullname],
	[catsub_blnggroup],
	[catsub_blngteam],
	[catsub_blngline],
	[catsub_ecupnrate],
	[catsub_blnggrpid],
	[catsub_type],
	[catsub_spsgstgrossmargin],
	[catsubusr_id],
	[catsubusr_catsubid],
	[catsubusr_dpt],
	[catsubusr_usrname],
	[catsubusr_usrfullname],
	[catsubusr_extno],
	[catsubusr_user],
	[catsubusr_sysdate],
	[catsubusr_updated],
	[catsubusr_updateddate],
	[catsubusr_updateduser],
	[catsubusr_pusrname],
	[catsubusr_pusrfullname],
	[catsubusr_pextno]
FROM
	dbo.catsub(NOLOCK)
	LEFT JOIN dbo.catsubusr WITH (NOLOCK) ON catsubusr_catsubid = catsub_id
WHERE
	catsub_id IN ({0})
",
 string.Join(",", ids));

            var result = SqlComm.GetEntityList(
                CommandType.Text,
                commandText,
                this._connectionString,
                dataRow =>
                {
                    var subCat = ColumnMappingHelper.MappingEntity<CatSub>(dataRow);
                    subCat.User = ColumnMappingHelper.MappingEntity<CatSubUsr>(dataRow);
                    return subCat;
                });

            return result;
        }
    }
}