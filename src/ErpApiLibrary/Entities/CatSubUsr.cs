using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Monday.DataAccess.Common;

namespace ErpApi.Entities
{
    /// <summary>
    /// mapping table name: catsubusr。
    /// </summary>
    public class CatSubUsr
    {
        /// <summary>
        /// catsub子項序號。
        /// </summary>
        [DBColumnMapping("catsubusr_id")]
        public int Id { get; set; }

        /// <summary>
        /// 對應子站序號。
        /// </summary>
        [DBColumnMapping("catsubusr_catsubid")]
        public int CatSubId { get; set; }

        /// <summary>
        /// 對應部門。
        /// </summary>
        [DBColumnMapping("catsubusr_dpt")]
        public string Dpt { get; set; }

        /// <summary>
        /// 對應人名。
        /// </summary>
        [DBColumnMapping("catsubusr_usrname")]
        public string UsrName { get; set; }

        /// <summary>
        /// catsubusr_usrfullname。
        /// </summary>
        [DBColumnMapping("catsubusr_usrfullname")]
        public string UsrFullName { get; set; }

        /// <summary>
        /// catsubusr_extno。
        /// </summary>
        [DBColumnMapping("catsubusr_extno")]
        public string ExtNo { get; set; }

        /// <summary>
        /// 建檔人。
        /// </summary>
        [DBColumnMapping("catsubusr_user")]
        public string User { get; set; }

        /// <summary>
        /// 實際建檔日期。
        /// </summary>
        [DBColumnMapping("catsubusr_sysdate")]
        public DateTime SysDate { get; set; }

        /// <summary>
        /// Updated。
        /// </summary>
        [DBColumnMapping("catsubusr_updated")]
        public byte Updated { get; set; }

        /// <summary>
        /// 最後修改日期。
        /// </summary>
        [DBColumnMapping("catsubusr_updateddate")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// 最後修改人。
        /// </summary>
        [DBColumnMapping("catsubusr_updateduser")]
        public string UpdatedUser { get; set; }

        /// <summary>
        /// 對應企劃。
        /// </summary>
        [DBColumnMapping("catsubusr_pusrname")]
        public string PusrName { get; set; }

        /// <summary>
        /// 對應企劃全名。
        /// </summary>
        [DBColumnMapping("catsubusr_pusrfullname")]
        public string PusrFullName { get; set; }

        /// <summary>
        /// 對應企劃分機。
        /// </summary>
        [DBColumnMapping("catsubusr_pextno")]
        public string PeExtNo { get; set; }
    }
}
