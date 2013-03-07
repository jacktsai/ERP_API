using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ErpApi.Entities
{
    [DataContract]
    public class GetUserProfileResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public int Degree { get; set; }

        [DataMember]
        public string Homepage { get; set; }

        [DataMember]
        public string ExtNumber { get; set; }

        [DataMember]
        public string BackyardID { get; set; }

        [DataMember]
        public string SubCatIds { get; set; }
    }
}