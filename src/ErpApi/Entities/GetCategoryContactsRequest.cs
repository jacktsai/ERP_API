using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategoryContacts request format.
    /// </summary>
    [DataContract]
    public class GetCategoryContactsRequest
    {
        /// <summary>
        /// 子站編號
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public int[] CategoryIds { get; set; }
    }
}