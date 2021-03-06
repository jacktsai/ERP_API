﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    /// <summary>
    /// GetSubCategories request format.
    /// </summary>
    [DataContract]
    public sealed class GetCategoriesRequest
    {
        /// <summary>
        /// 子站編號
        /// </summary>
        [DataMember(IsRequired = true), Required]
        public int[] CategoryIds { get; set; }
    }
}