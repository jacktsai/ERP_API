using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategoryContacts response format.
    /// </summary>
    [DataContract]
    public class GetCategoryContactsResponse
    {
        /// <summary>
        /// The contacts.
        /// </summary>
        [DataMember]
        public CategoryContact[] CategoryContacts { get; set; }
    }
}