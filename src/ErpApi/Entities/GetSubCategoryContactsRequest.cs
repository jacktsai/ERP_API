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
        /// 子站編號
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public int[] CatSubIds { get; set; }
    }
}