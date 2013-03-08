using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetUserProfile request format.
    /// </summary>
    [DataContract]
    public class GetUserProfileRequest
    {
        /// <summary>
        /// Backyard ID。
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public string BackyardId { get; set; }
    }
}