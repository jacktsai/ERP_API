using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategoryContacts response format.
    /// </summary>
    [DataContract]
    public class GetSubCategoryContactsResponse
    {
        /// <summary>
        /// The contacts.
        /// </summary>
        [DataMember]
        public SubCategoryContact[] Contacts { get; set; }
    }
}