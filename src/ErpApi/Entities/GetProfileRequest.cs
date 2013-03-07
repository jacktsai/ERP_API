using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ErpApi.Entities
{
    [DataContract]
    public class GetProfileRequest
    {
        [DataMember(IsRequired = true), Required]
        public string BackyardId { get; set; }
    }
}