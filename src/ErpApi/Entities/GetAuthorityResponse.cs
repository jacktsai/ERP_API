using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    [DataContract]
    public class GetAuthorityResponse
    {
        [DataMember]
        public string BackyardId { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public bool CanAccess { get; set; }

        [DataMember]
        public bool CanSelect { get; set; }

        [DataMember]
        public bool CanInsert { get; set; }

        [DataMember]
        public bool CanUpdate { get; set; }

        [DataMember]
        public bool CanDelete { get; set; }

        [DataMember]
        public bool CanParticular { get; set; }
    }
}