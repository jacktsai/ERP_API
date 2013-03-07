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
        /// 取得是否可以連到 URL 的權限。
        /// </summary>
        /// <value>
        /// 是否可以連到 URL 的權限。
        /// </value>
        [DataMember]
        public bool CanAccess { get; set; }

        /// <summary>
        /// 取得是否有細部權限-SELECT。
        /// </summary>
        /// <value>
        /// 是否有細部權限-SELECT。
        /// </value>
        [DataMember]
        public bool CanSelect { get; set; }

        /// <summary>
        /// 取得是否有細部權限-INSERT。
        /// </summary>
        /// <value>
        /// 是否有細部權限-INSERT。
        /// </value>
        [DataMember]
        public bool CanInsert { get; set; }

        /// <summary>
        /// 取得是否有細部權限-UPDATE。
        /// </summary>
        /// <value>
        /// 是否有細部權限-UPDATE。
        /// </value>
        [DataMember]
        public bool CanUpdate { get; set; }

        /// <summary>
        /// 取得是否有細部權限-DELETE。
        /// </summary>
        /// <value>
        /// 是否有細部權限-DELETE。
        /// </value>
        [DataMember]
        public bool CanDelete { get; set; }

        /// <summary>
        /// 取得是否有細部權限-PARTICULAR。
        /// </summary>
        /// <value>
        /// 是否有細部權限-PARTICULAR。
        /// </value>
        [DataMember]
        public bool CanParticular { get; set; }
    }
}