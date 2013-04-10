using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategories response fomrat.
    /// </summary>
    [DataContract]
    public sealed class GetCategoriesResponse
    {
        /// <summary>
        /// 大類資訊
        /// </summary>
        [DataMember]
        public CategoryType[] CategoryTypes { get; set; }
    }
}