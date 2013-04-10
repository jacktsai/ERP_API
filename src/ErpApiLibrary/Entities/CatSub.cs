using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: catsub。
    /// </summary>
    public class CatSub
    {
        /// <summary>
        /// 商品線序號。
        /// </summary>
        [DBColumnMapping("catsub_id")]
        public int Id { get; set; }

        /// <summary>
        /// 隸屬區序號。
        /// </summary>
        [DBColumnMapping("catsub_catzoneid")]
        public short ZoneId { get; set; }

        /// <summary>
        /// 分類序號。
        /// </summary>
        [DBColumnMapping("catsub_catlinid")]
        public short CatLinId { get; set; }

        /// <summary>
        /// 商品線。
        /// </summary>
        [DBColumnMapping("catsub_name")]
        public string Name { get; set; }

        /// <summary>
        /// 興奇採購人員。
        /// </summary>
        [DBColumnMapping("catsub_mdypurher")]
        public string MdyPurher { get; set; }

        /// <summary>
        /// 興奇採購主任。
        /// </summary>
        [DBColumnMapping("catsub_mdystaff")]
        public string MdyStaff { get; set; }

        /// <summary>
        /// 特別推薦段數。
        /// </summary>
        [DBColumnMapping("catsub_casrcdqty")]
        public short CasrcdQty { get; set; }

        /// <summary>
        /// 庫存修正檔案數。
        /// </summary>
        [DBColumnMapping("catsub_stkfileqty")]
        public short StkFileQty { get; set; }

        /// <summary>
        /// 實際建檔日期。
        /// </summary>
        [DBColumnMapping("catsub_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// 更改次數。
        /// </summary>
        [DBColumnMapping("catsub_updated")]
        public byte Updated { get; set; }

        /// <summary>
        /// 最後更改日期。
        /// </summary>
        [DBColumnMapping("catsub_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 最後更改人。
        /// </summary>
        [DBColumnMapping("catsub_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// 大PM。
        /// </summary>
        [DBColumnMapping("catsub_mdypm")]
        public string MdyPm { get; set; }

        /// <summary>
        /// 市場參考毛利率。
        /// </summary>
        [DBColumnMapping("catsub_grossmargin")]
        public decimal GrossMargin { get; set; }

        /// <summary>
        /// 長尾商品毛利率調整值。
        /// </summary>
        [DBColumnMapping("catsub_ltgrossmargin")]
        public decimal LtGrossMargin { get; set; }

        /// <summary>
        /// 商品線-可以使用的功能。
        /// </summary>
        [DBColumnMapping("catsub_funcs")]
        public string Funcs { get; set; }

        /// <summary>
        /// 賣場毛利率限制百分比。
        /// </summary>
        [DBColumnMapping("catsub_gdlmtrate")]
        public decimal GdLmtRate { get; set; }

        /// <summary>
        /// 興奇採購人員全名。
        /// </summary>
        [DBColumnMapping("catsub_purhfullname")]
        public string PurhFullName { get; set; }

        /// <summary>
        /// 興奇採購主任全名。
        /// </summary>
        [DBColumnMapping("catsub_stafffullname")]
        public string StaffFullName { get; set; }

        /// <summary>
        /// 大PM全名。
        /// </summary>
        [DBColumnMapping("catsub_pmfullname")]
        public string PmFullName { get; set; }

        /// <summary>
        /// 業績歸屬(群)。
        /// </summary>
        [DBColumnMapping("catsub_blnggroup")]
        public string BlngGroup { get; set; }

        /// <summary>
        /// 業績歸屬team 。
        /// </summary>
        [DBColumnMapping("catsub_blngteam")]
        public int BlngTeam { get; set; }

        /// <summary>
        /// 業績歸屬線。
        /// </summary>
        [DBColumnMapping("catsub_blngline")]
        public int BlngLine { get; set; }

        /// <summary>
        /// 電子禮券折扣率。
        /// </summary>
        [DBColumnMapping("catsub_ecupnrate")]
        public decimal EcUpnRate { get; set; }

        /// <summary>
        /// 業績歸屬(群)ID。
        /// </summary>
        [DBColumnMapping("catsub_blnggrpid")]
        public byte BlngGrpId { get; set; }

        /// <summary>
        /// 子站類別(0: 一般子站, 1: 品牌子站)。
        /// </summary>
        [DBColumnMapping("catsub_type")]
        public byte Type { get; set; }

        /// <summary>
        /// 供應商提案毛利率。
        /// </summary>
        [DBColumnMapping("catsub_spsgstgrossmargin")]
        public decimal SpsGstGrossMargin { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public CatSubUsr User { get; set; }
    }
}
