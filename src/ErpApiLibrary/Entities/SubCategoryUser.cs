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
    public class SubCategoryUser
    {
        /// <summary>
        /// catsub子項序號。
        /// </summary>
        [DBColumnMapping("catsubusr_id")]
        public Int32 catsubusr_id { get; set; }

        /// <summary>
        /// 對應子站序號。
        /// </summary>
        [DBColumnMapping("catsubusr_catsubid")]
        public Int32 catsubusr_catsubid { get; set; }

        /// <summary>
        /// 對應部門。
        /// </summary>
        [DBColumnMapping("catsubusr_dpt")]
        public string catsubusr_dpt { get; set; }

        /// <summary>
        /// 對應人名。
        /// </summary>
        [DBColumnMapping("catsubusr_usrname")]
        public string catsubusr_usrname { get; set; }

        /// <summary>
        /// catsubusr_usrfullname。
        /// </summary>
        [DBColumnMapping("catsubusr_usrfullname")]
        public string catsubusr_usrfullname { get; set; }

        /// <summary>
        /// catsubusr_extno。
        /// </summary>
        [DBColumnMapping("catsubusr_extno")]
        public string catsubusr_extno { get; set; }

        /// <summary>
        /// 建檔人。
        /// </summary>
        [DBColumnMapping("catsubusr_user")]
        public string catsubusr_user { get; set; }

        /// <summary>
        /// 實際建檔日期。
        /// </summary>
        [DBColumnMapping("catsubusr_sysdate")]
        public DateTime catsubusr_sysdate { get; set; }

        /// <summary>
        /// Updated。
        /// </summary>
        [DBColumnMapping("catsubusr_updated")]
        public Byte catsubusr_updated { get; set; }

        /// <summary>
        /// 最後修改日期。
        /// </summary>
        [DBColumnMapping("catsubusr_updateddate")]
        public DateTime catsubusr_updateddate { get; set; }

        /// <summary>
        /// 最後修改人。
        /// </summary>
        [DBColumnMapping("catsubusr_updateduser")]
        public string catsubusr_updateduser { get; set; }

        /// <summary>
        /// 對應企劃。
        /// </summary>
        [DBColumnMapping("catsubusr_pusrname")]
        public string catsubusr_pusrname { get; set; }

        /// <summary>
        /// 對應企劃全名。
        /// </summary>
        [DBColumnMapping("catsubusr_pusrfullname")]
        public string catsubusr_pusrfullname { get; set; }

        /// <summary>
        /// 對應企劃分機。
        /// </summary>
        [DBColumnMapping("catsubusr_pextno")]
        public string catsubusr_pextno { get; set; }
    }
}
