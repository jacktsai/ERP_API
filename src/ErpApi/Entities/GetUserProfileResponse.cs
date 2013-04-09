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
        /// 使用者序號。
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 帳號。
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 部門。
        /// </summary>
        [DataMember]
        public string Department { get; set; }

        /// <summary>
        /// 等級。
        /// </summary>
        [DataMember]
        public int Degree { get; set; }

        /// <summary>
        /// 首頁。
        /// </summary>
        [DataMember]
        public string Homepage { get; set; }

        /// <summary>
        /// 分機。
        /// </summary>
        [DataMember]
        public string ExtNumber { get; set; }

        /// <summary>
        /// Backyard ID。
        /// </summary>
        [DataMember]
        public string BackyardID { get; set; }

        /// <summary>
        /// 子站代碼。
        /// </summary>
        [DataMember]
        public int[] CatSubIds { get; set; }
    }
}