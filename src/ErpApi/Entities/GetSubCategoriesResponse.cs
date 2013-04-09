using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategories response fomrat.
    /// </summary>
    [DataContract]
    public sealed class GetSubCategoriesResponse
    {
        /// <summary>
        /// 大類資訊
        /// </summary>
        [DataMember]
        public CatType[] CatTypes { get; set; }
    }
}