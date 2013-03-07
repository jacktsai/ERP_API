using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetUserAuthority response format.
    /// </summary>
    [DataContract]
    public class GetUserAuthorityResponse
    {
        /// <summary>
        /// Gets or sets the backyard id.
        /// </summary>
        /// <value>
        /// The backyard id.
        /// </value>
        [DataMember]
        public string BackyardId { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// 是否可以連到 URL 的權限。
        /// </summary>
        [DataMember]
        public bool CanAccess { get; set; }

        /// <summary>
        /// 是否有 SELECT 權限。
        /// </summary>
        [DataMember]
        public bool CanSelect { get; set; }

        /// <summary>
        /// 是否有 INSERT 權限。
        /// </summary>
        [DataMember]
        public bool CanInsert { get; set; }

        /// <summary>
        /// 是否有 UPDATE 權限。
        /// </summary>
        [DataMember]
        public bool CanUpdate { get; set; }

        /// <summary>
        /// 是否有 DELETE 權限。
        /// </summary>
        [DataMember]
        public bool CanDelete { get; set; }

        /// <summary>
        /// 是否有特殊權限。
        /// </summary>
        [DataMember]
        public bool CanParticular { get; set; }
    }
}