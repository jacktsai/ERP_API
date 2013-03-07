using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetUserAuthority request format.
    /// </summary>
    [DataContract]
    public class GetUserAuthorityRequest
    {
        /// <summary>
        /// Gets or sets the backyard id.
        /// </summary>
        /// <value>
        /// The backyard id.
        /// </value>
        [DataMember(IsRequired = true), Required]
        public string BackyardId { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [DataMember(IsRequired = true), Required]
        public string Url { get; set; }
    }
}