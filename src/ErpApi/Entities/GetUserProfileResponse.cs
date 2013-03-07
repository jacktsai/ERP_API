using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetUserProfile response format.
    /// </summary>
    [DataContract]
    public class GetUserProfileResponse
    {
        /// <summary>
        /// 取得 ID。
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 取得姓名。
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 取得中文姓名。
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 取得部門。
        /// </summary>
        [DataMember]
        public string Department { get; set; }

        /// <summary>
        /// 取得操作等級。
        /// </summary>
        [DataMember]
        public int Degree { get; set; }

        /// <summary>
        /// 取得首頁。
        /// </summary>
        [DataMember]
        public string Homepage { get; set; }

        /// <summary>
        /// 取得分機號碼。
        /// </summary>
        [DataMember]
        public string ExtNumber { get; set; }

        /// <summary>
        /// 取得 Backyard ID。
        /// </summary>
        [DataMember]
        public string BackyardID { get; set; }

        /// <summary>
        /// 子站代碼。
        /// </summary>
        [DataMember]
        public string SubCatIds { get; set; }
    }
}