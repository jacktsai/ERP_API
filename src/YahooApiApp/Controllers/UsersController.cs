using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Yahoo.Controllers
{
    public class UsersController : ApiController
    {
        public UsersController()
        {
        }

        [HttpGet]
        public string Test(string test)
        {
            return test;
        }

        [DataContract]
        public class GetProfileRequest
        {
            [DataMember(IsRequired = true), Required]
            public string BackyardId { get; }
        }

        public class GetProfileResponse
        {
            public string BackyardID;
            public string Name;
            public string FullName;
            public string Department;
            public int Degree;
            public string Homepage;
            public string ExtensionNumber;
            public string[] CatSubIds;
        }

        [HttpPost]
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            var profile = this.securityService.GetUser(request.BackyardId.Value);

            var response = new GetProfileResponse
            {
                PriuserID = profile.UserId,
                PriuserName = profile.Name,
                CatprivilegeCatsubids = "1,2,3,4",
                PriuserFullName = profile.FullName,
                PriuserDepartment = "研發",
                PriuserDegree = 1,
                PriuserHomepage = "http://",
                PriuserExtno = "124567",
                BackyardID = "jacktsai",
            };

            return response;
        }

        [DataContract]
        public class GetAuthorityRequest
        {
            [DataMember(IsRequired = true), Required]
            public string BackyardId { get; }

            [DataMember(IsRequired = true), Required]
            public string Url { get; }
        }

        public class GetAuthorityResponse
        {
            public string BackyardId;
            public string Url;
            public bool HasSelect;
            public bool HasInsert;
            public bool HasUpdate;
            public bool HasDelete;
            public bool HasParticular;
        }
    }
}
