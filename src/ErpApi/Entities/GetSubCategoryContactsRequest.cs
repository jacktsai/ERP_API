using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategoryContacts request format.
    /// </summary>
    [DataContract]
    public class GetSubCategoryContactsRequest
    {
        /// <summary>
        /// Gets or sets the sub category ids.
        /// </summary>
        /// <value>
        /// The sub category ids.
        /// </value>
        [DataMember(IsRequired = true), Required]
        public int[] SubCategoryIds { get; set; }
    }
}