﻿using System.ComponentModel.DataAnnotations;
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
        /// Gets or sets the backyard id.
        /// </summary>
        /// <value>
        /// The backyard id.
        /// </value>
        [DataMember(IsRequired = true), Required]
        public string BackyardId { get; set; }
    }
}